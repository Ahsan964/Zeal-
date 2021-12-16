using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class companyCurrency_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _currencyIdx;
        public int currencyIdx
        {
            get { return _currencyIdx; }
            set { _currencyIdx = value; }
        }

        private decimal _exhangeRate;
        public decimal exhangeRate
        {
            get { return _exhangeRate; }
            set { _exhangeRate = value; }
        }

        private int _createdByUserIdx;
        public int createdByUserIdx
        {
            get { return _createdByUserIdx; }
            set { _createdByUserIdx = value; }
        }

        private DateTime _creationDate;
        public DateTime creationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        private int _lastModifiedByUserIdx;
        public int lastModifiedByUserIdx
        {
            get { return _lastModifiedByUserIdx; }
            set { _lastModifiedByUserIdx = value; }
        }

        private string _lastModificationDate;
        public string lastModificationDate
        {
            get { return _lastModificationDate; }
            set { _lastModificationDate = value; }
        }

        private int _visble;
        public int visble
        {
            get { return _visble; }
            set { _visble = value; }
        }

        public List<currency_Property> CurrencyLST { get; set; }
    }
}
