using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class LP_CustomerBanks_Property
    {
        public int idx { get; set; }
        public int customerIdx { get; set; }
        public string accountTitle { get; set; }
        public string accountNumber { get; set; }
        public int bankIdx { get; set; }
        public string ibanNumber { get; set; }
        public string creationDate { get; set; }
        public int createdBy { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int visible { get; set; }
        public List<Bank_Property> BankList { get; set; }
        public List<Customers_Property> CustomerList { get; set; }
    }
}
