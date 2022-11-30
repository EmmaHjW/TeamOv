using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Shapes;

namespace TeamOv
{
    public class Transfer
    {
        private decimal tempSekAmount;
        private decimal amount;
        private decimal dollarRate = 10.58m;
        private decimal dollarToEuro = 0.96m;
        private decimal euroRate = 10.89m;
        private decimal euroToDollar = 1.04m;

        public void Deposit(string loggedInCustomer) //Deposit to accounts
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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter account ID to deposit to: ");
                int toAccount = int.Parse(Console.ReadLine());
                Console.Write("Enter amount to deposit: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deposit amount must be positive");
                    Console.ResetColor();
                }
                else
                {
                    var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);
                    ToAccount.Balance += amount;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"New balance: {ToAccount.Balance.ToString("N" + 2)} {ToAccount.Currency}");
                    Console.ResetColor();
                    Transactionservice.transactionslist.Add($"{DateTime.Now} Deposit: {amount} {ToAccount.Currency} to Account number: {ToAccount.AccountNumber} ");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you have more to deposit? Y/N?");
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Balance after withdraw: {FromAccount.Balance.ToString("N" + 2)} {FromAccount.Currency}");
                    Console.ResetColor();
                    Transactionservice.transactionslist.Add($"{DateTime.Now} Withdraw: {amount} {FromAccount.Currency} from account number: {FromAccount.AccountNumber} ");
                    Console.WriteLine();
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter accountID to transfer from: ");
                int fromAccount = int.Parse(Console.ReadLine());
                Console.Write("Transfer to: ");
                int toAccount = int.Parse(Console.ReadLine());
                Console.Write("Please enter amount: ");

                var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
                var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);
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
                        foreach (var item in BankAccount.bankAccounts) //Search for right currency to accountID
                        {
                            if (FromAccount.Currency == "SEK" && ToAccount.Currency == "SEK")
                            {
                                _ = amount;
                                break;
                            }
                            else if (FromAccount.Currency == "USD" && ToAccount.Currency == "USD")
                            {
                                _ = amount;
                                break;
                            }
                            else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "EUR")
                            {
                                _ = amount;
                                break;
                            }
                            else if (FromAccount.Currency == "USD" && ToAccount.Currency == "SEK")
                            {
                                tempSekAmount = amount;
                                tempSekAmount *= 0.95m;
                                amount /= dollarRate;
                                break;
                            }
                            else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
                            {
                                tempSekAmount = amount;
                                amount /= dollarRate;
                                break;
                            }
                            else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
                            {
                                tempSekAmount = amount;
                                tempSekAmount *= euroRate;
                                amount /= euroRate;
                                break;
                            }
                            else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
                            {
                                amount /= euroRate;
                                break;
                            }
                            else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
                            {
                                amount *= euroToDollar;
                                break;
                            }
                            else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
                            {
                                amount *= dollarToEuro;
                                break;
                            }
                        }
                        //temp amount to store right amount when SEK is from or toAccount
                        if (FromAccount.Currency == "SEK")
                        {
                            FromAccount.Balance -= tempSekAmount;
                            ToAccount.Balance += amount;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {tempSekAmount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
                            Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {amount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
                            Console.ResetColor();
                            Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {tempSekAmount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {amount.ToString("N" + 2)} {ToAccount.Currency}");
                        }
                        else if (ToAccount.Currency == "SEK")
                        {
                            ToAccount.Balance += tempSekAmount;
                            FromAccount.Balance -= amount;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {amount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
                            Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {tempSekAmount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
                            Console.ResetColor();
                            Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {amount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {tempSekAmount} {ToAccount.Currency}");
                        }
                        else
                        {
                            FromAccount.Balance -= amount;
                            ToAccount.Balance += amount;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {amount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
                            Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {amount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
                            Console.ResetColor();
                            Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {amount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {amount.ToString("N" + 2)} {ToAccount.Currency}");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to make another transfer? Y/N?");
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
                    Console.WriteLine($"Owner: {owner.Owner} Account ID: {owner.AccountId} Account number: {owner.AccountNumber} Account name: {owner.AccountName} Balance: {owner.Balance} {owner.Currency}");
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
                        Transactionservice.transactionslist.Add($"{DateTime.Now} Transfer added {amount.ToString("N" + 2)} {FromAccount.Currency} Account: {FromAccount.AccountNumber} || " +
                            $"{DateTime.Now.AddMinutes(15)} Transfer received {amount.ToString("N" + 2)} {ToAccount.Currency} Account: {ToAccount.AccountNumber} ");
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
            bool menu = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {loggedInCustomer}\n{DateTime.Now}");
                var transferOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]*** Customer menu ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Own accounts",
                        "Third party",
                        "Back to menu",
                        "Logout"
                        }));
                switch (transferOptions)
                {
                    case "Own accounts":
                        TransferAmount(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Third party": //Create account
                        ThirdPartTransfer(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Back to menu": //Create account
                        CustomerMenu.ShowCustomerScreen(loggedInCustomer);
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

            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("(O)wn accounts | (T)hird party transfer ");
            //Console.ResetColor();
            //string inputTransfer = Console.ReadLine();

            //if (inputTransfer.ToLower() == "o")
            //{
            //    TransferAmount(loggedInCustomer);
            //}
            //if (inputTransfer.ToLower() == "t")
            //{
            //    ThirdPartTransfer(loggedInCustomer);
            //}
        }
        private int CheckForInt(string accountIn, int accountOut)
        {
            
            while (true)
            {
                bool CheckSuccess = int.TryParse(Console.ReadLine(), out accountOut);
            }
            

        }
    }
}
