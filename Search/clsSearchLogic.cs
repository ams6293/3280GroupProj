using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{
    class clsSearchLogic
    {
        /// <summary>
        /// this gives us a link to our database
        /// </summary>
        clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// this is a link to all sql queries
        /// </summary>
        clsSearchSQL Sql = new clsSearchSQL();

      
        /// <summary>
        /// this gets all the Invoices and adds them to a list of invoices to be displayed later
        /// </summary>
        /// <returns></returns>
        public List<Invoice> getInvoices()
        {
            int iNumRetValues = 0;
            var retList = new List<Invoice>();
            DataSet ds;
            try
            {
                ds = db.ExecuteSQLStatement(Sql.SelectAllInvoices(), ref iNumRetValues);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    retList.Add(new Invoice
                    {
                        InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                        InvoiceDate = dr["InvoiceDate"].ToString(),
                        TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
            return retList;

        }
        /// <summary>
        /// this gets a list of the invoiceNums. For some reason it is adding a 0 to all of them though..
        /// </summary>
        /// <returns></returns>
        public List<int> getInvoiceNums()
        {
            int iNumRetValues = 0;
            var retList = new List<int>();
            DataSet ds;
            try
            {
                ds = db.ExecuteSQLStatement(Sql.SelectInvoiceNums(), ref iNumRetValues);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    retList.Add(Int32.Parse(dr["InvoiceNum"].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            return retList;
        }
        /// <summary>
        /// this gets a list of invoice dates
        /// </summary>
        /// <returns>returns a list of invoice dates</returns>
        public List<string> getInvoiceDates()
        {
            int iNumRetValues = 0;
            var retList = new List<string>();
            DataSet ds;
            try
            {
                ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDates(), ref iNumRetValues);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    retList.Add(dr["InvoiceDate"].ToString());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            return retList;
        }

        /// <summary>
        /// this gets a list of the invoice total costs
        /// </summary>
        /// <returns> a list of the invoice total costs</returns>
        public List<int> getInvoiceTotalCosts()
        {
            int iNumRetValues = 0;
            var retList = new List<int>();
            DataSet ds;
            try
            {
                ds = db.ExecuteSQLStatement(Sql.SelectInvoiceTotals(), ref iNumRetValues);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    retList.Add(Int32.Parse(dr["TotalCost"].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
            return retList;
        }

        public List<Invoice> getFilterResults(string invoiceID, string invoiceDate, string  invoiceCost)
        {
            int iNumRetValues = 0;
            var retList = new List<Invoice>();
            DataSet ds;
            try
            {
                if (invoiceID == "")
                {
                    if (invoiceDate == "")
                    {
                        ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByTotal(invoiceCost), ref iNumRetValues);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            retList.Add(new Invoice
                            {
                                InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                InvoiceDate = dr["InvoiceDate"].ToString(),
                                TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                            });
                        }
                    }
                    else
                    {
                        if (invoiceCost == "")
                        {
                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByDate(invoiceDate), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }
                        }
                        else
                        {
                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByTotalAndDate(invoiceCost, invoiceDate), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }
                        }
                    }
                }
                else
                {
                    if (invoiceDate == "")
                    {
                        if (invoiceCost == "")
                        {
                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByID(invoiceID), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }

                        }
                        else
                        {
                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByIDAndTotal(invoiceID, invoiceCost), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }
                        }
                    }
                    else
                    {
                        if (invoiceCost == "")
                        {

                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByIDAndDate(invoiceID, invoiceDate), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }
                        }
                        else
                        {
                            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDataByIDAndDateAndTotal(invoiceID, invoiceDate, invoiceCost), ref iNumRetValues);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                retList.Add(new Invoice
                                {
                                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                                    InvoiceDate = dr["InvoiceDate"].ToString(),
                                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retList;
        }
    }
}
