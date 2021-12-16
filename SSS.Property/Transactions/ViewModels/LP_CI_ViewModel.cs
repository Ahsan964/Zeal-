using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SSS.Property.Setups.Accounts;

namespace SSS.Property.Transactions.ViewModels
{
  public  class LP_CI_ViewModel
    {
        // Added By Ahsan
        public decimal TD { get; set; }
        public int vendorIdx { get; set; }
        public int coaIdx { get; set; }
        public List<Vendors_Property> VendorList { get; set; }
        public List<fourthTier_Property> childList { get; set; }
        public List<LP_CI_ViewModel> DetailList { get; set; }
        public string childHeadName { get; set; }
        public string vendorName { get; set; }

        public int IEcheck { get; set; }
        public int idx { get; set; }

        public int PINO { get; set; }
        public string poNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime purchaseDate { get; set; }
        public string description { get; set; }
        public decimal totalAmount { get; set; }
        public decimal netAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balanceAmount { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public DateTime lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public int paymentStatus { get; set; }
        public string status { get; set; }
        public decimal grandTotalAVPKR { get; set; } //Added By Arsalan 10-04-21 For Imported Expense 
        public int numberOfProducts { get; set; } //Added By Arsalan 10-04-21
        public decimal totalTD { get; set; }//Added By Arsalan 10-04-21
        public decimal ExchangeRate { get; set; }//Added By Arsalan 10-04-21
        public int itemIdx { get; set; }
        public decimal unitPrice { get; set; }
        public decimal qty { get; set; }
        public decimal amount { get; set; }
        public string ItemDescription { get; set; }
        public decimal DVRate { get; set; }
        public decimal TDVRate { get; set; }
        public decimal ADVRate { get; set; }
        public decimal ASSVCI { get; set; }
        public decimal Landing { get; set; }

        public decimal CDPercntage { get; set; }
        public decimal RDPercentage { get; set; }

        public decimal ACDPercentage { get; set; }

        public decimal STPercentage { get; set; }

        public decimal ASTPercentage { get; set; }

        public decimal ITPercentage { get; set; }
        
        public decimal TDTax { get; set; }
        public decimal CleaningPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int productIdx { get; set; }
        public decimal stock { get; set; }
        public List<Product_Property> ProductList{ get; set; }
        public List<LP_Performa_Invoice_Property> PerformaLISt { get; set; }
        public List<LP_Performa_Invoice_Details_Property> PerformaDTLLISt { get; set; }
        public List<LP_CI_PurchaseDetails_Property> CILIST { get; set; }

        // Added By Ahsan
        public decimal clearingExpensePerProduct { get; set; }
        public decimal pricePerProduct { get; set; }
        public decimal TotalAVPkr { get; set; }
    }
}
