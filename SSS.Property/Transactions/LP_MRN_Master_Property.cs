using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_MRN_Master_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _mrNumber;
        public string mrNumber
        {
            get { return _mrNumber; }
            set { _mrNumber = value; }
        }

        //private int _vendorIdx;
        //public int vendorIdx
        //{
        //    get { return _vendorIdx; }
        //    set { _vendorIdx = value; }
        //}

        //private int _purchaseTypeIdx;
        //public int purchaseTypeIdx
        //{
        //    get { return _purchaseTypeIdx; }
        //    set { _purchaseTypeIdx = value; }
        //}

        private DateTime _mrnDate;
        public DateTime mrnDate
        {
            get { return _mrnDate; }
            set { _mrnDate = value; }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
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

        private DateTime _lastModificationDate;
        public DateTime lastModificationDate
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

      

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
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
