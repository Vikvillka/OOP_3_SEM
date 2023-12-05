using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public abstract class ElemOfManage : IManagement
    {
        public bool Tap { get; set; }


        public override string ToString()
        {
            return $"Это элемент управления";
        }

        public void Show()
        {

        }
        public void Input()
        {

        }
    }
}
