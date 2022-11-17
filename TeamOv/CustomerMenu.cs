﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class CustomerMenu
    {
        public static void ShowCustomerScreen()
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

                Console.WriteLine("                            Welcome to VaennikATM");
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
            new Text("(A)ccount info", new Style(Color.Green, Color.Black)).RightAligned(),
            new Text("(D)eposit", new Style(Color.Green, Color.Black)).Centered(),
            new Text("(W)ithdrawl", new Style(Color.Green, Color.Black)).Centered(),
            new Text("(C)hange currency account", new Style(Color.Green, Color.Black)).LeftAligned(),
            new Text("(L)ogout", new Style(Color.Green, Color.Black)).LeftAligned()
            });

                AnsiConsole.Write(grid);

                string customerOptions = Console.ReadLine();

                switch (customerOptions.ToLower())
                {
                    case "a":
                        Console.WriteLine("Print account info here");
                        Console.ReadLine();
                        break;
                    case "d":
                        Console.WriteLine("Deposit on its way");
                        Console.ReadLine();
                        break;
                    case "w":
                        Console.WriteLine("Withdrawl all money");
                        Console.ReadLine();
                        break;
                    case "c":
                        Console.WriteLine("Currency changed from SEK to USD");
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
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
