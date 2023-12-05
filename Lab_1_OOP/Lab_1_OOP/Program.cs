using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------обьявление переменных------------
            bool bool_var = true;
            byte byte_var = 1;
            sbyte sbyte_var = -100;
            char char_var = 'a';
            decimal decimal_var = 1.5m;
            double double_var = 1.5d;
            float float_var = 1.5f;
            int int_var = int.MaxValue;
            uint uint_var = uint.MaxValue;
            long long_var = long.MaxValue;
            ulong ulong_var = 123456;
            short short_var = short.MaxValue;
            ushort ushort_var = ushort.MaxValue;
            Console.WriteLine($"bool_var = {bool_var} - byte_var = {byte_var} - sbyte_var = {sbyte_var} - char_var = {char_var} " +
                $"- decimal_var = {decimal_var} - double_var = {double_var} - float_var = {float_var} - int_var = {int_var} - " +
                $"uint_var = {uint_var} - long_var = {long_var} - ulong_var = {ulong_var} - short_var = {short_var} - ushort_var = " +
                $"{ushort_var}");

            //-----------ввод и вывод значений----------
            bool a_1 = bool.Parse(Console.ReadLine());
            Console.WriteLine("bool " + a_1);

            byte a_2 = byte.Parse(Console.ReadLine());
            Console.WriteLine("byte " + a_2);

            sbyte a_3 = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("sbyte " + a_3);

            char a_4 = char.Parse(Console.ReadLine());
            Console.WriteLine("char " + a_4);

            decimal a_5 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("decimal " + a_5);

            double a_6 = double.Parse(Console.ReadLine());
            Console.WriteLine("double " + a_6);

            float a_7 = float.Parse(Console.ReadLine());
            Console.WriteLine("float " + a_7);

            int a_8 = int.Parse(Console.ReadLine());
            Console.WriteLine("int " + a_7);

            uint a_9 = uint.Parse(Console.ReadLine());
            Console.WriteLine("uint " + a_9);

            long a_10 = long.Parse(Console.ReadLine());
            Console.WriteLine("long " + a_10);

            ulong a_11 = ulong.Parse(Console.ReadLine());
            Console.WriteLine("ulong " + a_11);

            short a_12 = short.Parse(Console.ReadLine());
            Console.WriteLine("short " + a_12);

            ushort a_13 = ushort.Parse(Console.ReadLine());
            Console.WriteLine("ushort " + a_13);

            //-----------явное преобразование--------------
            int int_1 = 1;
            byte tobyte = (byte)int_1;

            double double_1 = 2.2d;
            float tofloat = (float)double_1;

            float float_1 = 3.3f;
            decimal todecimal = (decimal)float_1;

            char char_1 = 'f';
            string tostring = char_1.ToString();

            string string_1 = "1206";
            int toint = Convert.ToInt32(string_1);

            //-----------неявное преобразование------------
            byte a = 3;
            short s = a;
            int i = a;
            long l = a;
            float f = a;
            double d = a;

            //------упаковка и распаковка------------------
            int c_1 = 5;
            Object c_2 = c_1;
            int c_3 = (int)c_2;

            //-pабота с неявно типизированными переменными-
            var d_1 = true;
            var d_2 = 5;
            var d_3 = 5.5;
            var d_4 = 'g';
            var d_5 = "hello!!!";
            Console.WriteLine($"firstvar = {d_1} - {d_1.GetType()}");
            Console.WriteLine($"firstvar = {d_2} - {d_2.GetType()}");
            Console.WriteLine($"firstvar = {d_3} - {d_3.GetType()}");
            Console.WriteLine($"firstvar = {d_4} - {d_4.GetType()}");
            Console.WriteLine($"firstvar = {d_5} - {d_5.GetType()}");

            //--------------nullable переменная---------------------
            int? nullableInt = null;
            Console.WriteLine(nullableInt);
            nullableInt = 5;
            Console.WriteLine(nullableInt);

            //-------------var------------------------------
            //var test = true;
            //test = 3;

            //---------------СТРОКИ-------------------------
            //--------строковые литералы--------------------
            string str_1 = "811";
            string str_2 = "1206";
            Console.WriteLine($"\nсравнение {str_1 == str_2}");

            //------работа со строками----------------------
            string string1 = "Vika";
            string string2 = "Bychkovskaya";
            string string3 = "Hello world !!!";
            //сцепление
            Console.WriteLine($"{string.Concat(string1, string2, string3)} - сцепление");
            //копирование
            Console.WriteLine($"{string.Copy(string2)} - копирование");
            //выделение подстроки
            Console.WriteLine($"{string2.Substring(0, 3)} - подстрока");
            //разделение строки на слова
            string[] words = string3.Split(new[] { ' ' });
            Console.WriteLine($"первое слово - {words[0]}, второе слово - {words[1]}"); 
            //вставка подстроки в заданную позицию
            Console.WriteLine($"{string1.Insert(0, "Hello ")} - вставка подстроки");
            //удаление заданной подстроки
            Console.WriteLine($"{string3.Remove(0, 3)} - удаление подстроки");

            //----------IsNullOrEmpty-----------------------
            Console.WriteLine("\nПустая и null строка");
            string str = string.Empty;
            string str1 = null;
            string str2 = "ff";
            Console.WriteLine(string.IsNullOrEmpty(str));
            Console.WriteLine(string.IsNullOrEmpty(str1));
            Console.WriteLine(string.IsNullOrEmpty(str2));

            //-------------StringBuilder---------------------
            Console.WriteLine("\nСтрока на основе StringBuilder");
            StringBuilder stringg = new StringBuilder("Hello world");
            stringg.Remove(0, 6);
            Console.WriteLine(stringg);
            stringg.Insert(0, "Bye ");
            Console.WriteLine(stringg);
            stringg.Append("(");
            Console.WriteLine(stringg);

            //------------------МАССИВЫ---------------------
            //-------------двумерный массив-----------------
            Console.WriteLine("\n");
            int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };
            int rows = arr.GetUpperBound(0) + 1;    // количество строк
            int columns = arr.GetUpperBound(1) + 1;        // количество столбцов
                                                        
            for (int r = 0; r < rows; r++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{arr[r, j]}  ");
                }
                Console.WriteLine();
            }

            //-----------массив строк----------------------
            var stringArr = new[] { "One", "Two", "Three" };
            Console.WriteLine("\nМассив:");
            for (int r = 0; r < stringArr.Length; r++)
            {
                Console.Write("{0} ", stringArr[r]);
            }
            Console.WriteLine($"\nДлина массива - {stringArr.Length}");
            Console.WriteLine("Введите номер элемента массива:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение элемента массива:");
            string value = Console.ReadLine();
            stringArr[index] = value;
            Console.WriteLine("Массив после изменения:");
            for (int r = 0; r < stringArr.Length; r++)
            {
                Console.Write("{0} ", stringArr[r]);
            }

            //------------ступенчатый массив----------------
            Console.WriteLine("\n" + "Ступенчатый массив с вещественными числами");
            double[][] myArr = new double[3][] { new double[2], new double[3], new double[4] };
            for (int v = 0; v < myArr.Length; v++) 
            {
                for (int j = 0; j < myArr[v].Length; j++)
                {
                    Console.Write($"myArr[{v}][{j}] = ");
                    myArr[v][j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\n");
            for (int g = 0; g < myArr.Length; g++)
            {
                Console.WriteLine(string.Join(" ", myArr[g]));
            }

            //----------неявная типизация----------------------
            var arr1 = new[] { 1, 2, 3, 4, 5 };
            var str_not_type = new[] { "Hello", "world", "!!!"};
            Console.WriteLine("Массив:");
            for (int r = 0; r < arr1.Length; r++)
            {
                Console.Write("{0} ", arr1[r]);
            }
            Console.WriteLine();
            Console.WriteLine("Строка:");
            for (int r = 0; r < str_not_type.Length; r++)
            {
                Console.Write("{0} ",str_not_type[r]);
            }

            //--------------------КОРТЕЖИ----------------------

            var t = new Tuple<int, string, char, string, ulong>(1, "Two",'3',"Four", 5ul);
            var tuple = (1, "Two", '3', "Four", 5ul);
            
            //---------------------вывод-----------------------
            Console.WriteLine("\nВывод кортежа");
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            //--------распаковка кортежа в переменные-----------
            Console.WriteLine("\nPаспаковка кортежа");
            var (t_1, t_2, t_3, t_4, t_5) = tuple;
            Console.WriteLine(t_1);
            Console.WriteLine(t_2);
            Console.WriteLine(t_3);
            Console.WriteLine(t_4);
            Console.WriteLine(t_5);
            
            //------использование переменной(_)---------------
            Console.WriteLine("\nИспользование переменной(_)");
            var (f_1, _, _, j_1, _) = tuple;
            Console.WriteLine(f_1);
            Console.WriteLine(j_1);

            //----------- cравнение двух кортежей--------------
            Console.WriteLine("\nСравнение двух кортежей");
            var tuple1 = (1, "Two", '3', "Four", 5ul);
            Console.WriteLine($"{tuple == tuple1}");

            //----------- Локальная функция -------------------
            Console.WriteLine("\nЛокальная функция");

             (int, int, int, char) LocalFunction(int[] arrVar, string strVar)
            {
                int maxArrayElement = arrVar.Max();
                int minArrayElement = arrVar.Min();
                int arrayElementsSum = arrVar.Sum();
                char firstStringChar = strVar[0];
                return (maxArrayElement, minArrayElement, arrayElementsSum, firstStringChar);
            }

            //----------Работа с checked/unchecked------------
            void CheckedFunc()
            {
                checked
                {
                    int Max = int.MaxValue;
                    //Max ++;
                    Console.WriteLine(Max);
                }
            }
            void Unchecked()
            {
                unchecked
                {
                    int Max = int.MaxValue;
                    Console.WriteLine(Max);
                }
            }
            CheckedFunc();
            Unchecked();
        }
    }
}

