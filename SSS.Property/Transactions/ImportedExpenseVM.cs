using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class ImportedExpenseVM
    {
        public int PINO { get; set; }
        public string poNumber { get; set; }
        public List<LP_Performa_Invoice_Property> PerformaLISt { get; set; }
        public decimal expense { get; set; }
        public int numberOfProducts  { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal grandTotalExpense { get; set; }
        public decimal totalTD { get; set; }
        public decimal grandTotalAVPKR { get; set; }

        public List<ImportedExpenseVM> DetailList { get; set; }
        public string childHeadName { get; set; }
        public string vendorName { get; set; }
        public int idx { get; set; }
        public int commercialIdx { get; set; }
        public string ieNumber { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        //public DateTime date { get; set; }
        public string date { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        //public DateTime creationDate { get; set; }
        public string creationDate { get; set; }

        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public string status { get; set; }        
        public int vendorIdx { get; set; }
        public int coaIdx { get; set; }
        public decimal totalExpense { get; set; }
        public decimal amount { get; set; }
        public List<LP_CI_PurchaseOrder_Property> CIPO { get; set; }
        public List<Vendors_Property> VendorList { get; set; }
        public List<fourthTier_Property> childList { get; set; }//only subheadidx 13 for Imported Expense
        public List<LP_ImportedExpense_Details_Property> ImportedExpenseDetailLST { get; set; }//make a model for quotation Detail
        public string reference { get; set; }
        public decimal totalCost { get; set; }
        public decimal valueAdditionPercent { get; set; } //Default 30%
        public decimal valueAddition { get; set; }
        public decimal additionalSalesTaxPercent { get; set; } //Default 3%
        public decimal additionalSalesTax { get; set; }
        public decimal profitPercent { get; set; }
        public decimal profit { get; set; }
        public decimal finalPercentage { get; set; } //Added By Arsalan 14-04-21
    }
}
