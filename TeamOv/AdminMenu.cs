using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Text = Spectre.Console.Text;
using Color = Spectre.Console.Color;
using Serilog;
using System.Reflection.Metadata;

namespace TeamOv
{
  public static class AdminMenu
    {
        public static void ShowAdminScreen(string currentUser)
        {
            bool menu = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.DarkGray;
                Console.WriteLine($"Logged in as: {currentUser}\n{DateTime.Now}");
                Console.ResetColor();
                Console.WriteLine();
                var menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[lightgreen]*** Admin menu ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Print customers",
                        "Create customer",
                        "Delete customer",
                        "Back to login screen",
                        "Logout"
                        }));
                    switch (menuOptions)
                    {
                        case "Print customers":
                            PrintAllCustomers();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("|enter to get back to menu|");
                        Console.ResetColor();
                        Console.ReadLine();
                            break;
                        case "Create customer":
                            CreateCustomerScreen();
                            Console.ReadLine();
                            break;
                        case "Delete customer":
                            DeleteCustomer();
                            Console.ReadLine();
                            break;
                        case "Back to login screen":
                            Console.Clear();
                            Loginservice loginservice = new Loginservice();
                            loginservice.ValidateLogin();
                            Console.ReadLine();
                            break;
                        case "Logout":
                            Console.WriteLine("You going to be logged out..");
                            Console.WriteLine("_");
                            Thread.Sleep(200);
                            Console.WriteLine("_");
                            Thread.Sleep(200);
                            Console.WriteLine("_");
                            Thread.Sleep(200);
                            Console.WriteLine("logged out complete");
                            Environment.Exit(0);
                            break;
                        default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Do you want to go back? Yes/No");
                        var back = Console.ReadLine();
                        if (back.ToLower() == "no")
                        {
                            Environment.Exit(0);
                        }
                            continue;
                }
            } while (menu);  
        }
        public static bool AddUser(string username, string password, string customerName, bool active) //Add new customer to bank
        {
            bool add;
            if (UserExists(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                add = false;
                Log.Information("Duplicate username {username}. No user added.", username);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                add = true;
                User.customerList.Add(new Customer(username, password, customerName, (bool)active));
            }
            return add;
        }
        public static void CreateCustomerScreen() //Admin can create new customer
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Input customer data");
            Console.WriteLine(new string('-', 19));
            bool completed = false;
            do
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("Input username: ");
                var username = Console.ReadLine();
                Console.ResetColor();
                if (UserExists(username))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Duplicate username!");
                    Console.ResetColor();
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Input password: ");
                var password = Console.ReadLine();
                Console.Write("Enter firstname and lastname: ");

                var customerName = Console.ReadLine();
                bool? active;
                do
                {
                    Console.WriteLine("Active or Inactive?");
                    active = Console.ReadLine() switch
                    {
                        "Active" => true,
                        "active" => true,
                        "A" => true,
                        "a" => true,
                        "Inactive" => false,
                        "inactive" => false,
                        "I" => false,
                        "i" => false,
                        _ => null
                    };
                } while (active is null);
                completed = AddUser(username, password, customerName, (bool) active);
                if (!completed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Operation failed. No user added.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Customer {username} created");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("|enter to get back to menu|");
                }
            } while (completed == false);  
        }
        public static bool UserExists(string username)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            bool exists = Customer.customerList.Exists(user => user.UserName == username);
            Log.Debug(
               
                "User with username {username} {existing}",
                username,
                (exists ? "exists." : "does not exist.")
            );
            return exists;
        }
        public static void PrintAllCustomers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var customers in User.customerList)
            {
                Console.WriteLine(customers);
            }
            Console.WriteLine();
        }
        public static void DeleteCustomer() //Removes customer
        {
            if (User.customerList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No customer to delete!");
            }
            else
            {
                PrintAllCustomers();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter customer accountID to delete: ");
                var toDelete = int.Parse(Console.ReadLine());
                var ToDelete = User.customerList.Find(i => i.UserId == toDelete);
                Console.ForegroundColor = ConsoleColor.Green;
                User.customerList.Remove(ToDelete);
                Console.WriteLine($"Customer: {ToDelete} deleted.", ToDelete);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|enter to get back to menu|");
                Console.ResetColor();
            } 
        }
    }
}
