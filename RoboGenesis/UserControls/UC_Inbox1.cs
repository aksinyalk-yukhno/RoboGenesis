using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using OutlookDemo.Properties;
using Guna.UI2.HtmlRenderer.Adapters;

namespace OutlookDemo.UserControls
{
    public partial class UC_Inbox1 : UserControl
    {
        public UC_Inbox1()
        {
            InitializeComponent();

            uC_InboxAuthorization1.AuthenticationSuccessful += UС_InboxAuthorization_AuthenticationSuccessful;
        }
        private void UС_InboxAuthorization_AuthenticationSuccessful(object sender, EventArgs e)
        {
            uC_Inbox21.Visible = true;
            uC_Inbox21.BringToFront();
        }

    }
}
