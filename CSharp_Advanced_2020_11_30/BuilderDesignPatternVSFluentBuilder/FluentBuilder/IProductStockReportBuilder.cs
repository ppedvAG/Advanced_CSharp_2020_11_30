using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPatternVSFluentBuilder.FluentBuilder
{
    public interface IProductStockReportBuilder
    {
        IProductStockReportBuilder BuildHeader();
        IProductStockReportBuilder BuildBody();
        IProductStockReportBuilder BuildFooter();
        ProductStockReport GetReport();
    }
}
