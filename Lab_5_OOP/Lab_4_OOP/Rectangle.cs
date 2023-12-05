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
            this.pointY = pointY;
            this.width = width;
            this.height = height;

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
                        Console.WriteLine("\n-------Прямоугольник не может быть RadioButton--------\n");
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
