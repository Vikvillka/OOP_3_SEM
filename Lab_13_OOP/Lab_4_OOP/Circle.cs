using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class Circle : Figure , IManagement 
    {
        public float radius;
        public Checktbox? checktbox;
        public Radiobutton? radiobutton;

        Radiobutton newbutton = new Radiobutton();
        public Circle(float pointX, float pointY, float radius, ElemOfManage button)
        {

            this.pointX = pointX;
            this.pointY = pointY;
            this.radius = radius;
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
            return $"pointX{pointX} \t pointY{pointY} \t Radius{radius} \t ";
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
            
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" + newbutton);

        }
        public void Input()
        {
            Console.WriteLine("Это класс круг\n");
        }

        
    }
}
