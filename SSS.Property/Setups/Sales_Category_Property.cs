using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Setups
{
    public class Sales_Category_Property
    {

        #region Class Member Declarations
        private SqlInt32 _distributor_ID, _distributor_IDOld, _iD, operated_By;
        private SqlString _details, _status, _route_Long_Name, _route_Code, _route_Short_Name;
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
        public SqlInt32 Distributor_IDOld
        {
            get
            {
                return _distributor_IDOld;
            }
            set
            {
                _distributor_IDOld = value;
            }
        }


        public SqlString Route_Code
        {
            get
            {
                return _route_Code;
            }
            set
            {
                SqlString route_CodeTmp = (SqlString)value;
                if (route_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Route_Code", "Route_Code can't be NULL");
                }
                _route_Code = value;
            }
        }


        public SqlString Route_Short_Name
        {
            get
            {
                return _route_Short_Name;
            }
            set
            {
                _route_Short_Name = value;
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
        public SqlString Route_Long_Name
        {
            get
            {
                return _route_Long_Name;
            }
            set
            {
                _route_Long_Name = value;
            }
        }


        public SqlString Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
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
