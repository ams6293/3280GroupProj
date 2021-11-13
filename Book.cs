using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{
    /// <summary>
    /// this class is the getters and setters for the book/item object
    /// </summary>
    public class Book
    {
        public string ItemCode { get; set; }

        public string ItemDesc { get; set; }
        public int Cost { get; set; }

        /// <summary>
        /// overrides to string class for book to print title description and cost
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ItemCode} {ItemDesc} {Cost}";
        }
    }
}
