﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using AnsiConsole = Spectre.Console.AnsiConsole;



namespace TeamOv
{
    public static class AdminMenu
    {
        public static void ShowAdminScreen()
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
                Console.WriteLine("                         Welcome to VaennikATM");

                // Add header row 
                grid.AddRow(new Spectre.Console.Text[]{
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
                        
                        Console.ReadLine();
                        break;
                    case "c":
                        CreateCustomerScreen();
                        Console.ReadLine();
                        break;
                    case "d":
                        Console.WriteLine("Delete customer");
                        Console.ReadLine();
                        break;
                    case "l":
                        Console.WriteLine("You going to be logged out..");
                        Console.WriteLine("_");
                        Thread.Sleep(300);
                        Console.WriteLine("_");
                        Thread.Sleep(300);
                        Console.WriteLine("_");
                        Thread.Sleep(300);
                        Console.WriteLine("logged out complete");
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                }
            }
            Console.ReadKey();
        }

        public static void CreateCustomerScreen()
        {
            Console.Clear();
            Console.WriteLine("Input customer data");
            bool completed = false;
            do
            {
                Console.Write("Input username: ");
                var username = Console.ReadLine();
                if (User.UserExists(username))
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

                completed = UserService.AddUser(username, password, (bool)active); //Fix!!
                if (!completed)
                {
                    Console.WriteLine("Operation failed. No user added.");
                }
            } while (completed == false);
        }
    }
}
