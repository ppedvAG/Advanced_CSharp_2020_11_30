using System;

namespace EventSample
{

    //Erstellen eines eigenen Delegate-Typs
    delegate int NumbChange(int n); //Zeiger der auf eine Methode/Function zeigt


    public delegate void Del(string message);
    class Program
    {

        static int num = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Delegates vor .NET 2.0 

            NumbChange nc1 = new NumbChange(AddNum); //Verwende AddNum (muss die selbe Methoden-Signatur vorweisen, wie diese in Delegate angegeben wurde 
            //nc1(33); //AddNum wird gecalled

            nc1 += MultNum; // mit += kann man weitere Methoden an dem Delegate dranhängen
            //nc1(15);

            Console.WriteLine($"{nc1(10)}"); // Ausgabe der letzten angehängten Methode

            nc1 -= AddNum; //AddNum wurde vom Delegate entfernt und wird auch nicht mehr aufgerufen. 


            NumbChange numberChanger1 = new NumbChange(AddNum);
            NumbChange numberChanger2 = new NumbChange(AddNum);

            nc1 = numberChanger1;
            nc1(11);

            nc1 += numberChanger2;

            nc1(99);

            Console.ReadLine();
            #endregion


            #region Delegate with Callbacks
            Del handler = DelegateMethod;
            handler("Hallo World");

            MethodWithCallback(1,2, handler);
            Console.ReadLine();
            #endregion


            #region Action<T> und Func<T>

            //Geht hier nur mit Methoden mit void 
            Action a1 = new Action(A);
            a1 += B;
            a1(); // Hier wird Methode A und B gecalled


            Action<int> a2 = C;
            a2(123);

            Action<int, int, int> a3 = AddNums;
            a3(123, 456, 789);

            Func<int, int, int> rechner = Add;

            int result = rechner(22, 33);
            #endregion
        }


        #region MEthoden die für das Beispiel Delegates vor .NET 2.0 gelten
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        #endregion


        #region Methode mit einem Callback
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            //Berechne irgendwas mit param1 und param2
            //SQL Abfrage + Wartezeit

            //Callback Methode wird am Ende der Methode aufgerufen. 
            callback("The number is " + (param1 + param2).ToString());
        }
        #endregion


        #region Methoden zu Action und Function
        public static void A()
        {
            Console.WriteLine("A");
        }

        public static void B()
        {
            Console.WriteLine("B");
        }

        static void C(int zahl)
        {
            Console.WriteLine("C" + zahl);
        }


        public static void AddNums(int a, int b, int c)
        {
            int result = a + b + c;

            Console.WriteLine($"{result}");
        }



        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }
        #endregion
    }
}
