using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class Arr<T> : IGeneric<T> where T : class
    {
        public T[] array;
        private int index;


        public int Index
        {
            get
            {
                return index;
            }
        }
        public Arr(int Index)
        {
            index = Index;
            array = new T[Index];

        }
        public T this[int number]
        {
            get
            {
                return array[number];
            }
            set
            {
                if (number <= this.Index + 1)
                {
                    array[number] = value;
                }
                else
                {
                    Console.WriteLine("Превышено количество");
                }
            }
        }

        void IGeneric<T>.Show()
        {
            foreach (var e in array)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
        }

        void IGeneric<T>.Delete(int index, int quantity)
        {
            if (quantity > this.array.Length - index)
            {
                throw new Exception();
            }
            Array.Clear(array, index, quantity);
        }

        void IGeneric<T>.Add(T e)
        {

            T[] m = { e };

            array = array.Concat(m).ToArray();

        }

        void IGeneric<T>.Find(T x)
        {
            if (array.Contains(x))
            {
                Console.WriteLine("содержит");
            }
            else
            {
                Console.WriteLine("не содержит");
            }
               
        }

        public static void WriteToFile(ref Arr<T> arr)
        {
            string filePath = @"..\..\..\log.txt";

            using (var file = new StreamWriter(filePath, false)) 
            {
                foreach (var item in arr.array)
                {
                    file.WriteLine(item);
                }
            }
        }

        public static void ReadFromFile()
        {
            using (var file = new StreamReader(@"..\..\..\log.txt", true))
            {
                Console.WriteLine(file.ReadToEnd());
            }
        }
        
        
        //-------перегрузка операторов----------

        public static bool operator >(Arr<T> x, T element)
        {
            foreach (var n in x.array)
            {
                if (n.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator <(Arr<T> x, T element)
        {
            foreach (var n in x.array)
            {
                if (!n.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Arr<T> x, Arr<T> y)
        {
            if (x.array.Length == y.array.Length)
            {
                for (int i = 0; i < x.array.Length; i++)
                {
                    if (!x[i].Equals(y[i]))
                        return true;
                }
            }
            return false;
        }
        public static bool operator ==(Arr<T> x, Arr<T> y)
        {
            if (x.array.Length == y.array.Length)
            {
                for (int i = 0; i < x.array.Length; i++)
                {
                    if (!x[i].Equals(y[i]))
                        return true;
                }
            }
            return false;
        }
        public static T[] operator +(Arr<T> x, Arr<T> y)
        {
            T[] result = x.array.Concat(y.array).ToArray();
            return result;
        }

        public void Show()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + " ");
            }
        }

        public class Developer
        {
            public int id;
            public string name;
            public string department;
            public Developer(int id, string name, string department)
            {
                this.id = id;
                this.name = name;
                this.department = department;
            }
            public void Show()
            {
                Console.WriteLine("ID: " + id);
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Department: " + department);
            }
        }

        public class Production
        {
            public int id;
            public string nameOrganization;
            public Production(int id, string nameOrganization)
            {
                this.id = id;
                this.nameOrganization = nameOrganization;
            }
            public void Show()
            {
                Console.WriteLine("ID Organization: " + id);
                Console.WriteLine("Name Organization: " + nameOrganization);
            }

        }
    }
}
