using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class Transfer
    {
        //public bool TransferFunds(int fromAccountId, int toAccountId, decimal transferAmount)
        //{
        //    if (transferAmount <= 0)
        //    {
        //        throw new ApplicationException("transfer amount must be positive");
        //    }
        //    else if (transferAmount == 0)
        //    {
        //        throw new ApplicationException("invalid transfer amount");
        //    }

        //    BankAccount fromAccount = GetAccount(fromAccountId);
        //    BankAccount toAccount = GetAccount(toAccountId);

        //    if (fromAccount.balance < transferAmount)
        //    {
        //        throw new ApplicationException("insufficient funds");
        //    }

        //    fromAccount.Transfer(-1 * transferAmount, toAccountId);
        //    toAccount.Transfer(transferAmount, fromAccountId);

        //    return true;
        //}
    }
}
