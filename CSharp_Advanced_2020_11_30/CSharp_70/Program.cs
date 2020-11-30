using System;

namespace CSharp_70
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Out Variable

            Console.Write($"Bitte geben Sie eine Zahl ein > ");
            string input = Console.ReadLine();
            int i;

            //i = Convert.ToInt32(input); // Exception anfällig, wenn die Eingabe '12345a' ist  
            //i = int.Parse(input); // Exception anfällig, wenn die Eingabe '12345a' ist  


            if (int.TryParse(input, out i)) // TryParse ist ein Ansatz von defensiven Programmieren = schauen, ob Variablen oder Parameter valide sind 
            {
                Console.WriteLine($"Die konventierte Zahl heisst {i}");
            }
            else
            {
                Console.WriteLine($"Die Zahl konnte nicht konventiert werden, weil die Eingabe nicht valide war!");
                Console.WriteLine($"Eingabe war: {input}");
                Console.WriteLine("Eingabe war: " + input);
            }

            #endregion

            #region Pattern Matching
            CheckParam("12343");
            #endregion

            #region Tupel
            Person p1 = new Person() { Firstname = "Tobias", Lastname = "Muster" };
            var person = p1.GetCompleteName();
            Console.WriteLine($"{person.Item1}{person.Item2}{person.Item3}");

            var (fn, sfn, ln) = p1; //Deconstruct(out string Firstname, out string SecondFirstname, out string Nachname) wird aufgerufen

            Console.WriteLine($"{fn}{sfn}{ln}");


            #endregion

            #region Literale
            decimal moneyValue = 1_000_000m; //1.000.000 
            Console.WriteLine($"{moneyValue}");


            float floatValue = 1234f;
            Console.WriteLine($"{floatValue}");

            int integerAsHex = 0xFFFAAA; //Hexwert als Initialisierung
            #endregion


            #region Rückgabe per Referenz
            int[] zahlen = { 5, 7, 123, 543, -344, -3 };

            ref int position = ref Zahlensuche(543, zahlen);

            position = 1_000_000;
            foreach (int  currentZahl in zahlen)
            {
                Console.WriteLine(currentZahl); 
            }

            Console.ReadLine();
            #endregion
        }


        static void CheckParam(object o)
        {
            if (o is null)
                Console.WriteLine("object is null");

            if (o is string s)
            {
                Console.WriteLine("object is a string");

                Console.WriteLine($"String-Length:{s.Length} ");
            }

            if (o is DateTime d)
                Console.WriteLine($"d ist ein Datum -> {d.ToShortDateString()}");
        }


        static public ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }
    }




    public class Person
    {
        public string Firstname { get; set; }
        public string SecondFirstname { get; set; }
        public string Lastname { get; set; }


        public (string, string, string) GetCompleteName()
        {
            return (Firstname, SecondFirstname, Lastname);
        }

        public void Deconstruct(out string Firstname, out string SecondFirstname, out string Nachname)
        {
            Firstname = this.Firstname;
            SecondFirstname = this.SecondFirstname;
            Nachname = Lastname;
        }
    }

    public class Animal
    {
        private string _name;
        private int _age;

        public Animal()
        {

        }


        // Definition von Properties in .NET 1.0
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }
    }
}
