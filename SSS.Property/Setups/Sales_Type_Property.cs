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
    [Serializable()]
    public class Sales_Type_Property
    {
        #region Class Member Declarations
        private SqlBoolean _is_Active;
        private SqlDateTime _created_on;
        private SqlInt32 _iD;
        private SqlString _created_by, _status, _description, _sales_Type_Code;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName, operation;
        private SqlInt32 operated_By;
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


        public SqlString Sales_Type_Code
        {
            get
            {
                return _sales_Type_Code;
            }
            set
            {
                
                _sales_Type_Code = value;
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


        public SqlBoolean Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
               
                _is_Active = value;
            }
        }


        public SqlDateTime Created_on
        {
            get
            {
                return _created_on;
            }
            set
            {
               
                _created_on = value;
            }
        }


        public SqlString Created_by
        {
            get
            {
                return _created_by;
            }
            set
            {
                
                _created_by = value;
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
        #endregion
    }
}
