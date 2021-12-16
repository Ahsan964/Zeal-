using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_salesTaxes_Property
    {
        public int idx { get; set; }
        public int taxType { get; set; } //Added By Arsalan
        public int quotationIdx { get; set; } //Added By Arsalan
        public int taxIdx { get; set; }
        public int saleIdx { get; set; }
        public DateTime creationDate { get; set; }
        public int createdBy { get; set; }
        public bool status { get; set; }
        public decimal taxPercent { get; set; }
    }
}
