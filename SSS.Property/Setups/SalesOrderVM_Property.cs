using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class SalesOrderVM_Property
    {
        // Added By Ahsan
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime DeliveryDate { get; set; }
        public string ItemDescription { get; set; }
        public List<Branch_Property> BranchList { get; set; }
        public int branchIdx { get; set; }
        public string DriverName { get; set; }
        public string DriverCnic { get; set; }

        [Required]
        public int salesTypeIdx { get; set; }
        public int? qsIdx { get; set; }
        public List<LP_Quotation_Master_Property> QSList { get; set; }
        public int idx { get; set; }
        public string soNumber { get; set; }
        [Required(ErrorMessage = "Please Select Customer")]

        public int customerIdx { get; set; }
        //public int MRNIdx { get; set; }
        public int customerBankIdx { get; set; }
        //public int purchaseTypeIdx { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime salesorderDate { get; set; }
        public string description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal totalAmount { get; set; }
        public decimal netAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balanceAmount { get; set; }
        //[Required(ErrorMessage = "Please Select Payment")]
        public int paymentModeIdx { get; set; }
        public int bankIdx { get; set; }
        public string accorChequeNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime paidDate { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public int paymentStatus { get; set; }
        public string status { get; set; }
        public int isPaid { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public decimal taxAount { get; set; }
        public string itemName { get; set; }
        public int itemIdx { get; set; }
        public decimal salePrice { get; set; }
        public decimal qty { get; set; }
        public decimal costPrice { get; set; } //Added By Arsalan
        public decimal stock { get; set; } //Added By Arsalan
        public decimal amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime salesorderduedate { get; set; }

        public List<Customers_Property> CustomerLST { get; set; }

        public List<Product_Property> ProductList { get; set; }
        public List<SalesPerson_Property> SalesPersonList { get; set; }

        public List<PaymentMode_Property> Paymentmodelist { get; set; }//important to be Added
        public List<Company_Bank_Property> BankList { get; set; }

        public List<SalesOrdersDetails_Property> SalesOrderDetailLST { get; set; }//make a model for quotation Detail
        public List<Taxes_Property> TaxList { get; set; }
        public List<LP_salesTaxes_Property> salesTaxesLST { get; set; }
        public string reference { get; set; } //Added By Arsalan
        public int wareHouseIdx { get; set; } //Added By Arsalan
        public List<WareHouse_Property> wareHouseList { get; set; } //Added By Arsalan
        public int salespersonIdx { get; set; }
        public decimal shippingCost { get; set; } //Added By Arsalan
    }
}
