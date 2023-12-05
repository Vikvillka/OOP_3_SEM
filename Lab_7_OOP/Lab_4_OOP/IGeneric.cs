using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public interface IGeneric <T>
    {
        public void Add(T e);
        public void Delete(int index, int quantity);
        public void Show();
        public void Find(T x);
    }
}
