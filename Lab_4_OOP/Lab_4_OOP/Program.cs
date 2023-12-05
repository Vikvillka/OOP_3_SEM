using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    class Program
    {
        public static void Main()
        {

            Button NiceButton = new Button();

            Checktbox NiceChecBox = new Checktbox();

            Radiobutton NiceRadioButton = new Radiobutton();

            Circle circleButtton = new Circle((float)4, (float)5, (float)4.4, NiceButton);
            Circle circleCheckBox = new Circle((float)11, (float)21, (float)3, NiceChecBox);
            Circle circleRadioButton = new Circle((float)2, (float)12, (float)6.3, NiceRadioButton);
            
            circleButtton.Input();
            circleButtton.Show();

            circleCheckBox.checktbox.Tap = true;
            circleCheckBox.checktbox.Input();
            circleCheckBox.Show();

            ((Figure)circleRadioButton).Show();
            circleRadioButton.radiobutton.Input();
            circleRadioButton.radiobutton.Tap = true;
            circleRadioButton.radiobutton.Input();

            Console.WriteLine("Метод из интерфейса: ");
            ((IManagement)circleRadioButton).Show();
            IManagement psdf = circleButtton;
                
            
                
            Console.WriteLine("\n\nРабота с прямоугольником");
            Rectangle rectangle1 = new Rectangle((float)4.1, (float)4.1, (float)2, (float)7, NiceButton);
            Rectangle rectangle2 = new Rectangle((float)4.2, (float)4.2, (float)3, (float)8, NiceChecBox);
            Rectangle rectangle3 = new Rectangle((float)4.3, (float)4.3, (float)4, (float)9, NiceRadioButton);

            rectangle2.Input();
            rectangle1.Show();
            rectangle2.Show();
            rectangle3.Show();

            Console.WriteLine();

            Console.WriteLine("\nРабота с классом Print");

            var printer = new IManagement[] { rectangle1, rectangle2, rectangle3, circleButtton, circleCheckBox, circleRadioButton };

            foreach (var el in printer)
            {
                Printer.IAmPrinting(el);
            }

            Console.ReadLine();
        }
    }
}



