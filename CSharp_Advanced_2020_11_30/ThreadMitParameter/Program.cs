using System;
using System.Threading;

namespace ThreadMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart paramThreadStart = new ParameterizedThreadStart(MachEtwasInEinemThreadMitParameter);

            Thread thread = new Thread(paramThreadStart);
            thread.Start(33);
            thread.Join();

            Console.WriteLine("Bin fertig!");
            Console.ReadKey();
        }




        private static void MachEtwasInEinemThreadMitParameter(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                //Thread.Sleep(500);
                Console.Write("#");
            }
        }
    }




}
