using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
 public  class LP_ConsigmentDetails
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _InvoiceNo;
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }

        private int _ParentDocumentId;
        public int ParentDocumentId
        {
            get { return _ParentDocumentId; }
            set { _ParentDocumentId = value; }
        }

        private int _status;
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _creationDate;
        public DateTime creationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        private int _createdByUserIdx;
        public int createdByUserIdx
        {
            get { return _createdByUserIdx; }
            set { _createdByUserIdx = value; }
        }

        private DateTime _lastModificationDate;
        public DateTime lastModificationDate
        {
            get { return _lastModificationDate; }
            set { _lastModificationDate = value; }
        }

        private int _lastModifiedByUserIdx;
        public int lastModifiedByUserIdx
        {
            get { return _lastModifiedByUserIdx; }
            set { _lastModifiedByUserIdx = value; }
        }

        private int _Productidx;
        public int Productidx
        {
            get { return _Productidx; }
            set { _Productidx = value; }
        }

        private decimal _Transfer;
        public decimal Transfer
        {
            get { return _Transfer; }
            set { _Transfer = value; }
        }

        private decimal _Custom;
        public decimal Custom
        {
            get { return _Custom; }
            set { _Custom = value; }
        }

        private decimal _Regulity;
        public decimal Regulity
        {
            get { return _Regulity; }
            set { _Regulity = value; }
        }

        private decimal _SalesTax;
        public decimal SalesTax
        {
            get { return _SalesTax; }
            set { _SalesTax = value; }
        }

        private decimal _IncomeTax;
        public decimal IncomeTax
        {
            get { return _IncomeTax; }
            set { _IncomeTax = value; }
        }

        private decimal _Freight;
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }

        private decimal _Exise;
        public decimal Exise
        {
            get { return _Exise; }
            set { _Exise = value; }
        }

        private decimal _Delivery;
        public decimal Delivery
        {
            get { return _Delivery; }
            set { _Delivery = value; }
        }

        private decimal _Container;
        public decimal Container
        {
            get { return _Container; }
            set { _Container = value; }
        }

        private decimal _KICT;
        public decimal KICT
        {
            get { return _KICT; }
            set { _KICT = value; }
        }

        private decimal _INF;
        public decimal INF
        {
            get { return _INF; }
            set { _INF = value; }
        }

        private decimal _LCBankCharges;
        public decimal LCBankCharges
        {
            get { return _LCBankCharges; }
            set { _LCBankCharges = value; }
        }

        private decimal _Insurance;
        public decimal Insurance
        {
            get { return _Insurance; }
            set { _Insurance = value; }
        }

        private decimal _CFKICT;
        public decimal CFKICT
        {
            get { return _CFKICT; }
            set { _CFKICT = value; }
        }

        private decimal _LULoading;
        public decimal LULoading
        {
            get { return _LULoading; }
            set { _LULoading = value; }
        }

        private decimal _CustomEntry;
        public decimal CustomEntry
        {
            get { return _CustomEntry; }
            set { _CustomEntry = value; }
        }

        private decimal _Appraisment;
        public decimal Appraisment
        {
            get { return _Appraisment; }
            set { _Appraisment = value; }
        }

        private decimal _Agency;
        public decimal Agency
        {
            get { return _Agency; }
            set { _Agency = value; }
        }

        private decimal _Labour;
        public decimal Labour
        {
            get { return _Labour; }
            set { _Labour = value; }
        }

        private decimal _TotalClearing;
        public decimal TotalClearing
        {
            get { return _TotalClearing; }
            set { _TotalClearing = value; }
        }

        private decimal _AdDSalesTax;
        public decimal AdDSalesTax
        {
            get { return _AdDSalesTax; }
            set { _AdDSalesTax = value; }
        }

        private decimal _FastTrackProfit;
        public decimal FastTrackProfit
        {
            get { return _FastTrackProfit; }
            set { _FastTrackProfit = value; }
        }

        private decimal _ValueAddition1;
        public decimal ValueAddition1
        {
            get { return _ValueAddition1; }
            set { _ValueAddition1 = value; }
        }

        private decimal _ValueAddition2;
        public decimal ValueAddition2
        {
            get { return _ValueAddition2; }
            set { _ValueAddition2 = value; }
        }

        private decimal _CalculatedPercentage;
        public decimal CalculatedPercentage
        {
            get { return _CalculatedPercentage; }
            set { _CalculatedPercentage = value; }
        }
        private decimal _TotalClearingFinal;
        public decimal TotalClearingFinal
        {
            get { return _TotalClearingFinal; }
            set { _TotalClearingFinal = value; }
        }
    }
}
