using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BuilderPattern
{
    public interface IBuilder
    {
        void StartUpOperations();
        void ErstelleBasisGerät();
        void Hinzufügen_Reifen();
        void Hinzufügen_Scheinwerfer();
        void EndOperations();

        Product GetVehicle();
    }
}
