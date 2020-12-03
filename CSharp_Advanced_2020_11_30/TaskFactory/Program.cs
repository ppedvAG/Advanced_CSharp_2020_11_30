using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactory
{


    //Task.Start vs. Task.Factory.StartNew(...);
    //https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(IchMacheEtwasImTask);
            
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("*");
            }

            //Start New wird auch in der Funktionalität Task.Run
            Task task2 = Task.Run(IchMacheEtwasImTask); // Im Hintergrund wird die  -> Task.Factory.StartNew(IchMacheEtwasImTask); aufgerufen

            Console.ReadKey();

        }


        private static void IchMacheEtwasImTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
    }
}
