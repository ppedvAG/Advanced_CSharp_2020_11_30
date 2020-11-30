using CSharp72;
using System;

namespace CSharp72
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int z1 = 10;
            int z2 = 15;
            int z3 = 20;

            long ergebnis = Summe(z1, z2, z3);
            long ergebnis2 = Summe(z1, zahl3: z3, zahl2: z2);
            long ergebnis3 = Summe(z1, zahl2: z2, z3);

        }


        static void ChangeValue(out int myVar)
        {
            myVar = 123; // out MUSS unbedingt eine Zuweisung bekommen
        }

        static void ReadValue(ref int myVar)
        {
            myVar = 34; //Ref ist frei.. du KANNST es überschreiben
            Console.WriteLine(myVar);
        }

        static void ReadValueWithIn(in int myVar) //in 
        {
            //myVar = 123; //Fehler -> myVar ist nur readonly -> wegen in int myVar
        }


        public static long Summe(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            return (zahl1 + zahl2 + zahl3);
        }
    }


    public class MyClass
    {
        public void GetPublic() { }
        private void GetPrivate() { }
        internal void GetInternal() { }
        protected void GetProtected() { }
        protected internal void GetProtectedInternal() { }
        protected private void GetPrivateProtected() { }

        private protected void GetPrivateProtected1() { }
    }


    public class YourClass : MyClass
    {
        MyClass mc = new MyClass();
        public void Show()
        {
            mc.GetPublic();
            //mc.GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            mc.GetInternal();
            //mc.GetProtected(); Not accessible as protected members can be accessed only through inheritance and not by creating an object.  
            mc.GetProtectedInternal();
            //mc.GetPrivateProtected(); Not accessible as Private Protected members can be accessed only through inheritance in same assembly.                




            GetPublic();
            //GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            GetInternal();
            GetProtected();
            GetProtectedInternal();
            GetPrivateProtected();

            GetPrivateProtected1();
        }
    }
}


namespace ClassLibrary1
{
    public class YourClass1 : CSharp72.MyClass
    {
        MyClass mc = new MyClass();
        public void show()
        {
            mc.GetPublic();
            //mc.GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            mc.GetInternal(); //Not accessible as internal members are not accessible outside it's assembly.  
            //mc.GetProtected(); Not accessible as protected members can be accessed only through inheritance and not by creating an object.  
            //mc.GetProtectedInternal(); Not accessible as Protected Internal members can not be accessed outside of assembly by creating an object.  
            //mc.GetPrivateProtected(); Not accessible as Private Protected members are not accessible outside of assembly by creating an object or through inheritance.      
            GetPublic();
            //GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            GetProtected();
            //GetInternal(); Not accessible as internal members are not accessible outside it's assembly.  
            GetProtectedInternal();
            //GetPrivateProtected(); Not accessible as Private Protected members are not accessible outside of assembly by creating an object or through inheritance.    
        }
    }
}
