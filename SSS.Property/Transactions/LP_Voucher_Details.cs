using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_Voucher_Details
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _voucher_master_id;
        public int voucher_master_id
        {
            get { return _voucher_master_id; }
            set { _voucher_master_id = value; }
        }

        private int _parent_doc_id;
        public int parent_doc_id
        {
            get { return _parent_doc_id; }
            set { _parent_doc_id = value; }
        }

        private decimal _amount;
        public decimal amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private DateTime _Datecreated;
        public DateTime Datecreated
        {
            get { return _Datecreated; }
            set { _Datecreated = value; }
        }
    }
}
