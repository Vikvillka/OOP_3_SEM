using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GoodStack<int> intStack = new GoodStack<int>();
                intStack.Push(3);
                intStack.Push(4);
                foreach (int i in intStack)
                {
                    Console.WriteLine(i);
                }
                //intStack.Pop();

                //GoodStack<Point> PStack = new GoodStack<Point>();
            }
            catch (InsufficientExecutionStackException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            string[] strings = { "Apple,", "Banana.", "Carrot?", "Watermelon!", "Apricot", "Water" };

            int count = (from s in strings
                         where (s.EndsWith(",") || s.EndsWith(".") || s.EndsWith("?") || s.EndsWith("!"))
                                && (s.StartsWith("A") || s.StartsWith("W"))
                         select s).Count();

            Console.WriteLine("Количество строк, удовлетворяющих условию: " + count);
            
            var filteredStrings = strings.Where(s => (s.EndsWith(",") || s.EndsWith(".") || s.EndsWith("?") || s.EndsWith("!"))
                                               && (s.StartsWith("A") || s.StartsWith("W")));

            foreach (var str in filteredStrings)
            {
                Console.WriteLine(str);
            }

            var fil = strings.Where(s => (s.Contains("rrot")));
            foreach (var str in fil)
            {
                Console.WriteLine(str);
            }


            Sale sale = new Sale();

            SuperCar car1 = new SuperCar("Ferrari");
            SuperCar car2 = new SuperCar("Lamborghini");
            SuperCar car3 = new SuperCar("Porsche");

            sale.NextYear += new dildo(car1.HandleNaxtYear);

            sale.TriggerNextYear();

            Console.WriteLine("Sale status after NextYear event:");
            Console.WriteLine($"Car1: {car1.Model}, IsOnSale: {car1.IsOnSale}");
            Console.WriteLine($"Car2: {car2.Model}, IsOnSale: {car2.IsOnSale}");
            Console.WriteLine($"Car3: {car3.Model}, IsOnSale: {car3.IsOnSale}");
        }
    }
}
