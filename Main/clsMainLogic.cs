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



        // method to add an invoice to the datagrid


        // method to update an item in the datagrid

        
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





















        /*
         * IGNORE THIS FOR NOW 
         * 
         * ///////////////////// DOESN'T WORK -- only after the second selection, it's always one item behind
                int sum = 0;
                for (int i = 0; i < itemDescDataGrid.Items.Count - 1; i++)
                {
                    sum += (Int32.Parse((itemDescDataGrid.Columns[2].GetCellContent(itemDescDataGrid.Items[i]) as TextBlock).Text));
                }

                totalLbl.Content = "$ " + sum + ".00";
         */

        /*
         * ///////////////////// DOESN'T WORK -- only after the second selection, it's always one item behind
                int sum = 0;
                for (int i = 0; i < itemDescDataGrid1.Items.Count - 1; i++)
                {
                    // adds each row in the cost column together -- or it SHOULD!!
                    sum += (Int32.Parse((itemDescDataGrid1.Columns[2].GetCellContent(itemDescDataGrid1.Items[i]) as TextBlock).Text));
                }

                // displays the total in a label
                totalLbl2.Content = "$ " + sum + ".00";
         * 
         */




    }
}
