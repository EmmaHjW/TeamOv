using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class SavingAccount : Transfer
    {
        //public string checkCredit;
        //public float allowedLoan;

        //public decimal interrestAmountS(decimal amount)
        //{
        //    return amount * interrestRateSaving;
        //}
        //public decimal interrestAmountF(decimal amount)
        //{
        //    return amount * interrestRateFund;
        //}





        public static void CustomerChoice(string loggedInCustomer)
        {
            Transfer transfer = new Transfer();
            bool account = true;
            do
            {
                
                var accountOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]*** Options ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Saving account",
                        "Fund",    
                        }));
                switch (accountOptions)
                {
                    case "Saving account":
                        AddANewSavingAccount(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Fund":
                        AddANewSavingAccount(loggedInCustomer);
                        break;
                    default:
                        break;
                }

            } while (account);

        }

        public static void AddANewSavingAccount(string loggedInCustomer)
        {
            //CustomerChoice(loggedInCustomer);

            BankAccount bankAccount = new BankAccount();
            decimal interrestRateSaving = 0.8m;
            decimal interrestRateFund = 1.3m;

            Console.WriteLine("Choose which type of saving account: (Saving or Fund)");
            var chooseSaving = Console.ReadLine();
            if (chooseSaving.ToLower() == "s" || chooseSaving.ToLower() == "saving")
            {
                Console.WriteLine("Please enter a name to your new account: ");
                var accountname = Console.ReadLine();
                string accountNumber = BankAccount.GenerateBankAccountNumber();
                string owner = loggedInCustomer;
                BankAccount.bankAccounts.Add(new BankAccount(accountNumber, accountname, owner, 0, "SEK", true));
                Console.WriteLine(value: $"Your interrest rate on your choosen account will be: {interrestRateSaving}");
                Console.WriteLine($"{accountname} account {accountNumber} created");
                Console.WriteLine();

                Console.WriteLine("Do you want to make a first deposit? (Yes/No)");
                var firstDeposit = Console.ReadLine();
                decimal amount;
                Console.Write("Enter amount: ");
                if (firstDeposit.ToLower() == "y" || firstDeposit.ToLower() == "yes")
                {
                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        string accountnumber = BankAccount.GenerateBankAccountNumber();
                        string deposit = accountnumber;
                        var Deposit = BankAccount.bankAccounts.Find(a => a.AccountNumber == deposit);
                        Deposit.Balance *= interrestRateSaving += amount;
                        Console.WriteLine($"Successful deposit with {amount} {Deposit.Currency}.");
                        Console.ReadLine();
                        Transactionservice.transactionslist.Add($"{DateTime.Now} Depsoit: {amount} {Deposit.Currency} to account number: {Deposit.AccountNumber}");
                    }
                }
      

            else if (chooseSaving.ToLower() == "f" || chooseSaving.ToLower() == "fund")
            {
                Console.WriteLine("Please enter a name to your new account: ");
                var accountname2 = Console.ReadLine();
                string accountNumber2 = BankAccount.GenerateBankAccountNumber();
                string owner2 = loggedInCustomer;
                BankAccount.bankAccounts.Add(new BankAccount(accountNumber, accountname, owner, 0, "SEK", true));
                Console.WriteLine(value: $"Your interrest rate on your choosen account will be: {interrestRateFund}");
                Console.WriteLine($"{accountname} account {accountNumber} created");
                Console.WriteLine();

                Console.WriteLine("Do you want to make a first deposit? (Yes/No)");
                var firstDeposit2 = Console.ReadLine();
                decimal amountF;
                Console.Write("Enter amount: ");
                    if (firstDeposit.ToLower() == "y" || firstDeposit.ToLower() == "yes")
                    {
                        if (decimal.TryParse(Console.ReadLine(), out amountF))
                        {
                            string accountnumber = BankAccount.GenerateBankAccountNumber();
                            string deposit = accountnumber;
                            var Deposit = BankAccount.bankAccounts.Find(a => a.AccountNumber == deposit);
                            Deposit.Balance *= interrestRateFund += amountF;
                            Console.WriteLine($"Successful deposit with {amountF} {Deposit.Currency}.");
                            Console.ReadLine();
                            Transactionservice.transactionslist.Add($"{DateTime.Now} Depsoit: {amountF} {Deposit.Currency} to account number: {Deposit.AccountNumber}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("It´s ok, you can come back another time.");
                    }
            }
                
            }
            else
            {
                Console.WriteLine("You can do it another time instead.");
            }
        }
            
    }
    
}
