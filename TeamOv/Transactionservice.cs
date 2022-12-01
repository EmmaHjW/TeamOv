using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace TeamOv
{
    internal class Transactionservice : BankAccount
    {
        public string AccountOwner { get; set; }

        public static List<string> transactionslist = new List<string>();
        public static List<string> loanTransacktionList = new List<string>();
        public Transactionservice(string accountOwner)
        {
            AccountOwner = accountOwner;

        }
        public static void PrintTransactionHistory() //Prints history
        {
            AnsiConsole.Foreground = Color.CadetBlue;
            AnsiConsole.WriteLine("Transfer history");
            foreach (var transactions in transactionslist)
            {
                AnsiConsole.WriteLine(transactions);
                Console.WriteLine();
            }
            AnsiConsole.ResetColors();
            PrintLoanHistory();
        }  
        public static void PrintLoanHistory()
        {
            AnsiConsole.Foreground = Color.IndianRed;
            AnsiConsole.WriteLine("Loan history");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|enter to go back to menu|");
            Console.ResetColor();
            foreach (var loanTransaktions in loanTransacktionList)
            {
                AnsiConsole.WriteLine(loanTransaktions);
                Console.WriteLine();
            }
            AnsiConsole.ResetColors();
        }
    }
}
