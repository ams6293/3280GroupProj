using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3280groupProj
{

    /// <summary>
    /// this class is the geters and setters for invoices
    /// </summary>
    class Invoice
    {
        public int InvoiceNum { get; set; }
        public string InvoiceDate { get; set; }
        public int TotalCost { get; set; }

        /// <summary>
        /// overrides tostring class to print invoicenum date and cost
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{InvoiceNum} {InvoiceDate} {TotalCost}";
        }
    }
}
