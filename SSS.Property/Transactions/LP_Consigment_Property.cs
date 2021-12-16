using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_Consigment_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _InvoiceNo;
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        private DateTime _Invoicedate;
        public DateTime Invoicedate
        {
            get { return _Invoicedate; }
            set { _Invoicedate = value; }
        }

        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }

        private int _ParentDocumentId;
        public int ParentDocumentId
        {
            get { return _ParentDocumentId; }
            set { _ParentDocumentId = value; }
        }

        private int _ParentDocumentType;
        public int ParentDocumentType
        {
            get { return _ParentDocumentType; }
            set { _ParentDocumentType = value; }
        }

        private int _status;
        public int status
        {
            get { return _status; }
            set { _status = value; }
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

        public DataTable DetailData { get; set; }

        public DataTable CIPODetails { get; set; }
        public string TableName { get; set; }
    }
}
