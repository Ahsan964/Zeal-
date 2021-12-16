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
    public class Registration_Type_Property
    {
        #region Class Member Declarations
        private SqlInt32 _iD;
        private SqlString _status, _registration_Type_Code, _registration_Type, _description;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
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


        public SqlString Registration_Type_Code
        {
            get
            {
                return _registration_Type_Code;
            }
            set
            {
                SqlString _registration_Type_CodeTmp = (SqlString)value;
                if (_registration_Type_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Registration_Type_Code", "Registration_Type_Code can't be NULL");
                }
                _registration_Type_Code = value;
            }
        }


        public SqlString Registration_Type
        {
            get
            {
                return _registration_Type;
            }
            set
            {
                SqlString _registration_TypeTmp = (SqlString)value;
                if (_registration_TypeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Registration_Type", "Registration_Type can't be NULL");
                }
                _registration_Type = value;
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
        #endregion

    }
}
