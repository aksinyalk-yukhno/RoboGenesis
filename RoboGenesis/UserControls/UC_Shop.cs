using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OutlookDemo.BookHelper;
using static OutlookDemo.ProductHelper;

namespace OutlookDemo.UserControls
{
    public partial class UC_Shop : UserControl
    {
        public UC_Shop()
        {
            InitializeComponent();
            GenerateDynamicUserControl();
            totalPrice = 0m;
            
        }
      
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
 
        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            ProductHelper productHelper = new ProductHelper();
            List<ProductHelper.Product> products = productHelper.GetProducts();

            foreach (ProductHelper.Product product in products)
            {
                UC_Basket_Example productControl = new UC_Basket_Example();
                productControl.Title = product.Title;
                productControl.Description = product.Description;
                productControl.Price = product.Price;
                productControl.IconPath = product.IconPath;
                if (!string.IsNullOrEmpty(product.IconPath))
                {
                    productControl.Icon = Image.FromFile(product.IconPath);
                }
                productControl.IconBackground = System.Drawing.Color.FromArgb(224, 224, 224);

                flowLayoutPanel1.Controls.Add(productControl);
                productControl.Click += new EventHandler(this.UC_Basket_Example_Click);
            }
        }

     

        private List<UC_Basket_Example> FindMatchingProductElements(string searchText)
        {
            List<UC_Basket_Example> matchingElements = new List<UC_Basket_Example>();

            foreach (UC_Basket_Example control in flowLayoutPanel1.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

      

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search1;
                // Показать все элементы управления в flowLayoutPanel1
                foreach (UC_Basket_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = true;
                }
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search2;
                // Скрыть все элементы управления в flowLayoutPanel1
                foreach (UC_Basket_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = false;
                }

                // Найти и показать соответствующие элементы управления
                List<UC_Basket_Example> matchingElements = FindMatchingProductElements(guna2TextBox1.Text);
                foreach (UC_Basket_Example control in matchingElements)
                {
                    control.Visible = true;
                }
            }
        }

        private decimal totalPrice = 0;
       
        void UC_Basket_Example_Click(object sender, EventArgs e)
        {
            UC_Basket_Example clickedControl = (UC_Basket_Example)sender;

            UC_Basket_Details existingDetails = flowLayoutPanel2.Controls.OfType<UC_Basket_Details>()
                                                               .FirstOrDefault(d => d.Title == clickedControl.Title);

            if (existingDetails != null)
            {
                if (existingDetails.Amount < 10)
                {
                    existingDetails.Amount++;
                    existingDetails.TotalPrice += decimal.Parse(clickedControl.Price.ToString());
                    totalPrice += decimal.Parse(clickedControl.Price.ToString());
                    
                }
                
            }
            else
            {
                // Если такого UC_Basket_Details еще нет, создаем новый
                UC_Basket_Details details = new UC_Basket_Details();
                details.Title = clickedControl.Title;
                details.Price = clickedControl.Price;
                details.Icon = clickedControl.Icon;
                details.TotalPrice = decimal.Parse(clickedControl.Price.ToString());
                // Добавляем новый UC_Basket_Details во flowLayoutPanel2
                flowLayoutPanel2.Controls.Add(details);
                totalPrice += decimal.Parse(clickedControl.Price.ToString());
            }
            

            lblPriceBasket.Text = totalPrice.ToString("");
        }

        private void FlowLayoutPanel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is UC_Basket_Details removedDetails)
            {
                totalPrice -= removedDetails.TotalPrice;
                lblPriceBasket.Text = totalPrice.ToString();
            }
        }


        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void uС_User_Panel1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int userId = Globals.GlobalUserId; // Получаем идентификатор текущего пользователя
            decimal totalAmount = decimal.Parse(lblPriceBasket.Text); // Получаем общую сумму заказа

            ProductHelper productHelper = new ProductHelper();
            bool orderSaved = productHelper.SaveOrder(userId, totalAmount);

            if (orderSaved)
            {
                // Заказ успешно сохранен, очистить корзину
                flowLayoutPanel2.Controls.Clear();
                uC_NoAuth_Form1.Visible = true;
            }
            else
            {
                // Ошибка при сохранении заказа
                MessageBox.Show("Произошла ошибка при оформлении заказа. Пожалуйста, попробуйте еще раз.");
            }
        }
    }
}
