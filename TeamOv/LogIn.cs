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
        public static bool ValidateLogin(string name, string password)
        {
           //Users temp = Users.Any(i => i.Key == name && i.Value == password);
            
            if (Users.ContainsKey(name))
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Wrong username");
                return false;
            }
            
            if (Users.ContainsValue(password))
            {
                Console.WriteLine("Du är inloggad");
                return true;
            }
            else
            {
                Console.WriteLine("Wrong password");
                return false;
            }

        }
    }
        
}
