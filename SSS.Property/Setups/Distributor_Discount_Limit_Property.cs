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
    public class Distributor_Discount_Limit_Property
    {
        #region Class Member Declarations

        private SqlInt32 _company_ID, _distributor_ID, _discount_Master_ID, _max_Allowed_Skus, _iD, _iErrorCode, _errorcode, operated_By;
        private SqlString _status;

        private string _sortColumn, _tableName, operation;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
       
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
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
                _iD = value;
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


        public SqlInt32 Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                SqlInt32 product_IDTmp = (SqlInt32)value;
                if (product_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("_company_ID", "_company_ID can't be NULL");
                }
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


        public SqlInt32 Discount_Master_ID
        {
            get
            {
                return _discount_Master_ID;
            }
            set
            {
                _discount_Master_ID = value;
            }
        }

        public SqlInt32 Max_Allowed_Skus
        {
            get
            {
                return _max_Allowed_Skus;
            }
            set
            {
                _max_Allowed_Skus = value;
            }
        }

        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorcode;
            }
            set
            {

                _errorcode = value;
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
        #endregion
    }
}
