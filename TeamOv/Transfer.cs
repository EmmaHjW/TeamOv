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
            Console.WriteLine("Enter accountID to transfer to: ");
            int toAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());

         

            bankAccounts.Find(i => i.AccountId == fromAccount);
            bankAccounts.Find(i => i.AccountId == toAccount);

          

        }
        public void GetAccount()
        {

        }

        //public bool TransferFunds(int fromAccountId, int toAccountId, decimal transferAmount)
        //{
        //    if (transferAmount <= 0)
        //    {
        //        throw new ApplicationException("transfer amount must be positive");
        //    }
        //    else if (transferAmount == 0)
        //    {
        //        throw new ApplicationException("invalid transfer amount");
        //    }

        //    BankAccount fromAccount = GetAccount(fromAccountId);
        //    BankAccount toAccount = GetAccount(toAccountId);

        //    if (fromAccount.balance < transferAmount)
        //    {
        //        throw new ApplicationException("insufficient funds");
        //    }

        //    fromAccount.Transfer(-1 * transferAmount, toAccountId);
        //    toAccount.Transfer(transferAmount, fromAccountId);

        //    return true;
        //}
    }
}
