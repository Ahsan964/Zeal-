using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_PI_Taxes_Property
    {
        private int _Tax_Id;
        public int Tax_Id
        {
            get { return _Tax_Id; }
            set { _Tax_Id = value; }
        }

        private int _PID;
        public int PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        private DateTime _CreatedDate;
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private decimal _taxPercent;
        public decimal TaxPercent
        {
            get { return _taxPercent; }
            set { _taxPercent = value; }
        }
    }
}
