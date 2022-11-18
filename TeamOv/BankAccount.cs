using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class BankAccount
    {
        public string AccountNumber { get; init; }
        public decimal Money { get; set; }
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
            decimal money = 0m,
            Currency currency = Currency.SEK
        )
        {
            AccountNumber = accountNumber;
            Money = money;
            //InterestRate = interestRate;
            AccountName = accountName;
            Active = active;
            Currency = currency;
            //Owner = owner;
        }

        public void Deposit(decimal amount)
        {
            Money += amount;
        }

        public void Withdraw(decimal amount)
        {
            Money -= amount;
        }

        public override string ToString()
        {
            return $"{nameof(AccountNumber)}: {AccountNumber},{nameof(Money)}: {Money}, {nameof(Active)}: {Active}, {nameof(InterestRate)}: {InterestRate}, {nameof(AccountName)}: {AccountName}, {nameof(Currency)}: {Currency}, {nameof(Owner.UserId)}: {Owner.UserId}";
        }
    }
}

