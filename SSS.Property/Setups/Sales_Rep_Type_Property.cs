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
    public class Sales_Rep_Type_Property
    {
        #region Class Member Declarations
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private SqlInt32 _sales_Rep_Type_Code, _iD, operated_By;
        private SqlString _status, _sales_Rep_Type_Desc;
        private string _sortColumn, _tableName, operation;
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
                //SqlInt32 iDTmp = (SqlInt32)value;
                //if (iDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                //}
                _iD = value;
            }
        }


        public SqlInt32 Sales_Rep_Type_Code
        {
            get
            {
                return _sales_Rep_Type_Code;
            }
            set
            {
                //SqlInt32 sales_Rep_Type_CodeTmp = (SqlInt32)value;
                //if (sales_Rep_Type_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Sales_Rep_Type_Code", "Sales_Rep_Type_Code can't be NULL");
                //}
                _sales_Rep_Type_Code = value;
            }
        }


        public SqlString Sales_Rep_Type_Desc
        {
            get
            {
                return _sales_Rep_Type_Desc;
            }
            set
            {
                SqlString sales_Rep_Type_DescTmp = (SqlString)value;
                if (sales_Rep_Type_DescTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Sales_Rep_Type_Desc", "Sales_Rep_Type_Desc can't be NULL");
                }
                _sales_Rep_Type_Desc = value;
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
