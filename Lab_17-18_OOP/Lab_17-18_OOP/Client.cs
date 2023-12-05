using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public class Client : IClient
    {
        public string name { get; set; }

        public string Password { get; set; }

        public Client()
        {

        }
        public Client(string name)
        {
            this.name = name;
        }

        public void depositMoneyInTheBankAccounts(BankAccount bankAccount, double money)
        {
            bankAccount.AddMoney(money);
        }

        public void makePayment(BankAccount bankAccount, double money)
        {
            bankAccount.RemoveMoney(money);
        }
        public void BlockedBankAccount(BankAccount bankAccount)
        {
            bankAccount.Blocked();
        }
    }

    public class ClientManager
    {
        private List<Client> users;

        public ClientManager()
        {
            users = new List<Client>();
        }

        
        public bool Register(string username, string password)
        {
            // Проверяем, что пользователь с таким именем не существует
            if (users.Any(u => u.name.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Пользователь с таким именем уже существует.");
                return false;
            }

            // Создаем нового пользователя и добавляем его в список
            Client newUser = new Client
            {
                name = username,
                Password = password
            };
            users.Add(newUser);

            Console.WriteLine("Регистрация прошла успешно.");
            return true;
        }

        public bool Login(string username, string password)
        {
            // Проверяем, что пользователь существует и введенные данные совпадают
            Client user = users.FirstOrDefault(u =>
                u.name.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user != null)
            {
                Console.WriteLine("Вход выполнен успешно.");
                return true;
            }

            Console.WriteLine("Неверное имя пользователя или пароль.");
            return false;
        }

        public void Logout()
        {
            Console.WriteLine("Выход выполнен успешно.");
        }
    }

}
