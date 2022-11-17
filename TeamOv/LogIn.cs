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
        public static void InitiateUsers() //Adds users to userList at run
        {
            User.userList.Add(new User("Admin", "password",/* 0,*/ true/*, true*/));
            User.userList.Add(new User("Customer", "password"/*, 1*/, true /*false*/));
            User.userList.Add(new User("Oskar", "1234",/* 2,*/ true/*, false*/));
            User.userList.Add(new User("Emma", "1234",/* 3,*/ true/*, false*/));
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

                if (User.userList.Exists(User => User.UserName == name)) //Check if user in list
                {
                    //    Console.WriteLine("Logged in");
                    //    LoggedInUser(name);
                }
                if (User.userList.Exists(User => User.Password == password)) //Chekck dfj
                {
                    //Do nothing
                    Console.WriteLine("Logged in");
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
                Menu.AdminMenu();
            }
            else
            {
                Menu.CustomerMenu();
            }
        }
    }
        
}
