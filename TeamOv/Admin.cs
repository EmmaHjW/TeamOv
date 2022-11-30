using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Spectre.Console;


namespace TeamOv
{
    public class Admin : User
    {
        public static List<Admin> adminList = new();
        public Admin(string userName, string password, string customerName, bool active): base (userName,password,customerName,active)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
