using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public partial class Circle : Figure , IManagement 
    {
 
        Radiobutton newbutton = new Radiobutton();
        public Circle(float pointX, float pointY, float radius, ElemOfManage button, int colorType)
        {
            this.pointX = pointX;
            if (pointX < 0)
            {
                throw new TypeException("Неверное значение pointX", (int)pointX);
            }
            this.pointY = pointY;
            if (pointY < 0)
            {
                throw new TypeException("Неверное значение pointY", (int)pointY);
            }
            this.radius = radius;
            if (radius < 0)
            {
                throw new TypeException("Неверное значение radius", (int)radius);
            }
            Checktbox newbutton1 = button as Checktbox;
            this.checktbox = newbutton1;
            if (this.checktbox == null)
            {
                Radiobutton newbutton2 = button as Radiobutton;
                this.radiobutton = newbutton2;
                if (this.radiobutton == null)
                {
                    Button radioButton1 = button as Button;
                    if (radioButton1 != null)
                    {
                        throw new NameException("Круг не может быть Button", "");
                    }
                }
            }
            if (colorType < -1 || colorType > 4)
            {
                throw new TypeException("Неверное значение для перечисления", colorType);
            }
            if (colorType == 1)
            {
                color.red = 255;
                color.green = 0;
                color.blue = 0;
                color.str = "красный";
            }
            if (colorType == 2)
            {
                color.red = 0;
                color.green = 255;
                color.blue = 0;
                color.str = "зеленый";
            }
            if (colorType == 3)
            {
                color.red = 0;
                color.green = 0;
                color.blue = 255;
                color.str = "синий";
            }
            if (colorType == 4)
            {
                color.red = 0;
                color.green = 0;
                color.blue = 0;
                color.str = "черный";
            }
        }

        public Circle(float pointX, float pointY, float radius, ElemOfManage button)
        {
            this.pointX = pointX;
            this.pointY = pointY;
            this.radius = radius;
            if (radius < 0 || radius > 100)
            {
                throw new TypeException("Неверное значение radius", (int)radius);
            }
            Checktbox newbutton1 = button as Checktbox;
            this.checktbox = newbutton1;
            if (this.checktbox == null)
            {
                Radiobutton newbutton2 = button as Radiobutton;
                this.radiobutton = newbutton2;
                if (this.radiobutton == null)
                {
                    Button radioButton1 = button as Button;
                    if (radioButton1 != null)
                    {
                        Console.WriteLine("\n---------Круг не может быть Button----------\n");
                    }
                }
            }
        }


        public override string ToString()
        {
            return $"pointX{pointX} pointY{pointY} Radius{radius} ";
        }

        public override bool Equals(object s)
        {
            if (s == null)
                return false;
            Circle temp = (Circle)s;
            return temp.radius == radius;
        }
        public override int GetHashCode()
        {
            return 123 * (int)radius;
        }
        void IManagement.Show()
        {

            Console.WriteLine("Координаты кнопки: {0},{1}", pointX, pointY);

            Console.WriteLine("Радиус кнопки: {0}", radius);

        }

        public override void Show()
        {
            if (this.checktbox != null)
            {
                this.checktbox.Show();
                Console.WriteLine("Радиус кнопки: {0}", radius);
            }
            if (this.radiobutton != null)
            {
                
                this.radiobutton.Show();
                Console.WriteLine("Радиус кнопки: {0}", radius);
            }
            if (checktbox == null && radiobutton == null)
            {
                Console.WriteLine("Эта кнопка не является кругом ");
            }

            Console.WriteLine("Координаты кнопки: {0},{1}", pointX, pointY);
            Console.WriteLine($"цвета элемента красный {color.red}  зеленый {color.green}  синий {color.blue}, цвет кнопки: {color.str}");
            Console.WriteLine("\n\n");

        }
        public void Input()
        {
            Console.WriteLine("Это класс круг\n");
        }

        
    }
}
