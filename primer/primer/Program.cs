using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // переменные 
            var a = 1;
            var b = 2;
            var result = a + b;
            Console.WriteLine(result.ToString());
            string ass = result.ToString();
            Console.WriteLine(ass.GetType());
            
            string str = "10";
            int num = Convert.ToInt32(str);// int.parce(str)( // Преобразование строки в int с помощью Convert.ToInt32
            //bool success = double.TryParse(str, out num); // Преобразование строки в double с помощью double.TryParse
            
            
            // строки 
            // дубляж литары
            string str1 = Console.ReadLine();
            char lastLET = str1[str1.Length-1];
            Console.WriteLine(str1 + lastLET);
            // содержит ли
            if (str1.Contains(" hh"))
            {
                Console.WriteLine("laaaaaaa");
            }
            
            // обратный порядок 
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                Console.Write(str1[i]);
            }
            Console.WriteLine();

            // обратный порядок
            char[] charArray = str1.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);
            Console.WriteLine(reversedString);

            foreach (char f in charArray)
            {
                Console.WriteLine(" "+ f);
            }
            
            //
            string strrr = "Пример строки с пробелами";
            string stringWithoutSpaces = strrr.Replace(" ", "");
            Console.WriteLine(stringWithoutSpaces);

            // массивы
            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] numbers1 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers2 = new int[5];
            for (int i = 0; i < numbers2.Length; i++)
            {
                numbers2[i] = i + 1;
            }
            
            string[,] arr = new string[,] { {"aaF","bbb"}, {"ccc","ddd"} };
            int totalLettres = 0;
            foreach(string word in arr)
            {
                foreach(char let in word)
                {
                    if (char.IsLetter(let))
                    {
                        totalLettres++;
                    }
                }
            }
            Console.WriteLine(totalLettres);

            int[,] arr2 = new int[,] 
            { 
                { 2, -1 }, 
                { 6, 5 } 
            };
            int totalNum = 0;
            foreach (int numki in arr2)
            {
                    if (numki %2 != 0)
                    {
                        totalNum++;
                    }
            }
            Console.WriteLine(totalNum);


            int[,] array = new int[3,3]; // Размер массива: 10
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-10, 10); // Генерация случайного числа от -10 до 10
                }
            }

            // вывод в виде матрицы
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            // найбольший и наименший
            int[] arrayy = { 4, 2, 9, 7, 5 };
            Array.Sort(arrayy); // СОРТИРОВКА + REVERSE В УБЫВАНИИ
            int max = arrayy[0];
            int min = arrayy[0];
            for (int i = 1; i < arrayy.Length; i++)
            {
                if (arrayy[i] > max)
                {
                    max = arrayy[i];
                }
                if (arrayy[i] < min)
                {
                    min = arrayy[i];
                }
            }

            // полиндром ли
            /*int[] array = { 1, 2, 3, 2, 1 };
            bool isPalindrome = true;

            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            Console.WriteLine("Является ли массив палиндромом: " + isPalindrome);*/

            /*int[] array = { 3, 8, 5, 2, 9 };
            int index1 = 1; // Индекс первого элемента для замены
            int index2 = 3; // Индекс второго элемента для замены

            Console.WriteLine("Исходный массив: ");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }

            // Проверяем, что индексы находятся в пределах массива
            if (index1 >= 0 && index1 < array.Length && index2 >= 0 && index2 < array.Length)
            {
                int temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;

                Console.WriteLine("\nМассив после замены элементов: ");
                foreach (int num in array)
                {
                    Console.Write(num + " ");
                }
            }
            else
            {
                Console.WriteLine("\nНеверные индексы элементов для замены.");
            }*/

            // дубликаты
            int[] arraye = { 1, 2, 2, 3, 4, 4, 5 };
            int[] aye = { 8, 9, 10 };
            int[] combinedArray = arraye.Concat(aye).ToArray(); // обьединение 2 массивов
            int[] uniqueArray = arraye.Distinct().ToArray();
            foreach(int bb in uniqueArray)
            {
                Console.Write(bb);
            }
            if (arraye.Contains(1))
            {
                Console.WriteLine(arraye);
            }
            
        }
    }
}
