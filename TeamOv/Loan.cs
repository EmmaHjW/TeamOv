using SixLabors.ImageSharp.Metadata.Profiles.Icc;
using Spectre.Console;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Style = Spectre.Console.Style;

namespace TeamOv
{
    internal class Loan : BankAccount
    {
        private decimal loanInterestRate1 = 1.15m;
        private decimal loanInterestRate2 = 2.15m;
        private decimal loanInterestRate3 = 3.15m;
        private decimal givingLoanRate = 0.0m;

        public decimal LoanInterestRate(decimal amount, decimal givingLoanRate, string loggedInCustomer)
        {
            if (amount < 10000)
            {
                givingLoanRate = loanInterestRate1;
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate1 + "%");
                Transactionservice.loanTransacktionList.Add($"{DateTime.Now} {loggedInCustomer} Loan allowed: {amount} Rate: {givingLoanRate}");
            }
            else if (amount >= 10000 && amount <= 70000)
            {
                givingLoanRate= loanInterestRate2;
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate2 + "%");
                Transactionservice.loanTransacktionList.Add($"{DateTime.Now} {loggedInCustomer} Loan allowed: {amount} Rate: {givingLoanRate}");
            }
            else if (amount > 70000)
            {   
                givingLoanRate = loanInterestRate3;
                Console.WriteLine("Your interest rate on this loan will be: " + loanInterestRate3 + "%");
                Transactionservice.loanTransacktionList.Add($"{DateTime.Now} {loggedInCustomer} Loan allowed: {amount} Rate: {givingLoanRate}");
            }
            return givingLoanRate;  
        }
        public void CheckCredit(string loggedInCustomer, decimal amount)
        {
            List<BankAccount> Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.Owner == loggedInCustomer);
           // decimal allowedToLoan = 0;
            foreach (var item in Owner)
            {
                if (item.Currency == "SEK")
                {
                    if (amount > item.Balance * 5)
                    {
                        LoanDenied();
                        Transactionservice.transactionslist.Add($"{DateTime.Now} {loggedInCustomer}");
                    }
                    else
                    {
                        LoanAllowed();
                        LoanInterestRate(amount, givingLoanRate, loggedInCustomer);
                    }
                }
            }
        }
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
                    CheckCredit(loggedInCustomer, amount);
                }
            }
            else if(answer.ToLower() == "n" || answer.ToLower() == "no")
            {
                Console.WriteLine("Okej, let us know if you change your mind.");
            }
        }
        private void LoanAllowed()
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx =>
            {
                // Simulate some work
                AnsiConsole.MarkupLine("Counting on your loan application");
                Thread.Sleep(1000);

                // Update the status and spinner
                ctx.Status("\r\nWill check the budget calculation");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));

                // Simulate some work
                AnsiConsole.MarkupLine("Are you married?");
                Thread.Sleep(2000); 
                AnsiConsole.MarkupLine("It'll probably be fine. ");
                Thread.Sleep(2000); 
                AnsiConsole.MarkupLine("[Yellow]Your lone is allowed![/]");
                Thread.Sleep(2000);
            });
            Console.ReadLine();
        }    
        private void LoanDenied()
        {
            AnsiConsole.Status()
            .Start("Thinking...", ctx =>
            {
                // Simulate some work
                AnsiConsole.MarkupLine("Counting on your loan application");
                Thread.Sleep(1000);

                // Update the status and spinner
                ctx.Status("\r\nWill check the budget calculation");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));

                // Simulate some work
                AnsiConsole.MarkupLine("Planing to buy house?");
                Thread.Sleep(2000); 
                AnsiConsole.MarkupLine("It will be expensive to live there");
                Thread.Sleep(2000); 
                AnsiConsole.MarkupLine("[Red]Sorry, but your loan could not be approved![/]");
                Thread.Sleep(2000);
            });
            Console.ReadLine();
        }
    }
}
