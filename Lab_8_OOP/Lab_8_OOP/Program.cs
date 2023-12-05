using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User(3, 4, 1.3f);
            User u2 = new User(1, 2, 1.4f);
            User u3 = new User(5, 7, 1.1f);
            User u4 = new User(5, 5, 1.2f);
            var event_test = new Event();

            u1.move += (obj, x , y) => Console.WriteLine($"Перемещен на X = {x}, Y = {y} относительно начального положения");
            u2.move += event_test.MoveUser;
            u3.move += event_test.MoveUser;
            u3.compress += event_test.CompressUser;

            Console.WriteLine("\n----Первый обьект----\n");
            u1.Change(1, 3, 0);
            Console.WriteLine("\n----Второй обьект----\n");
            u3.Change(2, 2, 1.6F);
            Console.WriteLine("\n----Третий обьект----\n");
            u4.Change(2, 1, 1.3F);

            Console.WriteLine();
            string str = "Hello, world.";
            
            Func<string, string> a;
            
            a = Str.RemoveElement;
            Console.WriteLine(a(str));
            a = Str.RemoveSpaсe;
            Console.WriteLine(a(str));
            a = Str.Lower;
            Console.WriteLine(a(str));
            a = Str.Upper;
            Console.WriteLine(a(str));
            a = Str.AddToString;
            Console.WriteLine(a(str));
        }
    }
}
