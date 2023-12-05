using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public sealed class Button : ElemOfManage, IManagement
    {
        public void Show()
        {
            Console.WriteLine("Это кнопка");
        }

        public void Input()
        { 
            if (Tap)
            {
                Console.WriteLine("Кнопка зажата");
            }
            else
            {
                Console.WriteLine("Кнопка не нажата");
            }

        }
    }
}
