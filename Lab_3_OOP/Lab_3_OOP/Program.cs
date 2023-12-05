using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Arr array_1 = new Arr(5);
            array_1[0] = 10;
            array_1[1] = 12;
            array_1[2] = -3;
            array_1[3] = 44;
            array_1[4] = 51;

            Arr array_2 = new Arr(5);
            array_2[0] = 10;
            array_2[1] = 12;
            array_2[2] = -3;
            array_2[3] = 44;
            array_2[4] = 51;

            // проверка перегрузок 
            Console.WriteLine("Перегрузка - :");
            int skalar = 2;
            Arr array_3 = array_1 - skalar;
            array_3.Show();

            Console.WriteLine("\nПерегрузка > :");
            int element = 8;
            if(array_3 > element)
                Console.WriteLine($"Элемент {element} содержится в массиве сверху ");
            else
                Console.WriteLine($"Элемент {element} не содержится в массиве сверху ");

            Console.WriteLine("\nПерегрузка != :");
            if (array_1 != array_2)
                Console.WriteLine($"Массивы не равны");
            else
                Console.WriteLine($"Массивы равны");

            int it = array_2.Index + array_2.Index;
            Console.WriteLine(it);
            Console.WriteLine("\nПерегрузка + :");
            Arr array_4 = array_1 + array_2;
            array_4.Show();

            Console.WriteLine("\nStatisticOperation:");
            Console.WriteLine("MAX:" + array_1.max());
            Console.WriteLine("MIN:" + array_1.min());
            Console.WriteLine("Delta:" + array_1.delta());
            Console.WriteLine("Size:" + array_1.size());

            Console.WriteLine("\nDate, Developer, Organization:");
            Arr.Production prodArr = new Arr.Production(1, "Kozeco Corporation");
            prodArr.Show();
            Arr.Developer ownerArr = new Arr.Developer(2, "Bychkovskaya Vika Alexandrovna", "1206");
            ownerArr.Show();
           
            var str = "\nMне этот код уже абсолютно понятен";
            str.DeleteAllVowel();

            Console.WriteLine("\nУдаление первых 5 хуев");
            array_4.Delete();
        }
    }
}
