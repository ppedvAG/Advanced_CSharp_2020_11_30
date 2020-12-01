using System;
using System.Collections.Generic;

namespace GenericSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Verwendung von Generischen Klassen
            IList<string> stringListe = new List<string>();

            DataStore<string> store = new DataStore<string>();
            store.AddOrUpdate(0, "Mumbai");
            store.AddOrUpdate(1, "London");
            store.AddOrUpdate(2, "Madrid");
            
            
            string currentCity = store.GetData(2);

            if (!string.IsNullOrEmpty(currentCity))
            {
                //Mach was mit String
            }

            Console.WriteLine($"Die ausgelesene Stadt ist {currentCity}");





            DataStore<int?> intStore = new DataStore<int?>();
            intStore.AddOrUpdate(1, 12);
            intStore.AddOrUpdate(1, 32); 
            intStore.AddOrUpdate(1, 34);
            intStore.AddOrUpdate(1, 33);
            intStore.AddOrUpdate(1, 1);
            intStore.AddOrUpdate(1, 7);
            intStore.AddOrUpdate(1, 19);


            int? value = intStore.GetData(1);
           
            if (value.HasValue)
            {
                Console.WriteLine($"Die ausgelesene Lottozahl  ist {value.Value}");
            }
            

            //Verwendung von Generischen Methoden
            store.DisplayDefaultOf<int>();
            store.DisplayDefaultOf<DateTime>();


            Console.ReadLine();
        }
    }

    public class DataStore<T>
    {
        public T Data { get; set; }
        public T[] _data = new T[10];

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData (int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T); //Alternativ ist eine Exception möglich.
        }

        public void DisplayDefaultOf<TT>() //Generische Methode. Der Platzhalter wird jedesmal expiziet angegeben. 
        {
            var val = default(TT);
            Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
        }

    }
}
