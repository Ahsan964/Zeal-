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
    public class Paking_Unit_Setup_Property
    {
        #region Class Member Declarations
        private SqlBoolean _is_Active;
        private SqlInt32 _iD, _pageNum, _pageSize, _totalRowsNum, _operated_By;
        private string _sortColumn, _tableName;
        private SqlString _status, _description, _packing_Unit_Code, _short_Description;
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


        public SqlString Packing_Unit_Code
        {
            get
            {
                return _packing_Unit_Code;
            }
            set
            {
                SqlString packing_Unit_CodeTmp = (SqlString)value;
                if (packing_Unit_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Packing_Unit_Code", "Packing_Unit_Code can't be NULL");
                }
                _packing_Unit_Code = value;
            }
        }


        public SqlString Short_Description
        {
            get
            {
                return _short_Description;
            }
            set
            {
                SqlString short_DescriptionTmp = (SqlString)value;
                if (short_DescriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Short_Description", "Short_Description can't be NULL");
                }
                _short_Description = value;
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
                SqlString descriptionTmp = (SqlString)value;
                if (descriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                }
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
                SqlBoolean is_ActiveTmp = (SqlBoolean)value;
                if (is_ActiveTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Is_Active", "Is_Active can't be NULL");
                }
                _is_Active = value;
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


        public SqlInt32 PageNum
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

        public SqlInt32 PageSize
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

        public SqlInt32 TotalRowsNum
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
