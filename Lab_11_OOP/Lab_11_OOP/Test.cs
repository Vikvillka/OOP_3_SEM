﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{
    public class Test : Show
    {
        public string name;

        public string Nаme
        {
            get { return name; }
            set { name = value; }
        }

        public Test() { }
        public Test(string name)
        {
            this.name = name;
        }

        void Show.Show()
        {
            Console.WriteLine(name);
        }

        public void Toconsole(List<string> vs)
        {
            foreach (string str in vs)
                Console.WriteLine(str);
        }

        public override string ToString()
        {
            return "Task: My name - " + name;
        }
        
    }

    interface Show
    {
        void Show();
    }
}
