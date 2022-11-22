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

        public List<BankAccount> BankAccounts//?
        {
            get { return bankAccounts; }
            set { bankAccounts = value; }
        }
        private static int accountIdPool;
        public int AccountId { get; set; }
        public string AccountNumber { get; init; }
        public decimal Balance { get; set; }
        public bool Active { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountName { get; set; }
        public Currency Currency { get; set; }


        public BankAccount(
            int accountId, //?
            string accountNumber,
            //decimal interestRate,//?
            string accountName,
            decimal balance = 0m,
            Currency currency = Currency.SEK,
            bool active = false
        )
        {
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
            BankAccount bankAccount1 = new BankAccount() { AccountId = 0, AccountNumber = GenerateBankAccountNumber(), AccountName = "Salary account", Balance = 20000, Currency = Currency.USD, Active = true };
            BankAccount bankAccount2 = new BankAccount() { AccountId = 0, AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 15000, Currency = Currency.SEK, Active = false };
            BankAccount bankAccount3 = new BankAccount() { AccountId = 0, AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 45600, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount4 = new BankAccount() { AccountId = 2, AccountNumber = GenerateBankAccountNumber(), AccountName = "Salary account", Balance =30000, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount5 = new BankAccount() { AccountId = 2, AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 50000, Currency = Currency.GBP, Active = true };
            BankAccount bankAccount6 = new BankAccount() { AccountId = 2, AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 5000, Currency = Currency.GBP, Active = true };

            bankAccounts.Add(bankAccount1);
            bankAccounts.Add(bankAccount2);
            bankAccounts.Add(bankAccount3);
            bankAccounts.Add(bankAccount4);
            bankAccounts.Add(bankAccount5);
            bankAccounts.Add(bankAccount6);
        }
        public void Deposit(decimal amount)
        {
            if (bankAccounts.Count < 1)
            {
                Console.WriteLine("No accounts found to deposit money into");
            }
            Console.WriteLine("Enter amount to deposit: ");
            decimal Amount = decimal.Parse(Console.ReadLine());
            if (Amount <= 0)
            {
                Console.WriteLine("Amount cant be less then 1");

            }
            else
            {
                Balance += Amount;
                //Amount += Balance;
                bankAccounts.Add(this);
            }
        }
        public void setBalance(decimal amount) //? 
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

        }
        public void CheckBalance()
        {
            Console.WriteLine($"Account balance: {Balance}.{Currency.SEK}");
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
            return $"AccountID {(AccountId)}, AccountNumber: {AccountNumber}, AccountName: {AccountName}, Balance: {Balance}, Currency: {Currency.SEK} ";
        }
    }
}

