using System;
using System.Collections.Generic;

namespace Solid_Übung3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IRepository
    {
        Employee GetById(int Id);
        IList<Employee> GetAll();


        void Update(int Id, Employee modifiedEmployee);
        void Insert(Employee employee);

        void Delete(int Id);
    }


    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
    }
}
