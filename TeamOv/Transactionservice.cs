using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    internal class Transactionservice
    {
        public static List<Transactionservice> transactionslist = new List<Transactionservice>();

        public enum Type { Open, Deposit, Withdrawl, TransferAmount, ThirdParyTransfer}
        public Type TransactionTyp { get; }
        public string Description { get; set; }
        public DateTime Timestamp { get; }

        public Transactionservice(Type transactionType, string description) //Constructor
        {
            TransactionTyp= transactionType;
            Description= description;
            Timestamp = DateTime.Now;
        }
        public void PrintTransactionHistory() //Prints history
        {
            foreach (var transactions in transactionslist)
            {
                Console.WriteLine("Transactions");
                Console.WriteLine(transactions);
            }
        }
        public override string ToString()
        {
            return $"{Timestamp}: {TransactionTyp} - {Description}";
        }
        //public void TransactionHistory(string description)
        //{

        //}
    }
}
