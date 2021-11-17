using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{
    class Item
    {

        /// <summary>
        /// this class is the geters and setters for items
        /// </summary>
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Cost { get; set; }
        public int LineItemNum { get; set; }

        /// <summary>
        /// overrides tostring class to print LineItemNum, ItemCode, ItemDesc, and Cost
        /// </summary>
        /// <returns> returns the appropriate string based on what info is provided.</returns>
        public override string ToString()
        {

            return $"{ItemCode} {ItemDesc} {Cost} {LineItemNum}";
        }
    }
}
