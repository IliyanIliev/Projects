using System;
using System.Collections.Generic;
using System.Linq;
using Bellini.Library;
using System.Xml;
using Bellini.Data;

namespace Bellini.Client
{
    public class VendorExpenseReader
    {
        public static List<VendorExpense> Start()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\Vendor-Expenses.xml");
            XmlNodeList sales = doc.SelectNodes("//sale");
            List<VendorExpense> vendorExpenses = new List<VendorExpense>();
            foreach (XmlNode sale in sales)
            {
                string vendorName = sale.Attributes["vendor"].Value;
                VendorExpense newVendorExpense = new VendorExpense(vendorName);
                vendorExpenses.Add(newVendorExpense);

                List<Expense> expenses = new List<Expense>();
                foreach (XmlNode expense in sale.ChildNodes)
                {
                    string month = expense.Attributes["month"].Value;
                    string sum = expense.InnerText;
                    expenses.Add(new Expense(month, float.Parse(sum)));
                }
                newVendorExpense.Expenses = expenses;
            }

            return vendorExpenses;
        }

        public void GetVendorExpensesInDb(ICollection<VendorExpense> vendorExpenses)
        {
            foreach (var vendorExpense in vendorExpenses)
            {
                VendorExpense currentVE = new VendorExpense();
                currentVE = vendorExpense;
                SessionState.db.VendorExpenses.Add(currentVE);
            }
            SessionState.db.SaveChanges();
        }
    }
}
