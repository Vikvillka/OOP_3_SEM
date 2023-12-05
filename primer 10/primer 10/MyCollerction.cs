using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_10
{
    public class MyCollerction<T>: List<T>
    {
       
        public bool Add(T element)
        {
            if(element is int n)
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
                throw new Exception("hewee");
            }
        }
        public void Print()
        {
            for (int i = 0; i < base.Count; i++)
                Console.WriteLine(base[i]);
        }
        public bool Find(T element)
        {
            return base.Contains(element);
        }
    }
}
