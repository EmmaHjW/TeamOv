using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Spectre.Console;
using System.Numerics;

namespace TeamOv
{
    public class Bank
    {
        public static void RunBank()
        {
            BankAccount bankAccount = new BankAccount();
            Loginservice loginservice = new Loginservice();
            bankAccount.InitiateBankAccount();
            User.InitiateUsers();
            loginservice.ValidateLogin();
        }
}   }
