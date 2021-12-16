using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;


namespace SSS.Property.Transactions
{
    public class Collection_Detail_Property
    {
        #region Class Member Declarations
        private SqlDateTime _date, _checque_DueDate;
        private SqlDecimal _amount, _chqAmount;
        private SqlInt32 _iD, _collection_Master_ID, _collection_Master_IDOld, _distributor_ID, _company_ID, _daily_Cash_Recieved_ID, _daily_Cash_Recieved_IDOld, operated_By;
        private SqlString _status, _type, _bank_Name, _checque_No, _branch;
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
                SqlInt32 iDTmp = (SqlInt32)value;
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
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


        public SqlInt32 Daily_Cash_Recieved_ID
        {
            get
            {
                return _daily_Cash_Recieved_ID;
            }
            set
            {
                _daily_Cash_Recieved_ID = value;
            }
        }
        public SqlInt32 Daily_Cash_Recieved_IDOld
        {
            get
            {
                return _daily_Cash_Recieved_IDOld;
            }
            set
            {
                _daily_Cash_Recieved_IDOld = value;
            }
        }


        public SqlInt32 Collection_Master_ID
        {
            get
            {
                return _collection_Master_ID;
            }
            set
            {
                _collection_Master_ID = value;
            }
        }
        public SqlInt32 Collection_Master_IDOld
        {
            get
            {
                return _collection_Master_IDOld;
            }
            set
            {
                _collection_Master_IDOld = value;
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


        public SqlDecimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        public SqlDecimal ChqAmount
        {
            get
            {
                return _chqAmount;
            }
            set
            {
                _chqAmount = value;
            }
        }

        public SqlString Bank_Name
        {
            get
            {
                return _bank_Name;
            }
            set
            {
                _bank_Name = value;
            }
        }


        public SqlString Checque_No
        {
            get
            {
                return _checque_No;
            }
            set
            {
                _checque_No = value;
            }
        }


        public SqlString Branch
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }


        public SqlDateTime Checque_DueDate
        {
            get
            {
                return _checque_DueDate;
            }
            set
            {
                _checque_DueDate = value;
            }
        }


        public SqlString Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
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
        #endregion

    }
}
