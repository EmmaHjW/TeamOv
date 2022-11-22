using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Transfer : BankAccount
    {

        public void Deposit(decimal amount)
        {
            if (bankAccounts.Count < 1)
            {
                Console.WriteLine("No accounts found to deposit money into");
            }
            Console.WriteLine("Enter amount to deposit: ");
            decimal Amount = decimal.Parse(Console.ReadLine());
            if (Amount <= 0)
            {
                Console.WriteLine("Amount cant be less then 1");
            }
            else
            {
                Balance += Amount;
                //Amount += Balance;
                bankAccounts.Add(this);
            }
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;

        }
        public void CheckBalance()
        {
            Console.WriteLine($"Account balance: {Balance}.{Currency.SEK}");
        }

        public void TransferAmount(string loggedInCustomer)
        {
            CustomerMenu.PrintAccountInfo(loggedInCustomer);
            Console.WriteLine("Enter accountID to transfer from: ");
            int fromAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Transfer to: ");
            int toAccount = int.Parse(Console.ReadLine());
            Console.WriteLine();
            GetAccount(fromAccount, toAccount);
            Console.WriteLine("Please enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("transfer amount must be positive");
            }
            else if (amount == 0)
            {
                Console.WriteLine("invalid transfer amount");
            }
            else (amount > Balance)
            {
                Console.WriteLine("The amount is to high, choose a lower amount please");
            }
           
            //fromAccount = TransferAmount();
            //toAccount = TransferAmount(toAccount);

            //if (fromAccount.balance < TransferAmount)
            //{
            //    Console.WriteLine("insufficient funds");
            //}

            //fromAccount.Transfer(-1 * transferAmount, toAccount);
            //toAccount.Transfer(transferAmount, fromAccount);

        }
        public void GetAccount(int FromAccountId, int ToAccountId)
        {
            bankAccounts.Find(a => a.AccountId == FromAccountId);
            bankAccounts.Find(a => a.AccountId == ToAccountId);
        }
    }
}
