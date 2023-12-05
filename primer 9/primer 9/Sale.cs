using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_9
{
    public delegate void dildo();
    public class Sale
    {
        public event dildo NextYear;
        
        public void TriggerNextYear()
        {
            if (NextYear != null)
                NextYear();
        }
    }

    public class SuperCar
    {
        public string Model { get; set; }
        public bool IsOnSale { get; set; }

        public SuperCar(string model)
        {
            Model = model;
            IsOnSale = false;
        }

        public void HandleNaxtYear()
        {
            Console.WriteLine($"подписан на хуйню {Model}...");
            IsOnSale = true;
        }
    }
}
