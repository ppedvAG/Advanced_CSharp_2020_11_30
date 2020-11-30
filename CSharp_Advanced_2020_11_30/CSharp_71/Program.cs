using System;
using System.Threading.Tasks;

namespace CSharp_71
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start...");
            await Task.Delay(3000); //Wartet 3 Sekunden´
            Console.Write("Ausgabe nach 3 Sek:");



            Console.WriteLine("Optionale Parameter");
            OptionaleParameter();

            Console.ReadLine();
        }

        //Nullable Datentypen
        private static void OptionaleParam(int? i = null) // i
        {
            if (i.HasValue)
            {
                Console.WriteLine($"{i.Value}");
            }

            decimal? d = null;
        }

        private static void OptionaleParameter(int i = default) //i=0 -  //Optionaler Parameter -> Methodenaufruf kann auch so ausschauen -> OptionaleParameter();
        {
            Console.WriteLine(i);
        }
    }
}
