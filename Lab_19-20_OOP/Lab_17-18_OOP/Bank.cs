using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public class Bank : IBank
    {
        private static int idCount = -1;

        public BankAccount CreateBankAccount(string name)
        {
            idCount++;
            return (new BankAccount(idCount.ToString(), name));
        }
    }
}
