
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
        Dictionary<string, float> Currencies = new Dictionary<string, float>();
        private BankAccount? FromAccount;
        private BankAccount? ToAccount;
        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.96f);

            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Today's exchange rates");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 15));
            foreach (var currency in Currencies)
            {
                Console.WriteLine(currency);
            }
            Console.WriteLine(new string('-', 15));
            Console.ResetColor();
        } 
        //public double CurrencyConverter(double amount, int fromAccount, int toAccount)
        //{
        //    DifferentCurrency();

        //    double dollarRate = 10.58;
        //    double dollarToEuro = 0.96;
        //    double kronaRate = 10.9653;
        //    double euroRate = 10.89;
        //    double euroToDollar = 1.04;



        //    foreach (var item in BankAccount.bankAccounts)
        //    {
        //        if (FromAccount.Currency == "SEK" && ToAccount.Currency == "SEK")
        //        {
        //            return amount;
        //        }
        //        else if (FromAccount.Currency == "USD" && ToAccount.Currency == "USD")
        //        {
        //            return amount;
        //        }
        //        else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "EUR")
        //        {
        //            return amount;
        //        }
        //        else if (FromAccount.Currency == "USD" && ToAccount.Currency == "SEK")
        //        {
        //            return amount * kronaRate;
        //        }
        //        else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
        //        {
        //            return amount / dollarRate;
        //        }
        //        else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
        //        {
        //            return amount * euroRate;
        //        }
        //        else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
        //        {
        //            return amount / euroRate;
        //        }
        //        else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
        //        {
        //            return amount * euroToDollar;
        //        }
        //        else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
        //        {
        //            return amount * dollarToEuro;
        //        }
        //    }
        //    return amount;
        //}
    } 
}
