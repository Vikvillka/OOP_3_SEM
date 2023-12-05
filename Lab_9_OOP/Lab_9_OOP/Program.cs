using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Concurrent;

namespace Lab_9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {

            Books<string, string> books = new Books<string, string>();

            books.Add("Гордость и предубеждение", "Джейн Остен");
            books.Add("Великий Гэтсби", "Ф. С. Фицджеральд");
            books.Add("Маленькие женщины", "Луиза Мэй Олкотт");
            books.Add("1984", "Джордж Оруэлл");
            books.Add("Убить пересмешника", "Харпер Ли");

            books.Print();

            Console.WriteLine("\nСписок всех книг: ");
            foreach (string i in books.Keys)
                Console.WriteLine(i);

            Console.WriteLine("\nСписок всех авторов: ");
            foreach (string i in books.Values)
                Console.WriteLine(i);

            int bookCount = books.Count;
            Console.WriteLine("\nВсего книг: "+ bookCount );

            books.Remove("1984");
            Console.WriteLine("\nПосле удаления: ");
            foreach (string i in books.Keys)
                Console.WriteLine(i);

            var search = "Маленькие женщины";
            if (books.ContainsKey(search))
            {
                Console.WriteLine($"\nКнига '{search}' найдена в коллекции.");
            }
            else
            {
                Console.WriteLine($"\nКнига '{search}' не найдена в коллекции.");
            }

            if (books.TryGetValue(search, out string value))
            {
                Console.WriteLine($"\nКнигу '{search}' написал {value}.");
            }
            else
            {
                Console.WriteLine($"\nКнига '{search}' не найдена в коллекции.");
            }

            Books<int, string> forDelete = new Books<int, string>();

            forDelete.Add(1, "Джейн Остен");
            forDelete.Add(2, "Джейн Остен");
            forDelete.Add(3, "Джейн Остен");
            forDelete.Add(4, "Джейн Остен");

            forDelete.RemoveRange(3, 1);
            Console.WriteLine("\nПосле удаления n книг:");
            forDelete.Print();

            // Вторая коллекция
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var pair in books)
            {
                dict.Add(pair.Key, pair.Value);
            } 

            Console.WriteLine("\nПример вывода 2 коллекции:");
            foreach (string i in dict.Values)
                Console.WriteLine(i);
            
            if (dict.ContainsValue("Джейн Остен"))
                Console.WriteLine("\nCодержит 'Джейн Остен'");
            else Console.WriteLine("\nНе содержит");

            //Создайте объект наблюдаемой коллекции ObservableCollection<T>.
            ObservableCollection<Books<string, string>> MyColletion = new ObservableCollection<Books<string, string>>();

            MyColletion.CollectionChanged += MyCollection_onChange;
            MyColletion.Add(books);
            MyColletion.RemoveAt(0);

        }
        private static void MyCollection_onChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("\nДобавлен элемент в коллекцию MyCollection");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("\nУдалён элемент в коллекции MyCollection");
                    break;
            }
        }
    }
}
