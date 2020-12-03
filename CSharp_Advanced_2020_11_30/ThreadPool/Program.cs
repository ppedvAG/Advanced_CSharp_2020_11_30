using System;
using System.Threading;

namespace ThreadPoolSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Methode1);
            ThreadPool.QueueUserWorkItem(Methode2);
            ThreadPool.QueueUserWorkItem(Methode3);
            Console.WriteLine("Bin fertig!");
            Console.ReadKey();
        }

        static void ThreadPoolWithJoin ()
        {
            int threadCount = 5;
            Console.WriteLine("Starting Threads");

            using (CountdownEvent counter = new CountdownEvent(threadCount))
            {
                for (int i = 0; i < threadCount; i++)
                {
                    int sleepTime = i;
                    ThreadPool.QueueUserWorkItem(_ => ThreadPoolJoin(sleepTime, counter));
                }
                counter.Wait();
            }
            Console.WriteLine("All threads finished execution");
            Console.ReadLine();
        }

        static void ThreadPoolJoin(int seconds, CountdownEvent evt)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Hi from Thread:{0}", Thread.CurrentThread.ManagedThreadId);
            evt.Signal();
        }


        private static void Methode1(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("#");
            }
        }

        private static void Methode2(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("-");
            }
        }

        private static void Methode3(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write("*");
            }
        }
    }
}
