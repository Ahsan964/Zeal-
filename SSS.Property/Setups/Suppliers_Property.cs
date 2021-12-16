using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    [Serializable()]
   public class Suppliers_Property
    {
        #region Class Member Declarations

        private int _supplier_id;
        private int? _user_id, _PageNum, _PageSize, operated_By;

        private string _supplier_code, _supplier_name, _phone, _mobile, _address, _email, _status;
        private DateTime _date_created;
        private bool _is_active;
        private string _tableName, _documentNo;

        #endregion

        #region Class Property Declarations

        public int Supplier_Id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; }

        }
        public int? UserId
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public int? PageNum
        {
            get
            {
                return _PageNum;
            }
            set
            {

                _PageNum = value;
            }
        }

        public int? PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {

                _PageSize = value;
            }
        }

        public string SuppliersCode
        {
            get { return _supplier_code; }
            set { _supplier_code = value; }
        }
        public string SupplierPhone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string SupplierMobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string SupplierName
        {
            get { return _supplier_name; }
            set { _supplier_name = value; }
        }

        public string SupplierAddress
        {
            get { return _address; }
            set { _address = value; }
        }
        public string SupplierEmail
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime CreatedDate
        {
            get { return _date_created; }
            set { _date_created = value; }
        }
        public bool ISActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }


        public string TableName
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
        public int? Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                //SqlInt32 Operated_ByTmp = (SqlInt32)value;
                //if (Operated_ByTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                //}
                operated_By = value;
            }
        }
        #endregion
    }
}
