using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RoboGenesis.TestHelper;

namespace RoboGenesis.UserControls
{
    public partial class UC_Test_Question_Example : UserControl
    {
        public UC_Test_Question_Example()
        {
            InitializeComponent();
        }
        public event EventHandler Option1Clicked;
        public event EventHandler Option2Clicked;
        public event EventHandler Option3Clicked;
        public event EventHandler Option4Clicked;
        public event EventHandler<AnswerEventArgs> AnswerSelected;

        public class AnswerEventArgs : EventArgs
        {
            public int SelectedAnswer { get; set; }
        }

        private string _description;
        private string _iconPath;
        private int _testId;
        private string _option1;
        private string _option2;
        private string _option3;
        private string _option4;
        private int _correctAnswer;

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        [Category("Custom Props")]
        public int TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }

        [Category("Custom Props")]
        public string Option1
        {
            get { return _option1; }
            set { _option1 = value; bnOption1.Text = value; }
        }

        [Category("Custom Props")]
        public string Option2
        {
            get { return _option2; }
            set { _option2 = value; bnOption2.Text = value; }
        }

        [Category("Custom Props")]
        public string Option3
        {
            get { return _option3; }
            set { _option3 = value; bnOption3.Text = value; }
        }

        [Category("Custom Props")]
        public string Option4
        {
            get { return _option4; }
            set { _option4 = value; bnOption4.Text = value; }
        }

        [Category("Custom Props")]
        public int CorrectAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; }
        }

        [Category("Custom Props")]
        public string IconPath
        {
            get { return _iconPath; }
            set
            {
                _iconPath = value;
                if (!string.IsNullOrEmpty(_iconPath))
                {
                    pbIcon.Image = Image.FromFile(_iconPath);
                }
                else
                {
                    pbIcon.Image = Properties.Resources.basket_no_img; // Ваше изображение по умолчанию
                }
            }
        }

        private void bnOption1_Click(object sender, EventArgs e)
        {
            Option1Clicked?.Invoke(this, EventArgs.Empty);
            AnswerSelected?.Invoke(this, new AnswerEventArgs { SelectedAnswer = 1 });
            bnOption1.Checked = true;

            bnOption2.Checked = false;
            bnOption3.Checked = false;
            bnOption4.Checked = false;
        }

        private void bnOption2_Click(object sender, EventArgs e)
        {
            Option2Clicked?.Invoke(this, EventArgs.Empty);
            AnswerSelected?.Invoke(this, new AnswerEventArgs { SelectedAnswer = 2 });
            bnOption2.Checked = true;

            bnOption1.Checked = false;
            bnOption3.Checked = false;
            bnOption4.Checked = false;
        }

        private void bnOption3_Click(object sender, EventArgs e)
        {
            Option3Clicked?.Invoke(this, EventArgs.Empty);
            AnswerSelected?.Invoke(this, new AnswerEventArgs { SelectedAnswer = 3 });
            bnOption3.Checked = true;

            bnOption1.Checked = false;
            bnOption2.Checked = false;
            bnOption4.Checked = false;
        }

        private void bnOption4_Click(object sender, EventArgs e)
        {
            Option4Clicked?.Invoke(this, EventArgs.Empty);
            AnswerSelected?.Invoke(this, new AnswerEventArgs { SelectedAnswer = 4 });
            bnOption4.Checked = true;

            bnOption1.Checked = false;
            bnOption2.Checked = false;
            bnOption3.Checked = false;
        }

        private void bnOption1_DoubleClick(object sender, EventArgs e)
        {
            bnOption1.Checked = false;
        }

        private void bnOption2_DoubleClick(object sender, EventArgs e)
        {
            bnOption2.Checked = false;
        }

        private void bnOption3_DoubleClick(object sender, EventArgs e)
        {
            bnOption3.Checked = false;
        }
        private void bnOption4_DoubleClick(object sender, EventArgs e)
        {
            bnOption4.Checked = false;
        }
    }
}

