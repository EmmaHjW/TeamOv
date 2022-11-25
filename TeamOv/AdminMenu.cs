﻿using System;
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
            while (true)
            {
                Console.Clear();
                var grid = new Grid();
                // Add columns 
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                Console.WriteLine("                         Welcome to OV.ATM");
                Console.WriteLine($"Logged in as: {currentUser}\n{DateTime.Now}");
                // Add header row 
                grid.AddRow(new Text[]{
                new Text(" ").LeftAligned(),
                new Text(" ").Centered(),
                new Text(" ").Centered(),
                new Text(" ").RightAligned(),
                new Text(" ").RightAligned()
                });
                // Add content row 
                grid.AddRow(new Text[]{
                new Text("(P)rint customers", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(C)reate customer", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(D)elete customer", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(L)ogout", new Style(Color.Green, Color.Black)).Centered(),
                });
                AnsiConsole.Write(grid);
                string customerOptions = Console.ReadLine();
                switch (customerOptions.ToLower())
                {
                    case "p":
                        PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "c":
                        CreateCustomerScreen();
                        Console.ReadLine();
                        break;
                    case "d":
                        Console.WriteLine("Delete customer");
                        DeleteCustomer();
                        Console.ReadLine();
                        break;
                    case "l":
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
                        continue;
                }
            }
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
