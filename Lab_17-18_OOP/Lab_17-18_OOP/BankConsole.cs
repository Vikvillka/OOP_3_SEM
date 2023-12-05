using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public interface IBankConsole
    {
        void RunBankConsole();
    }

    public class BankConsole : IBankConsole
    {
        private string clientname;
        private ClientManager clientManager;
        private IBank bank;
        private IClient client;
       

        public BankConsole(IBank bank, IClient client)
        {
            this.bank = bank;
            this.client = client;
            //this.admin = admin;
            clientManager = new ClientManager();
        }

        public void RunBankConsole()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Вход");
                Console.WriteLine("3. Выход");
                Console.WriteLine("Выберите действие:");

                string input = Console.ReadLine();

                BankAccount bankAccount_01 = null;
                switch (input)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        if (true)
                        {
                            bool isRunn = true;
                            while (isRunn)
                            {
                                Console.WriteLine("1. Создать счет ");
                                Console.WriteLine("2. Создать кредитную карту (Dollar");
                                Console.WriteLine("3. Cоздать кредитную карту (Euro)");
                                Console.WriteLine("4. Заблокировать счет");
                                Console.WriteLine("5. Вывести информацию о счете");
                                Console.WriteLine("6. Пополнить счет");
                                Console.WriteLine("7. Совершить платеж");
                                Console.WriteLine("8. Выход");
                                Console.WriteLine();

                                string inputt1 = Console.ReadLine();

                                switch (inputt1)
                                {
                                    case "1":
                                        bankAccount_01 = bank.CreateBankAccount(clientname);
                                        break;
                                    case "2":
                                        if (bankAccount_01 != null)
                                        {
                                            bankAccount_01.CreateCreditDollarCard(clientname);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Счет еще не создан! Создайте счет");
                                        }
                                        break;
                                    case "3":
                                        if (bankAccount_01 != null)
                                        {
                                            bankAccount_01.CreateCreditEuroCard(clientname);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Счет еще не создан! Создайте счет");
                                        }
                                        break;
                                    case "4":
                                        client.BlockedBankAccount(bankAccount_01);
                                        break;
                                    case "5":
                                        bankAccount_01.WriteInfoCard();
                                        break;
                                    case "6":
                                        Console.WriteLine("Введите сумму поплнения:");
                                        string amountStr = Console.ReadLine();
                                        double amount;
                                        if (double.TryParse(amountStr, out amount))
                                        {
                                            client.depositMoneyInTheBankAccounts(bankAccount_01, amount);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверная сумма");
                                        }
                                        Console.WriteLine(bankAccount_01.ToString());
                                        break;
                                    case "7":
                                        Console.WriteLine("Введите сумму оплаты:");
                                        amountStr = Console.ReadLine();
                                        if (double.TryParse(amountStr, out amount))
                                        {
                                            client.makePayment(bankAccount_01, amount);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверная сумма");
                                        }
                                        break;
                                        Console.WriteLine(bankAccount_01.ToString());
                                    case "8":
                                        isRunn = false;
                                        break;
                                    default:
                                        Console.WriteLine("Неверное зачене!");
                                        break;
                                }

                            }
                        }
                        

                       
                        break;
                    case "3":
                        Logout();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверное значение!");
                        break;
                }


                Console.WriteLine();
            }
        }

        private void Register()
        {
            Console.WriteLine("Введите имя пользователя:");
            clientname = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            clientManager.Register(clientname, password);
        }

        private void Login()
        {
            bool loggedIn = false;

            while (!loggedIn)
            {
                Console.WriteLine("Введите имя пользователя:");
                string username = Console.ReadLine();

                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();

                loggedIn = clientManager.Login(username, password);

                if (!loggedIn)
                {
                    Console.WriteLine("Неверное имя пользователя или пароль. Попробуйте снова.");
                }
            }

        }

        private void Logout()
        {
            clientManager.Logout();
        }
    }

}
