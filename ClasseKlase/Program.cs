using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
namespace dogtest
{
    class Program
    {
        static void Main(string[] args)
        {
           Dog Dog1 = new Dog("foo");
            Dog Dog2 = new Dog("foo");
            if(Dog2 == Dog1)
            {
                Console.WriteLine("OK");
            }
            if (Dog2.Equals(Dog1)) 
            {
                Console.WriteLine("Nice");
            }
        }
    }

    class Head
    {
        string size;
        public Head(string size)
        {
            this.size = size;
        }
        public string getSize() { return size; }
        public void setSize(string size) { this.size = size; }

    }
    class Dog
    {
        string name;
        Head head;
        public Dog(string name)
        {
            this.name = name;
            this.head = new Head("20");
           
        }
        public string getName() { return name; }
        public void setName(string name) { this.name = name; }

    }


}














