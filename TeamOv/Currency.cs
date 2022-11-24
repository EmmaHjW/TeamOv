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
    public class Currency
    {
        Dictionary<string, float> Currencies = new Dictionary<string, float>();
        
        public void DifferentCurrency()
        {
            Currencies.Add("USD", 10.58f);
            Currencies.Add("EUR", 10.89f);
            Currencies.Add("SEK", 10.9653f);
            
        }
        //double Dollar;
        //float DollarRate = 10.58f;
        //double Krona;
        //float KronaRate = 10.9653f;
        //double Euro;
        //float EuroRate = 10.89f;
       
        decimal EnterDecimal(string message, bool zeroAllowed)
        {
            while (true)
            {
                Console.WriteLine(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    if (zeroAllowed || value != 0m)
                        return value; 
            }
        }

        string EnterCurrency(string message)
        {
            
            
            while (true)
            {
                Console.WriteLine(message);
                string CurrencyFrom = Console.ReadLine().ToUpperInvariant();
                if (Currency.Lenght == 3)
                {
                    return CurrencyFrom;
                }
            }

            string CurrencyFrom = EnterCurrency("Enter From currency: ");
            string CurrencyTo = EnterCurrency("Enter To currency: ");
            decimal rate = EnterDecimal($"Enter exchange rate from {CurrencyFrom} to {CurrencyTo}", false);
            decimal amountFrom = EnterDecimal($"Enter the amount of {CurrencyFrom} to convert", true);
            decimal amountTo = amountFrom * rate;
            Console.WriteLine($"{amountFrom} {CurrencyFrom} equals {amountTo} {CurrencyTo}");
        }
        
        //public void CurrencyConverter(string Currency1, string Currency2, decimal Amount)
        //{
        //    DifferentCurrency();
            



        //    if (Currency1 == "SEK" && Currency2 == "SEK")
        //    {
                
        //    }
        //    else if (Currency1 == "USD" && Currency2 == "USD")
        //    {

        //    }
        //    else if (Currency1 == "EUR" && Currency2 == "EUR")
        //    {

        //    }
        //    else if (Currency1 == "USD" && Currency2 == "SEK")
        //    {

        //    }
        //    else if (Currency1 == "SEK" && Currency2 == "USD")
        //    {

        //    }
        //    else if (Currency1 == "EUR" && Currency2 == "SEK")
        //    {

        //    }
        //    else if (Currency1 == "SEK" && Currency2 == "EUR")
        //    {

        //    }
        //    else if (Currency1 == "EUR" && Currency2 == "USD")
        //    {

        //    }
        //    else if (Currency1 == "USD" && Currency2 == "EUR")
        //    {

        //    }





        }
    }
}
