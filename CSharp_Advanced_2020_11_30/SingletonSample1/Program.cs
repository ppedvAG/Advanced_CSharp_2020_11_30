using System;

namespace SingletonSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private int numberOfInstances = 0;

        private Singleton()
        {
            numberOfInstances++;
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
