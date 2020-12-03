using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMitException
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                //Wir starten 4 Tasks

                t1 = new Task(MachEinenFehler1);
                t1.Start();


                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);

                t4 = Task.Run(MachKeinenFehler);

                //Im try Catch-Block muss Task.WaitAll ausgeführt werden. 
                Task.WaitAll(t1, t2, t3, t4); //Warte bis alle Task beendet sind und hier wird auch das ExceptionHandling Scharf

            }
            catch(AggregateException ex) //<-
            {
                foreach(Exception einzelneException in ex.InnerExceptions)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER:");
                    Console.WriteLine(einzelneException.Message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            


            //Verketten von Tasks mithilfe von Fortsetzungstasks
            //Task status

            if (t4.IsCompleted)
            {
                Console.WriteLine("Task 4 ist fertig");
            }

            // Task t3 
            if (t3.IsCompleted)
            {
                Console.WriteLine("Task 3 ist fertig");
            }

            if (t3.IsFaulted)
            {
                Console.WriteLine("Task 3 hat einen Fehler");
            }

            if (t3.IsCanceled)
            {
                Console.WriteLine("Task 3 wurde abgebrochen");
            }

        }


        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }


        private static void MachEinenFehler2()
        {
            Thread.Sleep(5000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(8000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("MachKeinenFehler wird ausgeführt");
        }
    }
}
