using System;

namespace SingletonSample2
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
        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }


    public sealed class ThreadSafeSingleton
    {
        private static volatile ThreadSafeSingleton instance;
        private static object lockObject = new Object();
        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    // Verhindert das beim Singleton Pattern ein Dead-Lock ensteht.
                    lock (lockObject)
                    {
                        if (instance == null)
                            instance = new ThreadSafeSingleton();
                    }
                }
                return instance;
            }
        }

        //Let’s see what C# specification tells you:
        //The volatile keyword indicates that a field might be modified by
        //multiple threads that are executing at the same time. Fields that
        //are declared volatile are not subject to compiler optimizations that
        //assume access by a single thread. This ensures that the most up-todate value is present in the field at all times.
        //In simple terms, the volatile keyword can help you to provide
        //a serialize access mechanism. In other words, all threads will
        //observe the changes by any other thread as per their execution
        //order. You will also remember that the volatile keyword is
        //applicable for class (or struct) fields; you cannot apply it to local
        //variables.

    }
}
