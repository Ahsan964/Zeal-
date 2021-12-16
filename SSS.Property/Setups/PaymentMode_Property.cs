using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class PaymentMode_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _paymentMode;
        public string paymentMode
        {
            get { return _paymentMode; }
            set { _paymentMode = value; }
        }
    }
}
