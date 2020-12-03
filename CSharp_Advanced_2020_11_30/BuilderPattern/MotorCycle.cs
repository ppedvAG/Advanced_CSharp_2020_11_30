using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class MotorCycle : IBuilder
    {
        private string brandName;
        private Product product;

        public MotorCycle(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }

        public void StartUpOperations()
        {   //Nothing in this case        
        }

        public void ErstelleBasisGerät()
        {
            product.Add("This is a body of a Motorcycle");
        }

        public void Hinzufügen_Reifen()
        {
            product.Add("2 wheels are added");
        }

        public void Hinzufügen_Scheinwerfer()
        {
            product.Add("1 Headlights are added");
        }

        public void EndOperations()
        {
            //Finishing up with brandname             
            product.Add(string.Format("Motorcycle Model name :{0}", this.brandName));
        }

        public Product GetVehicle()
        {
            return product;
        }
    }
}
