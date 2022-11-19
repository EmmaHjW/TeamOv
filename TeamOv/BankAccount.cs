﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class BankAccount
    {
        public static List<BankAccount> bankAccounts = new();
        private decimal balance;

        //public List<BankAccount> BankAccounts
        //{
        //    get { return bankAccounts; }
        //    set { bankAccounts = value; }
        //}
        // private static int accountIdPool;
        public int AccountId { get; set; }
        public string AccountNumber { get; init; }
        public decimal Amount { get; set; }
        public decimal Balance { get => Balance; set => Balance = value; }
        public bool Active { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountName { get; set; }
        public Currency Currency { get; set; }


        public BankAccount(
            //string accountId,
            string accountNumber,
            //decimal interestRate,
            string accountName,
            decimal balance,
            Currency currency = Currency.SEK,
            bool active = false
        )
        {
            // this.AccountId = accountIdPool++;
            this.AccountNumber = CustomerMenu.GenerateBankAccountNumber(); ;
            this.AccountName = accountName;
            this.Balance = Balance;
            this.Amount = Amount;
            //InterestRate = interestRate;
            this.Active = active;
            this.Currency = currency;
        }
        //public static void InitiateBankAccount() //Adds users to userList at run
        //{
        //    bankAccounts.Add(new BankAccount("C", "1", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("C", "1", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("C", "1", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("O", "2", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("O", "2", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("O", "2", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("E", "3", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("E", "3", 20000, Currency.SEK, true));
        //    bankAccounts.Add(new BankAccount("E", "3", 20000, Currency.SEK, true));
        //}
        public void Deposit(decimal Balance)
        {
            if (bankAccounts.Count < 1)
            {
                Console.WriteLine("No accounts found to deposit money into");
            }
            

            Amount += Balance;
        }
        public void setBalance(decimal Balance)
        {
            Amount += Balance;
        }

        public void Withdraw(decimal balance)
        {
            Amount -= balance;

        }
        public override string ToString()
        {
            return $"AccountID {(AccountId)}, AccountNumber: {AccountNumber}, AccountName: {AccountName}, Balance: {Balance}, Currency: {Currency.SEK} ";
        }
        public void CheckBalance()
        {
            Console.WriteLine($"Account balance: {Balance}.{Currency.SEK}");
        }

    }
}

