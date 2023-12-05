using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    [Serializable]
    public class Rectangle : Figure, IManagement
    {
        public float width { get; set; }
        public float height { get; set; }
        public Button? button { get; set; }
        public Checktbox? checktbox { get; set; }

        Button newButton = new Button();

        public Rectangle()
        {
                
        }
        public Rectangle(float pointX, float pointY, float width, float height)
        {
            this.pointX = pointX;
            this.pointY = pointY;
            this.width = width;
            this.height = height;

            
        }

        public override string ToString()
        {
            return $"pointX {pointX} \t pointY {pointY} \t width {width} \t height {height} \t ";
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
