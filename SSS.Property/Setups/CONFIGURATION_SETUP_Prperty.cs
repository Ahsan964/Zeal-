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
    public class CONFIGURATION_SETUP_Prperty
    {
        #region Class Member Declarations
        private SqlBoolean _isApplicable;
        private SqlInt32 _iD, _distributor_ID, _company_ID, operated_By, _errorCode;
        private SqlString _status, _functionality_Enum, _description;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName;
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

                _distributor_ID = value;
            }
        }


        public SqlString Functionality_Enum
        {
            get
            {
                return _functionality_Enum;
            }
            set
            {

                _functionality_Enum = value;
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

                _description = value;
            }
        }


        public SqlBoolean IsApplicable
        {
            get
            {
                return _isApplicable;
            }
            set
            {

                _isApplicable = value;
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
        #endregion
    }
}
