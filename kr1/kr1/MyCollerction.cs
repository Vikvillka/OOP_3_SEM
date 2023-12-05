using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr1
{
    public class MyCollerction<T>: List<T>
    {
        public bool Add(T element)
        {
            if (element is int n)
            {
                base.Add(element);
                return true;
            }
            if (element is double i)
            {
                base.Add(element);
                return true;
            }
            else
            {
                throw new Exception("Невозможно преобразовать");
            }
        }
        
        public void Print()
        {
            for (var i = 0; i < base.Count; i++)
            {
                Console.WriteLine(i);
            }
        }

        public bool Find(T element)
        {
            return base.Contains(element);
        }
    }
}
