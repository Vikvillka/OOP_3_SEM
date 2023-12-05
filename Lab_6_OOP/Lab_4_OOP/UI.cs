using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class UI
    {
        private List<Figure> _list;

        public UI()
        {
            _list = new List<Figure>();
        }
        public List<Figure> list
        {
            get => _list;
            set
            {
                if(value is List<Figure>)
                {
                    _list = value;
                }
            }
        }
        public void Add(object value)
        {
            if (value is Figure being)
            {
                _list.Add(being);
            }
        }

        public void Remove(object value)
        {
            if (value is Figure being)
            {
                _list.Remove(being);
            }
        }

    }
}
