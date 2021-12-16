using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_InventoryLogs_Property
    {
        public int idx { get; set; }
        public int productIdx { get; set; }
        public decimal stock { get; set; }
        public decimal qty { get; set; }
        public decimal amount { get; set; }
        public int productTypeIdx { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalAmount { get; set; }
        public DateTime creationDate { get; set; }
        public int TransactionTypeID { get; set; }
        public int MasterID { get; set; }
        public int FullReturn { get; set; }
        public int BRANCHID { get; set; }
        public int wareHouseIdx { get; set; }

    }
}
