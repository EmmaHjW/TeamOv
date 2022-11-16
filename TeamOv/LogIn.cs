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
        public static void ValidateLogin()
        {
            var tries = 0;
            Console.WriteLine("Welcome to TeamOv-Bank");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter username: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                tries++;

            if (Users.ContainsKey(name) && Users.ContainsValue(password))
            {
                Console.WriteLine("Logged in");
                    LoggedInUser(name);
                    break;
            }
            else
            {
                Console.WriteLine("Wrong username or password");
                
            }
            } while (tries < 3);

            if (tries == 3)
            {
                Console.WriteLine("Too many attempts, try again in 5 minutes. ");
            }
        }
        public static void LoggedInUser(string name)
        {
            if (name == "Admin")
            {
                Menu.AdminMenu();
            }
            else
            {
                Menu.CustomerMenu();
            }
        }
    }
        
}
