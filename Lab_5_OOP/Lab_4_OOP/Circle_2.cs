using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public partial class Circle : Figure, IManagement
    {
        public float radius;
        public Checktbox? checktbox;
        public Radiobutton? radiobutton;
        public Color color = new Color();
    }
}
