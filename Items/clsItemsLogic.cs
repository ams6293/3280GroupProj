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
    }
}
