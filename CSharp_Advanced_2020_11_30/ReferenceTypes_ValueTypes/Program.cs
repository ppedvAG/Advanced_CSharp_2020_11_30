using System;
using System.Collections.Generic;

namespace ReferenceTypes_ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            //Value Ty´pes
            int a = 77;

            int b = a; // b ist 77
            a = 75; //B behält den Wert 77 


            //Reference Typ 
            string name1 = "Peter";
            string name2 = name1; //Hier sollte die Refernce übergeben 
            name1 = "Petra";


            List<Person> personenListe = new List<Person>();
            personenListe.Add(new Person { Name = "Anna" });
            personenListe.Add(new Person { Name = "Bernd" });
            personenListe.Add(new Person { Name = "Caro" });


            Person selectPerson = personenListe[1];
            selectPerson.Name = "Birgit";


            foreach (Person person in personenListe)
            {
                Console.WriteLine($"Person: {person.Name}");
            }




            Console.WriteLine($"{name2}");
            Console.ReadLine();
            
        }
    }


    public class Person
    {
        public string Name { get; set; }

        //ctor + tab + tab
        public Person()
        {

        }
    }
}
