using System;
using System.Threading;

namespace ParameterloserThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //using System.Threading
            Thread thread = new Thread(IchBerechnerEtwasKomplexes);

            thread.Start(); //Thread wird gestartet

            thread.Join(); // Join gibt an, das wir warten, bis der Thread fertig abgearbeitet wird. 

            //thread.Abort();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("+");
            }


            Console.ReadKey();
        }


        private static void IchBerechnerEtwasKomplexes()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }
    }

    
}
