using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{
    class clsSearchSQL
    {
        /// <summary>
        /// This will be used to display all invoice data in the datagrid
        /// </summary>
        /// <returns>All invoice data sql statement</returns>
        public string SelectAllInvoices()
        {
            string sSQL = "SELECT * FROM Invoices";
            return sSQL;
        }



        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByID(string sInvoiceID)

        {

            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;

            return sSQL;

        }
        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID and Date.
        /// </summary>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByIDAndDate(string sInvoiceID, string sDate)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + "AND InvoiceDate = #" + sDate + "#";
            return sSQL;
        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID and Date and TotalCost.
        /// </summary>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByIDAndDateAndTotal(string sInvoiceID, string sDate, string sTotal)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDate + "# AND TotalCost = " + sTotal;
            return sSQL;
        }


        /// <summary>
        /// This SQL gets all data on an invoice for a given TotalCost.
        /// </summary>
        /// <param name="sTotal">The TotalCost for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByTotal(string sTotal)

        {

            string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + sTotal;

            return sSQL;

        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given TotalCost and Date.
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByTotalAndDate(string sTotal, string sDate)

        {

            string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + sTotal + " AND InvoiceDate = #" + sDate + "#";

            return sSQL;

        }

        /// <summary>
        /// This SQL gets all data on an invoice for a given Date.
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceDataByDate(string sDate)

        {

            string sSQL = "SELECT * FROM Invoices WHERE TotalCost = #" + sDate + "#";

            return sSQL;

        }
    }
}

