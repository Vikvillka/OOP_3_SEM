using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Client client = new Client("Ded Moroz");
            Admin admin = new Admin();
            BankAccount bankAccount_01 = bank.CreateBankAccount(client.name);
            //AbstractFabrik
            bankAccount_01.CreateCreditDollarCard(client.name);
            bankAccount_01.CreateCreditEuroCard(client.name);
            bankAccount_01.CreateDebitDollarCard(client.name);
            bankAccount_01.CreateDebitEuroCard(client.name);

            bankAccount_01.WriteInfoCard();

            client.depositMoneyInTheBankAccounts(bankAccount_01, 100);
            Console.WriteLine(bankAccount_01.ToString());

            //client.BlockedBankAccount(bankAccount_01);
            client.makePayment(bankAccount_01, 10);
            Console.WriteLine(bankAccount_01.ToString());

            Console.WriteLine("--------------------------------------");
            //Prototype
            ICard card_01 = new Card(new CreditDollarFactory(), "Card1");
            ICard card_02 = card_01.Clone();

            card_02.ShowCardInfo();

            //Builder

            Cardener carder = new Cardener();

            CardBuilder builder = new CreditDollarBuilder();

            Console.WriteLine("--------------------------------------");
            Card card_03 = carder.CreateCard(builder);
            card_03.ShowCardInfo();


            //Decorator
            BankAccount bankAccount = new BankAccount();
            bankAccount.AddMoney(1000); 
            bankAccount.WriteMoney(); 

            DollarBankAccount dollarBankAccount = new DollarBankAccount(bankAccount);
            dollarBankAccount.WriteMoney();

            //Adapter
            client.BlockedBankAccount(bankAccount_01);

            ComputerChanel computerChanel = new ComputerChanel();
            computerChanel.UnblockBankAccount(admin, bankAccount); 

            ClientToAdminAdapter clientToAdminAdapter = new ClientToAdminAdapter(client);

            computerChanel.UnblockBankAccount(clientToAdminAdapter, bankAccount_01);

            //Command
            Console.WriteLine("--------------------------------------");

            ComputerClient computerClient = new ComputerClient();
            BankAccountOnCommandBank commandBank = new BankAccountOnCommandBank(bankAccount_01);
            computerClient.SetCommand(commandBank);
            computerClient.PressBlock();
            computerClient.PressUnBlock();

            //Observer
            Console.WriteLine("--------------------------------------");

            BankObservable bankObservable = new BankObservable();
            BankAccount bankAccount_02 = new BankAccount("12", "Ashot", 1000, bankObservable);
            bankObservable.AddObserver(admin);

            bankAccount_02.AddMoney(100);

            //Memento
            Console.WriteLine("--------------------------------------");

            BankHistory bankHistory = new BankHistory();
            Console.WriteLine(bankAccount_02.ToString());

            Console.WriteLine();
            bankHistory.Save(bankAccount_02.SaveState());
            bankAccount_02.AddMoney(1000000);
            Console.WriteLine(bankAccount_02.ToString());
            Console.WriteLine();

            bankAccount_02.RestoreState(bankHistory.History.Pop());
            Console.WriteLine(bankAccount_02.ToString());

            /*IBank bank = new Bank();
            IClient client = new Client();
            IBankConsole ban = new BankConsole(bank, client);


            BankAccount bankAccount_01 = new BankAccount();
            ban.RunBankConsole();*/
        }

    }
}
