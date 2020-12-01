using System;
using System.Diagnostics;

namespace CSharp_90
{
    class Program
    {
        //Benefits of Records
        //Simple to Setup
        //Thread Safe per Definition
        //Easy/safe to share


        //When to UseRecords
        //Capturing external Data z.B. WhaetherService, SWAPI.dev
        //APICalls
        //Processing Data
        //Readonly Data


        //When not to used Records
        //Working with Entity Framework (when you need to change the data)
        static void Main(string[] args)
        {
            Person record1 = new Person("Tim", "Corey");
            Person record2 = new Person("Tim", "Corey");

            PersonClass class1 = new PersonClass("Tim", "Corey");
            PersonClass class2 = new PersonClass("Tim", "Corey");

            Console.WriteLine($"PersonClass -> ToString() : {class1}");
            Console.WriteLine($"PersonRecord -> ToString() : {record1}");

            Stopwatch stopWatch = new Stopwatch();


            #region class vs.record ToString() + Benchmark
            Console.WriteLine("----------------------- Class->ToString() ----------------------------");
            stopWatch.Start();
            Console.WriteLine($"PersonClass -> ToString() : {class1.ToString()}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Reference Check: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("----------------------- Record->ToString() ----------------------------");
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine($"PersonRecord -> ToString() : {record1.ToString()}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Value Check: {stopWatch.ElapsedMilliseconds}");
            #endregion

            stopWatch.Reset();
            #region class vs record  Equals + Benchmark
            Console.WriteLine("----------------------- Class->Equal ----------------------------");
            stopWatch.Start();
            Console.WriteLine($"PersonClass -> Compare() : {Equals(class1, class2)}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Reference Check: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("----------------------- Record->Equal ----------------------------");
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine($"PersonRecord -> Compare() : {Equals(record1, record2)}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Value Check: {stopWatch.ElapsedMilliseconds}");
            #endregion

            stopWatch.Reset();
            #region class/record vs ReferenceEqual + Benchmark
            Console.WriteLine("----------------------- Class->ReferenceEqual ----------------------------");
            stopWatch.Start();
            Console.WriteLine($"PersonClass -> Compare() : {ReferenceEquals(class1, class2)}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Reference Check: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("----------------------- Record->ReferenceEqual ----------------------------");
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine($"PersonRecord -> Compare() : {ReferenceEquals(record1, record2)}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Value Check: {stopWatch.ElapsedMilliseconds}");
            #endregion

            stopWatch.Reset();
            #region class/record vs ==  + Benchmark
            Console.WriteLine("----------------------- Class-> == Operator ----------------------------");
            stopWatch.Start();
            Console.WriteLine($"PersonClass -> == Operator : {class1 == class2}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Reference Check: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("----------------------- Record-> == Operator ----------------------------");
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine($"PersonRecord -> == Operator : {record1 == record2}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Value Check: {stopWatch.ElapsedMilliseconds}");
            #endregion


            stopWatch.Reset();
            #region class vs record -> HashCode()
            Console.WriteLine("----------------------- Class->GetHashCode() ----------------------------");
            stopWatch.Start();
            Console.WriteLine($"Class1 -> GetHashCode() : {class1.GetHashCode()}");
            Console.WriteLine($"Class2 -> GetHashCode() : {class2.GetHashCode()}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Reference Check: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("----------------------- Record->GetHashCode() ----------------------------");
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine($"Record1 -> GetHashCode() : {record1.GetHashCode()}");
            Console.WriteLine($"Record2 -> GetHashCode() : {record2.GetHashCode()}");
            stopWatch.Stop();
            Console.WriteLine($"Benchmark-Time for Value Check: {stopWatch.ElapsedMilliseconds}");
            #endregion


            Console.ReadLine();

            Console.WriteLine("################## Record -> Tupel with decoupeling ######################");
            var (fn, ln) = record1;



            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");


            Console.WriteLine("################## Record -> Record Object copy  ######################");


            Person record3 = record1 with
            {
                FirstName = "John"
            };


            Console.WriteLine("################## Record -> AccessModifier  ######################");


            Person p = new Person("Nina", "Hagen");

            Person person3 = new("Kevin", "Winter");

            Console.ReadLine();
            Console.WriteLine();






        }
    }


    // Person ist eigentlich eine Klasse mit mehr Funktionalität
    // Immutable -> Werte können nicht geändert werden
    public record Person(string FirstName, string LastName);
    public record Employee(int id, string FirstName, string LastName) : Person(FirstName, LastName);

    public record Person2(string FirstName, string LastName)
    {
        internal string FirstName { get; init; } = FirstName;
    }
    public record Person3(string FirstName, string LastName)
    {
        internal string FirstName { get; init; } = FirstName;

        public string Fillanem { get => $"{FirstName}{LastName}"; }
    }

    public class PersonClass
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public PersonClass(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }
}
