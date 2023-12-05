using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_OOP
{

    static class Reflector
    {
        static public void GetName(object obj)
        {
            Type type = Type.GetType(obj.ToString());
            Console.WriteLine($" Name: {type.Assembly.FullName}\n");
        }

        static public void GetConstructors(object obj)
        {
            Type type = Type.GetType(obj.ToString());
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (constructors.Length > 0)
            {
                Console.WriteLine("Публичные конструкторы есть!\n");
            }
            else
            {
                Console.WriteLine("Публичных конструкторов нет(\n");
            }
        }

        static public void GetMethod(object obj)                       
        {
            Type type = Type.GetType(obj.ToString());
            
            foreach (MethodInfo methodInfo in type.GetMethods())
                Console.WriteLine(methodInfo.Name);
            Console.WriteLine("\n");

        }

        static public void GetField(object obj)                         // получает информацию о полях и свойствах класса
        {
            Type type = Type.GetType(obj.ToString());

            foreach (FieldInfo fieldInfo in type.GetFields())
                Console.WriteLine(fieldInfo);
            foreach (PropertyInfo propertyInfo in type.GetProperties())
                Console.WriteLine(propertyInfo);
        }

        static public void GetInterface(object obj)
        {
            Type type = Type.GetType(obj.ToString());

            foreach (Type interfaceMapping in type.GetInterfaces())
                Console.WriteLine(interfaceMapping);
        }

        static public void MethodForType(object obj, string parametr)
        {
            Type type = Type.GetType(obj.ToString());
            MethodInfo[] methodInfo = type.GetMethods();
            Console.WriteLine($"Метод из класса: {obj} с параметрами :{parametr}");
            
            for (int i = 0; i < methodInfo.Length; i++)
            {
                ParameterInfo[] param = methodInfo[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name)
                        Console.WriteLine(methodInfo[i].Name);
                }
            }
            
        }

        public static void Invoke(string name, string methode)
        {
            Type type = Type.GetType(name);
            
            List<string> list = File.ReadAllLines("D:\\3_SEM_LABS\\OOP\\Lab_11_OOP\\Lab_11_OOP\\Out.txt").ToList();
            List<string>[] list2 = new List<string>[] { list };
                
            object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methode);    
            
            Console.WriteLine(methodInfo.Invoke(obj, list2));
           
        }

        public static void Create(string name, string parm)        
        {
            Type type = Type.GetType(name);
            
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            object obj = Activator.CreateInstance(type, args: parm);
            Console.WriteLine(obj.ToString());
        }

        public static void InfoToFile(string obj)
        {
            Type type = Type.GetType(obj.ToString());
            string path = "D:\\3_SEM_LABS\\OOP\\Lab_11_OOP\\Lab_11_OOP\\reflector.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.WriteLine($"-----------------{obj}-----------------");
                sw.WriteLine($"Ассембли:" + type.Assembly);
                foreach (ConstructorInfo constructorInfo in type.GetConstructors())
                    sw.WriteLine(constructorInfo);
                sw.WriteLine($"Методы:");
                foreach (MethodInfo methodInfo in type.GetMethods())
                    sw.WriteLine(methodInfo.Name);
                sw.WriteLine($"Поля и свойства:");
                foreach (FieldInfo fieldInfo in type.GetFields())
                    sw.WriteLine(fieldInfo);
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                    sw.WriteLine(propertyInfo);
                sw.WriteLine($"Интерфейсы:");
                foreach (Type interfaceMapping in type.GetInterfaces())
                    sw.WriteLine(interfaceMapping);
                sw.WriteLine();
            }
        }
    }
}
