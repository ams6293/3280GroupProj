using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace _3280groupProj.Main
{
    class clsMainSQL
    {

        /// <summary>
        /// returns a query to get all the items
        /// </summary>
        /// <returns></returns>
        public string GetItems()
        {
            return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
        }


        /// <summary>
        /// returns a query to get the selected code from combo box
        /// </summary>
        /// <returns></returns>
        public string GetSelectedCode(string itemID)
        {
            return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc WHERE ItemCode LIKE '%" + itemID + "'";
        }

        /// <summary>
        /// returns a query to get an invoice by the invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string GetInvoice(int invoiceNum)
        {
            return "SELECT* FROM Invoices WHERE InvoiceNum = " + invoiceNum.ToString();
        }

        /// <summary>
        /// returns a statement that deletes an invoice with a specific invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string DeleteInvoice(int invoiceNum)
        {
            return "DELETE From Invoices WHERE InvoiceNum = " + invoiceNum.ToString();    // for the Invoices table
        }

        /// <summary>
        /// returns a statement that deletes an invoice from the LineItems table with a specific invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string DeleteLineItem(int invoiceNum)
        {
            return "DELETE From LineItems WHERE InvoiceNum = " + invoiceNum.ToString();     // for the LineItems table
        }


        public string DeleteInvoiceLine(int invoiceNum)
        {
            return "DELETE From Invoices WHERE InvoiceNum = " + invoiceNum.ToString();
        }


        /// update an invoice
        /// - remove an item
        /// - add an item
        /// - change total cost
        /// - delete an invoice




    }
}
