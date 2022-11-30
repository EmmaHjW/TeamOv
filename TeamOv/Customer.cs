using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Customer : User
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();
        public Customer(List<BankAccount> bankAccounts)
        {
            this.bankAccounts = bankAccounts;
        }

        public Customer(string username, string password, bool active)
        {
            this.username = username;
            this.password = password;
            Active = active;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
