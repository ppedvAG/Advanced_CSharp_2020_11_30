using System;

namespace CSharp_73
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            PersonStruc p1 = new PersonStruc();
            p1.Vorname = "Peter";
            p1.Nachname = "Mustermann";


            PersonStruc p2 = p1; //hier kopiert er alle Werte von dem einen Struct in das andere. 

            ref PersonStruc referenz = ref p1; //Hier werden nicht alle Member-Variablen von a nach b kopiert, sonder nur die Speicheradresse (dadurch schneller) 
            
            
            
            Span<int> values = stackalloc[] { 5, 10, 15, 20 }; //Span = Safe Code

            unsafe
            {
                int* array = stackalloc int[1024];
            }
            

        }
    }


    public struct PersonStruc // Dieses Struct schaut aus wie eine Klasse (Klasse = ReferenzTyp), ist allerdings ein Wertetyp 
    {
        public string  Vorname { get; set; }
        public string  Nachname { get; set; }

    }
}
