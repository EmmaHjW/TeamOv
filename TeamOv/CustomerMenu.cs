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
        public static void ShowCustomerScreen(string loggedInCustomer)
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

                Console.WriteLine("                            Welcome to OV.ATM");
                Console.WriteLine($"Logged in as: {loggedInCustomer} \n{DateTime.Now}");
                // Add header row 
                grid.AddRow(new Text[]{
                new Text("(A)ccount info", new Style(Color.Green, Color.Black)).RightAligned(),
                new Text("(O)pen account", new Style(Color.Green, Color.Black)).LeftAligned(),
                new Text("(D)eposit", new Style(Color.Green, Color.Black)).LeftAligned(),
                new Text("(W)ithdraw", new Style(Color.Green, Color.Black)).LeftAligned(),
                });

                // Add content row 
                grid.AddRow(new Text[]{
               
                new Text("(T)ransfer", new Style(Color.Green, Color.Black)).LeftAligned(),
                new Text("(C)hange currency account", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(H)istory transactions", new Style(Color.Green, Color.Black)).LeftAligned(),
                new Text("(L)ogout", new Style(Color.Green, Color.Black)).LeftAligned()
                });
                AnsiConsole.Write(grid);

                Currency currency = new Currency();
                Transfer transfer = new Transfer();
                BankAccount bankAccount = new BankAccount();
                string customerOptions = Console.ReadLine();
                switch (customerOptions.ToLower())
                {
                    case "a":
                        Console.WriteLine("Accounts");
                        PrintAccountInfo(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "o": //Create account
                        Console.WriteLine("Create account");
                        AddBankAccount(loggedInCustomer);
                        break;
                    case "d": //Deposit
                        Console.WriteLine("Make a deposit");
                        transfer.Deposit(loggedInCustomer);
                        break;
                    case "w": //Withdrawl
                        Console.WriteLine("Make a withdraw");
                        transfer.Withdraw(loggedInCustomer);

                        break;
                    case "t": //Transfer
                        transfer.TransferMenu(loggedInCustomer);
                        break;
                    case "c":        
                        Console.WriteLine("Change Currency");
                        //currency.CurrencyConverter(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "h":        
                        Console.WriteLine("Transaction history");
                        Transactionservice.PrintTransactionHistory();
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
        }
        public static void AddBankAccount(string loggedInCustomer)
        {
            Console.Write("Please enter a name to your new account: ");
            string name = Console.ReadLine();
            string accountNumber = BankAccount.GenerateBankAccountNumber();
            string owner = loggedInCustomer;

            BankAccount.bankAccounts.Add(new BankAccount(owner, accountNumber, name, 0, true, "SEK"));
            Console.WriteLine($"{name} account {accountNumber} created");
            Console.ReadLine();
        }
        public static void PrintAccountInfo(string loggedInCustomer) //Somthing wrong!Fix!
        {  
            if (BankAccount.bankAccounts.Count < 0)
            {
                Console.WriteLine("No accounts found, talk to a bank employee to open one.");
            }
            List<BankAccount>Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.Owner == loggedInCustomer); //WORKS YIIPPPEEE!!!

            foreach (var own in Owner)
            {
                Console.WriteLine(own);
            }
            Console.WriteLine();
        } 
    }
}
