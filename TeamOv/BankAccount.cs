using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class BankAccount
    {
        
        public static List<BankAccount> bankAccounts = new List<BankAccount>();
        private static int accountIdPool;
        public string Owner { get; set; }
        public int AccountId { get; set; }
        public string AccountNumber { get; init; }
        public decimal Balance { get; set; }
        public bool Active { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountName { get; set; }
        public Currency Currency { get; set; }


        public BankAccount(
            string owner, 
            int accountId, 
            string accountNumber,
            //decimal interestRate,//?
            string accountName,
            decimal balance = 0m,
            Currency currency = Currency.SEK,
            bool active = false
        )
        {
            this.Owner = owner;
            this.AccountId = accountIdPool++;
            this.AccountNumber = GenerateBankAccountNumber(); ;
            this.AccountName = accountName;
            this.Balance = balance;
            //InterestRate = interestRate;
            this.Active = active;
            this.Currency = currency;
        }

        public BankAccount() //constructor
        {
        }

        public void InitiateBankAccount() //Adds account to users at program run
        {
            BankAccount bankAccount1 = new BankAccount() { Owner = "Oskar", AccountId = 0, AccountNumber = GenerateBankAccountNumber(), AccountName = "Salary account", Balance = 20000, Currency = Currency.USD, Active = true };
            BankAccount bankAccount2 = new BankAccount() { Owner = "Oskar", AccountId = 1, AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 15000, Currency = Currency.SEK, Active = false };
            BankAccount bankAccount3 = new BankAccount() { Owner = "Oskar", AccountId = 2, AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 45600, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount4 = new BankAccount() { Owner = "Emma", AccountId = 3, AccountNumber = GenerateBankAccountNumber(), AccountName = "Salary account", Balance =30000, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount5 = new BankAccount() { Owner = "Emma", AccountId = 4, AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 50000, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount6 = new BankAccount() { Owner = "Emma", AccountId = 5, AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 5000, Currency = Currency.GBP, Active = true };

            bankAccounts.Add(bankAccount1);
            bankAccounts.Add(bankAccount2);
            bankAccounts.Add(bankAccount3);
            bankAccounts.Add(bankAccount4);
            bankAccounts.Add(bankAccount5);
            bankAccounts.Add(bankAccount6);
        }
        
        public static string GenerateBankAccountNumber()
        {
            Random random = new Random();
            string bankaccount = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bankaccount = bankaccount + random.Next(0, 10).ToString();
                }
                bankaccount = bankaccount + "-";
            }
            return bankaccount.Trim('-');
        }
        public override string ToString()
        {
            return $"Owner: {Owner}, AccountID {AccountId}, AccountNumber: {AccountNumber}, AccountName: {AccountName}, Balance: {Balance}, Currency: {Currency.SEK} ";
        }

        public void ChangeCurrency()
        {
            foreach (Currency Currency in Enum.GetValues<Currency>())
            {
                Console.WriteLine(Currency);
            }
            Console.WriteLine("Choose currency from list: ");
            int toCurrency = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose account: ");
            int ToAccountId = int.Parse(Console.ReadLine());

            var ToCurrency = bankAccounts.Find(a => a.AccountId == ToAccountId);
            ToCurrency.Currency = TeamOv.Currency;


            Console.WriteLine($"Currency changed to {ToCurrency.Currency}");
            Console.ReadLine();
        }
    }
}

