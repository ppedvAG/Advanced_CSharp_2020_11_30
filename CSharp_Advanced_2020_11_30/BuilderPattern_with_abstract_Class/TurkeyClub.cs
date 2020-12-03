using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern_with_abstract_Class
{
    /// <summary>
    /// A ConcreteBuilder class
    /// </summary>
    class TurkeyClub : SandwichBuilder
    {
        public TurkeyClub()
        {
            sandwich = new Sandwich("Turkey Club");
        }

        public override void AddBread()
        {
            sandwich["bread"] = "12-Grain";
        }

        public override void AddMeats()
        {
            sandwich["meat"] = "Turkey";
        }

        public override void AddCheese()
        {
            sandwich["cheese"] = "Swiss";
        }

        public override void AddVeggies()
        {
            sandwich["veggies"] = "Lettuce, Tomato";
        }

        public override void AddCondiments()
        {
            sandwich["condiments"] = "Mayo";
        }

        
    }
}
