using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public sealed class PostAdmin
    {
        private static PostAdmin instance;
        private static object syncRoot = new object();

        public void UnBlockedBankAccount(BankAccount bankAccount)
        {
            if (bankAccount.status == "blocked")
            {
                bankAccount.status = "unblocked";
                Console.WriteLine("The bank account has been successfully unblocked");
            }
            else Console.WriteLine("The bank account was not blocked");
        }

        private PostAdmin() { }
        public static PostAdmin GetInstance()
        {
            if (instance == null)
                lock (syncRoot)
                {
                    instance = new PostAdmin();
                }
            return instance;
        }
    }
}
