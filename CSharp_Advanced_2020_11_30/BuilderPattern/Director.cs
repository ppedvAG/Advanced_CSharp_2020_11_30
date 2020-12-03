using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class Director
    {
        IBuilder builder;

        public void Construct(IBuilder builder)
        {
            this.builder = builder;
            this.builder.StartUpOperations();
            this.builder.ErstelleBasisGerät();
            this.builder.Hinzufügen_Reifen();
            this.builder.Hinzufügen_Scheinwerfer();
            builder.EndOperations();
        }
    }
}
