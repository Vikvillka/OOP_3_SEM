using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer
{
    public class GoodStack<T> : Stack<T>
    {
        public GoodStack()
        {
            if (typeof(T) == typeof(Point))
            {
                throw new ArgumentException("fsfdfs");
            }
        }

        public new void Push(T item)
        {
            base.Push(item);
        }

        public new T Pop()
        {
            throw new InsufficientExecutionStackException("error");
        }

    }

    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
