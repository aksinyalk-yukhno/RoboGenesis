using RoboGenesis.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboGenesis
{
    internal class UserPanelUpdater
    {
        public static void UpdateUserPanel(object container)
        {
            if (container is Control control)
            {
                foreach (Control childControl in control.Controls)
                {
                    if (childControl is UС_User_Panel userPanel)
                    {
                        userPanel.getImageAndUsername();
                    }
                    else if (childControl.Controls.Count > 0)
                    {
                        UpdateUserPanel(childControl);
                    }
                }
            }
        }
    }
}
