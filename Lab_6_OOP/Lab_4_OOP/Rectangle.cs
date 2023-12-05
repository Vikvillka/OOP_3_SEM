using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class Rectangle : Figure, IManagement
    {
        public float width;
        public float height;
        public Button? button;
        public Checktbox? checktbox;

        Button newButton = new Button();

        public Rectangle(float pointX, float pointY, float width, float height, IManagement button)
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
            this.width = width;
            if (width < 0)
            {
                throw new TypeException("Неверное значение width", (int)width);
            }
            this.height = height;
            if (height < 0)
            {
                throw new TypeException("Неверное значение height", (int)height);
            }
            Button newbutton1 = button as Button;
            this.button = newbutton1;
            if(this.button == null)
            {
                Checktbox newbutton2 = button as Checktbox;
                this.checktbox = newbutton2;
                if (this.button == null)
                {
                    Radiobutton radioButton = button as Radiobutton;
                    if (radioButton != null)
                    {
                        throw new NameException("Прямоугольник не может быть RadioButton", "");
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"pointX {pointX} pointY {pointY} width {width} height {height} ";
        }

        void IManagement.Show()
        {

            Console.WriteLine("Координаты кнопки: {0},{1}", pointX, pointY);

            Console.WriteLine("Ширина и высота кнопки: {0},{1}", width, height);

        }

        public override void  Show()
        {

            if (this.button != null)
            {
                this.button.Show();
                Console.WriteLine("Ширина кнопки: {0}", width);
                Console.WriteLine("Высота кнопки: {0}", height);
            }
            if (this.checktbox != null)
            {
                this.checktbox.Show();
                Console.WriteLine("Ширина кнопки: {0}", width);
                Console.WriteLine("Высота кнопки: {0}", height);
            }
            if (button == null && checktbox == null)
            {
                Console.WriteLine("\nНе является прямоугольной кнопкой ");
            }

            Console.WriteLine("Координаты кнопки: {0},{1}", pointX, pointY);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" + newButton);
        }

        public void Input()
        {
            Console.WriteLine("\n\nЭто класс прямоугольник");
        }
    }
}
