using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _3280groupProj.Items
{
    class clsItemsLogic
    {
        clsDataAccess db = new clsDataAccess();
        clsItemsSQL sql = new clsItemsSQL();

        /// <summary>
        /// this gets a list of all items by code with description and cost.
        /// </summary>
        /// <returns>list of all items</returns>
        public List<Item> getItems()
        {
            int iNumRetValues = 0;
            var retList = new List<Item>();
            DataSet ds;
            try
            {
                ds = db.ExecuteSQLStatement(sql.selectAllItems(), ref iNumRetValues);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    retList.Add(new Item
                    {
                        ItemCode = dr["ItemCode"].ToString(),
                        ItemDesc = dr["ItemDesc"].ToString(),
                        Cost = Int32.Parse(dr["Cost"].ToString())
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return retList;
        }
        /// <summary>
        /// This method allows the user to update the item description and or cost given the correct item code
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="iCost"></param>
        /// <param name="sItemCode"></param>
        public void updateItem(string sItemDesc, int iCost, string sItemCode)
        {
            try
            {
                db.ExecuteNonQuery(sql.updateItem(sItemDesc, iCost, sItemCode));
            }
            catch (Exception a)
            {
                throw a;
            }
        }
        /// <summary>
        /// This method allows the user to enter a new item in the database
        /// </summary>
        /// <param name="sDescription"></param>
        /// <param name="iCost"></param>
        /// <param name="sItemCode"></param>
        public void insertNewItem(string sDescription, int iCost, string sItemCode)
        {
            try
            {
                db.ExecuteNonQuery(sql.insertItem(sDescription, iCost, sItemCode));
            }
            catch (Exception b)
            {
                throw b;
            }
        }

        /// <summary>
        /// this method allows the user to delete a row from the database by itemcode
        /// </summary>
        /// <param name="sItemCode"></param>
        public void deleteItem(string sItemCode)
        {
            try
            {
                db.ExecuteNonQuery(sql.deleteItem(sItemCode));
            }
            catch (Exception c)
            {
                throw c;
            }
        }
    }
}
