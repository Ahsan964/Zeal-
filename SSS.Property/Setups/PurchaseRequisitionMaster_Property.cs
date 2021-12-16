using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    [Serializable()]
    public  class PurchaseRequisitionMaster_Property
    {
        #region Class Member Declarations

        private int _iD, _location_id, _user_id, _pos_id;
        private string _document_Id, _document_name, _narration, _status, _reference, _document_type, _documentNo, _tableName, _tempID;
        private DateTime _document_datetime, _deliverydate,_from_date,_to_date;
        private decimal _total_amount, _discount, _net_amount;
        private DataTable _detail_data;
        private Boolean _is_active;
        #endregion

        #region Class Property Declarations

        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        }

        public int LocationId
        {
            get
            {
                return _location_id;
            }
            set
            {

                _location_id = value;
            }
        }
        public int UserId
        {
            get
            {
                return _user_id;
            }
            set
            {

                _user_id = value;
            }
        }
        public int PosID
        {
            get
            {
                return _pos_id;
            }
            set
            {

                _pos_id = value;
            }
        }

        public string DocumentId
        {
            get
            {
                return _document_Id;
            }
            set
            {
                _document_Id = value;
            }
        }
        public string DocumentName
        {
            get
            {
                return _document_name;
            }
            set
            {
                _document_name = value;
            }
        }
        public string Narration
        {
            get
            {
                return _narration;
            }
            set
            {
                _narration = value;
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public string Reference
        {
            get
            {
                return _reference;
            }
            set
            {
                _reference = value;
            }
        }
        public string DocumentType
        {
            get
            {
                return _document_type;
            }
            set
            {
                _document_type = value;
            }
        }
        public string DocumentNo
        {
            get
            {
                return _documentNo;
            }
            set
            {
                _documentNo = value;
            }
        }
        public DateTime DocumentDateTime
        {
            get
            {
                return _document_datetime;
            }
            set
            {
                _document_datetime = value;
            }
        }
        public DateTime DeliveryDate
        {
            get
            {
                return _deliverydate;
            }
            set
            {
                _deliverydate = value;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return _from_date;
            }
            set
            {
                _from_date = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return _to_date;
            }
            set
            {
                _to_date = value;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                return _total_amount;
            }
            set
            {

                _total_amount = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return _discount;
            }
            set
            {

                _discount = value;
            }
        }
        public decimal NetAmount
        {
            get
            {
                return _net_amount;
            }
            set
            {

                _net_amount = value;
            }
        }

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
        public Boolean IsActive
        {
            get
            {
                return _is_active;
            }
            set
            {
                _is_active = value;
            }
        }
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
        public string TempID
        {
            get
            {
                return _tempID;
            }
            set
            {
                _tempID = value;
            }
        }
        #endregion
    }
}
