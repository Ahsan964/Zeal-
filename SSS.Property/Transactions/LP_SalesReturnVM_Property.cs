using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_SalesReturnVM_Property
    {
        public List<LP_SalesOrder_Master_Property> SalesLST { get; set; }
        [Required(ErrorMessage = "Please Select Sale Invoice")]
        public string SaleInvoiceNumber { get; set; }

        public List<Customers_Property> CustomerLSt { get; set; }
        [Required(ErrorMessage = "Please Select  Customer")]
        public int customerIdx { get; set; }

        public int SaleDetailsID { get; set; }

        public int SalesMasterID { get; set; }

        public int Saleqty { get; set; }

        public int Salerate { get; set; }

        public int StockQty { get; set; }

        public decimal SaleAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal BalanceRemaining { get; set; }
        public int returnqty { get; set; }
    }
}
