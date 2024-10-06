using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo
{
    internal class Globals
    {
       // this class will make the logged in user id global everywhere in the application

        public static int GlobalUserId { get; private set; }

        public static void SetGlobalUserId(int userId)
        {
            GlobalUserId = userId;
        }
    }
}
