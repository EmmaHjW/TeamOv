using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class LogIn
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        public LogIn()
        {
            Users.Add("Admin", "PassWord");
            Users.Add("Customer", "password");
            Users.Add("Customer", "password");
            Users.Add("Customer", "password");
        }
        public bool ValidateLogin(string name, string password)
        {
            return Users.Any(i => i.Key == name && i.Value == password);
            if (Users.ContainsKey(name, password,  ))
            {

            }
        }
    }
        
}
