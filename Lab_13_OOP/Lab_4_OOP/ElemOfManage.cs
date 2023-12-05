using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    [Serializable]
    public abstract class ElemOfManage 
    {
        public bool Tap { get; set; }


        public override string ToString()
        {
            return $"Это элемент управления";
        }
    }
}
