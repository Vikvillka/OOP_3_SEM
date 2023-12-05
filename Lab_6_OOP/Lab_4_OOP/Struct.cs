using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{

        public struct Color
        {
            public byte red;
            public byte green;
            public byte blue;
            public string str;

            public Color( byte red, byte green, byte blue, string str)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
                this.str = "";
            }
        }
    }

