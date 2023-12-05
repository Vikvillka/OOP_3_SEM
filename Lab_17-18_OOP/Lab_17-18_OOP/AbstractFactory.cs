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


























/*Абстрактная фабрика (AbstractFactory):
Это абстрактный класс, который определяет методы для создания семейства связанных объектов. В вашем случае, 
AbstractFactory содержит абстрактные методы CreateGetCurrency() и CreateGetType(), которые возвращают объекты типа CurrencyCard и TypeCard соответственно.

Конкретные фабрики (CreditDollarFactory, DebitDollarFactory, CreditEuroFactory, DebitEuroFactory):
Каждая из этих классов является конкретной реализацией абстрактной фабрики (AbstractFactory). Конкретные фабрики предоставляют
реализацию методов CreateGetCurrency() и CreateGetType(), которые создают конкретные объекты типов CurrencyCard и TypeCard.

Абстрактные продукты (CurrencyCard, TypeCard):
Это абстрактные классы, которые определяют интерфейсы для конкретных продуктов. В вашем коде CurrencyCard и TypeCard являются
абстрактными классами с абстрактными методами GetCurrency() и GetTypeCard() соответственно.

Конкретные продукты (Dollar, Euro, CreditCard, DebitCard):
Каждый из этих классов представляет конкретную реализацию абстрактных продуктов (CurrencyCard и TypeCard). Классы Dollar,
Euro, CreditCard и DebitCard переопределяют методы GetCurrency() и GetTypeCard() с соответствующей реализацией.*/