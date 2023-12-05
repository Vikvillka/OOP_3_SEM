using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class UI_Controller
    {
        public void CountOf(UI _list)
        {
            Console.WriteLine($"\nВсего зарегистрированно {_list.list.Count()} элементов\n\n ");

        }

        public void AllSquare(UI _list)
        {
            double square = 0;
            foreach (var being in _list.list)
            {
                switch (being)
                {
                    case (Circle):
                        square += ((Circle)being).radius * ((Circle)being).radius * Math.PI;
                        break;

                    case (Rectangle):
                        square += ((Rectangle)being).width * ((Rectangle)being).height;
                        break;
                }
            }
            Console.WriteLine(Math.Round(square, 3));
        }

        public void Print(UI _list)
        {
            foreach (var being in _list.list)
            {
                switch (being)
                {
                    case Circle:
                        if (((Circle)being).checktbox != null)
                        {
                            Console.WriteLine($"Круглый chekctbox площадью {Math.Round(((Circle)being).radius * ((Circle)being).radius * Math.PI, 2)}" +
                                $", и расположена по координатом X:{((Circle)being).pointX}  Y:{((Circle)being).pointY}");
                        }
                        if (((Circle)being).radiobutton != null)
                        {
                            Console.WriteLine($"Круглая радио-кнопка  площадью {Math.Round(((Circle)being).radius * ((Circle)being).radius * Math.PI, 2)}" +
                                $", и расположена по координатом X:{((Circle)being).pointX}  Y:{((Circle)being).pointY}");
                        }
                        break;
                    case Rectangle:
                        if (((Rectangle)being).button != null)
                        {
                            Console.WriteLine($"Прямоугольная кнопка площадью {((Rectangle)being).width * ((Rectangle)being).height}" +
                                $", и расположена по координатом X:{((Rectangle)being).pointX}  Y:{((Rectangle)being).pointY}");
                        }
                        if (((Rectangle)being).checktbox != null)
                        {
                            Console.WriteLine($"Прямоугольный chekctbox площадью {((Rectangle)being).width * ((Rectangle)being).height}" +
                                $", и расположена по координатом X:{((Rectangle)being).pointX}  Y:{((Rectangle)being).pointY}");
                        }
                        break;
                    default:
                        Console.WriteLine($"error");
                        break;
                }
            }
        }
    }
}
