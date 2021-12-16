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
    public class Financial_Period_Property
    {
        #region Class Member Declarations
        private SqlDateTime _end_Date, _start_Date;
        private SqlInt32 _iD, operated_By;
        private SqlString _status, _period_Name, _period_Description;
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


        public SqlString Period_Name
        {
            get
            {
                return _period_Name;
            }
            set
            {
                _period_Name = value;
            }
        }


        public SqlString Period_Description
        {
            get
            {
                return _period_Description;
            }
            set
            {
                _period_Description = value;
            }
        }


        public SqlDateTime Start_Date
        {
            get
            {
                return _start_Date;
            }
            set
            {
                _start_Date = value;
            }
        }


        public SqlDateTime End_Date
        {
            get
            {
                return _end_Date;
            }
            set
            {
                _end_Date = value;
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
