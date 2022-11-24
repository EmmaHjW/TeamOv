using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    internal class Transactionservice
    {
        public static List<string> transactionslist = new List<string>();

        public Transactionservice()
        {
            
        }
        public static void PrintTransactionHistory() //Prints history
        {
            foreach (var transactions in transactionslist)
            {
                Console.WriteLine("Transactions");
                Console.WriteLine(transactions);
            }
        }
       
        //public void TransactionHistory(string description)
        //{

        //}
    }
}
