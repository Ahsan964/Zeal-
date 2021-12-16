using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.Accounts
{
    public class AccountMasterGL
    {
        public int idxx { get; set; }
        public int tranTypeIdx { get; set; }
        public int userIdx { get; set; }
        public int vendorIdx { get; set; }
        public int employeeIdx { get; set; }
        public int customerIdx { get; set; }
        public string invoiceNoIdx { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public DateTime createDate { get; set; }
        public string modifiedDate { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balance { get; set; }
        public decimal discount { get; set; }
        public int isCredit { get; set; }
        public int creditDays { get; set; }
        public int visible { get; set; }
        public int paymentModeIdx { get; set; }
        public int bankIdx { get; set; }
        public string chequeNumber { get; set; }
        public string memo { get; set; }
        public DateTime DueDate { get; set; }
        public int ItemId { get; set; }
        public DateTime ChequeDate { get; set; }
        public int Isdeposited { get; set; }
    }
}
