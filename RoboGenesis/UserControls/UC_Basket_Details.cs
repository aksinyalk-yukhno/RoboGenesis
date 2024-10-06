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

namespace OutlookDemo.UserControls
{
    public partial class UC_Basket_Details : UserControl
    {
        public UC_Basket_Details()
        {
            InitializeComponent();
        }

        private string _title;
        private int _amount = 1;
        private string _price;
        private Image _icon;
        private Color _iconBack;
        public event EventHandler PriceChanged;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }
        
        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        
        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        [Category("Custom Props")]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; lblAmount.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pbIcon.Image = value; }
        }

        [Category("Custom Props")]
        public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel1.FillColor = value; }
        }

        private void UC_Basket_Details_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            // Ищем flowLayoutPanel2 на родительской форме
            FlowLayoutPanel flowLayoutPanel2 = parentForm.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(p => p.Name == "flowLayoutPanel2");

            // Если flowLayoutPanel2 найден, удаляем текущую форму из него
            if (flowLayoutPanel2 != null)
            {
                flowLayoutPanel2.Controls.Remove(this);
            }

            // Вызываем метод Dispose() для освобождения ресурсов
            this.Dispose();
        }

        private void lblAmount_ValueChanged(object sender, EventArgs e)
        {
            Amount = (int)lblAmount.Value;
        }
    }
}
