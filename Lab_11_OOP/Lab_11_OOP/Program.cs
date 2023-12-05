using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{
    public class Object { }
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("\n--------------------------------- Reflector for class Test ---------------------------------\n");
            Console.WriteLine("---- СБОРКА: ----");
            Reflector.GetName("Lab_11_OOP.Test");
            Console.WriteLine("---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("Lab_11_OOP.Test");
            Console.WriteLine("---- МЕТОДЫ: ----");
            Reflector.GetMethod("Lab_11_OOP.Test");
            Console.WriteLine("---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("Lab_11_OOP.Test");
            Console.WriteLine("---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterface("Lab_11_OOP.Test");
            Console.WriteLine();
            Console.WriteLine("---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("Lab_11_OOP.Test", "String");
            Console.WriteLine();

            Reflector.Invoke("Lab_11_OOP.Test", "Toconsole");
            Reflector.Create("Lab_11_OOP.Test", "Vika");

            Console.WriteLine("\n--------------------------------- Reflector for class Airline ---------------------------------\n");
            Console.WriteLine("---- СБОРКА: ----");
            Reflector.GetName("Lab_11_OOP.Airline");
            Console.WriteLine("---- КОНСТРУКТОРЫ: ----");
            Reflector.GetConstructors("Lab_11_OOP.Airline");
            Console.WriteLine("---- МЕТОДЫ: ----");
            Reflector.GetMethod("Lab_11_OOP.Airline");
            Console.WriteLine("---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("Lab_11_OOP.Airline");
            Console.WriteLine("---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterface("Lab_11_OOP.Airline");
            Console.WriteLine();
            Console.WriteLine("---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("Lab_11_OOP.Airline", "String");
            Console.WriteLine();

            Console.WriteLine("\n--------------------------------- Reflector for class System.Object---------------------------------\n");
            Console.WriteLine("---- СБОРКА: ----");
            Reflector.GetName("Lab_11_OOP.Object");
            Console.WriteLine("---- МЕТОДЫ: ----");
            Reflector.GetMethod("System.Object");
            Console.WriteLine("---- CВОЙСТВА И ПОЛЯ: ----");
            Reflector.GetField("System.Object");
            Console.WriteLine("---- ИНТЕРФЕЙСЫ: ----");
            Reflector.GetInterface("System.Object");
            Console.WriteLine();
            Console.WriteLine("---- МЕТОДЫ ПО ПАРАМЕТРУ: ----");
            Reflector.MethodForType("System.Object", "String");
            Console.WriteLine();

            Reflector.InfoToFile("Lab_11_OOP.Airline");
        }
    }
}
