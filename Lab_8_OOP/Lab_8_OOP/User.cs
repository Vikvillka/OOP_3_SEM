using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_OOP
{
    public delegate void Move(User obj, int x, int y);
    public delegate void Compress(User obj, float ratio);

    public class User
    {
        public int pointX;
        public int pointY;
        public float compressionRatio;

        public User(int x, int y, float ratio)
        {
            pointX = x;
            pointY = y;
            compressionRatio = ratio;
        }

        public event Move move;
        public event Compress compress;

        public void Change(int x, int y, float ratio)
        {
            Console.WriteLine(ToString());
            Console.WriteLine();
            Console.WriteLine("Изминения:");

            if (move != null)
            {
                move.Invoke(this, x, y);
            }
            else
            {
                Console.WriteLine("Позиция не изменилась");
            }
            if (compress != null)
            {
                compress.Invoke(this, ratio);
            }
            else
            {
                Console.WriteLine("Нет изминения сжатия");
            }
            Console.WriteLine();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Позиция обьекта: x = {pointX}, y = {pointY}, сжатие = {compressionRatio}";
        }
    }
}
