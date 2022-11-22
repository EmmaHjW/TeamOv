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
        
        public Customer(string? userName, string? password, bool active) 
            : base(userName, password, active)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
        //public List<BankAccount> bankAccounts
        //{
        //    get { return bankAccounts; }
        //    set { bankAccounts = value; }
        //}
    }
}
