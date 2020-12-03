using System;
using System.Threading;
using System.Threading.Tasks;

namespace EinfacherTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(IchMacheEteasInEinemTask);
            easyTask.Start();
            easyTask.Wait();
            
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("*");
            }

            Console.ReadKey();
        }

        public static void IchMacheEteasInEinemTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
    }
}
