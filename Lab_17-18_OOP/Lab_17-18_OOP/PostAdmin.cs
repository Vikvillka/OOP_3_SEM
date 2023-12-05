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

        public void BlockedBankAccount(BankAccount bankAccount)
        {
            if (bankAccount.status != "blocked")
            {
                bankAccount.status = "blocked";
                Console.WriteLine("The bank account has been successfully blocked");
            }
            else Console.WriteLine("The bank account was blocked");
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












/*Приватный конструктор:
Класс PostAdmin имеет приватный конструктор private PostAdmin(), что означает, 
что он не может быть создан внешними классами. Это гарантирует, что экземпляры класса PostAdmin 
могут быть созданы только внутри самого класса.

Статическое поле экземпляра и объект синхронизации:
В классе PostAdmin объявлены два статических поля: instance
и syncRoot. Поле instance хранит единственный экземпляр класса PostAdmin,
а поле syncRoot используется для синхронизации потоков при создании экземпляра класса.

Метод GetInstance():
Метод GetInstance() является статическим и предоставляет
глобальную точку доступа к единственному экземпляру класса PostAdmin. 
Если экземпляр класса еще не создан (instance == null), выполняется блокировка 
с помощью объекта syncRoot, чтобы гарантировать, что только один поток может создать экземпляр.
Затем в блоке создается новый экземпляр класса PostAdmin и присваивается полю instance. 
В конце метод возвращает этот экземпляр.

*/