using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPatternVSFluentBuilder.FluentBuilder
{
    public class ProductStockReportDirector
    {
        private readonly IProductStockReportBuilder _productStockReportBuilder;

        public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
        {
            _productStockReportBuilder = productStockReportBuilder;
        }

        public void BuildStockReport()
        {
            _productStockReportBuilder
                .BuildHeader()
                .BuildBody()
                .BuildFooter();
        }
    }
}
