using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.ViewModels
{
    public class LP_PerformaInvoice_ViewModel
    {
        public int productCatIdx { get; set; }
        public int branchIdx { get; set; }
        public List<Branch_Property> BranchList { get; set; }
        public int idx { get; set; }
        public string poNumber { get; set; }
        public int vendorIdx { get; set; }
        public int gridVendorIdx { get; set; }//Added By Arsalan 05-04-21
        public int purchaseTypeIdx { get; set; }
        [DataType(DataType.Date)]
        public DateTime purchaseDate { get; set; }
        public string description { get; set; }
        public decimal totalAmount { get; set; }
        public decimal netAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balanceAmount { get; set; }
        public int paymentModeIdx { get; set; }
        public int bankIdx { get; set; }
        public string accorChequeNumber { get; set; }
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
        public DateTime purchaseduedate { get; set; }
        public bool IsGRNLocked { get; set; }
        public int DepartmentID { get; set; }
        public string ContainerNo { get; set; }
        public string DocumentNumber { get; set; }
        public decimal unitPrice { get; set; }
        public decimal qty { get; set; }
        public decimal amount { get; set; }
        public decimal DVAmount { get; set; }
        public decimal ADVAmount { get; set; }
        public decimal TotalADVAmount { get; set; } //Added By Arsalan 05-04-21
        public decimal TDVAmount { get; set; }
        public string ItemDescription { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal grandTotalAVPKR { get; set; }
        public string HSCode { get; set; }
        public string Category { get; set; }
        public List<Vendors_Property> VendorLST { get; set; }
        public int numberOfProducts { get; set; }//Added By Arsalan 10-04-21
        public string reference { get; set; } // Added By Arsalan 03-04-21
        public List<Product_Property> ProductList { get; set; }
        public int warehouseIdx { get; set; }
        //public List<Departments_property> DepartmentList { get; set; }
        public List<WareHouse_Property> WarehouseList { get; set; }
        public List<PaymentMode_Property> Paymentmodelist { get; set; }//important to be Added
        public List<Company_Bank_Property> BankList { get; set; }
        public List<LP_Performa_Invoice_Details_Property> CommercialDetailList { get; set; }
    }
}
