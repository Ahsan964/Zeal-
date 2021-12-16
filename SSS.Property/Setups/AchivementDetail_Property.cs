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
   public  class AchivementDetail_Property
    {

        #region Class Member Declarations

        private SqlDateTime _insertion_date;
        private Int32? _sNo;
        private SqlInt32 _iD, _inserted_by, _achivement_MasterId;
        private SqlString _description, _short_description , _status;
        private SqlDecimal _insentiveAmount ,_validfromvalue , _validtovalue;
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

        public SqlInt32 Achivement_MasterId
        {
            get
            {
                return _achivement_MasterId;
            }
            set
            {
                SqlInt32 achivementMasterIdTmp = (SqlInt32)value;
                if (achivementMasterIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Achivement_MasterId", "Achivement_MasterId can't be NULL");
                }
                _achivement_MasterId = value;
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

        public SqlString Short_Description
        {
            get
            {
                return _short_description;
            }
            set
            {
                _short_description = value;
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

        public SqlDecimal InsentiveAmount
        {
            get
            {
                return _insentiveAmount;
            }
            set
            {
                SqlDecimal _insentiveAmountTmp = (SqlInt32)value;
                if (_insentiveAmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("InsentiveAmount", "InsentiveAmount can't be NULL");
                }
                _insentiveAmount = value;
            }
        }

        public SqlDecimal ValidFromValue
        {
            get
            {
                return _validfromvalue;
            }
            set
            {
                SqlDecimal _validfromvalueTmp = (SqlInt32)value;
                if (_validfromvalueTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ValidFromValue", "ValidFromValue can't be NULL");
                }
                _validfromvalue = value;
            }
        }

        public SqlDecimal ValidToValue
        {
            get
            {
                return _validtovalue;
            }
            set
            {
                SqlDecimal _validtovalueTmp = (SqlInt32)value;
                if (_validtovalueTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ValidToValue", "ValidToValue can't be NULL");
                }
                _validtovalue = value;
            }
        }
        
       public int? SNo
        {
            get
            {
                return _sNo;
            }
            set
            {
                _sNo = value;
            }
        }

        #endregion
    }
}
