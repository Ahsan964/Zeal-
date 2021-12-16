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
   public  class TargetType_Property
    {

        #region Class Member Declarations
        private SqlDateTime _insertion_date;
        private SqlInt32 _iD, _inserted_by;
        private SqlString _name, _description , _status;
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

        public SqlString Name
        {
            get
            {
                return _name;
            }
            set
            {
                SqlString _nameTmp = (SqlString)value;
                if (_nameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Name", "Name can't be NULL");
                }
                _name = value;
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
        
        public SqlInt32 InsertedBy
        {
            get
            {
                return _inserted_by;
            }
            set
            {
                _inserted_by = value;
            }
        }

        public SqlDateTime InsertionDate
        {
            get
            {
                return _insertion_date;
            }
            set
            {
                _insertion_date = value;
            }
        }

        #endregion
    }
}
