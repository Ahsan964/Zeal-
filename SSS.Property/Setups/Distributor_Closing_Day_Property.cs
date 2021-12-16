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
    public class Distributor_Closing_Day_Property
    {
        #region Class Member Declarations
        private SqlDateTime _closing_Date, _transaction_Date;
        private SqlInt32 _iD, _closingTypeEnum, _distributor_ID, _fINANCIAL_PERIOD_CALANDER_ID, operated_By, _result;
        private SqlString _status, _reason;
        private string _sortColumn, _tableName;
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
                _iD = value;
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


        public SqlInt32 FINANCIAL_PERIOD_CALANDER_ID
        {
            get
            {
                return _fINANCIAL_PERIOD_CALANDER_ID;
            }
            set
            {
                _fINANCIAL_PERIOD_CALANDER_ID = value;
            }
        }


        public SqlDateTime Closing_Date
        {
            get
            {
                return _closing_Date;
            }
            set
            {
                _closing_Date = value;
            }
        }


        public SqlInt32 ClosingTypeEnum
        {
            get
            {
                return _closingTypeEnum;
            }
            set
            {
                _closingTypeEnum = value;
            }
        }


        public SqlString Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
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

        public SqlInt32 Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public SqlDateTime Transaction_Date
        {
            get
            {
                return _transaction_Date;
            }
            set
            {
                _transaction_Date = value;
            }
        }
        #endregion
    }
}
