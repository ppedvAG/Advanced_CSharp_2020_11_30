using System;
using System.Reflection;

namespace HelloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly geladeneDll = Assembly.LoadFrom("netcoreapp3.1\\TrumpTaschenrechner.dll");

            //var allTypes = geladeneDll.GetTypes(); // Gebe alle Typen aus der dll (class, struc, delegate, enums...)
            Type trumpTaschenrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            object tr = Activator.CreateInstance(trumpTaschenrechnerTyp);

            MethodInfo addInfo = trumpTaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            var result = addInfo.Invoke(tr, new object[] { 6, 4 });

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
