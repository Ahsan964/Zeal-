using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Setups
{
     [Serializable()]
    public class Wh_Location_Property
    {
        #region Class Member Declarations
        private SqlBoolean _is_Active;
        private SqlDateTime _created_on;
        private SqlInt32 _iD, _company_ID, _distributor_ID;
        private SqlString _status, _created_by, _wH_Location_Code, _description;


        private Int32? _pageNum, _pageSize, _totalRowsNum, _sNo;
        private string _sortColumn;

        private SqlInt32 operated_By;
        private SqlString operation, _record_Table_Name, _tableName;
        private SqlDateTime _operation_Date;

        #endregion

        #region Class Property Declarations


        public SqlInt32 ID
        {
            get
            {
                return _iD;
            }
            set
            {
                //SqlInt32 iDTmp = (SqlInt32)value;
                //if (iDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                //}
                _iD = value;
            }
        }


        public SqlInt32 Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                //SqlInt32 company_IDTmp = (SqlInt32)value;
                //if (company_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                //}
                _company_ID = value;
            }
        }
      

        public SqlInt32 Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }
            set
            {
                //SqlInt32 distributor_IDTmp = (SqlInt32)value;
                //if (distributor_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Distributor_ID", "Distributor_ID can't be NULL");
                //}
                _distributor_ID = value;
            }
        }


        public SqlString WH_Location_Code
        {
            get
            {
                return _wH_Location_Code;
            }
            set
            {
                //SqlString wH_Location_CodeTmp = (SqlString)value;
                //if (wH_Location_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("WH_Location_Code", "WH_Location_Code can't be NULL");
                //}
                _wH_Location_Code = value;
            }
        }


        public SqlString Description
        {
            get
            {
                return _description;
            }
            set
            {
                //SqlString descriptionTmp = (SqlString)value;
                //if (descriptionTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                //}
                _description = value;
            }
        }


        public SqlBoolean Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                //SqlBoolean is_ActiveTmp = (SqlBoolean)value;
                //if (is_ActiveTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Is_Active", "Is_Active can't be NULL");
                //}
                _is_Active = value;
            }
        }


        public SqlDateTime Created_on
        {
            get
            {
                return _created_on;
            }
            set
            {
                //SqlDateTime created_onTmp = (SqlDateTime)value;
                //if (created_onTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Created_on", "Created_on can't be NULL");
                //}
                _created_on = value;
            }
        }


        public SqlString Created_by
        {
            get
            {
                return _created_by;
            }
            set
            {
                //SqlString created_byTmp = (SqlString)value;
                //if (created_byTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Created_by", "Created_by can't be NULL");
                //}
                _created_by = value;
            }
        }


        public SqlString Status
        {
            get
            {
                return _status;
            }
            set
            {
                //SqlString statusTmp = (SqlString)value;
                //if (statusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                //}
                _status = value;
            }
        }
        public int? PageNum
        {
            get
            {
                return _pageNum;
            }
            set
            {
                _pageNum = value;
            }
        }

        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int? TotalRowsNum
        {
            get
            {
                return _totalRowsNum;
            }
            set
            {
                _totalRowsNum = value;
            }
        }

        public string SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                _sortColumn = value;
            }
        }
        public int? SNo
        {
            get
            {
                return _sNo;
            }
            set
            {
                _sNo = value;
            }
        }
        public SqlDateTime Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _operation_Date = value;
            }
        }

        public SqlString Operation
        {
            get
            {
                return operation;
            }
            set
            {
                //SqlString OperationTemp = (SqlString)value;
                //if (OperationTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation", "Operation can't be NULL");
                //}
                operation = value;
            }
        }

        public SqlInt32 Operated_By
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
        public SqlString Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                //SqlString record_Table_NameTemp = (SqlString)value;
                //if (record_Table_NameTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Record_Table_Name", "Record Table Name can't be NULL");
                //}
                _record_Table_Name = value;
            }
        }

        public SqlString TableName
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
        #endregion
    }
}
