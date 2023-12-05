using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18_OOP
{
    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(string message);
    }

    public interface IObserver
    {
        void Update(string message);
    }

    public class BankObservable : IObservable
    {
        private List<IObserver> observers;
        public BankObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
                observer.Update(message);
        }
    }
}














/*В данном случае, интерфейс IObservable определяет методы для управления списком наблюдателей 
 * и уведомления их о изменениях. Интерфейс IObserver определяет метод Update, который наблюдатели 
 * должны реализовать для обработки уведомлений.

Класс BankObservable реализует интерфейс IObservable и 
предоставляет конкретную реализацию методов AddObserver, RemoveObserver и NotifyObservers.
В конструкторе класса создается список observers, который будет хранить всех наблюдателей.

Метод AddObserver добавляет наблюдателя в список observers, метод RemoveObserver
удаляет наблюдателя из списка, а метод NotifyObservers проходит по списку и вызывает 
метод Update для каждого наблюдателя, передавая ему сообщение об изменении состояния.

Когда объект BankObservable изменяет свое состояние и хочет уведомить всех 
наблюдателей, он вызывает метод NotifyObservers, передавая сообщение об изменении. 
Каждый наблюдатель, добавленный в observers, будет получать это уведомление и выполнять свою специфичную логику в методе Update.

Таким образом, паттерн "Наблюдатель" позволяет реализовать слабую связь
между наблюдаемым объектом и наблюдателями, так что изменения в наблюдаемом 
объекте автоматически передаются всем заинтересованным наблюдателям без необходимости явно связывать их.*/