using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace Lab_14_OOP
{
    class Program
    {
        static void Main(string[] args)
        { 
            // задание 1
            Process[] processes = Process.GetProcesses();

            foreach(Process process in processes)
            {
                Console.WriteLine($"id: {process.Id}\n " +
                    $"Имя: {process.ProcessName} \n" +
                    $"Приоритет: {process.BasePriority}\n" +
                    $"Время запуска: {process.Responding}\n"
                   /* $"total time: {process.TotalProcessorTime}"*/);
            }

            // задание 2

            AppDomain currentDomain = AppDomain.CurrentDomain;

            Console.WriteLine("Имя домена: " + currentDomain.FriendlyName);
            Console.WriteLine("База приложений: " + currentDomain.SetupInformation.ApplicationBase);
            Console.WriteLine("Конфигурационные файлы: " + currentDomain.SetupInformation.ConfigurationFile);
            Console.WriteLine("Целевая версия: " + currentDomain.SetupInformation.TargetFrameworkName);

            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine("Сборка: " + assembly.FullName);
            }

            // задание 3

            Thread simpleThread = new Thread(Methods.SimpleNumbers);    
            simpleThread.Start();                                       
            Console.WriteLine("\nИнформация о потоке:");
            Console.WriteLine("Выполняется ли поток: " + simpleThread.IsAlive);
            Console.WriteLine("Приоритет потока: " + simpleThread.Priority);
            Console.WriteLine("Идентификатор: " + simpleThread.ManagedThreadId);
            simpleThread.Join();

            // задание 4

            Console.WriteLine("\nПотоки чётных и нечётных чисел:");
            Thread evenThread = new Thread(Methods.EvenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;          
            evenThread.Start();            
            //evenThread.Join();              

            Console.WriteLine();
            Thread oddThread = new Thread(Methods.OddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start();
            
            // задание 5

            TimerCallback tm = new TimerCallback(Methods.Task5);        /// делегат для таймера
            Timer timer = new Timer(tm, null, 1000, 1000);              /// null - параметр которого нет, 1000 - 
            Thread.Sleep(4000);
            timer.Dispose();                                            /// время через которое запустится процесс
                                                                        /// с таймером, 1000 - периодичность таймера,
                                                                        /// 4000 - ждем и не закрываем поток
        }
    }
}















// создание нового домена 
            /*AppDomain newDomain = AppDomain.CreateDomain("NewDomain");

            try
            {
                newDomain.Load("name");
                AppDomain.Unload(newDomain);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/