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
        //User currentUser;
        public Loginservice() //Constructor
        {
            
        }
        public static void InitiateUsers() //Adds users to userList at run
        {
            Admin.adminList.Add(new Admin("Admin", "password",/* 0,*/ true/*, true*/));
            User.userList.Add(new Customer("Customer", "password"/*, 1*/, true /*false*/));
            User.userList.Add(new Customer("Oskar", "1234",/* 2,*/ true/*, false*/));
            User.userList.Add(new Customer("Emma", "1234",/* 3,*/ true/*, false*/));
        }
        public void ValidateLogin() //Login with validation if user exists
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


                if (User.userList.Exists(User => User.UserName == name) || Admin.adminList.Exists(Admin => Admin.UserName == name))//Check if user in list
                {
                    
                }
                if (User.userList.Exists(User => User.Password == password) || Admin.adminList.Exists(Admin => Admin.Password == password)) //Chekck dfj
                {
                    Console.WriteLine("Logged in");
                    //LoggedIn();
                     LoggedInUser(name);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong password or username");
                    
                }

            } while (tries < 3);

            if (tries == 3)
            {
                Console.WriteLine("Too many attempts, try again in 5 minutes. ");
            }
        }
        public static void LoggedInUser(string name) //Check if user is admin or customer
        {
            if (name == "Admin") //fix this 
            {
                AdminMenu.ShowAdminScreen();
            }
            else
            {
                CustomerMenu.ShowCustomerScreen();
            }
        }
        //public void LoggedIn()
        //{
        //    if (currentUser.IsAdmin)
        //    {
        //        Menu.AdminMenu();
        //    }
        //    else
        //    {
        //        Menu.CustomerMenu();
        //    }
        //}
    }
        
}
