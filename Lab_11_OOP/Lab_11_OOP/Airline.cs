using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{
    public class Airline
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
        public (int? hours, int? minutes) DepartureTime
        {
            get => departureTime;
            set
            {
                if ((value.hours < 24 && value.hours >= 0) &&
                    (value.minutes >= 0 && value.minutes < 60) ||
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

        // конструктор без параметров
        public Airline()
        {
            id = Guid.NewGuid().ToString(); ;
            destination = "Минск";
            flightNumber = 10;
            planeType = "Грузовой";
            departureTime = (12, 30);
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
        public Airline(int id, string destination, int hours, int minutes, int flightNumber = 123, string planeType = "Грузовой", string day = "Пятница")
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
    public class Flight
    {
        public string Id { get; set; }
        public string Destination { get; set; }
    }

    public class Passenger
    {
        public string Name { get; set; }
        public string AirlineId { get; set; }
    }
}
