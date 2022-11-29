using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class CustomerMenu
    {
        public static void ShowCustomerScreen(string loggedInCustomer)
        {
            //while (true)
            //{
            //    Console.Clear();
            //    var grid = new Grid();

            //    // Add columns 
            //    grid.AddColumn();
            //    grid.AddColumn();
            //    grid.AddColumn();
            //    grid.AddColumn();

            //    Console.WriteLine("                            Welcome to EmOs Bank 2.0");
            //    Console.ForegroundColor= ConsoleColor.DarkGray;
            //    Console.WriteLine($"Logged in: {DateTime.Now}\nCustomer: {loggedInCustomer}");
            //    Console.ResetColor();
            //    Console.WriteLine();
            //    // Add header row 
            //    grid.AddRow(new Text[]{
            //    new Text("(A)ccount info", new Style(Color.Green, Color.Black)).RightAligned(),
            //    new Text("(O)pen account", new Style(Color.Green, Color.Black)).LeftAligned(),
            //    new Text("(D)eposit", new Style(Color.Green, Color.Black)).LeftAligned(),
            //    new Text("(W)ithdraw", new Style(Color.Green, Color.Black)).LeftAligned(),
            //    });
            //    // Add content row 
            //    grid.AddRow(new Text[]{

            //    new Text("(T)ransfer", new Style(Color.Green, Color.Black)).LeftAligned(),
            //    new Text("(C)hange currency account", new Style(Color.Green, Color.Black)).Centered(),
            //    new Text("(H)istory transactions", new Style(Color.Green, Color.Black)).LeftAligned(),
            //    new Text("(L)ogout", new Style(Color.Green, Color.Black)).LeftAligned()
            //    });
            //    AnsiConsole.Write(grid);

            //    CurrencyService currency = new CurrencyService();
            //    Transfer transfer = new Transfer();
            //    BankAccount bankAccount = new BankAccount();
            //    string customerOptions = Console.ReadLine();
            //    switch (customerOptions.ToLower())
            //    {
            //        case "a":
            //            PrintAccountInfo(loggedInCustomer);
            //            Console.ReadLine();
            //            break;
            //        case "o": //Create account
            //            AddBankAccount(loggedInCustomer);
            //            break;
            //        case "d": //Deposit
            //            transfer.Deposit(loggedInCustomer);
            //            break;
            //        case "w": //Withdrawl
            //            transfer.Withdraw(loggedInCustomer);

            //            break;
            //        case "t": //Transfer
            //            transfer.TransferMenu(loggedInCustomer);
            //            break;
            //        case "c":        
            //            Console.ReadLine();
            //            break;
            //        case "h":        
            //            Transactionservice.PrintTransactionHistory();
            //            Console.ReadLine();
            //            break;
            //        case "l":
            //            Console.WriteLine("You going to be logged out..");
            //            Console.WriteLine("_");
            //            Thread.Sleep(200);
            //            Console.WriteLine("_");
            //            Thread.Sleep(200);
            //            Console.WriteLine("_");
            //            Thread.Sleep(200);
            //            Console.WriteLine("logged out complete");
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            break;
            //    }
            //}        
            Transfer transfer = new Transfer();
            bool menu = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Logged in as: {loggedInCustomer}\n{DateTime.Now}");
                var menuOptions = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("[green]*** Customer menu ***[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                        .AddChoices(new[] {
                        "Account info",
                        "Open account",
                        "Deposit",
                        "Withdrawl",
                        "Transfer",
                        "Loan",
                        "Transaction history",
                        "Logout"
                        }));
                switch (menuOptions)
                {
                    case "Account info":
                        PrintAccountInfo(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Open account": //Create account
                        AddBankAccount(loggedInCustomer);
                        break;
                    case "Deposit": //Deposit
                        transfer.Deposit(loggedInCustomer);
                        break;
                    case "Withdrawl": //Withdrawl
                        transfer.Withdraw(loggedInCustomer);
                        break;
                    case "Transfer": //Transfer
                        transfer.TransferMenu(loggedInCustomer);
                        break;
                    case "Loan": //Loanservice
                        Console.WriteLine("Under construction");
                        Loan loan = new Loan();
                        loan.LoanFromBank(loggedInCustomer);
                        Console.ReadLine();
                        break;
                    case "Transaction history": //Print transaction history
                        Transactionservice.PrintTransactionHistory();
                        Console.ReadLine();
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
        }
        public static void ChosenSalaryAccount(string loggedInCustomer)
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
                    Console.WriteLine($"Successful deposit with {amount} {Deposit.Currency}.");
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
        public static void AddBankAccount(string loggedInCustomer)
        {
            SavingAccount savingAccount = new SavingAccount();
            Console.WriteLine("Which type of account do you want to open?: \n(SA)lary/(S)aving");
            var chooseAccount = Console.ReadLine();
            if (chooseAccount.ToLower() == "sa" || chooseAccount.ToLower() == "Salary")
            {
                ChosenSalaryAccount(loggedInCustomer);
            }
            else if (chooseAccount.ToLower() == "s" || chooseAccount.ToLower() == "Saving")
            {
                
                savingAccount.ChosenSavingAccount(loggedInCustomer);
            }
        }
        public static void PrintAccountInfo(string loggedInCustomer)
        {  
            if (BankAccount.bankAccounts.Count < 0)
            {
                Console.WriteLine("No accounts found, talk to a bank employee to open one.");
            }
            List<BankAccount>Owner = BankAccount.bankAccounts.FindAll(bankAccounts => bankAccounts.Owner == loggedInCustomer); //WORKS YIIPPPEEE!!!

            foreach (var own in Owner)
            {
                Console.WriteLine(own);
            }
        }
    }
}
