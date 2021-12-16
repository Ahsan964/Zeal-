using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_Consigment_ViewModel
    {
        public int idx { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Invoicedate { get; set; }
        public string Reference { get; set; }
        public int ParentDocumentId { get; set; }
        public int ParentDocumentType { get; set; }
        public int status { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public DateTime lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }

        public List<Product_Property> ProductList { get; set; }
        public List<LP_CI_PurchaseOrder_Property> CIPO { get; set; }
        public List<LP_CI_PurchaseDetails_Property> CIDetailsPO { get; set; }
        public List<LP_ConsigmentDetails> ConsigmentDetails { get; set; }

        public int Productidx { get; set; }
        public decimal Transfer { get; set; }
        public decimal Custom { get; set; }
        public decimal Regulity { get; set; }
        public decimal SalesTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal Freight { get; set; }
        public decimal Exise { get; set; }
        public decimal Delivery { get; set; }
        public decimal Container { get; set; }
        public decimal KICT { get; set; }
        public decimal INF { get; set; }
        public decimal LCBankCharges { get; set; }
        public decimal Insurance { get; set; }
        public decimal CFKICT { get; set; }
        public decimal LULoading { get; set; }
        public decimal CustomEntry { get; set; }
        public decimal Appraisment { get; set; }
        public decimal Agency { get; set; }
        public decimal Labour { get; set; }
        public decimal TotalClearing { get; set; }
        public decimal AdDSalesTax { get; set; }
        public decimal FastTrackProfit { get; set; }
        public decimal ValueAddition1 { get; set; }
        public decimal ValueAddition2 { get; set; }
        public decimal CalculatedPercentage { get; set; }
        public decimal TotalClearingFinal { get; set; }
    }
}
