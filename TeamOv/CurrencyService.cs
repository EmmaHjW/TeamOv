using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;

namespace TeamOv
{
    public class CurrencyService
    {
        private decimal tempSekAmount;
        private decimal amount;
        private double amountD;
        private readonly int fromAccount;
        private readonly int toAccount;
        private decimal dollarRate = 10.58m;
        private decimal dollarToEuro = 0.96m;
        private decimal kronaRate = 10.9653m;
        private decimal euroRate = 10.89m;
        private decimal euroToDollar = 1.04m;

        Dictionary<string, float> Currencies = new Dictionary<string, float>();
        private BankAccount? FromAccount;
        private BankAccount? ToAccount;

        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.9653f);

        }
        public double CurrencyConverter(double amount, int fromAccount, int toAccount)
        {
            DifferentCurrency();

            double dollarRate = 10.58;
            double dollarToEuro = 0.96;
            double kronaRate = 10.9653;
            double euroRate = 10.89;
            double euroToDollar = 1.04;

            //Console.WriteLine("Enter accountID to transfer from");
            //fromAccount = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter accountID to transfer to");
            //toAccount = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter amount to transfer: ");

            FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
            ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);


            foreach (var item in BankAccount.bankAccounts)
            {
                if (FromAccount.Currency == "SEK" && ToAccount.Currency == "SEK")
                {
                    return amount;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "USD")
                {
                    return amount;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "EUR")
                {
                    return amount;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "SEK")
                {
                    return amount * kronaRate;
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
                {
                    return amount / dollarRate;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
                {
                    return amount * euroRate;
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
                {
                    return amount / euroRate;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
                {
                    return amount * euroToDollar;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
                {
                    return amount * dollarToEuro;
                }
            }
            return amount;
        }
        //public double Currency(decimal amount, int fromAccount, int toAccount)
        //{
        //    var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
        //    var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);

        //    while (decimal.TryParse(Console.ReadLine(), out amount)) //Check that amount is valid to transfer
        //    {
        //        if (amount <= 0)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Transfer amount must be positive");
        //            Console.ResetColor();
        //        }
        //        else if (amount == 0)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Invalid transfer amount");
        //            Console.ResetColor();
        //        }
        //        else if (amount > FromAccount.Balance)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Not enought money on account");
        //            Console.ResetColor();
        //        }
        //        else
        //        {
        //            foreach (var item in BankAccount.bankAccounts) //Search for right currency to accountID
        //            {
        //                if (FromAccount.Currency == "SEK" && ToAccount.Currency == "SEK")
        //                {
        //                    _ = amount;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "USD")
        //                {
        //                    _ = amount;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "EUR")
        //                {
        //                    _ = amount;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "SEK")
        //                {
        //                    tempSekAmount = amount;
        //                    tempSekAmount *= 0.95m;
        //                    amount /= dollarRate;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
        //                {
        //                    tempSekAmount = amount;
        //                    amount /= dollarRate;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
        //                {
        //                    tempSekAmount = amount;
        //                    tempSekAmount *= euroRate;
        //                    amount /= euroRate;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
        //                {
        //                    amount /= euroRate;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
        //                {
        //                    amount *= euroToDollar;
        //                    break;
        //                }
        //                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
        //                {
        //                    amount *= dollarToEuro;
        //                    break;
        //                }
        //            }
        //            return amount;
        //            //temp amount to store right amount when SEK is from or toAccount
        //            if (FromAccount.Currency == "SEK")
        //            {
        //                FromAccount.Balance -= tempSekAmount;
        //                ToAccount.Balance += amount;
        //                Console.ForegroundColor = ConsoleColor.White;
        //                Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {tempSekAmount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
        //                Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {amount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
        //                Console.ResetColor();
        //                Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {tempSekAmount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {amount.ToString("N" + 2)} {ToAccount.Currency}");
        //            }
        //            else if (ToAccount.Currency == "SEK")
        //            {
        //                ToAccount.Balance += tempSekAmount;
        //                FromAccount.Balance -= amount;
        //                Console.ForegroundColor = ConsoleColor.White;
        //                Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {amount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
        //                Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {tempSekAmount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
        //                Console.ResetColor();
        //                Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {amount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {tempSekAmount} {ToAccount.Currency}");
        //            }
        //            else
        //            {
        //                FromAccount.Balance -= amount;
        //                ToAccount.Balance += amount;

        //                Console.ForegroundColor = ConsoleColor.White;
        //                Console.WriteLine($"{DateTime.Now} Your transfer has been placed: {amount.ToString("N" + 2)}.{FromAccount.Currency} New balance: {FromAccount.Balance.ToString("N" + 2)}{FromAccount.Currency} on {FromAccount.AccountName}");
        //                Console.WriteLine($"{DateTime.Now.AddMinutes(15)} Transfer received: {amount.ToString("N" + 2)} {ToAccount.Currency} New balance: {ToAccount.Balance.ToString("N" + 2)}.{ToAccount.Currency} on {ToAccount.AccountName}");
        //                Console.ResetColor();
        //                Transactionservice.transactionslist.Add($"{DateTime.Now} {FromAccount.AccountNumber} Transfer added {amount.ToString("N" + 2)} {FromAccount.Currency} {DateTime.Now.AddMinutes(15)} {ToAccount.AccountNumber} transfer received {amount.ToString("N" + 2)} {ToAccount.Currency}");
        //                Console.ResetColor();
        //            }
        //        }
        //    }
        //}
    } 
}
