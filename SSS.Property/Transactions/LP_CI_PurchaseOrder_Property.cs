using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_CI_PurchaseOrder_Property
    {
        public  decimal TD { get; set; }
        public int glIdx { get; set; }
        //public int IEcheck { get; set; }
        public int CIcheck { get; set; }
        public decimal TotalPrice { get; set; }
        public int productIdx { get; set; }
        public decimal stock { get; set; }
        public decimal unitPrice { get; set; }

        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }
        private int _PINO;
        public int PINO
        {
            get { return _PINO; }
            set { _PINO = value; }
        }

        private string _poNumber;
        public string poNumber
        {
            get { return _poNumber; }
            set { _poNumber = value; }
        }

        private DateTime _purchaseDate;
        public DateTime purchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private decimal _totalAmount;
        public decimal totalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        private decimal _netAmount;
        public decimal netAmount
        {
            get { return _netAmount; }
            set { _netAmount = value; }
        }

        private decimal _paidAmount;
        public decimal paidAmount
        {
            get { return _paidAmount; }
            set { _paidAmount = value; }
        }

        private decimal _balanceAmount;
        public decimal balanceAmount
        {
            get { return _balanceAmount; }
            set { _balanceAmount = value; }
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

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private int _paymentStatus;
        public int paymentStatus
        {
            get { return _paymentStatus; }
            set { _paymentStatus = value; }
        }

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private DataTable _detaildata;
        public DataTable DetailData

        {
            get { return _detaildata; }
            set { _detaildata = value; }
        }
        public decimal totalTD { get; set; }//Added By Arsalan
        public decimal grandTotalAVPKR { get; set; }//Added By Arsalan
        public int numberOfProducts { get; set; } //Added By Arsalan
        public decimal ExchangeRate { get; set; }//Added By Arsalan

        // Added By Ahsan
        public decimal clearingExpensePerProduct { get; set; }
        public decimal pricePerProduct { get; set; }
        
    }
}
