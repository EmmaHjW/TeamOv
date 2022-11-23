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
        public void Withdraw(decimal amount)
        {
            Balance -= amount;

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
                        Console.WriteLine("Not enought money on account");
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
    }   }   
        //public void GetAccount(int FromAccountId, int ToAccountId)
        //{
        //    bankAccounts.Find(a => a.AccountId == FromAccountId);
        //    bankAccounts.Find(a => a.AccountId == ToAccountId);
        //}
    
}
