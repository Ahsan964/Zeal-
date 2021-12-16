using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_Voucher_Property
    {
        //private int _idx;
        //public int idx
        //{
        //    get { return _idx; }
        //    set { _idx = value; }
        //}

        //private int _voucher_type;
        //public int voucher_type
        //{
        //    get { return _voucher_type; }
        //    set { _voucher_type = value; }
        //}

        //private string _voucher_no;
        //public string voucher_no
        //{
        //    get { return _voucher_no; }
        //    set { _voucher_no = value; }
        //}

        //private decimal _voucher_amount;
        //public decimal voucher_amount
        //{
        //    get { return _voucher_amount; }
        //    set { _voucher_amount = value; }
        //}

        //private int _payment_type;
        //public int payment_type
        //{
        //    get { return _payment_type; }
        //    set { _payment_type = value; }
        //}

        //private int _vendor_id;
        //public int vendor_id
        //{
        //    get { return _vendor_id; }
        //    set { _vendor_id = value; }
        //}
        //private int _customer_id;
        //public int customer_id
        //{
        //    get { return _customer_id; }
        //    set { _customer_id = value; }
        //}
        //private string _account_cheque_no;
        //public string account_cheque_no
        //{
        //    get { return _account_cheque_no; }
        //    set { _account_cheque_no = value; }
        //}

        //private int _bank_id;
        //public int bank_id
        //{
        //    get { return _bank_id; }
        //    set { _bank_id = value; }
        //}

        //private string _description;
        //public string description
        //{
        //    get { return _description; }
        //    set { _description = value; }
        //}


        //private DateTime _date_created;
        //public DateTime date_created
        //{
        //    get { return _date_created; }
        //    set { _date_created = value; }
        //}

        //private int _u_id;
        //public int u_id
        //{
        //    get { return _u_id; }
        //    set { _u_id = value; }
        //}

        //private int _status;
        //public int status
        //{
        //    get { return _status; }
        //    set { _status = value; }
        //}

        //private bool _voucher_proccessed;
        //public bool voucher_proccessed
        //{
        //    get { return _voucher_proccessed; }
        //    set { _voucher_proccessed = value; }
        //}

        //public DataTable DetailData { get; set; }

        //public string TableName { get; set; }
        public int branchIdx { get; set; }
        public int idx { get; set; }
        public int voucher_type { get; set; }
        public int natureType { get; set; } //Added By Arsalan 17-05-21
        public string voucher_no { get; set; }
        public decimal voucher_amount { get; set; }
        public int payment_type { get; set; }
        public int vendor_id { get; set; }
        public int exp_id { get; set; }//Added By Arsalan 17-05-21
        public int customer_id { get; set; }
        public string account_cheque_no { get; set; }
        //public int bank_id { get; set; }
        
        public string date_created { get; set; }//changedatetime to string
        public int u_id { get; set; }
        public int status { get; set; }
        public bool voucher_proccessed { get; set; }

        public string description { get; set; }
        public string reference { get; set; }

       
       

        //public DataTable DetailData { get; set; }
        

        //public List<Company_Bank_Property> banklist { get; set; }

        

        public string cashBankBalance { get; set; } //Added By Arsalan 17-05-21
        public string vendorBalance { get; set; } //Added By Arsalan 17-05-21
        public decimal paidAmount { get; set; } //Added By Arsalan 17-05-21
        public int customerBankIdx { get; set; }
        public int paymentModeIdx { get; set; }
        public int bankIdx { get; set; }
        public string accorChequeNumber { get; set; }
        
        public int invoiceIdx { get; set; }//Added By Arsalan
        public decimal invoiceBalance { get; set; }//Added By Arsalan 
        public List<AccountGJ> AccountGJLST { get; set; }
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


        private string _tableName;
        public string TableName
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
        public int glIdx { get; set; } // Master Id 
    }
}
