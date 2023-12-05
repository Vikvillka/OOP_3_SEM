using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public class MyException : System.Exception
    {
        public string Value { get; set; }
        public MyException(string message, string value) : base(message) 
        {
            this.Value = value;
        }
    }
    public class NameException : MyException
    {
        public  string Name { get; set; }
        public NameException(string message, string name) : base(message, "Error name\n")  
        {
            this.Name = name;
        }
    }
    public class TypeException : MyException
    {
        public int Value { get; set; }
        public TypeException(string message, int value) : base (message, "Error type\n")
        {
            this.Value = value;
        }
    }
    public class ZeroException : MyException
    {
        public int value { get; set; }
        public ZeroException(string message, int error) : base(message, "Error division by zero\n") 
        {
            this.value = error;
        }
    }



}
