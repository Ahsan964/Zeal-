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
    public class Business_Type_Property
    {
        #region Class Member Declarations
        private SqlInt32 _iD, _operated_By;
        private SqlString _status, _business_Type_Code, _business_Type_Name, _description;
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


        public SqlString Business_Type_Code
        {
            get
            {
                return _business_Type_Code;
            }
            set
            {
                SqlString _business_Type_CodeTmp = (SqlString)value;
                if (_business_Type_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Business_Type_Code", "Business_Type_Code can't be NULL");
                }
                _business_Type_Code = value;
            }
        }


        public SqlString Business_Type_Name
        {
            get
            {
                return _business_Type_Name;
            }
            set
            {
                SqlString _business_Type_NameTmp = (SqlString)value;
                if (_business_Type_NameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Business_Type_Name", "Business_Type_Name can't be NULL");
                }
                _business_Type_Name = value;
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
                SqlString _descriptionTmp = (SqlString)value;
                if (_descriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                }
                _description = value;
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
