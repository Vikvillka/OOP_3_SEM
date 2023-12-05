using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace Lab_15_OOP
{
    public static class Tasks
    {
        public static void Matrix()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[,] A = new int[5, 5];
            int[,] B = new int[5, 5];

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    A[i, j] = random.Next(-10, 55);
                    Console.Write(A[i, j] + ", ");
                }
                Console.WriteLine();
            }

            Thread.Sleep(100);
            Console.WriteLine();

            Random random1 = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    B[i, j] = random1.Next(1, 20);
                    Console.Write(B[i, j] + ", ");
                }
                Console.WriteLine();
            }

            var resmatr = new int[7, 7];
            Console.WriteLine();

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        resmatr[i, j] += A[i, k] * B[k, j];
                    }
                    Console.Write(resmatr[i, j] + ", ");
                }
                Console.WriteLine();
            }
            sw.Stop();
            Console.WriteLine($"Создание и перемножение матриц заняло: {sw.ElapsedMilliseconds} милисекунд");
        }

        public static void Task1()
        {
            Console.WriteLine("-----Task 1-----");
            Task task1 = new Task(Matrix, TaskCreationOptions.LongRunning);
            Console.WriteLine($"Task #{task1.Id}, статус - {task1.Status}");
            task1.Start();
            Console.WriteLine($"Task #{task1.Id}, статус - {task1.Status}");

            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Task #{task1.Id} status - {task1.Status}");
                if (task1.Status == TaskStatus.RanToCompletion)
                    break;

            }
        }
        public static void Task2()
        {
            Console.WriteLine("\n-----Task 2-----");
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(Matrix, cts.Token).Start();
            Thread.Sleep(5);
            cts.Cancel();
        }

        public static void Task3and4()
        {
            Console.WriteLine("\n-----Task 3-4 -----");
            
            int Sum(int a, int b) => a + b;
            int Sub(int a, int b) => a - b;
            int Mul(int a, int b) => a * b;
            void PrintResult(int sum) => Console.WriteLine($"Результат задачи: {sum}");

            Task<int> sumTask = new Task<int>(() => Sum(2, 3));
            
            Task<int> subTask = sumTask.ContinueWith(t => Sub(2, 3));
            Task<int> mulTask = subTask.ContinueWith(t => Mul(2, 3));
            Task printTask1 = sumTask.ContinueWith(t => PrintResult(t.Result));
            Task printTask2 = subTask.ContinueWith(t => PrintResult(t.Result));
            Task printTask3 = mulTask.ContinueWith(t => PrintResult(t.Result));

            sumTask.Start();
            
            printTask3.Wait();

            //объект ожидания
            var awaiter = sumTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine($"Результат задачи GetAwaiter(): {res}");
            });
        }

        public static void Task5()
        {
            Console.WriteLine("\n-----Task 5-----");
            var array1 = new int[10000000];
            var array2 = new int[10000000];
            var array3 = new int[10000000];
            var array4 = new int[10000000];

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            //FOR
            Parallel.For(0, 10000000, CreatingArrayElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel FOR {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                array1[i] = 1;
                array2[i] = 1;
                array3[i] = 1;
            }

            stopwatch.Stop();
            Console.WriteLine($"Обычный FOR {stopwatch.ElapsedMilliseconds} ms");

            void CreatingArrayElements(int x)
            {
                array1[x] = 1;
                array2[x] = 1;
                array3[x] = 1;
            }
            //распараллельте вычисления цикла ForEach()
            stopwatch.Restart();

            int sum = 0;
            Parallel.ForEach(array1, SumOfElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel FOREACH {stopwatch.ElapsedMilliseconds} ms");
            sum = 0;
            stopwatch.Restart();
            foreach (int item in array1) sum += item;
            stopwatch.Stop();
            Console.WriteLine($"FOREACH {stopwatch.ElapsedMilliseconds} ms");

            void SumOfElements(int item)
            {
                sum += item;
            }

        }

        public static void Task6()
        {
            Console.WriteLine("\n-----Task 6-----");
            Parallel.Invoke
            (
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); }
            );
        }

        public static void Task7()
        {

            BlockingCollection<string> collection = new BlockingCollection<string>(5);

            Task[] sell = new Task[5] {
                new Task(() => {while(true){
                Thread.Sleep(1500);
                    collection.Add("Помидор"); }
                }),
                new Task(() => { while(true){
                Thread.Sleep(4000);
                    collection.Add("Огурец"); }
                }),
                new Task(() => {  while(true){
                Thread.Sleep(3000);
                    collection.Add("Шоколадка"); }
                }),
                new Task(() => {  while(true){
                Thread.Sleep(5800);
                    collection.Add("Камень"); }
                }),
                new Task(() => {  while(true){
                Thread.Sleep(7200);
                    collection.Add("Бумага"); }
                }),
                };

            Task[] consumers = new Task[10] {
                new Task(() => {
                    Thread.Sleep(1800);
                    if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        //tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(1900);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(2200);
                      if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(2500);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(2600);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(4000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(6000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(6600);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(7000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
                new Task(() => {
                    Thread.Sleep(8000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                       
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }),
            };
            foreach (var item in sell)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            foreach (var item in consumers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            int count = 0;
            while (true)
            {
                if (collection.Count != count && collection.Count != 0)
                {
                    count = collection.Count;
                    Thread.Sleep(200);
                    
                    Console.WriteLine("--------------- Склад ---------------");

                    foreach (var i in collection)
                        Console.WriteLine(i);
                }
            }
        }
        
        public static async Task Taskkk()
        {
            Console.WriteLine("\n-----Task 8-----");
            await PrintNameAsync("Tom");
            await PrintNameAsync("Bob");
            await PrintNameAsync("Sam");

            
            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);     
                Console.WriteLine(name);
            }
        }

        public static void Task8()
        {
            Task.Run(async () => await Taskkk()).Wait();
        }
    }
}
