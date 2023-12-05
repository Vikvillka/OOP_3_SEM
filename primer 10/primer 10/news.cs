using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_10
{
    public delegate void dildo();
    public class news
    {
        public event dildo post;

        public void WrightNews()
        {
            if (post != null)
                post();
        }
    }
    public class Sub
    {
        public void Read()
        {
            Console.WriteLine("ЧИТАЮ НОВОСТЬ");
        }
    }
}
