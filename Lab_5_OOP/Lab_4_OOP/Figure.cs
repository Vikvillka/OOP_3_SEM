using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public abstract class Figure
    {
        public float pointX;
        public float pointY;

        public Color color;

        public void SetColor(byte black, byte red, byte green, byte blue)
        {
            
            color.red = red;
            color.green = green;
            color.blue = blue;
        }

        public override string ToString()
        {
            return $"pointX{pointX} \t pointY{pointY}";
        }

        public abstract void Show();
    }
}
