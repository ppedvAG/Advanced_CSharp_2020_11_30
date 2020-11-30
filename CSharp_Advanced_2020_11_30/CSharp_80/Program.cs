using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp_80
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            WriteStreamOld();
            WriteStreamWithUsing();

            List<int?> list = null;
            list ??= new List<int?>(); //prüfen od die Liste , wenn nicht wird eine leere Liste aufgebaut, in der int? Variablen erwartet werden. 


            int? zahl = null;
            list.Add(zahl ??= 10); //Werteübergabe, prüfe ob Parameter null ist



            //Verbatim String
            string dateiPfad = "C:\\Temp\\log.txt";

            string text = "hallo hier ist die erste Zeile \n \t  und hier ist die zweite Zeile";


            string verbatimFilePath = @"c:\Temp\log.txt";
            string verbatimWithEscapeChars = @"erste Zeile Text \n Zweite Zeile Text....geht leider nix mehr";




            #region Interface-Neuerungen
            
            //Standard interface implementierung
            Test testClass = new Test();
            testClass.TestMe(12);
            testClass.ITested();


            //Interface Implementierungen
            Test2 testClass2 = new Test2();
            testClass2.IsTested();

            ITest2 testInterface2 = new Test2();
            testInterface2.TestMe(123);
            testInterface2.IsTested();
            #endregion
        }

        public static void WriteStreamOld()
        {
            FileStream stream = null;
            StringBuilder dane = new StringBuilder("");

            string pfad = string.Empty;
            try
            {
                stream = new FileStream(pfad, FileMode.Open);

                int w;
                do
                {
                    w = stream.ReadByte();
                    if (w != -1)
                        dane.Append((char)w);
                }
                while ((w > 0));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Brak pliku {0}", pfad);
            }
            finally
            {
                //Im finally-block werden Verbindungen (SQL, File Handler, HTTPClient, etc... abgebaut!!!!)
                if (stream != null)
                {
                    stream.Close(); //Ganz wichtige CodeZeile
                    
                }
            }

        }


        public static void WriteStreamWithUsing()
        {
            string path = "abc....irgendwas";
            //Create the file.
            using (FileStream fs = File.Create(path)) // FileStream.Dispose()-Methode -> Methode ist dafür zuständig, dass FileStream.Closed aufgerufen wird 
            {
                AddText(fs, "This is some text");
                AddText(fs, "This is some more text,");
                AddText(fs, "\r\nand this is on a new line");
                AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

                for (int i = 1; i < 120; i++)
                {
                    AddText(fs, Convert.ToChar(i).ToString());
                }
            }//Aufruf von FileStream.Dispose();

            using (Person p = new Person())
            {

            }//Nach dieser geschweiften Klammer soll Person p abgebaut werden (automatisch) 
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }

    
    public class Person : IDisposable
    {
        public string Name { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Jetzt wird alles aufgeräumt! hahahhahah ");
        }
    }

    public struct  Point
    {
        public int X { get; set; }
        public int Y { get; set; }


        //Readonly gibt den Member-Variablen einen Schreibschutz
        public readonly void Berrechnen(int offsetX, int offsetY)
        {
            Console.Write(X); //Funktioniert

            offsetY = 0;

            //X += 1; // Gibt einen Fehler aus, weil man versucht die Membervariable X zu überschreiben

        }
    }






    public interface ITest
    {
        void TestMe(int a); //alle Interface Methoden sind public. Diese Aussage gilt ab C# 8.0 nicht mehr

        bool ITested();
    }

    public class Test : ITest
    {
        public bool ITested()
        {
            throw new NotImplementedException();
        }

        public void TestMe(int a)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITest2
    {
        void TestMe(int a)
        {
            Console.WriteLine($"{a}");
        }

        bool IsTested();


        void Print();
    }

    public class Test2 : ITest2
    {
        public bool IsTested()
        {
            return true;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }

   


}
