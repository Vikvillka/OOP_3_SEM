using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public interface CommandBank
    {
        void Blocked();
        void UnBlocked();
    }

    public class BankAccountOnCommandBank : CommandBank
    {
        BankAccount bankAccount;

        public BankAccountOnCommandBank(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void Blocked()
        {
            bankAccount.Blocked();
        }
        public void UnBlocked()
        {
            bankAccount.UnBlocked();
        }
    }

    public class ComputerClient // клиентский класс, который является инициатором команд и выполняет их по запросу
    {
        CommandBank commandBank;

        public void SetCommand(CommandBank commandBank)
        {
            this.commandBank = commandBank;
        }

        public void PressBlock()
        {
            if (commandBank != null)
                commandBank.Blocked();
        }
        public void PressUnBlock()
        {
            if (commandBank != null)
                commandBank.UnBlocked();
        }
    }

}









/*CommandBank - интерфейс, который представляет команду для работы с банковским счетом. Он объявляет два метода: Blocked() и UnBlocked(), которые будут реализованы конкретными командами.
BankAccountOnCommandBank - конкретная команда, реализующая интерфейс CommandBank. В конструкторе команде передается объект bankAccount, с которым будет выполняться операция.
Метод Blocked() вызывает метод Blocked() на объекте bankAccount.
Метод UnBlocked() вызывает метод UnBlocked() на объекте bankAccount.
ComputerClient - клиентский класс, который является инициатором команд и выполняет их по запросу.
Метод SetCommand() устанавливает команду commandBank, которая будет выполняться при нажатии на кнопку.
Метод PressBlock() вызывает метод Blocked() на установленной команде commandBank, если команда не является нулевой.
Метод PressUnBlock() вызывает метод UnBlocked() на установленной команде commandBank, если команда не является нулевой.*/