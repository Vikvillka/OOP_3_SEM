using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    abstract class AbstractFactory
    {
        public abstract CurrencyCard CreateGetCurrency();
        public abstract TypeCard CreateGetType();
    }

    abstract class CurrencyCard
    {
        public abstract void GetCurrency();
    }

    abstract class TypeCard
    {
        public abstract void GetTypeCard();
    }

    class Dollar : CurrencyCard
    {
        public override void GetCurrency()
        {
            Console.WriteLine("Dollar");
        }
    }

    class Euro : CurrencyCard
    {
        public override void GetCurrency()
        {
            Console.WriteLine("Euro");
        }
    }

    class CreditCard : TypeCard
    {
        public override void GetTypeCard()
        {
            Console.WriteLine("Credit card");
        }
    }

    class DebitCard : TypeCard
    {
        public override void GetTypeCard()
        {
            Console.WriteLine("Debit Card");
        }
    }

    class CreditDollarFactory : AbstractFactory
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Dollar();
        }

        public override TypeCard CreateGetType()
        {
            return new CreditCard();
        }
    }

    class DebitDollarFactory : AbstractFactory
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Dollar();
        }

        public override TypeCard CreateGetType()
        {
            return new DebitCard();
        }
    }

    class CreditEuroFactory : AbstractFactory
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Euro();
        }

        public override TypeCard CreateGetType()
        {
            return new CreditCard();
        }
    }

    class DebitEuroFactory : AbstractFactory
    {
        public override CurrencyCard CreateGetCurrency()
        {
            return new Euro();
        }

        public override TypeCard CreateGetType()
        {
            return new DebitCard();
        }
    }
}
