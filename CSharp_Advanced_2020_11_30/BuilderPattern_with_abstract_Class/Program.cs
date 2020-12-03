using System;

namespace BuilderPattern_with_abstract_Class
{
    class Program
    {
        static void Main(string[] args)
        {

            HamAndCheese hamAndCheese = new HamAndCheese();

            SandwichMaker sandwichMaker = new SandwichMaker(hamAndCheese);
            sandwichMaker.buildSandwich();


            Sandwich sandwich = hamAndCheese.Sandwich;
            sandwich.Show();

            


        }
    }
}
