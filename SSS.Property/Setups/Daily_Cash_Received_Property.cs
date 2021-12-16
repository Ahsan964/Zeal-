using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Setups
{
    [Serializable()]
    public class Daily_Cash_Received_Property
    {
        #region Class Member Declarations
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private SqlDateTime _date;
        private SqlDecimal _cheque_Amount, _cash_Amount;
        private SqlInt32 _iD, _personnel_ID, operated_By, _distributor_ID;
        private SqlString _status, _posting_Status, _code;
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
                SqlInt32 iDTmp = (SqlInt32)value;
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
                _iD = value;
            }
        }


        public SqlDateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }


        public SqlDecimal Cash_Amount
        {
            get
            {
                return _cash_Amount;
            }
            set
            {
                _cash_Amount = value;
            }
        }


        public SqlDecimal Cheque_Amount
        {
            get
            {
                return _cheque_Amount;
            }
            set
            {
                _cheque_Amount = value;
            }
        }


        public SqlInt32 Personnel_ID
        {
            get
            {
                return _personnel_ID;
            }
            set
            {
                _personnel_ID = value;
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

        public SqlString Posting_Status
        {
            get
            {
                return _posting_Status;
            }
            set
            {
                _posting_Status = value;
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
                _code = value;
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
        #endregion
    }
}
