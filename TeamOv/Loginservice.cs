using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamOv
{
    public class Loginservice
    {
        public string CurrentUser;
        protected static int tries = 0;
        public Loginservice() //Constructor
        {
            
        }
        public static void InitiateUsers() //Adds users to userList at run
        {
            Admin.adminList.Add(new Admin("Admin", "password",/* 0,*/ true, true));
            User.CustomerList.Add(new Customer("Customer", "password"/*, 1*/, true, false));
            User.CustomerList.Add(new Customer("Oskar", "1234",/* 2,*/ true, false));
            User.CustomerList.Add(new Customer("Emma", "1234",/* 3,*/ true, false));
        }
        public void ValidateLogin() //Login with validation if user exists
        {
            Loginservice loginservice= new Loginservice();
            Console.WriteLine("Welcome to TeamOv-Bank");
            Console.WriteLine();
            do
            {
                Console.Write("Enter username: ");
                string name = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                
                if (User.CustomerList.Exists(User => User.UserName == name && User.Password == password)
                    || Admin.adminList.Exists(Admin => Admin.UserName == name && Admin.Password == password))   //Check if username exisist in list
                {
                    Console.WriteLine("Logged in");
                    LoggedInUser(name);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong password or username");
                    tries++;
                }
            } while (tries < 3);

            if (tries == 3)
            {
                Console.WriteLine("Too many attempts, try again in 5 minutes. ");
            }
        }
        public void LoggedInUser(string name) //Check if user is admin or customer
        {
            if (name == "Admin") //fix this 
            {
                AdminMenu.ShowAdminScreen(name);
            }
            else
            {
                CustomerMenu.ShowCustomerScreen(name);
            }
        }
    }
        
}
