﻿using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Transfer
    {
        private double amountD;
        private readonly int fromAccount;
        private readonly int toAccount;

        public void Deposit(string loggedInCustomer)
        {
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                CustomerMenu.PrintAccountInfo(loggedInCustomer);
                if (BankAccount.bankAccounts.Count < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No accounts found to deposit money into");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter account to deposit to");
                int toAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount to deposit: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Withdraw amount must be positive");
                    Console.ResetColor();
                }
                else
                {
                    var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);
                    ToAccount.Balance += amount;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Balance after deposit: {ToAccount.Balance}");
                    Console.ResetColor();
                    string accountOwner = loggedInCustomer;
                    Transactionservice.transactionslist.Add($"Amount: {amount}{0:C} deposit succesfull to AccountId: {ToAccount.AccountId} Account owner: {accountOwner}");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to try again? Y/N?");
                Console.ResetColor();
                input = Console.ReadLine();
            }
        }
        public void Withdraw(string loggedInCustomer)
        {
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                CustomerMenu.PrintAccountInfo(loggedInCustomer);
                Console.WriteLine();
                if (BankAccount.bankAccounts.Count < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No accounts found to withdraw money from");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter account to withdraw from");
                int fromAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter amount to withdraw: ");
                var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);

                decimal amount = decimal.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Withdraw amount must be positive");
                    Console.ResetColor();
                }
                else if (amount > FromAccount.Balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid transfer amount");
                    Console.ResetColor();
                }
                else
                {
                    FromAccount.Balance -= amount;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Balance after withdraw: {FromAccount.Balance}");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to try again? Y/N?");
                Console.ResetColor();
                input = Console.ReadLine();
            }
        }
        public void TransferAmount(string loggedInCustomer)
        {
            
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                CustomerMenu.PrintAccountInfo(loggedInCustomer);

                var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
                var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);

                decimal amount = (decimal)amountD;





                CurrencyService currencyService = new CurrencyService();
                currencyService.CurrencyConverter(amountD, fromAccount, toAccount);
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine("Enter accountID to transfer from: ");
                //int fromAccount = int.Parse(Console.ReadLine());
                //Console.WriteLine("Transfer to: ");
                //int toAccount = int.Parse(Console.ReadLine());
                //Console.WriteLine("Please enter amount: ");

               
               

                while (decimal.TryParse(Console.ReadLine(), out amount)) //Check that amount is valid to transfer
                {
                    if (amount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Transfer amount must be positive");
                        Console.ResetColor();
                    }
                    else if (amount == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid transfer amount");
                        Console.ResetColor();
                    }
                    else if (amount > FromAccount.Balance)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not enought money on account");
                        Console.ResetColor();
                    }
                    else
                    {
                        FromAccount.Balance -= amount;
                        ToAccount.Balance += amount;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Amount transferred: {amount} You have: {FromAccount.Balance}{FromAccount.Currency} left on your {FromAccount.AccountName}");
                        Console.WriteLine($"You have: {ToAccount.Balance}{ToAccount.Currency} left on your {ToAccount.AccountName}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to try again? Y/N?");
                Console.ResetColor();
                input = Console.ReadLine();
            }
        }
        public void ThirdPartTransfer(string loggedInCustomer)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Accounts available for third party transfer.");
            Console.WriteLine(new string('_', 92));
            Console.ResetColor();
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                List<BankAccount> Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.AccountName == "Salary account");
                foreach (var owner in Owner)
                {
                    Console.WriteLine($"Owner: {owner.Owner} Account ID: {owner.AccountId} Account number: {owner.AccountNumber} Account name: {owner.AccountName}");
                }
                Console.WriteLine(new string('_', 92));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter accountID to transfer from: ");
                int fromAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter accountID to transfer to: ");
                int toAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter amount to transfer: ");

                var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);
                var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);

                decimal amount;
                while (decimal.TryParse(Console.ReadLine(), out amount)) //Check that amount is valid to transfer
                {
                    if (amount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Transfer amount must be positive");
                        Console.ResetColor();
                    }
                    else if (amount == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid transfer amount");
                        Console.ResetColor();
                    }
                    else if (amount > FromAccount.Balance)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not enought money on account");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine();
                        FromAccount.Balance -= amount;
                        ToAccount.Balance += amount;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Transfer success: {amount}.SEK");
                        Console.WriteLine($"You have: {FromAccount.Balance}.SEK left on your {FromAccount.AccountName}");
                        Console.ResetColor();
                    }
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to try again? Y/N?");
                input = Console.ReadLine();
                }
            }
        }
        public void TransferMenu(string loggedInCustomer)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(O)wn accounts | (T)hird party transfer ");
            Console.ResetColor();
            string inputTransfer = Console.ReadLine();

            if (inputTransfer.ToLower() == "o")
            {
                TransferAmount(loggedInCustomer);
            }
            if (inputTransfer.ToLower() == "t")
            {
                ThirdPartTransfer(loggedInCustomer);
            }
        }
    }
}
