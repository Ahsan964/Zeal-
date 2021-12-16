using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_PurchaseReturnVM_Property
    {
        public List<LP_P_Invoice_Property> PurchaseLST { get; set; }
        [Required(ErrorMessage = "Please Select Purchase Invoice")]
        public string PurhaseInvoiceNumber { get; set; }

        public List<Vendors_Property> VendorLST { get; set; }
        [Required(ErrorMessage = "Please Select  Vendor")]
        public int vendorIdx { get; set; }

        public int PurchaseDetailsID { get; set; }

        public int PurchaseMasterID { get; set; }

        public int qty { get; set; }

        public int unitPrice { get; set; }

        public int StockQty { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal BalanceRemaining { get; set; }
        public int returnqty { get; set; }
    }
}
