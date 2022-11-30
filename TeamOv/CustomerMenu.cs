﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Shapes;

namespace TeamOv
{
    public class CustomerMenu
    {
        public static void ShowCustomerScreen(string loggedInCustomer)
        {
            Transfer transfer = new Transfer();
            bool menu = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {loggedInCustomer}\n{DateTime.Now}");
                Console.WriteLine();
                var menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]*** Customer menu ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Account info",
                        "Open account",
                        "Deposit",
                        "Withdrawl",
                        "Transfer",
                        "Loan",
                        "Transaction history",
                        "Logout"
                        }));
                switch (menuOptions)
                {
                    case "Account info":
                        PrintAccountInfo(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Open account": //Create account
                        AddBankAccount(loggedInCustomer);
                        break;
                    case "Deposit": //Deposit
                        transfer.Deposit(loggedInCustomer);
                        break;
                    case "Withdrawl": //Withdrawl
                        transfer.Withdraw(loggedInCustomer);
                        break;
                    case "Transfer": //Transfer
                        transfer.TransferMenu(loggedInCustomer);
                        break;
                    case "Loan": //Loanservice
                        Loan loan = new Loan();
                        loan.LoanFromBank(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Transaction history": //Print transaction history
                        Transactionservice.PrintTransactionHistory();
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
                        continue;
                }
            } while (menu);
        }
        public static void ChosenSalaryAccount(string loggedInCustomer)
        {
            Console.Write("Please enter a name to your new account: ");
            var accountname = Console.ReadLine();
            string accountNumber = BankAccount.GenerateBankAccountNumber();
            string owner = loggedInCustomer;
            BankAccount.bankAccounts.Add(new BankAccount(accountNumber, accountname, owner, 0, "SEK",true));
            Console.WriteLine($"{accountname} account {accountNumber} created");

            Console.WriteLine("Do you want to make a first deposit? (Yes/No)");
            var firstDeposit = Console.ReadLine();
            if (firstDeposit.ToLower() == "y" || firstDeposit.ToLower() == "yes")
            {
                decimal amount;
                Console.Write("Enter amount: ");
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    string deposit = accountNumber;
                    var Deposit = BankAccount.bankAccounts.Find(a => a.AccountNumber == deposit);
                    Deposit.Balance += amount;
                    Console.WriteLine($"Successful deposit with {amount} {Deposit.Currency}.");
                    Console.ReadLine();
                    Transactionservice.transactionslist.Add($"{DateTime.Now} Depsoit: {amount} {Deposit.Currency} to account number: {Deposit.AccountNumber}");
                }
                else
                {
                    Console.WriteLine("It´s ok, you can come back another time.");
                }
            }
            else
            {
                Console.WriteLine("You can do it another time instead.");
            }
        }
        public static void AddBankAccount(string loggedInCustomer)
        {
            Console.WriteLine();
            SavingAccount savingAccount = new SavingAccount();
            bool menu = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {loggedInCustomer}\n{DateTime.Now}");
                Console.WriteLine();
                var menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]Which type of account do you want to open?[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Salary account",
                        "Saving account",
                        "Back to menu",
                        "Logout"
                        }));
                switch (menuOptions)
                {
                    case "Salary account":
                        ChosenSalaryAccount(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Saving account": //Create account
                        savingAccount.ChosenSavingAccount(loggedInCustomer);
                        break;
                    case "Back to menu": //Create account
                        ShowCustomerScreen(loggedInCustomer);
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
                        continue;
                }
            } while (menu);
        }
        public static void PrintAccountInfo(string loggedInCustomer) //Print account info loggInCustomer
        {
            if (BankAccount.bankAccounts.Count < 0)
            {
                Console.WriteLine("No accounts found, talk to a bank employee to open one.");
            }
            List<BankAccount>Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.Owner == loggedInCustomer); //WORKS YIIPPPEEE!!!
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('-', 101));
            foreach (var own in Owner)
            {
                Console.WriteLine(own);
            }
            Console.WriteLine(new string('-', 101));
            Console.ResetColor();
        }
    }
}
