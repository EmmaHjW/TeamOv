using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Transfer : BankAccount
    {

        public void Deposit(string loggedInCustomer)
        {
            CustomerMenu.PrintAccountInfo(loggedInCustomer);
            if (bankAccounts.Count < 1)
            {
                Console.WriteLine("No accounts found to deposit money into");
            }
            Console.WriteLine("Enter account to deposit to");
            int toAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine("Amount cant be less then 1");
            }
            else
            {
                var ToAccount = bankAccounts.Find(a => a.AccountId == toAccount);
                ToAccount.Balance += amount;
                Console.WriteLine($"Balance after deposit: {ToAccount.Balance}");
            }
            Console.ReadLine();
        }
        public void Withdraw(string loggedInCustomer)
        {
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                CustomerMenu.PrintAccountInfo(loggedInCustomer);
            if (bankAccounts.Count < 1)
            {
                Console.WriteLine("No accounts found to withdraw money from");
            }
            Console.WriteLine("Enter account to withdraw from");
            int toAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine("Amount cant be less then 1");
            }
            else
            {
                var ToAccount = bankAccounts.Find(a => a.AccountId == toAccount);
                ToAccount.Balance -= amount;
                Console.WriteLine($"Balance after withdraw: {ToAccount.Balance}");
            }
            }
            Console.WriteLine();
            Console.WriteLine("Do you want to try again? Y/N?");
            input = Console.ReadLine();

        }
        public void CheckBalance()
        {
            Console.WriteLine($"Account balance: {Balance}.SEK{Currency}");
        }

        public void TransferAmount(string loggedInCustomer)
        {
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                CustomerMenu.PrintAccountInfo(loggedInCustomer);
                Console.WriteLine("Enter accountID to transfer from: ");
                int fromAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Transfer to: ");
                int toAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter amount: ");

                var FromAccount = bankAccounts.Find(a => a.AccountId == fromAccount);
                var ToAccount = bankAccounts.Find(a => a.AccountId == toAccount);

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
                        FromAccount.Balance -= amount;
                        ToAccount.Balance += amount;

                        Console.WriteLine($"You have: {FromAccount.Balance}{Currency = "SEK"} left on your {FromAccount.AccountName}");
                        Console.WriteLine($"You have: {ToAccount.Balance}{Currency = "SEK"} left on your {ToAccount.AccountName}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to try again? Y/N?");
                input = Console.ReadLine();
            }
        }
        public void ThirdPartTransfer(string loggedInCustomer)
        {
            string input = "Y";
            while (input == "Y" || input == "y")
            {
                List<BankAccount> Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.AccountName == "Salary account");
                foreach (var owner in Owner)
                {
                    Console.WriteLine($"Owner: {owner.Owner} Account ID: {owner.AccountId} Account number: {owner.AccountNumber} Account name: {owner.AccountName}");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter accountID to transfer from: ");
                int fromAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter accountID to transfer to: ");
                int toAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter amount to transfer: ");
                

                var ToAccount = bankAccounts.Find(a => a.AccountId == toAccount);
                var FromAccount = bankAccounts.Find(a => a.AccountId == fromAccount);
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
                        Console.WriteLine($"Transfer success: {amount}.SEK{Currency}");
                        Console.WriteLine($"You have: {FromAccount.Balance}{Currency = "SEK"} left on your {FromAccount.AccountName}");
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
    }
}
