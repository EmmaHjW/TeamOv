using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Spectre.Console;
using PanoramicData.ConsoleExtensions;

namespace TeamOv
{
    public class Loginservice
    {
        protected static int tries = 0;
        public Loginservice() //Constructor
        {      
        }
        public void ValidateLogin() //Login with validation if user exists
        {
            Loginservice loginservice= new Loginservice();
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
                var name = Console.ReadLine();
                Console.Write("{0," + Console.WindowWidth / 2 + "}", "Enter password: ");
                var password = ConsolePlus.ReadPassword();
                
                if (User.customerList.Exists(User => User.UserName == name && User.Password == password))   //Check if username exisist in list
                {
                    var currentUser = User.customerList.Find(c => c.UserName == name); //Find customerName for loggedInUser.
                    Console.WriteLine("Logged in");
                    LoggedInUser(currentUser.CustomerName, name);
                    break;
                }
                if (Admin.adminList.Exists(Admin => Admin.UserName == name && Admin.Password == password))
                {
                    var currentUser = Admin.adminList.Find(c => c.UserName == name); //Find AdminName for loggedInUser
                    LoggedInUser(currentUser.AdminName, name);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string msg = "Invalid username or password!";
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
        public void LoggedInUser(string currentUser, string name) //Check if user is admin or customer
        {
            if (name == "Admin")
            {
                AdminMenu.ShowAdminScreen(currentUser);
            }
            else
            {
                CustomerMenu.ShowCustomerScreen(currentUser);
            }
        }
        public SecureString GetPassword() //Hides password
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }  
}
