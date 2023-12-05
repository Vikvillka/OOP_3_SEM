using OOP_Lab17_18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab17_18
{
    using System;

    interface IPaymentService
    {
        void MakePayment(PaymentAccount account, decimal amount);
        void BlockAccount(PaymentAccount account);
        void TopUpAccount(PaymentAccount account, decimal amount);
    }

    interface IAdminService
    {
        void RemoveAccountBlock(PaymentAccount account);
    }

    class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CreditCard[] CreditCards { get; set; }
    }

    class CreditCard
    {
        public string Number { get; set; }
        public string ExpiryDate { get; set; }
        public string Owner { get; set; }
    }

    class PaymentAccount
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
    }

    class PaymentService : IPaymentService
    {
        public void MakePayment(PaymentAccount account, decimal amount)
        {
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
                Console.WriteLine("Payment successful!");
            }
            else
            {
                Console.WriteLine("Insufficient funds in the account.");
            }
        }

        public void BlockAccount(PaymentAccount account)
        {
            Console.WriteLine("Account blocked.");
        }

        public void TopUpAccount(PaymentAccount account, decimal amount)
        {
            account.Balance += amount;
            Console.WriteLine("Account topped up successfully.");
        }
    }

    class AdminService : IAdminService
    {
        public void RemoveAccountBlock(PaymentAccount account)
        {
            Console.WriteLine("Account unblocked.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание клиента
            Client client = new Client
            {
                Id = "123",
                Name = "John Doe",
                CreditCards = new CreditCard[]
                {
                new CreditCard { Number = "1111-2222-3333-4444", ExpiryDate = "12/23", Owner = "John Doe" },
                new CreditCard { Number = "5555-6666-7777-8888", ExpiryDate = "09/24", Owner = "John Doe" }
                }
            };

            // Создание счета
            PaymentAccount account = new PaymentAccount
            {
                Id = "789",
                Balance = 1000
            };

            // Использование сервиса платежей
            IPaymentService paymentService = new PaymentService();
            paymentService.MakePayment(account, 500);
            paymentService.BlockAccount(account);
            paymentService.TopUpAccount(account, 200);

            // Использование сервиса администратора
            IAdminService adminService = new AdminService();
            adminService.RemoveAccountBlock(account);

            Console.ReadLine();
        }
    }
}