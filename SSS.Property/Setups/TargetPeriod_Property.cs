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
    public class TargetPeriod_Property
    {

        #region Class Member Declarations
        private SqlDateTime _start_date, _end_date , _insertion_date;
        private SqlInt32 _iD, _parent_id, _inserted_by, _types, operated_By;
        private SqlString _name, _description, _OrderbookerId, _Targetsummaryxml, _PreviusSalesxml, _Salesummaryxml, _status, _tableName;
        private SqlBoolean  _isAnnual_Period ;
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

        public SqlInt32 ParentID
        {
            get
            {
                return _parent_id;
            }
            set
            {
                SqlInt32 _parentidTmp = (SqlInt32)value;
                if (_parentidTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ParentID", "ParentID can't be NULL");
                }
                _parent_id = value;
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
        public SqlString PreviusSalesxml
        {
            get
            {
                return _PreviusSalesxml;
            }
            set
            {
                _PreviusSalesxml = value;
            }
        }
        public SqlString Salesummaryxml
        {
            get
            {
                return _Salesummaryxml;
            }
            set
            {
                _Salesummaryxml = value;
            }
        }
        public SqlString Targetsummaryxml
        {
            get
            {
                return _Targetsummaryxml;
            }
            set
            {
                _Targetsummaryxml = value;
            }
        }
        public SqlString OrderbookerId 
        {
            get
            {
                return _OrderbookerId;
            }
            set
            {
                _OrderbookerId = value;
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

        public SqlDateTime StartDate
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
            }
        }

        public SqlDateTime EndDate
        {
            get
            {
                return _end_date;
            }
            set
            {
                _end_date = value;
            }
        }

        public SqlBoolean IsAnnual_Period
        {
            get
            {
                return _isAnnual_Period;
            }
            set
            {
                _isAnnual_Period = value;
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

        public SqlInt32 Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
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

        public SqlString TableName
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
                SqlInt32 Operated_ByTmp = (SqlInt32)value;
                if (Operated_ByTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                }
                operated_By = value;
            }
        }



      #endregion

    }
}
