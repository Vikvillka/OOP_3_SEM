using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_OOP
{
    class Arr
    {
        public int [] array;
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
            array = new int[Index];

        }
        public int this[int number]
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
        

        //-------перегрузка операторов----------

        public static Arr operator -(Arr x, int scalar)
        {
            Arr temp = new Arr(x.Index);
            for (int i = 0; i < temp.array.Length; i++)
            {
                temp.array[i] = x.array[i] - scalar;
            }
            return temp;
        }

        public static bool operator >(Arr x, int element)
        {
            for (int i = 0; i < x.array.Length; i++)
            {
                if (x.array[i] == element)
                    return true;
            }
            return false;
        }
        public static bool operator <(Arr x, int element)
        {
            for (int i = 0; i < x.array.Length; i++)
            {
                if (x.array[i] != element)
                    return true ;
                    
            }
            return false;
        }
        public static bool operator !=(Arr x, Arr y)
        {
            if (x.array.Length == y.array.Length)
            {
                for (int i = 0; i < x.array.Length; i++)
                {
                    if (x.array[i] != y.array[i])
                        return true;
                }
            }
            return false;
        }
        public static bool operator ==(Arr x, Arr y)
        {
            if (x.array.Length == y.array.Length)
            {
                for (int i = 0; i < x.array.Length; i++)
                {
                    if (x.array[i] == y.array[i])
                        return true;
                }
            }
            return false;
        }
        public static Arr operator +(Arr x, Arr y)
        {
            
            Arr temp = new Arr(x.array.Length + y.array.Length);
            for (int i = 0; i < x.array.Length; i++)
            {
                temp.array[i] = x.array[i];
            }
            for (int i = 0; i < y.array.Length; i++)
            {
                temp.array[i + y.array.Length] = y.array[i];
            }
            return temp;
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
