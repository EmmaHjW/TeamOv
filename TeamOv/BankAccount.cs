using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class BankAccount
    {
        public static List<BankAccount> bankAccounts = new();
        public List<BankAccount> BankAccounts
        {
            get { return bankAccounts; }
            set { bankAccounts = value; }
        }
        public int AccountId { get; set; }
        public string AccountNumber { get; init; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountName { get; set; }
        public Currency Currency { get; set; }
        

        public BankAccount(
            int accountId,
            string accountNumber,
            //decimal interestRate,
            string accountName,
            bool active = false,
            decimal amount = 0,
            Currency currency = Currency.SEK
            
        )
        {
            AccountId = accountId;
            AccountNumber = accountNumber;
            Amount = amount;
            //InterestRate = interestRate;
            AccountName = accountName;
            Active = active;
            Currency = currency;
            
            
        }
        public static void InitiateBankAccount() //Adds users to userList at run
        {
            bankAccounts.Add(new BankAccount(0, "1", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(0, "2", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(0, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(1, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(1, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(1, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(2, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(2, "3", "Salary", true, 0, Currency.SEK));
            bankAccounts.Add(new BankAccount(2, "3", "Salary", true, 0, Currency.SEK));
        }

        public void Deposit(decimal balance)
        {
            Amount += balance;
        }

        public void Withdraw(decimal balance)
        {
            Amount -= balance;
        }

        public override string ToString()
        {
            return $"{nameof(AccountId)}: {AccountId},{nameof(AccountNumber)}: {AccountNumber},{nameof(Amount)}: {Amount}, {nameof(Active)}: {Active}, {nameof(InterestRate)}: {InterestRate}, {nameof(AccountName)}: {AccountName}, {nameof(Currency)}: {Currency}";
        }
    }
}

