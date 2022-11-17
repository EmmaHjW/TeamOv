using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class LogIn
    {
        public LogIn() //Constructor
        {
            
        }
        public static void InitiateUsers() //Adds users to Dict at run
        {
            User.Users.Add("Admin", "PassWord");
            User.Users.Add("Customer", "password");
            User.Users.Add("Oskar", "1234");
            User.Users.Add("Emma", "1234");
        }
        public static void ValidateLogin() //Login with validation if user exists
        {
            var tries = 0;
            Console.WriteLine("Welcome to TeamOv-Bank");
            Console.WriteLine();
            do
            {
                Console.Write("Enter username: ");
                string name = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                tries++;

                if (User.Users.ContainsKey(name) && User.Users.ContainsValue(password)) //Check if user in list
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
        public static void LoggedInUser(string name) //Check if user is admin or customer
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
