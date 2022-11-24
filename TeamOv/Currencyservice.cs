using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Security.Cryptography;

namespace TeamOv
{
    public class Currencyservice
    {
        Dictionary<string, float> Currencies = new Dictionary<string, float>();

        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.9653f);

        }


        //decimal EnterDecimal(string message, bool zeroAllowed)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine(message);
        //        if (decimal.TryParse(Console.ReadLine(), out decimal value))
        //            if (zeroAllowed || value != 0m)
        //                return value;
        //    }
        //}

        //string EnterCurrency(string message)
        //{

        //    while (true)
        //    {
        //        Console.WriteLine(message);
        //        var CurrencyFrom = Console.ReadLine().ToUpperInvariant();
        //        if (Currency.Lenght == 3)
        //        {
        //            return CurrencyFrom;
        //        }
        //    }

        //    string CurrencyFrom = EnterCurrency("Enter From currency: ");
        //    string CurrencyTo = EnterCurrency("Enter To currency: ");
        //    decimal rate = EnterDecimal($"Enter exchange rate from {CurrencyFrom} to {CurrencyTo}", false);
        //    decimal amountFrom = EnterDecimal($"Enter the amount of {CurrencyFrom} to convert", true);
        //    decimal amountTo = amountFrom * rate;
        //    Console.WriteLine($"{amountFrom} {CurrencyFrom} equals {amountTo} {CurrencyTo}");
        //}

        double Dollar;
        decimal DollarRate = 10;
        double Krona;
        decimal KronaRate = 10;
        double Euro;
        decimal EuroRate = 10;
        public decimal CurrencyConverter(string Currency1, string Currency2, decimal amount)
        {
            DifferentCurrency();

            if (Currency1 == "SEK" && Currency2 == "SEK")
            {
                return amount;
            }
            else if (Currency1 == "USD" && Currency2 == "USD")
            {
                return amount;
            }
            else if (Currency1 == "EUR" && Currency2 == "EUR")
            {
                return amount;
            }
            else if (Currency1 == "USD" && Currency2 == "SEK")
            {
                return amount;
            }
            else if (Currency1 == "SEK" && Currency2 == "USD")
            {
                return amount;
            }
            else if (Currency1 == "EUR" && Currency2 == "SEK")
            {
                return amount;
            }
            else if (Currency1 == "SEK" && Currency2 == "EUR")
            {
                return amount;
            }
            else if (Currency1 == "EUR" && Currency2 == "USD")
            {
                return amount;
            }
            else if (Currency1 == "USD" && Currency2 == "EUR")
            {
                return amount;
            }
            return amount;
        }
        public void CheckCurrencyInput()
        {
            Console.WriteLine("Enter currency ");
        }
    }
}
