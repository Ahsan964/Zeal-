using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class Taxes_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _taxName;
        public string taxName
        {
            get { return _taxName; }
            set { _taxName = value; }
        }
        private string _shortName;
        public string shortName //Added BY Arsalan 05-04-21
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        private decimal _taxPercent;
        public decimal taxPercent
        {
            get { return _taxPercent; }
            set { _taxPercent = value; }
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

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
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

        private bool _IsClaimble;
        public bool IsClaimble
        {
            get { return _IsClaimble; }
            set { _IsClaimble = value; }
        }

    }
}
