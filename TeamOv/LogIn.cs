using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class LogIn
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        public LogIn() //Constructor
        {
            
        }
        public static void InitiateUsers()
        {
            Users.Add("Admin", "PassWord");
            Users.Add("Customer", "password");
            Users.Add("Oskar", "1234");
            Users.Add("Emma", "1234");
        }
        public static bool ValidateLogin(string name, string password)
        {
            
            if (Users.ContainsKey(name) && Users.ContainsValue(password))
            {
                Console.WriteLine("Logged in");
                Menu(name);
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong username or password");
                return false;
            }
        }
        public static void Menu(string name)
        {
            if (name == "Admin")
            {
                AdminMenu();
            }
            else
            {
                CustomerMenu();
            }
        }
        public static void AdminMenu()
        {
            Console.WriteLine("AdminMenu");
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("CustomerMenu");
        }
    }
        
}
