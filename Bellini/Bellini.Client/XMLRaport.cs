using System;
using System.Linq;
using System.Text;
using Bellini.Data;

using System.Xml;

namespace Bellini.Client
{
    class XMLRaport
    {
        public void StartRaport()
        {
            var dbResult = (from sales in SessionState.db.Sales
                            select new
                            {
                                vendorName = sales.Product.Vendor.VendorName,
                                date = sales.Date,
                                sum = sales.Quantity * sales.Product.BasePrice

                            }).GroupBy(g => g.vendorName).ToDictionary(k => k.Key, k => k.GroupBy(g => g.date));

            string fileName = "..\\..\\Sales-by-Vendors-report.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");
                foreach (var vendor in dbResult)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", vendor.Key);
                    foreach (var date in vendor.Value)
                    {
                        var sum = date.ToList().Select(s => s.sum).Sum();

                        writer.WriteStartElement("summary");
                        writer.WriteAttributeString("date", date.Key.ToString());
                        writer.WriteAttributeString("total-sum", sum.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                Console.WriteLine("Document {0} created.", fileName);
            }

        }
    }
}
