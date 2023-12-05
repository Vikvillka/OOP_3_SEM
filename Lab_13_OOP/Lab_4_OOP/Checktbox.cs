using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    [Serializable]
    public sealed class Checktbox: ElemOfManage, IManagement
    {
        public void Show()
        {
            Console.WriteLine("Это ChecktBox ");
        }
        public void Input()
        {
            if (Tap)
            {
                Console.WriteLine("ChecktBox отмечен");
            }
            else
            {
                Console.WriteLine("ChecktBox не отмечен");
            }

        }
    }
}
