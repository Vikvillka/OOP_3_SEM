using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    abstract class CardBuilder
    {
        public Card Card { get; private set; }
        public void CreateCard()
        {
            Card = new Card();
        }
        public abstract void SetCurrency();
        public abstract void SetType();
    }
    class Cardener
    {
        public Card CreateCard(CardBuilder cardBuilder)
        {
            cardBuilder.CreateCard();
            cardBuilder.SetCurrency();
            cardBuilder.SetType();
            return cardBuilder.Card;
        }
    }
    class CreditDollarBuilder : CardBuilder
    {
        public override void SetCurrency()
        {
            this.Card.currency = new Dollar();
        }
        public override void SetType()
        {
            this.Card.type = new CreditCard();
        }
    }

}
