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
            try
            {
                return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a query to get an invoice by the invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string GetInvoice(int invoiceNum)
        {
            try
            {
                return "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all details from LineItems table and ItemDesc table by a specific invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string GetAllInvoiceDetails(int invoiceNum)
        {
            try
            {
                return "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a statement that deletes an invoice with a specific invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string DeleteInvoice(int invoiceNum)
        {
            try
            {
                // for the Invoices table
                return "DELETE From Invoices WHERE InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns a statement that deletes an invoice from the LineItems table with a specific invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string DeleteLineItem(int invoiceNum)
        {
            try
            {
                // for the LineItems table
                return "DELETE From LineItems WHERE InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// string to update the total cost of an invoice by an invoice number
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string UpdateInvoice(int cost, int invoiceNum)
        {
            try
            {
                return "UPDATE Invoices SET TotalCost = " + cost.ToString() + " WHERE InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// string to insert a new invoice with it's items into the LineItems table
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="lineItemNum"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string InsertLineItems(int invoiceNum, int lineItemNum, string itemCode)
        {
            try
            {
                return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (" + invoiceNum + ", " + lineItemNum + ", '" + itemCode + "')";
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// string to insert a new invoice with it's date and total cost into the Invoice table
        /// should the date be a string??
        /// </summary>
        /// <param name="date"></param>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public string InsertInvoices(string date, int invoiceNum)
        {
            try
            {
                return "INSERT INTO Invoices (InvoiceDate, TotalCost) Values ('#" + date + "#', " + invoiceNum.ToString() + ")";
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



    }
}
