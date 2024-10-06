using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboGenesis.UserControls
{
    public partial class UC_Test_Result : UserControl
    {
        public UC_Test_Result()
        {
            InitializeComponent();
            panel1.HorizontalScroll.Visible = false;

        }

        private int _testId;
        private int _perNumber;
        private int _correctNumber;
        private int _wrongNumber;
        private string _description;
        


        [Category("Custom Props")]
        public int TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }

        [Category("Custom Props")]
        public int PerNumber
        {
            get { return _perNumber; }
            set { _perNumber = value; lblPerNumber.Text = value.ToString() + "%"; }
        }

        [Category("Custom Props")]
        public int CorrectNumber
        {
            get { return _correctNumber; }
            set { _correctNumber = value; lblCorrectNumber.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int WrongNumber
        {
            get { return _wrongNumber; }
            set { _wrongNumber = value; lblWrongNumber.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        private void bnCloseResult_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            while (parent != null && !(parent is UC_Activity_Test_Details))
            {
                parent = parent.Parent;
            }

            if (parent != null && parent is UC_Activity_Test_Details)
            {
                (parent as UC_Activity_Test_Details).Visible = false;
            }
        }
    }
}
