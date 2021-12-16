using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
     public class PurchaseVM_Property
    {
        public int? MRNIdx { get; set; }
        public List<LP_MRN_Master_Property> MRList { get; set; }
        public int idx { get; set; }
        public string poNumber { get; set; }
        [Required(ErrorMessage = "Please Select Vendor")]

        public int vendorIdx { get; set; }
        //public int MRNIdx { get; set; }
        public int POIdx { get; set; }
        public int purchaseTypeIdx { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime purchaseDate { get; set; }
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
        public DateTime lastModificationDate { get; set; }
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
        public decimal unitPrice { get; set; }
        public decimal qty { get; set; }
        public decimal amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime purchaseduedate { get; set; }

        public bool IsGRNLocked { get; set; }

        public int DepartmentID { get; set; }
        public decimal DVAmount { get; set; }
        public decimal ADVAmount { get; set; }
        public decimal TDVAmount { get; set; }
        public string ItemDescription{ get; set; }

        public string HSCode { get; set; }
        public List<Vendors_Property> VendorLST { get; set; }
        public List<LP_Purchase_Type> PurchaseType_List { get; set; }
        public List<Product_Property> ProductList { get; set; }

        public List<Departments_property> DepartmentList { get; set; }
        public List<PaymentMode_Property> Paymentmodelist { get; set; }//important to be Added
        public List<Company_Bank_Property> BankList { get; set; }
        public List<PurchaseDetails_Property> PurchaseDetailLST { get; set; }

 

    }
}

