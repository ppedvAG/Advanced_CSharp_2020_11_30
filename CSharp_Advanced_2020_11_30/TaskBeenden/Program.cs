using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            //Variante mit Factory StartNew und CancelationToken
            Task task = Task.Factory.StartNew(MeineMethodeMitAbbrechen, source);
            
            //Variante mit Task Instance und CancelationToken
            Task t = new Task(MeineMethodeMitAbbrechen, token);
            t.Start();

            //Variante mit Task.Run und CancelationToken
            Task.Run(() => MeineMethodeMitAbbrechen(token));

            Thread.Sleep(10000);
            Console.WriteLine("Jetzt wird der Task geschlossen:");
            source.Cancel();

            Console.ReadKey();
        }

        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationToken source = (CancellationToken)param;

            while (true) //Entdlosschleife
            {
                Console.WriteLine("zzz......zzzzz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;

            }
        }
    }
}
