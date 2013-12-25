using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.IO;
using Bellini.Data.Library;
using Bellini.Data.Migrations;
using Bellini.Data.ReportGenerators;
using Bellini.Library;
using Bellini.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Bellini.Library;
using System.Web;
using System.Web.Script.Serialization;

namespace Bellini.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SupermarketSQLDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketSQLDbContext, Configuration>());

            //PdfReportGenerator.GeneratePdfReport("..\\..\\PdfReport.pdf");
            //Console.WriteLine("PDF report generated");

            //JsonReportGenerator.GenerateJsonReports("..\\..\\Product-Reports");
            //Console.WriteLine("JSON reports generated");

            //XmlReportGenerator.GenerateXmlReport("..\\..\\XmlReport.xml");
            //VendorExpenseReader vendorExpenseReader = new VendorExpenseReader();

            //List<VendorExpense> vendorExpenses = VendorExpenseReader.Start();
            //vendorExpenseReader.GetVendorExpensesInDb(vendorExpenses);

            //ProductTaxesDbContext context = new ProductTaxesDbContext();
            //foreach (var tax in context.ProductTaxes)
            //{
            //    Console.WriteLine(tax.ProductName);
            //}

            
            Console.WriteLine("Written to Excel");
        }
    }
}