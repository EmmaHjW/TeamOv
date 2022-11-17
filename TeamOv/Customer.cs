using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Customer : User
    {
        public Customer(string? userName, string? password, bool active) : base(userName, password, active)
        {
        }
    }
}
