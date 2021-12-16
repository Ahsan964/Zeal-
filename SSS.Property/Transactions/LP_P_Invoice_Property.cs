using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_P_Invoice_Property
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

        private int _InvoiceType;
        public int InvoiceType
        {
            get { return _InvoiceType; }
            set { _InvoiceType = value; }
        }

        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        private decimal _NetAmount;
        public decimal NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }

        private int _CreatedBy;
        public int CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private DateTime _CreatedDate;
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _PaymentType;
        public int PaymentType
        {
            get { return _PaymentType; }
            set { _PaymentType = value; }
        }

        private bool _IsPaid;
        public bool IsPaid
        {
            get { return _IsPaid; }
            set { _IsPaid = value; }
        }

        private decimal _PaidAmount;
        public decimal PaidAmount
        {
            get { return _PaidAmount; }
            set { _PaidAmount = value; }
        }

        private decimal _BalanceAmount;
        public decimal BalanceAmount
        {
            get { return _BalanceAmount; }
            set { _BalanceAmount = value; }
        }

        private int _ModifiedBy;
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        private DateTime _ModifiedDate;
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        
            private bool _Taxable;
        public bool Taxable
        {
            get { return _Taxable; }
            set { _Taxable = value; }
        }
        private int _ParentDocID;
        public int ParentDocID
        {
            get { return _ParentDocID; }
            set { _ParentDocID = value; }
        }

        private int _VendorID;
        public int VendorID
        {
            get { return _VendorID; }
            set { _VendorID = value; }
        }
        private decimal _ShippingCost;
        public decimal ShippingCost
        {
            get { return _ShippingCost; }
            set { _ShippingCost = value; }
        }

        private decimal _TaxAmount;
        public decimal TaxAmount
        {
            get { return _TaxAmount; }
            set { _TaxAmount = value; }
        }

        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }

        private int _BankId;
        public int BankId
        {
            get { return _BankId; }
            set { _BankId = value; }
        }

        private string _AccountChequeNo;
        public string AccountChequeNo
        {
            get { return _AccountChequeNo; }
            set { _AccountChequeNo = value; }
        }
        private DataTable _taxData;
        public DataTable TaxData
        {
            get
            {
                return _taxData;
            }
            set
            {
                _taxData = value;
            }
        }

        private DataTable _InvoiceDetails;
        public DataTable InvoiceDetails
        {
            get
            {
                return _InvoiceDetails;
            }
            set
            {
                _InvoiceDetails = value;
            }
        }
        private string _tableName;
        public String TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
    }
}
