using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.ViewModels
{
  public  class LP_Voucher_ViewModel
    {
        // Added By Ahsan
        public string PreviousPaid { get; set; }
        public List<Branch_Property> BranchList { get; set; }
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
        public int bank_id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_created { get; set; }
        public int u_id { get; set; }
        public int status { get; set; }
        public bool voucher_proccessed { get; set; }

        public string description { get; set; }
        public string reference { get; set; } 

        [DataType(DataType.Date)]
        public DateTime From_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime To_Date { get; set; }

        //public DataTable DetailData { get; set; }
        public List<LP_Voucher_Details> VoucherDetails { get; set; }

        public List<LP_Transaction_Type_Property> vouchertypelist { get; set; }

        //public List<Company_Bank_Property> banklist { get; set; }

        public List<Vendors_Property> vendorlist { get; set; }
        public List<fourthTier_Property> explist { get; set; }
        public List<Customers_Property> customerlist { get; set; }
        public string customerPaymentBalance { get; set; } //Added By Arsalan 17-05-21
        public string cashBankBalance { get; set; } //Added By Arsalan 17-05-21
        public string vendorBalance { get; set; } //Added By Arsalan 17-05-21
        public decimal paidAmount { get; set; } //Added By Arsalan 17-05-21
        public int customerBankIdx { get; set; }
        public int paymentModeIdx { get; set; }
        public int bankIdx { get; set; }
        public string accorChequeNumber { get; set; }
        public List<PaymentMode_Property> Paymentmodelist { get; set; }
        public List<Company_Bank_Property> BankList { get; set; }
        public List<LP_CustomerBanks_Property> CustomerBankList { get; set; }
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
