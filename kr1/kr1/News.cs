using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr1
{
    public delegate void delegat();
    public class News
    {
        public event delegat post;
        public void newws()
        {
            if (post != null)
                post();
        }

    }
    public class Sub
    {
         
        public void Read()
        {
            Console.WriteLine("Читаю новость");
        }
    }
}
