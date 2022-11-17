using Spectre.Console;
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
                var grid = new Spectre.Console.Grid();

                // Add columns 
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                grid.AddColumn();
                Console.WriteLine("                         Welcome to OV.ATM");

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
                        PrintAllCustomers();
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
}
