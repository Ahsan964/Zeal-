using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Setups
{
    public class Day_Property
    {
        #region Class Member Declarations
        private SqlBoolean _isDayClose;
        private SqlInt32 _iD, _distributor_ID, _distributor_IDOld, operated_By;
        private SqlString _status, _description, _day_Code, _day_Name;
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


        public SqlString Day_Code
        {
            get
            {
                return _day_Code;
            }
            set
            {
                _day_Code = value;
            }
        }


        public SqlString Day_Name
        {
            get
            {
                return _day_Name;
            }
            set
            {
                _day_Name = value;
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


        public SqlBoolean IsDayClose
        {
            get
            {
                return _isDayClose;
            }
            set
            {
                _isDayClose = value;
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
