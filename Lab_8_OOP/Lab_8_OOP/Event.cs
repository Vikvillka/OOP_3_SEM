using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_OOP
{
    public class Event
    {
        public void MoveUser(User obj,int x, int y)
        {
            obj.pointX += x;
            obj.pointY += y;
            Console.WriteLine($"Обьект смещен на позицию x = {x}, y = {y}");
        }
        public void CompressUser(User obj, float ratio)
        {
            obj.compressionRatio = ratio;
            Console.WriteLine($"Сжатие изменено: " + ratio);
        }
    }
}
