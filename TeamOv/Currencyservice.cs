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
        
        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.9653f);
            
        }
        public double CurrencyConverter(double amount)
        {
            DifferentCurrency();

            double dollarRate = 10.58;
            double dollarToEuro = 0.96;
            double kronaRate = 10.9653;
            double euroRate = 10.89;
            double euroToDollar = 1.04;

            Console.WriteLine("Enter accountID to transfer from");
            int fromAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter accountID to transfer to");
            int toAccount = int.Parse(Console.ReadLine());

            var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
            var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);

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
                    return amount *= kronaRate; 
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
                {
                    return amount /= dollarRate;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
                {
                    return amount *= euroRate;
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
                {
                    return amount /= euroRate;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
                {
                    return amount *= euroToDollar;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
                {
                    return amount *= dollarToEuro;
                }
            }
            return amount;

        }
        public void Validate() //My test method to check if it was possible to reach currency value! YAAAJ! Works :D
        {
            Console.WriteLine("Enter accountID to transfer from");
            int fromAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter accountID to transfer to");
            int toAccount = int.Parse(Console.ReadLine());

            var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
            var ToAccount = BankAccount.bankAccounts.Find(a => a.AccountId == toAccount);

            foreach (var item in BankAccount.bankAccounts)
            {
                if (FromAccount.Currency == "SEK" && ToAccount.Currency == "SEK")
                {
                    Console.WriteLine("Transferred in SEK");
                    break;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "USD")
                {
                    Console.WriteLine("Transferred in USD");
                    break;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "EUR")
                {
                    Console.WriteLine("Trasferred in EUR");
                    break;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "SEK")
                {
                    Console.WriteLine("Transferred USD to SEK");
                    break;
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "USD")
                {
                    Console.WriteLine("Transferred SEK to USD");
                    break;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "SEK")
                {
                    Console.WriteLine("Transferred EUR to SEK");
                    break;
                }
                else if (FromAccount.Currency == "SEK" && ToAccount.Currency == "EUR")
                {
                    Console.WriteLine("Transferred SEK to EUR");
                    break;
                }
                else if (FromAccount.Currency == "EUR" && ToAccount.Currency == "USD")
                {
                    Console.WriteLine("Transferred EUR to USD");
                    break;
                }
                else if (FromAccount.Currency == "USD" && ToAccount.Currency == "EUR")
                {
                    Console.WriteLine("Transferred USD to EUR");
                    break;
                }
            }
        }
    }
}
