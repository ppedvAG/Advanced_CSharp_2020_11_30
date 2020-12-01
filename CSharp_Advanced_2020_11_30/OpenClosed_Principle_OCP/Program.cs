using System;

namespace OpenClosed_Principle_OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Insert into employee table.
            return true;
        }
    }


    #region BadCode
    public class ReportGenerator
    {
        /// <summary>
        /// Report type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }
    #endregion


    #region Bessere Variante
    //Open - Part
    public class ReportGeneratorBase
    {
        public virtual void ReportGenerator(Employee em)
        {
            //From Base
        }
    }



    //Close - Part
    public class CrstalReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Generatore crystal report
        }
    }

    //Close-Part
    public class PDFReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Genrator für PDF Report
        }
    }

    #endregion




}
