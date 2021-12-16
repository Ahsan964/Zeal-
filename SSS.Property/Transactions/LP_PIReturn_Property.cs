using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_PIReturn_Property
    {
        public int idx;
        public int piIdx;
        public int VendorID { get; set; }
        public int coaVendorIdx { get; set; }
        public int coaBankIdx { get; set; }
        public string invoiceNo;
        public decimal returnAmount;
        public DateTime creationDate;
        public int createdBy;
        public int visible;
        private DataTable _detail_data;
        public DataTable DetailData
        {
            get
            {
                return _detail_data;
            }
            set
            {
                _detail_data = value;
            }
        }
        private DataTable _taxData;
        public DataTable taxData
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
        private DataTable _UpdatedDetailData;
        public DataTable UpdatedDetailData
        {
            get
            {
                return _UpdatedDetailData;
            }
            set
            {
                _UpdatedDetailData = value;
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
        public decimal NetAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalancAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal returnAmountInclusiveTax { get; set; }
        public decimal UpdatedPaidAmount { get; set; }
        public decimal UpdatedBalanceAmount { get; set; }
        public decimal UpdatedTaxAmount { get; set; }
        public decimal UpdatedNetAmount { get; set; }
        public decimal UpdatedTotalAmount { get; set; }
        public decimal amountTobeReceived { get; set; }
        public int isPaid { get; set; }
        public int glIdx { get; set; }
    }
}
