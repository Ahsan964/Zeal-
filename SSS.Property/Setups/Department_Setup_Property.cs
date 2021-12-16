using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    [Serializable()]
    public class Department_Setup_Property
    {
        #region Class Member Declarations

        private int _department_id;
        private int? _user_id, _PageNum, _PageSize, operated_By;

        private string _department_name,_status,_column_name;
        private DateTime _date_created;
        private bool _is_active;
        private string _tableName, _documentNo;

        #endregion

        #region Class Property Declarations

        public int Department_Id
        {
            get { return _department_id; }
            set { _department_id = value; }

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
        public string DepartmentName
        {
            get { return _department_name; }
            set { _department_name = value; }
        }
        
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string ColumnName
        {
            get { return _column_name; }
            set { _column_name = value; }
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
