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
            Client client = new Client("Viktoriya");
            BankAccount bankAccount_01 = bank.CreateBankAccount(client.name);
            Admin admin = new Admin();

            //AbstractFabrik
            bankAccount_01.CreateCreditDollarCard(client.name);
            bankAccount_01.CreateCreditEuroCard(client.name);
            
            client.BlockedBankAccount(bankAccount_01);
            admin.postAdmin.UnBlockedBankAccount(bankAccount_01);
            
            bankAccount_01.WriteInfoCard();
            Console.WriteLine();

            client.depositMoneyInTheBankAccounts(bankAccount_01, 100);
            Console.WriteLine(bankAccount_01.ToString());
            Console.WriteLine();

            client.makePayment(bankAccount_01, 10);
            Console.WriteLine(bankAccount_01.ToString());
            Console.WriteLine();
            
            //Prototype
            ICard card_01 = new Card(new CreditEuroFactory(), "Card1");
            ICard card_02 = card_01.Clone();

            card_02.ShowCardInfo();

            //Builder
            Cardener carder = new Cardener();

            CardBuilder builder = new CreditDollarBuilder();

            Console.WriteLine("--------------------------------------");
            Card card_03 = carder.CreateCard(builder);
            card_03.ShowCardInfo();


           /* IBank bank = new Bank();
            IClient client = new Client();
            IBankConsole ban = new BankConsole(bank, client);


            BankAccount bankAccount_01 = new BankAccount();
            ban.RunBankConsole();*/
        }

    }
}
