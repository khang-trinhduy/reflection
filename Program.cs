using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ReflectionTest
{
    class Program
    {
        private static int a = 5, b = 10, c = 20; // <== field

        public static string k = "Anh Khang", m = "初音ミク", ac = "look";
        static void Main(string[] args)
        {
            Type testType = typeof(Humanization);
            Type id = typeof(System.Int32);
            Type name = typeof(String);
            Type [] types =  {id, name};
            ConstructorInfo ctor = testType.GetConstructor(types);
            if(ctor != null)
            {       
                object instance = ctor.Invoke(new object [] {1412, "Duy Khang"} );
                MethodInfo methodInfo = testType.GetMethod("Humanoid");
                Console.WriteLine(methodInfo.Invoke(instance, null));
            }
            Console.ReadKey();
            Console.WriteLine(k + " " + m + "->" + ac);
            Console.WriteLine("Please enter the name of the variable that you wish to change:");
            string varName = Console.ReadLine();
            Type t = typeof(Program); //get type
            FieldInfo fieldInfo = t.GetField(varName, BindingFlags.Public | BindingFlags.Static); //private, static: get field 
            if(fieldInfo != null)
            {
                Console.WriteLine("The current value of " + fieldInfo.Name + " is " + fieldInfo.GetValue(null) + ". You may enter a new value now:");
                string newValue = Console.ReadLine();
                fieldInfo.SetValue(null, newValue);
                Console.WriteLine(k + " " + m + "->" + ac);
                Console.ReadKey();
            }
        }
    }
    class Humanization
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Humanization(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public void Humanoid()
        {
            System.Console.WriteLine($"Identity {ID} name {Name}");
        }
    }
}