using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_OOP
{
    partial class Airline
    {
        public readonly string id;
        public const string departureLocation = "Сморгонь"; // константа

        private string destination;
        private int? flightNumber;
        private string planeType;
        private (int? hours, int? minutes) departureTime;
        private string day;

        private static int numberOfFlights = 0;
        private static string infoAbout;

        //------Свойства------------
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
            }
        }
        public int? FlightNumber
        {
            get => flightNumber;
            set
            {
                if (value > 0)
                {
                    flightNumber = value;
                }
                else
                {
                    throw new Exception("Номер должен быть положительным");
                }
            }
        }
        public string PlaneType
        {
            get => planeType;
            set
            {
                string[] planeTypes = { "Пассажирский", "Грузовой" };
                if (planeTypes.Contains(value) || value == null)
                {
                    planeType = value;
                }
                else
                {
                    throw new Exception("Неверный тип самолета");
                }
            }
        }
        public  (int? hours, int? minutes) DepartureTime
        {
            get => departureTime;
            set
            {
                if((value.hours < 24 && value.hours >= 0) &&
                    (value.minutes >= 0 && value.minutes<60) ||
                    (value.minutes == null && value.minutes == null))
                {
                    departureTime = value;
                }
                else
                {
                    throw new Exception("Неверное время");
                } 
            }
        }
        public string Day
        {
            get => day;
            set
            {
                string[] daysOfWeek = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
                if (daysOfWeek.Contains(value) || value == null)
                {
                    day = value;
                }
                else
                {
                    throw new Exception("Неверный день недели");
                }
            }
        }

        //-------КОНСТРУКТРЫ--------
        // статический конструктор
        static Airline()
        {
            Console.WriteLine("Лаба №2 Работа с классами");
        }
        // конструктор без параметров
        public Airline()
        {
            id = Guid.NewGuid().ToString(); ;
            destination = "Минск";
            flightNumber = 10;
            planeType = "Грузовой";
            departureTime = (12 , 30);
            day = "Четверг";
            numberOfFlights++;
        }
        // конструктор с параметрами
        public Airline(int id, string destination, int flightNumber, string planeType, string day, int hours, int minutes)
        {
            
            this.id = Guid.NewGuid().ToString(); ;
            this.Destination = destination;
            this.FlightNumber = flightNumber;
            this.PlaneType = planeType;
            this.DepartureTime = (hours, minutes);
            this.Day = day;
            numberOfFlights++;
        }
        // конструктор с параметрами по умолчанию
        public Airline(int id, string destination, int hours, int minutes, int flightNumber = 123, string planeType = "Грузовой", string day ="Пятница")
        {
            
            this.id = Guid.NewGuid().ToString(); ;
            this.destination = destination;
            this.flightNumber = flightNumber;
            this.planeType = planeType;
            this.departureTime = (hours, minutes);
            this.day = day;
            numberOfFlights++;
        }
        // закрытый конструктор 
        private Airline(int id)
        {
            this.id = Guid.NewGuid().ToString(); ;
            this.destination = null;
            this.flightNumber = 1234;
            this.planeType = null;
            this.departureTime = (null, null);
            this.day = null;
            numberOfFlights++;
        }

        // -----Методы------
        // переопределение методов
        public override bool Equals(object obj)
        {
            Airline all = obj as Airline;

            if (all != null)
            {
                if (
                    all.destination == this.destination 
                )
                    return true;
                else return false;
            }
            else return false;
        }

        public override string ToString()
        {
            return $"{"".PadLeft(20, '-')}\n" +
                $"{Airline.departureLocation}-{this.Destination}\n" +
                $"{this.PlaneType} №{this.FlightNumber}\n" +
                $"{this.Day} {this.DepartureTime.hours}:{this.DepartureTime.minutes}\n" +
                $"{"".PadLeft(20, '-')}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static void ShowStatic()
        {
            Console.WriteLine($"Количество объектов: {numberOfFlights}");
        }

        // Пример метода, использующего ref и out параметры
        public void ModifyFlight(ref int flightNumber, out string status)
        {
            
            if (flightNumber > 0)
            {
                flightNumber++; 
                status = "Изменено успешно";
            }
            else
            {
                status = "Ошибка: Номер рейса должен быть положительным";
            }
        }


    }
    class LAB_2
    {
    static void Main(string[] args)
        {
            try
            {
                Airline airline1 = new Airline();
                int flightNumber = 1;
                string status;

                airline1.ModifyFlight(ref flightNumber, out status);

                Console.WriteLine($"Номер рейса: {airline1.FlightNumber}");
                Console.WriteLine($"Статус: {status}");

                // Создаем массив объектов класса Airline
                Airline[] airlines = new Airline[]
                {
                    new Airline(1, "Гродно", 1206, "Грузовой", "Понедельник", 11, 15),
                    new Airline(2, "Минск", 616, "Пассажирский", "Четверг", 10, 40),
                    new Airline(3, "Минск", 111, "Пассажирский", "Понедельник", 12, 45),
                    new Airline(),
                    new Airline(id: 1, destination: "Москва", hours: 15, minutes: 30)
                };

                Console.WriteLine($"Список всех рейсов:");
                foreach (var airline in airlines)
                {
                    Console.WriteLine(airline.ToString());
                }
                /*Console.WriteLine($"ID airline1: {airlines[0].id}");
                Console.WriteLine($"ID airline1: {airlines[2].id}");*/

                if (airlines[1].Equals(airlines[2]))
                {
                    Console.WriteLine($"\nCамолет под №{ airlines[1].FlightNumber} и самолет под №{ airlines[2].FlightNumber} летят в один город\n") ;
                }
                else
                {
                    Console.WriteLine($"\nCамолет под №{ airlines[1].FlightNumber} и самолет под №{ airlines[2].FlightNumber} не летят в один город\n");
                }

                // a) Вывод списка рейсов для заданного пункта назначения
                string destinationToSearch = "Гродно";
                var flightsToDestination = airlines.Where(airline => airline.Destination == destinationToSearch);

                Console.WriteLine($"Список рейсов для пункта назначения '{destinationToSearch}':");
                foreach (var flight in flightsToDestination)
                {
                    Console.WriteLine(flight.ToString());
                }

                // b) Вывод списка рейсов для заданного дня недели
                string dayOfWeekToSearch = "Понедельник";
                var flightsOnDayOfWeek = airlines.Where(airline => airline.Day == dayOfWeekToSearch);

                Console.WriteLine($"\nСписок рейсов для дня недели '{dayOfWeekToSearch}':");
                foreach (var flight in flightsOnDayOfWeek)
                {
                    Console.WriteLine(flight);
                }

                Airline.ShowStatic();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
