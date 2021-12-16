using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_MRN_Detail_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _mrnIdx;
        public int mrnIdx
        {
            get { return _mrnIdx; }
            set { _mrnIdx = value; }
        }

        //private int _productTypeIdx;
        //public int productTypeIdx
        //{
        //    get { return _productTypeIdx; }
        //    set { _productTypeIdx = value; }
        //}

        private int _itemIdx;
        public int itemIdx
        {
            get { return _itemIdx; }
            set { _itemIdx = value; }
        }

        //private decimal _unitPrice;
        //public decimal unitPrice
        //{
        //    get { return _unitPrice; }
        //    set { _unitPrice = value; }
        //}

        private decimal _qty;
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        //private decimal _amount;
        //public decimal amount
        //{
        //    get { return _amount; }
        //    set { _amount = value; }
        //}

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
        public String TableName
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
    }
}
