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
        public static void RunBank()
        {
            Console.WriteLine("Enter username: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            LogIn.ValidateLogin(name, password);

            
        }

    }
}
