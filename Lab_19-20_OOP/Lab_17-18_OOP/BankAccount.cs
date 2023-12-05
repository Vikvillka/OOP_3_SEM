using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public abstract class WriteMoneyInBankAccount
    {
        public abstract void WriteMoney();
    }

    public class BankAccount : WriteMoneyInBankAccount
    {
        public string id;
        internal double amountOfMoney;
        public string name;
        BankObservable bankObservable;

        public static int cardCount = 0;
        public string status;

        List<Card> cards = new List<Card>();

        public BankAccount()
        {

        }
        public BankAccount(string id, string name)
        {
            this.id = id;
            amountOfMoney = 0;
            status = "unblocked";
            this.name = name;
        }
        public BankAccount(string id, string name, double money)
        {
            this.id = id;
            this.amountOfMoney = money;
            amountOfMoney = money;
            status = "unblocked";
            this.name = name;
        }

        public BankAccount(string id, string name, double money, BankObservable bankObservable)
        {
            this.id = id;
            this.amountOfMoney = money;
            amountOfMoney = money;
            status = "unblocked";
            this.name = name;
            this.bankObservable = bankObservable;
        }

        public override void WriteMoney()
        {
            Console.WriteLine("= = = = = = = = = = =");
            Console.WriteLine($"Money = {this.amountOfMoney}");
            Console.WriteLine("= = = = = = = = = = =");
        }

        public void AddMoney(double money)
        {
            if (status != "blocked")
            {
                if (bankObservable != null) bankObservable.NotifyObservers("Ураа пополнение денег!!!");
                this.amountOfMoney += money;
            }
            else
            {
                Console.WriteLine("Bank account blocked");
                if (bankObservable != null) bankObservable.NotifyObservers("О нееет счет заблокирован!!!");
            }
        }
        
        public void RemoveMoney(double money)
        {
            if (status != "blocked")
            {
                if (this.amountOfMoney >= money)
                {
                    this.amountOfMoney -= money;
                }
                else Console.WriteLine("Insufficient funds");
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void Blocked()
        {
            if (status == "unblocked")
            {
                status = "blocked";
                Console.WriteLine("The bank account has been successfully blocked");
            }
            else Console.WriteLine("The bank account was not unblocked");
        }
        public void UnBlocked()
        {
            if (status == "blocked")
            {
                status = "unblocked";
                Console.WriteLine("The bank account has been successfully unblocked");
            }
            else Console.WriteLine("The bank account was not unblocked");
        }

        public override string ToString()
        {
            return "Name: " + this.name + " # Id: " + this.id + " # Money:" + this.amountOfMoney;
        }

        public void CreateCreditDollarCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new CreditDollarFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void CreateCreditEuroCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new CreditEuroFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void CreateDebitEuroCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new DebitEuroFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void CreateDebitDollarCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new DebitDollarFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void WriteInfoCard()
        {
            int i = 1;
            foreach (Card card in cards)
            {
                Console.WriteLine($"============ Card {i} ==============");
                card.GetCarrencyCard();
                card.GetTypeCard();
            }
        }

        public BankAccount SaveState()
        {
            Console.WriteLine($"Saving an account...\n Money = {amountOfMoney}");
            return new BankAccount(id, name, amountOfMoney, bankObservable);
        }
        public void RestoreState(BankAccount bankAccount)
        {
            this.id = bankAccount.id;
            this.name = bankAccount.name;
            this.amountOfMoney = bankAccount.amountOfMoney;
            this.bankObservable = bankAccount.bankObservable;
            Console.WriteLine($"Account Recovery...\n Money = {amountOfMoney}");
        }
    }
    public abstract class DecoratorBankAccount : BankAccount
    {
        BankAccount bankAccount;

        public DecoratorBankAccount(BankAccount bankAccount) : base(bankAccount.id, bankAccount.name, bankAccount.amountOfMoney / 3.2)
        {
            this.bankAccount = bankAccount;
        }
    }

    public class DollarBankAccount : DecoratorBankAccount
    {
        public DollarBankAccount(BankAccount bankAccount) : base(bankAccount)
        {

        }
    }

    class BankHistory
    {
        public Stack<BankAccount> History { get; private set; }
        public BankHistory()
        {
            History = new Stack<BankAccount>();
        }

        public void Save(BankAccount bankAccount)
        {
            History.Push(bankAccount);
        }
    }
}
