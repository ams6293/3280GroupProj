using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using _3280groupProj.Main;  /// to access clsMainSQL.cs

namespace _3280groupProj.Items
{
    class clsMainLogic
    {
        /// <summary>
        /// class constructor
        /// </summary>
        public clsMainLogic()
        {
            // instantiate Data Access Class
            db = new clsDataAccess();

            ds = new DataSet(); //Holds the return values, from database

            clsSQL = new clsMainSQL(); // instantiate the SQL class

            cInvoice = new Invoice(); // instantiate the Invoice class

            cItem = new Item(); // instantiate the Item class

            cLineItems = new LineItems(); // instantiate the LineItems class

            iRet = 0;   //Number of return values -- rows, basically
        }



        #region Attributes

        /// <summary>
        /// object of the data access class
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// A dataset to hold the values returned form the data access class
        /// </summary>
        DataSet ds;

        /// <summary>
        /// a class that holds all of the SQL statements
        /// </summary>
        clsMainSQL clsSQL;

        /// <summary>
        /// a class that holds the invoice variables -- do I need this?
        /// </summary>
        Invoice cInvoice;

        /// <summary>
        /// a class that holds the item variables -- do I need this?
        /// </summary>
        Item cItem;

        /// <summary>
        /// a class that holds the LineItems variabls -- do I need this?
        /// </summary>
        LineItems cLineItems;

        /// <summary>
        /// string to hold an SQL statement
        /// </summary>
        private string sSQL;

        /// <summary>
        /// Number of return values -- passed in by reference
        /// </summary>
        public int iRet;

        #endregion


        /// <summary>
        /// creates a list of items that will be used for the item combo boxes
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems()
        {
            try
            {
                // create a list that holds Item data
                List<Item> lstItems = new List<Item>();

                // create the SQL statemnt that will return the Items
                sSQL = clsSQL.GetItems();

                //Extract the items and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //Loop through the data and create Item classes
                for (int i = 0; i < iRet; i++)
                {
                    //Create a new user object with the item information
                    lstItems.Add(new Item
                    {
                        ItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        ItemDesc = ds.Tables[0].Rows[i][1].ToString(),
                        Cost = Int32.Parse(ds.Tables[0].Rows[i][2].ToString()),

                    });
                }
                // return the list of items
                return lstItems;
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of items of an invoice given the invoices ID
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public List<Item> GetSelectedInvoice(int invoiceNum)
        {
            try
            {
                // create the list of items
                List<Item> lstInvoice = new List<Item>();

                // get the SQL statement
                sSQL = clsSQL.GetAllInvoiceDetails(invoiceNum);

                //Extract the items and put them into the DataSet
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //Loop through the data and create Item classes
                for (int i = 0; i < iRet; i++)
                {
                    //Create a new user object with the item information
                    lstInvoice.Add(new Item
                    {
                        ItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        ItemDesc = ds.Tables[0].Rows[i][1].ToString(),
                        Cost = Int32.Parse(ds.Tables[0].Rows[i][2].ToString()),

                    });
                }

                // return the list of items in that invoice
                return lstInvoice;
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new invoice into the database, returns the invoice number
        /// </summary>
        /// <param name="lstItem"></param>
        /// <param name="invoiceNum"></param>
        /// <param name="cost"></param>
        /// <param name="date"></param>
        public int InsertInvoice(List<Item> lstItem, int invoiceNum, int cost, string date)
        {
            try
            {
                // get that invoice number from the cost and date
                sSQL = clsSQL.GetInvoiceNumber();
                string sID = db.ExecuteScalarSQL(sSQL); // storing the invoice ID

                // add the cost and the date to the invoice table
                sSQL = clsSQL.InsertInvoices(date, cost, sID);
                db.ExecuteNonQuery(sSQL);

                // loop through the list of items, adding them to the LineItems table --> index = the lineItemNumber -- i is the index
                for (int i = 0; i < lstItem.Count(); i++)
                {
                    sSQL = clsSQL.InsertLineItems(Int32.Parse(sID), i, lstItem[i].ItemCode.ToString());
                    db.ExecuteNonQuery(sSQL);
                }

                // return the invoice number of the new invoice
                return Int32.Parse(sID);
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing invoice in the Invoice and LineItems tables
        /// </summary>
        /// <param name="lstItem"></param>
        /// <param name="invoiceNum"></param>
        /// <param name="cost"></param>
        public void UpdateInvoice(List<Item> lstItem, int invoiceNum, int cost)
        {
            try
            {
                // delete all of the LineItem values for that invoice
                // so that deleted items in the datagrid get deleted in the table too
                sSQL = clsSQL.DeleteLineItem(invoiceNum);

                // delete the invoice from the LineItems table
                db.ExecuteNonQuery(sSQL);

                // insert all of the new LineItem values for that invoice
                // loop through the list of items, adding them to the LineItems table --> index = the lineItemNumber -- i is the index
                for (int i = 0; i < lstItem.Count(); i++)
                {
                    sSQL = clsSQL.InsertLineItems(invoiceNum, i, lstItem[i].ItemCode.ToString());
                    db.ExecuteNonQuery(sSQL);
                }

                // update the cost of that invoice
                sSQL = clsSQL.UpdateInvoice(cost, invoiceNum);
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the cost of a given invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        public int GetCost(int invoiceNum)
        {
            try
            {
                // get the string to return the total cost of that invoice
                sSQL = clsSQL.GetInvoiceCost(invoiceNum);
                string x = db.ExecuteScalarSQL(sSQL);

                // return the invoice
                return Int32.Parse(x);
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Deletes an invoice from the entire database given the invoice number
        /// </summary>
        /// <param name="invoiceNum"></param>
        public void DeleteInvoice (int invoiceNum)
        {
            try
            {
                // get the string to remove the invoice from the LineItems table    // DO THIS FIRST!!
                sSQL = clsSQL.DeleteLineItem(invoiceNum);

                // delete the invoice from the LineItems table
                db.ExecuteNonQuery(sSQL);

                // get the string to remove the invoice from the Invoice table
                sSQL = clsSQL.DeleteInvoice(invoiceNum);

                // delete the invoice from the Invoice table
                db.ExecuteNonQuery(sSQL);
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
