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
        public string AdminName { get; set; }
        public Admin()
        {
        }

        public Admin(string userName, string password, string adminName, bool active): base (userName,password,adminName,active)
        {
            AdminName= adminName;
        }
        public override string ToString()
        {
            return $"userid: {UserId}, username: {UserName}, password: {Password}, Name: {AdminName} active: {Active}, isAdmin: {IsAdmin}";
        }
    }
}
