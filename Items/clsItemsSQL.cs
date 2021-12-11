using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj.Items
{
    class clsItemsSQL
    {
        /// <summary>
        /// this method will display all current items in the item list
        /// </summary>
        /// <returns></returns>
        public string selectAllItems()
        {
            string sSQL = "select ItemCode, ItemDesc, Cost from ItemDesc";
            return sSQL;
        }
        /// <summary>
        /// this will return a specific invoice number containing a given itemcode
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string selectInvoicebyItem(int iInvoiceNum, string sItemCode)
        {
            string sSQL = "select distinct " + iInvoiceNum + " from LineItems where ItemCode = " + sItemCode;
            return sSQL;
        }
        /// <summary>
        /// this phrase will update the item description and cost given a specific itemcode
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string updateItem(string sItemDesc, int iCost, string sItemCode)
        {
            string sSQL = "Update ItemDesc Set ItemDesc = '" + sItemDesc + "', Cost = '" + iCost + "' where ItemCode = '" + sItemCode + "'";
            return sSQL;
        }
        /// <summary>
        /// this phrase will insert a new item in the list
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string insertItem(string sItemDesc, int iCost, string sItemCode)
        {
            string sSQL = "Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('" + sItemCode + "','" + sItemDesc + "','" + iCost + "')";
            return sSQL;
        }
        /// <summary>
        /// this phrase will delete a specific item from the list given a specific itemcode
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string deleteItem(string sItemCode)
        {
            string sSQL = "Delete from ItemDesc Where ItemCode = '" + sItemCode + "'";
            return sSQL;
        }

    }
}
