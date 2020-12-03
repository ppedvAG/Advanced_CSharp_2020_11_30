using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern_with_abstract_Class
{
    /// <summary>
    /// The Builder abstract class
    /// </summary>
    public abstract class SandwichBuilder //anstatt IBuilder interface
    {
        protected Sandwich sandwich;



        // Gets sandwich instance
        public Sandwich Sandwich
        {
            get
            {
                return sandwich;
            }
        }

        // Abstract build methods
        public abstract void AddBread();
        public abstract void AddMeats();
        public abstract void AddCheese();
        public abstract void AddVeggies();
        public abstract void AddCondiments();


        
    }
}
