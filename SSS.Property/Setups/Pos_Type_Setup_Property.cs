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
    public class Pos_Type_Setup_Property
    {
        #region Class Member Declarations
        private SqlInt32 _pos_Type_Code, _iD, _operated_By;
        private SqlString _status, _pos_Type_Name;
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


        public SqlInt32 Pos_Type_Code
        {
            get
            {
                return _pos_Type_Code;
            }
            set
            {
                SqlInt32 pos_Type_CodeTmp = (SqlInt32)value;
                if (pos_Type_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Pos_Type_Code", "Pos_Type_Code can't be NULL");
                }
                _pos_Type_Code = value;
            }
        }


        public SqlString Pos_Type_Name
        {
            get
            {
                return _pos_Type_Name;
            }
            set
            {
                SqlString pos_Type_NameTmp = (SqlString)value;
                if (pos_Type_NameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Pos_Type_Name", "Pos_Type_Name can't be NULL");
                }
                _pos_Type_Name = value;
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
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
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
                return _operated_By;
            }
            set
            {
                _operated_By = value;
            }
        }
        #endregion
    }
}
