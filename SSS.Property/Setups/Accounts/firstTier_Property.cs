using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.Accounts
{
    public class firstTier_Property
    {
        public int idx { get; set; }
        public string accountName { get; set; }
        public string accountCode { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public int parentIdx { get; set; }
    }
}
