using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class Car : IBuilder
    {
        private string brandName;
        private Product product;

        //ctor + Tab + Tab
        public Car(string brand)
        {
            this.brandName = brand;
            this.product = new Product();
        }


        public void EndOperations()
        {
            //Nothing in this case
        }

        public void ErstelleBasisGerät()
        {
            product.Add("2 HEadlights are added");
        }

        public void Hinzufügen_Reifen()
        {
            product.Add("4 wheels are added");
        }

        public void Hinzufügen_Scheinwerfer()
        {
            product.Add("2 Headlights are added");
        }

        public void StartUpOperations()
        {
            product.Add(string.Format("Car Model name: {0}", this.brandName));
        }

        public Product GetVehicle()
        {
            return product;
        }

        
    }
}
