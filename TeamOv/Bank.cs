﻿using System;
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
        
        public static void RunBank()
        {
            BankAccount bankAccount = new BankAccount();
            Loginservice loginservice= new Loginservice();
            bankAccount.InitiateBankAccount();
            Loginservice.InitiateUsers();
            loginservice.ValidateLogin();
            CustomerMenu.PrintAccountInfo();
            
            
            
            
            
            

        }
        

    }
}
