using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property
{
    [Serializable()]
   public class CALLCARD_PARAMETER_SETUP_Property
    {
        #region Class Member Declarations
        private SqlInt32 _parent_ID, _iD, operated_By, _errorCode;
        private SqlString _status, _description, _code, _name;
        private SqlBoolean _isParrent;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName, operation;
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
                SqlInt32 iDTmp = (SqlInt32)value;               
                _iD = value;
            }
        }


        public SqlString Code
        {
            get
            {
                return _code;
            }
            set
            {
                SqlString codeTmp = (SqlString)value;
               
                _code = value;
            }
        }


        public SqlString Name
        {
            get
            {
                return _name;
            }
            set
            {
                SqlString nameTmp = (SqlString)value;
                
                _name = value;
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
                SqlString descriptionTmp = (SqlString)value;
               
                _description = value;
            }
        }


        public SqlInt32 Parent_ID
        {
            get
            {
                return _parent_ID;
            }
            set
            {
                SqlInt32 parent_IDTmp = (SqlInt32)value;
               
                _parent_ID = value;
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
                SqlString statusTmp = (SqlString)value;
              
                _status = value;
            }
        }
        public SqlBoolean Is_Parrent
        {
            get
            {
                return _isParrent;
            }
            set
            {

                _isParrent = value;
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

        public SqlInt32 Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                operated_By = value;
            }
        }
        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                _errorCode = value;
            }
        }
        public string Operation
        {
            get
            {
                return operation;
            }
            set
            {

                operation = value;
            }
        }
        #endregion
    }
}
