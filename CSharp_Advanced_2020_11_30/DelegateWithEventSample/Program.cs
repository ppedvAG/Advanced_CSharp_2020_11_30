using System;

namespace DelegateWithEventSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.Processing += Bl_Processing;
            bl.ProcessCompleted += Bl_ProcessCompleted;
            bl.StartProcess();



            ProcessBusinessLogic2 bl2 = new ProcessBusinessLogic2();
            bl2.ProcessCompleted += Bl2_ProcessCompleted;
            bl2.ProcessCompletedNew += Bl2_ProcessCompletedNew;
            bl2.StartProcess();



            Console.ReadLine();
        }

        private static void Bl_Processing(int percent)
        {
            Console.WriteLine("Fortschritt : " + percent.ToString());
        }

        private static void Bl2_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArg myEventArg = (MyEventArg)e;
            Console.WriteLine($"Fertig am {myEventArg.Uhrzeit.ToString()}");
        }

        private static void Bl2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process BL2 Completed!");
        }

        private static void Bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
    }
}
