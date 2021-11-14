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
        clsDataAccess db = new clsDataAccess();
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

            ds = db.ExecuteSQLStatement(Sql.SelectAllInvoices(), ref iNumRetValues);

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                retList.Add(new Invoice
                {
                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString()),
                    InvoiceDate = dr["InvoiceDate"].ToString(),
                    TotalCost = Int32.Parse(dr["TotalCost"].ToString())
                });
            }
            return retList;

        }
        /// <summary>
        /// this gets a list of the invoiceNums. For some reason it is adding a 0 to all of them though..
        /// </summary>
        /// <returns></returns>
        public List<Invoice> getInvoiceNums()
        {
            int iNumRetValues = 0;
            var retList = new List<Invoice>();
            DataSet ds;

            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceNums(), ref iNumRetValues);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                retList.Add(new Invoice
                {
                    InvoiceNum = Int32.Parse(dr["InvoiceNum"].ToString())
                });
            }
            return retList;
        }
        /// <summary>
        /// this gets a list of invoice dates
        /// </summary>
        /// <returns>returns a list of invoice dates as invoices</returns>
        public List<Invoice> getInvoiceDates()
        {
            int iNumRetValues = 0;
            var retList = new List<Invoice>();
            DataSet ds;

            ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDates(), ref iNumRetValues);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                retList.Add(new Invoice
                {
                    InvoiceDate = (dr["InvoiceDate"].ToString())
                });
            }
            return retList;
        }
        //public List<Invoice> getInvoiceTotalCosts()
        //{
        //    int iNumRetValues = 0;
        //    var retList = new List<Invoice>();
        //    DataSet ds;

        //    ds = db.ExecuteSQLStatement(Sql.SelectInvoiceDates(), ref iNumRetValues);

        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        retList.Add(new Invoice
        //        {
        //            TotalCost = Int32.Parse(dr["TotalCost"].ToString())
        //        });
        //    }
        //    return retList;
        //}
    }
}
