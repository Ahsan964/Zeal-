using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class itemUnit_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _itemUnit;
        public string itemUnit
        {
            get { return _itemUnit; }
            set { _itemUnit = value; }
        }

        private DateTime _creationDate;
        public DateTime creationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        private int _createdByUserIdx;
        public int createdByUserIdx
        {
            get { return _createdByUserIdx; }
            set { _createdByUserIdx = value; }
        }

        private string _lastModificationDate;
        public string lastModificationDate
        {
            get { return _lastModificationDate; }
            set { _lastModificationDate = value; }
        }

        private int _lastModifiedByUserIdx;
        public int lastModifiedByUserIdx
        {
            get { return _lastModifiedByUserIdx; }
            set { _lastModifiedByUserIdx = value; }
        }

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
    }
}
