using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "December", "January", "February", "March", "April", "May", "September", "October", "November", "June", "July", "August", };

            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nПоследовательность месяцев с длиной строки равной n:");
            IEnumerable<string> monthLength = from m in months
                                                where m.Length == n
                                                select m;
            foreach (var m in monthLength)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос возвращающий только летние и зимние месяцы:");
            IEnumerable<string> summerAndWinterM = months.Take(3).Concat(months.Skip(9));
            
            foreach (var m in summerAndWinterM)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос возвращающий массив в алфавитном порядке:");
            IEnumerable<string> sortArr = from m in months
                                            orderby m 
                                            select m;
            foreach (var m in sortArr)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х:");
            IEnumerable<string> monthsWithU = from m in months
                                                 where(m.Contains("u") || m.Contains("U") && m.Length >=4)
                                                select m;
            foreach (var m in monthsWithU)
            {
                Console.WriteLine(m);
            }

           
            List<Airline> airline = new List<Airline>
            {
                new Airline (1, "Гродно", 1206, "Грузовой", "Понедельник", 11, 15 ),
                new Airline(2, "Минск", 616, "Пассажирский", "Четверг", 10, 40),
                new Airline(3, "Минск", 111, "Пассажирский", "Понедельник", 12, 45),
                new Airline (4, "Браслав", 1207, "Грузовой", "Понедельник", 11, 35 ),
                new Airline(5, "Полоцк", 600, "Пассажирский", "Вторник", 15, 40),
                new Airline(6, "Минск", 114, "Пассажирский", "Пятница", 14, 15),
                new Airline (7, "Гродно", 1200, "Грузовой", "Среда", 8, 35 ),
                new Airline(8, "Слуцк", 60, "Пассажирский", "Вторник", 12, 10),
                new Airline (9, "Браслав", 127, "Грузовой", "Среда", 9, 35 ),
                new Airline(10, "Сморгонь", 315, "Пассажирский", "Четверг", 18, 10),
            };

            Console.WriteLine("\nСписок рейсов для заданного пункта назначения:");
            IEnumerable<Airline> punct = from a in airline
                                         where a.Destination == "Минск"
                                         select a;
            foreach (var a in punct)
            {
                Console.WriteLine(a.Destination + " " + a.FlightNumber + " время вылета: " + a.DepartureTime);
            }

            Console.WriteLine("\nКоличество рейсов в понедельник:");
            IEnumerable<Airline> targetDay = from a in airline
                                             where a.Day == "Понедельник"
                                             select a;
            int count = targetDay.Count();
            Console.WriteLine(count);

            Console.WriteLine("\nРейс, который вылетает в понедельник раньше всех:");
            IEnumerable<Airline> ranshe = from a in airline
                                          where a.Day == "Понедельник"
                                          orderby a.DepartureTime.hours, a.DepartureTime.minutes
                                          select a;
            Airline b = ranshe.First();
            Console.WriteLine(b.Destination + " " + b.Day + " " + b.DepartureTime);

            Console.WriteLine("\nРейс, который вылетает в среду или пятницу позже всех:"); 
            IEnumerable<Airline> pozdno = from a in airline
                                          where a.Day == "Пятница" || a.Day == "Среда"
                                          orderby a.DepartureTime.hours, a.DepartureTime.minutes
                                          select a;
            Airline c = pozdno.Last();
            Console.WriteLine(c.Destination + " " + c.Day + " " + c.DepartureTime);

            Console.WriteLine("\nРейсы, упорядоченные по времени вылета:");
            IEnumerable<Airline> air = from a in airline
                                       orderby a.DepartureTime.hours, a.DepartureTime.minutes
                                       select a;
            foreach (var a in air)
            {
                Console.WriteLine(a.Destination + " " + a.FlightNumber + " время вылета: " + a.DepartureTime);
            }

            Console.WriteLine("\nСвой запрос:");
            var myQuery = from a in airline
                          where a.PlaneType == "Пассажирский"
                          group a by a.Day into g
                          let total = g.Count()
                          let earliestFlight = g.Min(a => a.DepartureTime)
                          let latestFlight = g.Max(a => a.DepartureTime)
                          orderby total descending
                          select new
                          {
                              Day = g.Key,
                              TotalFlights = total,
                              EarliestFlight = earliestFlight,
                              LatestFlight = latestFlight
                          };
            var result = myQuery.Take(3).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"День недели: {item.Day}");
                Console.WriteLine($"Общее количество авиарейсов: {item.TotalFlights}");
                Console.WriteLine($"Самый ранний вылет: {item.EarliestFlight.hours}:{item.EarliestFlight.minutes}");
                Console.WriteLine($"Самый поздний вылет: {item.LatestFlight.hours}:{item.LatestFlight.minutes}");
                Console.WriteLine();
            }
            
            var airlines = new List<Flight>
            {
                new Flight { Id = "1", Destination = "Минск" },
                new Flight { Id = "2", Destination = "Анус" },
                new Flight { Id = "3", Destination = "Париж" }
            };
            
            var passengers = new List<Passenger>{
                new Passenger { Name = "Иван", AirlineId = "1" },
                new Passenger { Name = "Пенис", AirlineId = "2" },
                new Passenger { Name = "Алексей", AirlineId = "1" },
                new Passenger { Name = "Елена", AirlineId = "3" }
            };

            var query = from a in airlines
                        join passenger in passengers on a.Id equals passenger.AirlineId
                        select new
                        {
                            PassengerName = passenger.Name,
                            Destination = a.Destination
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Пассажир: {item.PassengerName}, Направление: {item.Destination}");
            }

        }
       
    }
}
