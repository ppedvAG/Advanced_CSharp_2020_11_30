using System;

namespace Dependency_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new MockCarService();

            carService.RepairCar(new MockCar());

            carService.RepairCar(new Car());
        }
    }

    //Fails: 
    // 1.) Hart Verdrahtet -> Refactoring benötigt einen größeren Aufwand, weil die Lösung nicht erweiterbar ist. 
    // 2.) Paralleles entwickeln wird eingeschränkt. 
    //

    #region Bad Code
    public class BadCarService //Programmierer A benötigt 3 Tage
    {
        public void RepairCar(BadCar car)
        {
            //Mach was
        }
    }

    public class BadCar //Programmierer B benötigt 5 Tage
    {
        public string Brand { get; set; }
        public string Type { get; set; }

        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }
    #endregion

    #region Good Code

    public interface ICar
    {
        string Brand { get; set; }
        string Type { get; set; }
        DateTime ConstructionDate { get; set; }
        int PS { get; set; }
    }

    public interface ICarService 
    {
        void RepairCar(ICar car);

        void CheckCar(ICar car);
    }

    public interface IDebugInfos
    {
        public void DisplayAll();
    }


    public class MockCarService : ICarService
    {
        public void CheckCar(ICar car)
        {
            
        }

        public void RepairCar(ICar car)
        {
            //MachWas
        }

        public void DisplayAll()
        {

        }

        
    }


    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }

    public class CarService : ICarService
    {
        public void CheckCar(ICar car)
        {
            throw new NotImplementedException();
        }

        public void RepairCar(ICar car)
        {
            //Machwas
        }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Type { get; set; } = "Käfer";
        public DateTime ConstructionDate { get; set; } = DateTime.Now;
        public int PS { get; set; } = 40;
    }

    #endregion
}
