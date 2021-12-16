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
    public class Discount_Type_Setup_Property
    {
        #region Class Member Declarations
        private SqlInt32 _iD;
            private Int32? _pageNum, _pageSize, _totalRowsNum;
        private SqlString _status, _discount_Type_Title, _discount_Type_Code;
        private string _sortColumn;
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


        public SqlString Discount_Type_Code
        {
            get
            {
                return _discount_Type_Code;
            }
            set
            {
                SqlString discount_Type_CodeTmp = (SqlString)value;
                if (discount_Type_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_Type_Code", "Discount_Type_Code can't be NULL");
                }
                _discount_Type_Code = value;
            }
        }


        public SqlString Discount_Type_Title
        {
            get
            {
                return _discount_Type_Title;
            }
            set
            {
                SqlString discount_Type_TitleTmp = (SqlString)value;
                if (discount_Type_TitleTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_Type_Title", "Discount_Type_Title can't be NULL");
                }
                _discount_Type_Title = value;
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
        #endregion
    }
}
