using System;
using System.Collections.Generic;

namespace BuilderDesignPatternVSFluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.Product>
            {
                new BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.Product { Name = "Monitor", Price = 200.50 },
                new BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.Product { Name = "Mouse", Price = 20.41 },
                new BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.Product { Name = "Keyboard", Price = 30.15}
            };
            var builder = new BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.ProductStockReportBuilder(products);
            var director = new BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern.ProductStockReportDirector(builder);
            director.BuildStockReport();
            var report = builder.GetReport();
            Console.WriteLine(report);




            var productsFB = new List<BuilderDesignPatternVSFluentBuilder.FluentBuilder.Product>
            {
                new BuilderDesignPatternVSFluentBuilder.FluentBuilder.Product { Name = "Monitor", Price = 200.50 },
                new BuilderDesignPatternVSFluentBuilder.FluentBuilder.Product { Name = "Mouse", Price = 20.41 },
                new BuilderDesignPatternVSFluentBuilder.FluentBuilder.Product { Name = "Keyboard", Price = 30.15}
            };
            var builderFB = new BuilderDesignPatternVSFluentBuilder.FluentBuilder.ProductStockReportBuilder(productsFB);
            var directorFB = new BuilderDesignPatternVSFluentBuilder.FluentBuilder.ProductStockReportDirector(builderFB);
            director.BuildStockReport();
            var reportFB = builder.GetReport();
            Console.WriteLine(report);
        }
    }
}
