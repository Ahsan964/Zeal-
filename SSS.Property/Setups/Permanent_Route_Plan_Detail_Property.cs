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
    public class Permanent_Route_Plan_Detail_Property
    {
        #region Class Member Declarations
        private SqlInt32 _delivery_Man_ID, _delivery_Man_IDOld, _delivery_Man_Day_ID, _delivery_Man_Day_IDOld, _order_Booker_Day_ID, _order_Booker_Day_IDOld, _iD, _permanent_Route_Plan_Setup_ID, _permanent_Route_Plan_Setup_IDOld, _route_ID, _route_IDOld, operated_By;
        private Int32? _id, _pageNum, _pageSize, _totalRowsNum, _sNo;
        private SqlString _status, _tableName;
        private string _sortColumn, _operation;
        private DateTime _operation_Date;
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


        public SqlInt32 Permanent_Route_Plan_Setup_ID
        {
            get
            {
                return _permanent_Route_Plan_Setup_ID;
            }
            set
            {
                _permanent_Route_Plan_Setup_ID = value;
            }
        }
        public SqlInt32 Permanent_Route_Plan_Setup_IDOld
        {
            get
            {
                return _permanent_Route_Plan_Setup_IDOld;
            }
            set
            {
                _permanent_Route_Plan_Setup_IDOld = value;
            }
        }


        public SqlInt32 Route_ID
        {
            get
            {
                return _route_ID;
            }
            set
            {
                _route_ID = value;
            }
        }
        public SqlInt32 Route_IDOld
        {
            get
            {
                return _route_IDOld;
            }
            set
            {
                _route_IDOld = value;
            }
        }


        public SqlInt32 Delivery_Man_ID
        {
            get
            {
                return _delivery_Man_ID;
            }
            set
            {
                _delivery_Man_ID = value;
            }
        }
        public SqlInt32 Delivery_Man_IDOld
        {
            get
            {
                return _delivery_Man_IDOld;
            }
            set
            {
                _delivery_Man_IDOld = value;
            }
        }


        public SqlInt32 Delivery_Man_Day_ID
        {
            get
            {
                return _delivery_Man_Day_ID;
            }
            set
            {
                _delivery_Man_Day_ID = value;
            }
        }
        public SqlInt32 Delivery_Man_Day_IDOld
        {
            get
            {
                return _delivery_Man_Day_IDOld;
            }
            set
            {
                _delivery_Man_Day_IDOld = value;
            }
        }


        public SqlInt32 Order_Booker_Day_ID
        {
            get
            {
                return _order_Booker_Day_ID;
            }
            set
            {
                _order_Booker_Day_ID = value;
            }
        }

        public SqlInt32 Order_Booker_Day_IDOld
        {
            get
            {
                return _order_Booker_Day_IDOld;
            }
            set
            {
                _order_Booker_Day_IDOld = value;
            }
        }

        public Int32? SNo
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
                return _operation;
            }
            set
            {
                _operation = value;
            }
        }

        public DateTime Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                _operation_Date = value;
            }
        }
        #endregion
    }
}
