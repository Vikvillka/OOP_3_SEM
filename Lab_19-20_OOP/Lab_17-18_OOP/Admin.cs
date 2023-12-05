using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public interface IAdmin
    {
        void UnBlock(BankAccount bankAccount);
    }
    
    
    public class Admin : IAdmin, IObserver
    {
        public PostAdmin postAdmin;
        
        public Admin()
        {
            postAdmin = PostAdmin.GetInstance();
        }

        public void UnBlock(BankAccount bankAccount)
        {
            postAdmin.UnBlockedBankAccount(bankAccount);
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class ComputerChanel
    {
        public void UnblockBankAccount(IAdmin admin, BankAccount bankAccount)
        {
            admin.UnBlock(bankAccount);
        }
    }

    public class ClientToAdminAdapter : IAdmin
    {
        Client client;
        public ClientToAdminAdapter(Client client)
        {
            this.client = client;
        }

        public void UnBlock(BankAccount bankAccount)
        {
            client.UnBlockedBankAccount(bankAccount);
        }
    }
}




















/* В предоставленном коде показан пример адаптера ClientToAdminAdapter, который адаптирует интерфейс Client к интерфейсу IAdmin.
 * Адаптер позволяет объекту класса Client использовать методы интерфейса IAdmin.

В данном примере IAdmin представляет интерфейс, который должен быть адаптирован, и включает метод UnBlock(BankAccount bankAccount).
Admin реализует интерфейс IAdmin и метод Pdate(string message) интерфейса IObserver.

ComputerChanel представляет класс, который имеет метод UnblockBankAccount, принимающий объект типа IAdmin.

ClientToAdminAdapter является адаптером, реализующим интерфейс IAdmin и принимающим объект типа Client в конструкторе. В методе UnBlock адаптер вызывает соответствующий метод UnBlockedBankAccount в объекте Client.

 
 В данном случае, ComputerChanel выступает в качестве посредника между клиентом и администратором. Клиент или другие компоненты могут
использовать ComputerChanel для инициирования разблокировки 
банковского счета, предоставляя объект, реализующий интерфейс IAdmin. ComputerChanel передаст
этот объект администратору, который выполнит соответствующие действия для разблокировки указанного банковского счета.*/
