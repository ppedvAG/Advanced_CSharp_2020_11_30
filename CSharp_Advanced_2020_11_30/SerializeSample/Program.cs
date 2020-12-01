using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test-Objekt
            Person p1 = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 83,
                Kontostand = 100_000
            };

            #region Binäre Serialisierung

            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite("Person.bin");
            formatter.Serialize(stream, p1);
            stream.Close(); // gehört eigentlich in den finally Block...oder wir verwenden ein using-Statement
            #endregion

            #region Binäres einlesen
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)formatter.Deserialize(stream);
            stream.Close();


            Console.WriteLine("Binäre Serialisierung - Ergebnis:");
            Console.WriteLine(geladenePerson.Vorname);
            Console.WriteLine(geladenePerson.Nachname);
            Console.WriteLine(geladenePerson.Alter);
            Console.WriteLine(geladenePerson.Kontostand);


            #endregion

            #region XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, p1);
            stream.Close();



            stream = File.OpenRead("Person.xml");
            Person geladenePersonXML = (Person)xmlSerializer.Deserialize(stream);
            Console.WriteLine("XML Serialisierung - Ergebnis:");
            Console.WriteLine(geladenePersonXML.Vorname);
            Console.WriteLine(geladenePersonXML.Nachname);
            Console.WriteLine(geladenePersonXML.Alter);
            Console.WriteLine(geladenePersonXML.Kontostand);
            #endregion

            #region JSON 

            string jsonString = JsonConvert.SerializeObject(p1);
            File.WriteAllText("Person.json", jsonString);
            Console.WriteLine(jsonString);



            Person jsonPerson = JsonConvert.DeserializeObject<Person>(jsonString);
            Console.WriteLine(jsonPerson.Vorname);
            Console.WriteLine(jsonPerson.Nachname);
            Console.WriteLine(jsonPerson.Alter);
            Console.WriteLine(jsonPerson.Kontostand);

            #endregion



            #region CSV Serializer
            p1.Serialize("Person.csv");


            Person p2 = new Person();
            p2.Deserialize("Person.csv");

            Console.WriteLine(p2.Vorname);
            Console.WriteLine(p2.Nachname);
            Console.WriteLine(p2.Alter);
            Console.WriteLine(p2.Kontostand);

            #endregion
            Console.ReadLine();
        }
    }
}
