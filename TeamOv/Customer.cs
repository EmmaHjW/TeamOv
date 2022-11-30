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

        public Customer(string? userName, string? password, string customerName, bool active) : base(userName, password, customerName, active)
        {
        }

        //public Customer(string username, string password, string customerName, bool active)
        //{
        //    this.username = username;
        //    this.password = password;
        //    this.CustomerName= customerName;
        //    this.Active = active;
        //}

        //public override string ToString()
        //{
        //    return $"userid: {UserId}, username: {UserName}, password: {Password}, Name: {CustomerName} active: {Active}, isAdmin: {IsAdmin}";
        //}


    }
}
