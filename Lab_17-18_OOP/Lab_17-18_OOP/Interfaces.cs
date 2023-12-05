using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public interface ICard
    {
        ICard Clone();
        void ShowCardInfo();
    }

    public interface IClient
    {
        string name { get; set; }

        void depositMoneyInTheBankAccounts(BankAccount bankAccount, double money);
        void makePayment(BankAccount bankAccount, double money);
        void BlockedBankAccount(BankAccount bankAccount);
    }

    public interface IBank
    {
        BankAccount CreateBankAccount(string name);
    }
}
