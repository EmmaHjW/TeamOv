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
                grid.AddColumn();
                grid.AddColumn();

                Console.WriteLine("                            Welcome to OV.ATM");
                Console.WriteLine($"Logged in as: {loggedInCustomer}");
                // Add header row 
                grid.AddRow(new Text[]{
                new Text(" ").LeftAligned(),
                new Text(" ").Centered(),
                new Text(" ").Centered(),
                new Text(" ").Centered(),
                new Text(" ").RightAligned(),
                new Text(" ").RightAligned()
                });

                // Add content row 
                grid.AddRow(new Text[]{
                new Text("(A)ccount info", new Style(Color.Green, Color.Black)).RightAligned(),
                new Text("(O)pen account", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(D)eposit", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(W)ithdrawl", new Style(Color.Green, Color.Black)).Centered(),
                new Text("(C)hange currency account", new Style(Color.Green, Color.Black)).LeftAligned(),
                new Text("(L)ogout", new Style(Color.Green, Color.Black)).LeftAligned()
                });

                AnsiConsole.Write(grid);

                string customerOptions = Console.ReadLine();
                BankAccount bankAccount = new BankAccount();
                switch (customerOptions.ToLower())
                {
                    case "a":
                        Console.WriteLine("Accounts");
                        PrintAccountInfo();
                        break;
                    case "o": //Create account
                        Console.WriteLine("Create account");
                        AddBankAccount();
                        break;
                    case "d": //Deposit
                        Console.WriteLine("Deposit coming");
                        break;
                    case "w": //Withdrawl
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
        }
        public static void AddBankAccount()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    bankAccounts.Add(new Bank());

            //}
            Console.Write("Please enter a name to your new account: ");
            string name = Console.ReadLine(); 
            string accountNumber = GenerateBankAccountNumber();
            BankAccount.bankAccounts.Add(new BankAccount(accountNumber, name, 0, Currency.SEK));
            Console.WriteLine($"{name} account {accountNumber} created");
            Console.ReadLine();

        }
        public static void PrintAccountInfo() //Somthing wrong!Fix!
        {  
            if (BankAccount.bankAccounts.Count <1)
            {
                Console.WriteLine("No accounts found, talk to a bank employee to open one.");
            }
            foreach (var accounts in BankAccount.bankAccounts)
            {
                Console.WriteLine(accounts);
            }
            Console.ReadLine();
            //BankAccount.bankAccounts.FindAll(account => account.AccountId == "O");
            //foreach (var account in BankAccount.bankAccounts)
            //{
            //    Console.WriteLine(account);
            //}

            //foreach (var account in BankAccount.bankAccounts)
            //{
            //    Console.WriteLine(account.AccountId == "O");
            //}
       }
        public static void DeleteAccount()
        {
            Console.WriteLine("");
            
        }
        public static string GenerateBankAccountNumber()
        {
            Random random = new Random();
            string bankaccount = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bankaccount = bankaccount + random.Next(0, 10).ToString();
                }
                bankaccount = bankaccount + "-";
            }
            return bankaccount.Trim('-');
        }
    }
}
