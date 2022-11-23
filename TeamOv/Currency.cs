using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Security;

namespace TeamOv
{
    public class Currency
    {
        Dictionary<string, float> Currencies = new Dictionary<string, float>();
        
        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.9653f);
            Currencies.Add("GBP", 12.61f);
        }
        
        public void CurrencyConverter(string loggedInCustomer)
        {
            DifferentCurrency();
            CustomerMenu.PrintAccountInfo(loggedInCustomer);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter accountID for the account you want to change currency: ");
            int fromAccount = int.Parse(Console.ReadLine());

            foreach (var key in Currencies)
            {
                Console.WriteLine("Currencies: {0}", key);
            }

            Console.WriteLine($"Choose which currency: ");
            string toCurrency = Console.ReadLine();
            Console.WriteLine($"Changed to: {toCurrency}");

            var FromAccount = BankAccount.bankAccounts.Find(a => a.AccountId == fromAccount);
            var ToCurrency = BankAccount.bankAccounts.Find(a => a.Currency == toCurrency);



            //Console.WriteLine("Available Currencies");
            //Console.WriteLine(string.Join(",", availableCurrency));
            //Console.WriteLine("\n");

            //Console.WriteLine("Insert Currency you want to convert TO");

            //toCurrency = Console.ReadLine();
            //Console.WriteLine("\n");

            //float exchangeRate = CurrencyConverter.GetExchangeRate(fromCurrency, toCurrency, amount);
            //Console.WriteLine("FROM " + amount + " " + fromCurrency.ToUpper() + " TO " + toCurrency.ToUpper() + " = " + exchangeRate);

            //Console.ReadLine();
        }
        




    }
}
