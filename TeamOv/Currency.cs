using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.Design;

namespace TeamOv
{
    public class Currency
    {
        public object CurrencyConverter { get; private set; }

        public static string[] GetCurrencyTags()
        {
            return new string[] {"EUR", "USD", "JPY", "BGN", "CZK", "DKK", "GBP", "HUF", "LTL", "LVL"
            , "PLN", "RON", "SEK", "CHF", "NOK", "HRK", "RUB", "TRY", "AUD", "BRL", "CAD", "CNY", "HKD", "IDR", "ILS"
            , "INR", "KRW", "MXN", "MYR", "NZD", "PHP", "SGD", "ZAR"};
        }

        public static float GetCurrencyRateInEuro(string currency)
        {
            if (currency.ToLower() == "")
            
                throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
            if (currency.ToLower() == "eur")
                throw new ArgumentException("Invalid Argument! Cannot get exchange rate from EURO to EURO");

            try
            {
                string rssUrl = string.Concat("http://www.ecb.int/rss/fxref-", currency.ToLower() + ".html");

                // Create & Load New Xml Document
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(rssUrl);

                // Create XmlNamespaceManager for handling XML namespaces.
                System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("rdf", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

                // Get list of daily currency exchange rate between selected "currency" and the EURO
                System.Xml.XmlNodeList nodeList = doc.SelectNodes("//rdf:item", nsmgr);

                foreach (System.Xml.XmlNode node in nodeList)
                {
                    // Create a CultureInfo, this is because EU and USA use different sepperators in float (, or .)
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ".";

                    try
                    {
                        // Get currency exchange rate with EURO from XMLNODE
                        float exchangeRate = float.Parse(
                            node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                            NumberStyles.Any,
                            ci);

                        return exchangeRate;
                    }
                    catch { }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static float GetExchangeRate(string from, string to, float amount = 1)
        {
            if (from == null || to == null)
                return 0;

            if (from.ToLower() == "eur" && to.ToLower() == "eur")
            
                return amount;

            try
            {
                float toRate = GetCurrencyRateInEuro(to);
                float fromRate = GetCurrencyRateInEuro(from);

                if (from.ToLower() == "eur")
                {
                    return (amount * toRate);
                }
                else if (to.ToLower() == "eur")
                {
                    return (amount / fromRate);
                }
                else
                {
                    return (amount * toRate) / fromRate;
                }
            }
            catch { return 0; }
            
        }

        //public void TringOutSomething()
        //{
        //    string fromCurrency = "EUR";
        //    string toCurrency = "USD";
        //    int amount = 1;

        //    string[] availableCurrency = CurrencyConverter.GetCurrencyTags();

        //    Console.WriteLine("Available Currencies");
        //    Console.WriteLine(string.Join(",", availableCurrency));
        //    Console.WriteLine("\n");

        //    Console.WriteLine("Insert Currency you want to convert TO");
      
        //    toCurrency = Console.ReadLine();
        //    Console.WriteLine("\n");

        //    float exchangeRate = CurrencyConverter.GetExchangeRate(fromCurrency, toCurrency, amount);
        //    Console.WriteLine("FROM " + amount + " " + fromCurrency.ToUpper() + " TO " + toCurrency.ToUpper() + " = " + exchangeRate);

        //    Console.ReadLine();
        //}
    }
}
