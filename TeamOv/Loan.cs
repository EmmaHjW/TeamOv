using SixLabors.ImageSharp.Metadata.Profiles.Icc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Loan : BankAccount
    {
        private decimal loanInterestRate1 = 1.15m;
        private decimal loanInterestRate2 = 2.15m;
        private decimal loanInterestRate3 = 3.15m;
        private decimal givingLoanRate = 0.0m;
        private decimal checkCredit;

        public decimal LoanInterestRate(decimal amount, decimal givingLoanRate)
        {
            if (amount < 10000)
            {
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate1 + "%");
            }
            else if (amount >= 10000 && amount <= 70000)
            {
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate2 + "%");
            }
            else if (amount > 70000)
            {
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate3 + "%");
            }
            return givingLoanRate;
        }
        public bool TotalBalance(string loggedInCustomer, decimal amount)
        {
            List<BankAccount> Owner = BankAccount.bankAccounts.FindAll(b => b.Owner == loggedInCustomer);
            
            decimal allowedToLoan = 0;
            foreach (var item in Owner)
            {
                if (item.Currency == "SEK")
                {
                    allowedToLoan += item.Balance;
                }
            }
            return amount > allowedToLoan * 5;

        }

        //public decimal CheckCredit(string loggedInCustomer, decimal amount, decimal balance)
        //{
        //    if (balance >= amount)
        //    {

        //    }
        //}

        public void LoanFromBank(string loggedInCustomer)
        {
            Console.WriteLine("Would you like to take a loan? (Yes/No)");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                Console.WriteLine("Okey! To be able to offer you a loan we need to check if first, it is possible and second, to give you correct interest rate.\nHow mouch would you like to loan?");
                decimal amount;
                Console.Write("Enter amount: ");
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    
                }
            }
            else if(answer.ToLower() == "n" || answer.ToLower() == "no")
            {
                Console.WriteLine("Okej, let us know if you change your mind.");
            }
        }

    }
}
