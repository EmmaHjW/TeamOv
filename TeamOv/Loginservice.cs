﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace TeamOv
{
    public class Loginservice
    {
        protected static int tries = 0;
        public Loginservice() //Constructor
        {      
        }
        public static void InitiateUsers() //Adds users to userList at run
        {
            Admin.adminList.Add(new Admin("Admin", "password", true));
            User customer1 = new User() { UserName = "Oskar", Password = "1234", Active = true, UserId = 0};
            User customer2 = new User() { UserName = "Emma", Password = "1234", Active = true, UserId = 1 };
            User.customerList.Add(customer1);
            User.customerList.Add(customer2);
        }
        public void ValidateLogin() //Login with validation if user exists
        {
            Loginservice loginservice= new Loginservice();
            //Console.WriteLine("Welcome to TeamOv-Bank");
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine(DateTime.Now);
            Console.ResetColor();

            AnsiConsole.Write(
                new FigletText("Welcome to Team EmOs Bank 2.0")
                    .Centered()
                    .Color(Color.SandyBrown));
            var rule = new Rule();
            AnsiConsole.Write(rule);
            Console.WriteLine();
            do
            {
                Console.Write("{0," + Console.WindowWidth / 2 + "}", "Enter username: ");
                string name = Console.ReadLine();
                Console.Write("{0," + Console.WindowWidth / 2 + "}", "Enter password: ");
                string password = Console.ReadLine();

                string currentUser = name;
                if (User.customerList.Exists(User => User.UserName == name && User.Password == password)
                    || Admin.adminList.Exists(Admin => Admin.UserName == name && Admin.Password == password))   //Check if username exisist in list
                {
                    Console.WriteLine("Logged in");
                    LoggedInUser(currentUser);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string msg = "Wrong username or password";
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 3) + "}", msg);
                    Console.ResetColor();
                    tries++;
                }
            } while (tries < 3);

            if (tries == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string msg = "Too many attempts, try again in 5 minutes.";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 3) + "}", msg);
                Console.ResetColor();
            }
        }
        public void LoggedInUser(string currentUser) //Check if user is admin or customer
        {
            if (currentUser == "Admin")
            {
                AdminMenu.ShowAdminScreen(currentUser);
            }
            else
            {
                CustomerMenu.ShowCustomerScreen(currentUser);
            }
        }
    }  
}
