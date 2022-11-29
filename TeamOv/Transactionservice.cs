using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    internal class Transactionservice : BankAccount
    {
        public string AccountOwner { get; set; }

        public static List<string> transactionslist = new List<string>();
        public Transactionservice(string accountOwner)
        {
            AccountOwner = accountOwner;

        }
        public static void PrintTransactionHistory() //Prints history
        {
            foreach (var transactions in transactionslist)
            {
                Console.WriteLine();
                Console.WriteLine(transactions);
            }
        }  
    }
}
