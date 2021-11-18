using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{
    class LineItems
    {
        /// <summary>
        /// this class is the geters and setters for LineItems table
        /// </summary>
        public int InvoiceNum { get; set; }
        public int LineItemNum { get; set; }
        public string ItemCode { get; set; }
        public int Cost { get; set; }

        /// <summary>
        /// overrides tostring class to print InvoiceNum, ItemCode, LineItemNum, and Cost
        /// </summary>
        /// <returns> returns the appropriate string based on what info is provided.</returns>
        public override string ToString()
        {

            return $"{InvoiceNum} {ItemCode} {LineItemNum} {Cost}";
        }
    }
}
