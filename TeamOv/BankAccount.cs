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
        public string AccountNumber { get; init; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountName { get; set; }
        public Currency Currency { get; set; }
        public Customer Owner { get; set; } // TODO should it be possible to change owner to correct an error or to switch other owner?

        public BankAccount(
            string accountNumber,
            //decimal interestRate,
            string accountName,
            //Customer owner,
            bool active = false,
            decimal amount = 0,
            Currency currency = Currency.SEK
        )
        {
            AccountNumber = accountNumber;
            Amount = amount;
            //InterestRate = interestRate;
            AccountName = accountName;
            Active = active;
            Currency = currency;
            //Owner = owner;
        }
        public static void InitiateUsers() //Adds users to userList at run
        {
            bankAccounts.Add(new BankAccount("1", "Salary", true, 20000, Currency.SEK));
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
            return $"{nameof(AccountNumber)}: {AccountNumber},{nameof(Amount)}: {Amount}, {nameof(Active)}: {Active}, {nameof(InterestRate)}: {InterestRate}, {nameof(AccountName)}: {AccountName}, {nameof(Currency)}: {Currency}, {nameof(Owner.UserId)}: {Owner.UserId}";
        }
    }
}

