using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Arr<string> array = new Arr<string>(5);
                array[0] = "a1";
                array[1] = "b2";
                array[2] = "c3";
                array[3] = "d4";
                array[4] = "i5";
                ((IGeneric<string>)array).Show();
                ((IGeneric<string>)array).Add("f6");
                ((IGeneric<string>)array).Delete(1, 3);
                ((IGeneric<string>)array).Show();
                
                Console.WriteLine();

                Arr<object> array1 = new Arr<object>(2);
                array1[0] = 1.242335;
                array1[1] = 4.231231;
                ((IGeneric<object>)array1).Show();
                ((IGeneric<object>)array1).Add(1.4234234);
                ((IGeneric<object>)array1).Show();
                Console.WriteLine();

                Arr<object> array2 = new Arr<object>(2);
                array2[0] = 3;
                array2[1] = 4;
                ((IGeneric<object>)array2).Show();
                ((IGeneric<object>)array2).Add(5);
                ((IGeneric<object>)array2).Show();
                Console.WriteLine();

                Arr<object> arr = new Arr<object>(4);
                arr[0] = 1;
                arr[1] = 2;
                arr[2] = 3;
                arr[3] = 4;
                ((IGeneric<object>)arr).Find(3);

                Radiobutton radiobutton = new Radiobutton();

                Circle circle1 = new Circle(2, 5, 7, radiobutton);
                Circle circle2 = new Circle(2, 5, 7, radiobutton);
               
                 
                Arr<Circle> UserFigure = new Arr<Circle>(2);
                UserFigure[0] = circle1;
                UserFigure[1] = circle2;
                ((IGeneric<Circle>)UserFigure).Show();
                ((IGeneric<Circle>)UserFigure).Add(circle1);
                ((IGeneric<Circle>)UserFigure).Show();
                ((IGeneric<Circle>)UserFigure).Delete(0, 2);

                Arr<object>.WriteToFile(ref arr);
                Arr<object>.ReadFromFile();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Часть 1. Конец ");
            }
            /* Arr array_1 = new Arr(5);
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
             array_4.Delete();*/
        }
    }
}
