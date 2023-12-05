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




























/*Абстрактный класс CardBuilder:
Этот класс определяет общий интерфейс для всех конкретных строителей карточек. Он содержит метод CreateCard(),
который создает новый объект типа Card, и абстрактные методы SetCurrency() и SetType(),
которые должны быть реализованы в конкретных подклассах.

Класс Cardener:
Этот класс представляет директора, который управляет процессом создания карточки. Он принимает объект типа CardBuilder
в качестве параметра в своем методе CreateCard(). Сначала вызывается метод CreateCard() у переданного строителя, чтобы
создать новый объект Card. Затем вызываются методы SetCurrency() и SetType() у строителя для установки валюты и типа карточки соответственно. В конце метод возвращает созданную карточку.

Конкретный строитель CreditDollarBuilder:
Этот класс наследует абстрактный класс CardBuilder и реализует абстрактные методы SetCurrency() и SetType(). В методе
SetCurrency() устанавливается валюта карточки как Dollar, а в методе SetType() устанавливается тип карточки как CreditCard.*/