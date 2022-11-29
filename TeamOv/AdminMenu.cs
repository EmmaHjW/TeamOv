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
                Console.WriteLine($"Logged in as: {currentUser}\n{DateTime.Now}");
                var menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]*** Customer menu ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Print customers",
                        "Create customer",
                        "Delete customer",
                        "Logout"
                        }));
                    switch (menuOptions)
                    {
                        case "Print customers":
                            Console.WriteLine("Print Print");
                            PrintAllCustomers();
                            Console.ReadLine();
                            break;
                        case "Create customer":
                            CreateCustomerScreen();
                            Console.ReadLine();
                            break;
                        case "Delete customer":
                            Console.WriteLine("Delete customer");
                            DeleteCustomer();
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
        public static bool AddUser(string username, string password, bool active) //Add new customer to bank
        {
            bool add;
            if (UserExists(username))
            {
                add = false;
                Log.Information("Duplicate username {username}. No user added.", username);
            }
            else
            {
                add = true;
                User.customerList.Add(new Customer(username, password, (bool) active));
            }
            return add;
        }
        public static void CreateCustomerScreen() //Admin can create new customer
        {
            Console.WriteLine("Input customer data");
            bool completed = false;
            do
            {
                Console.Write("Input username: ");
                var username = Console.ReadLine();
                if (UserExists(username))
                {
                    Console.WriteLine("Duplicate username!");
                    continue;
                }
                Console.Write("Input password: ");
                var password = Console.ReadLine();
                bool? active;
                do
                {
                    Console.WriteLine("active or inactive");
                    active = Console.ReadLine() switch
                    {
                        "active" => true,
                        "inactive" => false,
                        _ => null
                    };
                } while (active is null);
                completed = AddUser(username, password, (bool) active);
                if (!completed)
                {
                    Console.WriteLine("Operation failed. No user added.");
                }
                else
                {
                    Console.WriteLine($"Customer {username} created");
                }
            } while (completed == false);  
        }
        public static bool UserExists(string username)
        {
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
            foreach (var customers in User.customerList)
            {
                Console.WriteLine(customers);
            }
        }
        public static void DeleteCustomer() //Removes customer
        {
            if (User.customerList.Count == 0)
            {
                Console.WriteLine("No customer to delete!");
            }
            else
            {
                PrintAllCustomers();
                Console.WriteLine("Enter customer accountID to delete: ");
                var toDelete = int.Parse(Console.ReadLine());
                var ToDelete = User.customerList.Find(i => i.UserId == toDelete);

                User.customerList.Remove(ToDelete);
                Console.WriteLine($"Customer: {ToDelete} deleted.", ToDelete);
            } 
        }
    }
}
