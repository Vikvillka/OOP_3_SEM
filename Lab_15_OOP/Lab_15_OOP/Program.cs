using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_15_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks.Task1();
            Thread.Sleep(1000);
            Tasks.Task2();
            Tasks.Task3and4();
            Thread.Sleep(1000);
            Tasks.Task5();
            Thread.Sleep(1000);
            Tasks.Task6();
            Thread.Sleep(1000);
            //Tasks.Task7();
            Thread.Sleep(1000);
            Tasks.Task8();
        }


    }

}
