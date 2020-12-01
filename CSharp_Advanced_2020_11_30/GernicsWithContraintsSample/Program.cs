using System;
using System.Collections;

namespace GernicsWithContraintsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implementierung von DataStore<T> where T : class
            //    DataStore<string> store1 = new DataStore<string>();
            //    DataStore<MyClass> store2 = new DataStore<MyClass>();
            //    DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();

            //    DataStore<MyStruct> store4 = new DataStore<MyStruct>();
            //    DataStore<int> store5 = new DataStore<int>();
            //    DataStore<ArrayList> store5 = new DataStore<ArrayList>();
            //}




            //DataStore1<T> where T : struct 

            //DataStore1<string> store1 = new DataStore1<string>();
            //DataStore1<MyClass> store2 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store3 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store6 = new DataStore1<MyStruct>();
            //DataStore1<int> store7 = new DataStore1<int>();




        }


    }
    class DataStore<T> where T : class
    {
        public T Data { get; set; }
    }

    class DataStore1<T> where T : struct
    {
        public T Data { get; set; }
    }

    class DataStore2<T> where T : Animal
    {
        public T Data { get; set; }
    }




        public class MyClass
    {

    }

    public  interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }


    public class Animal
    {
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "Schäferhund";
    }
}
