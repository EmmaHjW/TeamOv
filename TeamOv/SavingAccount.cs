using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class SavingAccount 
    {
        private readonly decimal interestRate1 = 0.0m;
        private readonly decimal interestRate2 = 0.8m;
        private readonly decimal interestRate3 = 1.3m;
        private readonly decimal givingRate = 0.0m;
        public decimal InterestRate(decimal amount, decimal givingRate)
        {
            if (amount < 10000)
            {
                Console.WriteLine("Your interest rate: " + interestRate1 + "%");
            }
            else if (amount >= 10000 && amount <= 50000)
            {
                Console.WriteLine("Your interest rate: " + interestRate2 + "%");
            }
            else if(amount >= 50000)
            {
                Console.WriteLine("Your interest rate: " + interestRate3 + "%");
            }
            return givingRate;
        }
        public void ChosenSavingAccount(string loggedInCustomer)
        {
            Console.Write("Please enter a name to your new account: ");
            var accountname = Console.ReadLine();
            string accountNumber = BankAccount.GenerateBankAccountNumber();
            string owner = loggedInCustomer;
            BankAccount.bankAccounts.Add(new BankAccount(accountNumber, accountname, owner, 0, "SEK", true)); //wrong accountname
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
                    InterestRate(amount, givingRate);
                    Console.WriteLine($"Successful deposit {amount} {Deposit.Currency}.");
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

    }
    
}
