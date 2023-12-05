using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    internal class Card : ICard
    {
        public CurrencyCard currency;
        public TypeCard type;
        string name;

        public Card()
        {
        }
        public Card(AbstractFactory abstractFactoryCard, string name)
        {
            currency = abstractFactoryCard.CreateGetCurrency();
            type = abstractFactoryCard.CreateGetType();
            this.name = name;
        }
        private Card(CurrencyCard currency, TypeCard type)
        {
            this.currency = currency;
            this.type = type;
        }

        public void GetTypeCard()
        {
            type.GetTypeCard();
        }

        public void GetCarrencyCard()
        {
            currency.GetCurrency();
        }

        public ICard Clone()
        {
            return new Card(this.currency, this.type);
        }

        public void ShowCardInfo()
        {
            this.GetCarrencyCard();
            this.GetTypeCard();
        }
    }
}
