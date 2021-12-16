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
    public class Organogram_Property
    {
        #region Class Member Declarations
        private SqlInt32 _compant_ID, _parent_Organo_ID, _iD;
        private SqlInt32? _PageSize, operated_By;
        private SqlString _status, _organogram_Code, _short_Description, _long_Description;
        private string _tableName;
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
        public SqlInt32? PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                SqlInt32 PageSizeTmp = (SqlInt32)value;
                if (PageSizeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PageSize", "PageSize can't be NULL");
                }
                _PageSize = value;
            }
        }
        public SqlInt32? Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                //SqlInt32 Operated_ByTmp = (SqlInt32)value;
                //if (Operated_ByTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                //}
                operated_By = value;
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

        public SqlString Organogram_Code
        {
            get
            {
                return _organogram_Code;
            }
            set
            {
               
                _organogram_Code = value;
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
                
                _short_Description = value;
            }
        }


        public SqlString Long_Description
        {
            get
            {
                return _long_Description;
            }
            set
            {
               
                _long_Description = value;
            }
        }


        public SqlInt32 Parent_Organo_ID
        {
            get
            {
                return _parent_Organo_ID;
            }
            set
            {
               
                _parent_Organo_ID = value;
            }
        }


        public SqlInt32 Compant_ID
        {
            get
            {
                return _compant_ID;
            }
            set
            {
                
                _compant_ID = value;
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
        #endregion

    }
}
