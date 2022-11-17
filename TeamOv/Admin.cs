using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Spectre.Console;


namespace TeamOv
{
    public class Admin : User
    {
        public Admin(string? userName, string? password/*, int userId*/, bool active/*, bool IsAdmin*/) : base(userName, password/*, userId*/, active/*, IsAdmin*/)
        {
        }
        
    }
}
