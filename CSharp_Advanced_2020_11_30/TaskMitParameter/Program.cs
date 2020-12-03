using System;
using System.Threading.Tasks;

namespace TaskMitParameter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Katze katze = new Katze();

            //Task.Factory.StartNew mit Parameter und Rückgabewert als Task<string> bzw task.Result
            Task<string> task = Task.Factory.StartNew(GibtDatumMitInput, katze);
            Task<string> task1 = Task.Factory.StartNew(GibtDatumMitInput, katze);
            Task<string> task2 = Task.Factory.StartNew(GibtDatumMitInput, katze);
            Task<string> task3 = Task.Factory.StartNew(GibtDatumMitInput, katze);
            Task.WaitAll(task, task1, task2, task3);
            Console.WriteLine(task.Result);



            //Task.Factory.StartNew mit Parameter und Rückgabewert + Verwendung von async/await Pattern -> Rückgabewert ist der eigentlich Typ und kein Task<T>
            string stringOutput = await Task.Factory.StartNew(GibtDatumMitInput, katze);
            
            //Da Task.Run intern Task.Factory.StartNew verwendet, wäre auch hier eine Lösung interessant, mit der man Parameter übergibt und einen Rückgabewert erhält.
            string val = await Task.Run(() => GibtDatumMitInput(katze));
            string val1 = await Task.Run(() => GibtDatumMitInput(katze));
            string val2 = await Task.Run(() => GibtDatumMitInput(katze));
            string val3 = await Task.Run(() => GibtDatumMitInput(katze));
            Console.WriteLine(val);


            Task<string> myTask = Task.Run(() => GibtDatumMitInput(katze));
            Task.WaitAll(myTask);

            ; //Alle Task müssen in sich abgeschlossen sein, dann geht es auch hier weiter! 

            Console.WriteLine(task.Result); //Hier drin steht die ausgabe von -> DateTime.Now.ToLongDateString();
            Console.WriteLine(val);
            Console.ReadKey();

        }

        private static string GibtDatumMitInput(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            Console.WriteLine(katze.Name);

            //int dauer = (int)input;

            //Thread.Sleep(dauer);
            return DateTime.Now.ToLongDateString();
        }

    }


    public class Katze
    {
        public string Name { get; set; } = "Tom";
    }
}
