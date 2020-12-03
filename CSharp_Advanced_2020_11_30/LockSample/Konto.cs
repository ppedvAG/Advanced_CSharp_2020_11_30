using System;
using System.Collections.Generic;
using System.Text;

namespace LockSample
{
    public class Konto
    {
        public decimal Kontostand { get; set; }

        private object lockOject = new object();


        public void Einzahlen(decimal betrag)
        {
            lock (lockOject)
            {
                Console.WriteLine($"Kontostand vor dem einzahlen: {Kontostand}");
                Kontostand += betrag;
                Console.WriteLine($"Kontostand nach dem einzahlen: {Kontostand}");
            }
        }

        public void Abheben(decimal betrag)
        {
            lock (lockOject)
            {
                Console.WriteLine($"Kontostand vor dem abheben: {Kontostand}");
                Kontostand = -betrag;
                Console.WriteLine($"Kontostand nach dem abheben: {Kontostand}");
            }
        }
    }
}
