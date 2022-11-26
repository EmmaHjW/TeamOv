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
        
        public string Currency { get; set; }
        public string AccountType { get; set; }
        public string? Name { get; }

        public BankAccount() //constructor
        {

        }
        public BankAccount(string accountNumber, string? accountname, string owner, int balance, string currency, bool active)
        {
            AccountId= accountIdPool++;
            Owner = owner;
            AccountNumber = accountNumber;
            AccountName = accountname;
            Balance = balance;
            Currency = currency;
            Active = active;
        }
        public void InitiateBankAccount() //Adds account to users at program run
        {
            BankAccount bankAccount1 = new BankAccount() { AccountNumber = GenerateBankAccountNumber(), AccountId = accountIdPool++, Owner = "Oskar", AccountName = "Salary account", Balance = 20000, Currency = "SEK", Active = true };
            BankAccount bankAccount2 = new BankAccount() { AccountId = accountIdPool++, Owner = "Oskar",  AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 150, Currency = "USD", Active = true };
            BankAccount bankAccount3 = new BankAccount() { AccountId = accountIdPool++, Owner = "Oskar", AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 456, Currency = "EUR", Active = true };
            BankAccount bankAccount4 = new BankAccount() { AccountId = accountIdPool++, Owner = "Emma", AccountNumber = GenerateBankAccountNumber(), AccountName = "Salary account", Balance =30000, Currency = "SEK", Active = true };
            BankAccount bankAccount5 = new BankAccount() { AccountId = accountIdPool++, Owner = "Emma", AccountNumber = GenerateBankAccountNumber(), AccountName = "Saving account", Balance = 5000, Currency = "USD", Active = true };
            BankAccount bankAccount6 = new BankAccount() { AccountId = accountIdPool++, Owner = "Emma", AccountNumber = GenerateBankAccountNumber(), AccountName = "Fund account", Balance = 500, Currency = "EUR", Active = true };

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
            return $"AccountID {AccountId}, AccountNumber: {AccountNumber}, " +
                $"AccountName: {AccountName}, Balance: {Balance.ToString("N" + 2)} {Currency} ";
        }
    }
}

