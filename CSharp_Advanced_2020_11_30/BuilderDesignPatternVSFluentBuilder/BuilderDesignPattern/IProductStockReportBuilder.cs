using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPatternVSFluentBuilder.BuilderDesignPattern
{
    public interface IProductStockReportBuilder
    {
        void BuildHeader();
        void BuildBody();
        void BuildFooter();
        ProductStockReport GetReport();
    }
}
