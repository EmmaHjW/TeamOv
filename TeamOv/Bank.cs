using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Bank
    {
        public static List<BankAccount> bankAccounts= new();
        public static void RunBank()
        {
            Loginservice.InitiateUsers();
            Loginservice.ValidateLogin();
        }
        public List<BankAccount> BankAccounts
        {
            get { return bankAccounts; }
            set { bankAccounts = value; }
        }

    }
}
