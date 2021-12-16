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
  public class AchivementMaster_Property
    {

        #region Class Member Declarations

        private SqlDateTime _insertion_date;
        private SqlInt32 _iD, _inserted_by, _targetannualperiod_Id  , _targetperiod_Id ,  _targettype_Id , _salesperson_Id  ;
        private SqlString _description, _status, _code;
        private DataTable _detailData;
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

        public SqlString Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public SqlInt32 TargetAnnualPeriodID
        {
            get
            {
                return _targetannualperiod_Id;
            }
            set
            {
                SqlInt32 targetannualperiodIdTmp = (SqlInt32)value;
                if (targetannualperiodIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetAnnualPeriodID", "TargetAnnualPeriodID can't be NULL");
                }
                _targetannualperiod_Id = value;
            }
        }

        public SqlInt32 TargetPeriodID
        {
            get
            {
                return _targetperiod_Id;
            }
            set
            {
                SqlInt32 targetperiodIdTmp = (SqlInt32)value;
                if (targetperiodIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetPeriodID", "TargetPeriodID can't be NULL");
                }
                _targetperiod_Id = value;
            }
        }

        public SqlInt32 TargetTypeID
        {
            get
            {
                return _targettype_Id;
            }
            set
            {
                SqlInt32 targettypeIdTmp = (SqlInt32)value;
                if (targettypeIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetTypeID", "TargetTypeID can't be NULL");
                }
                _targettype_Id = value;
            }
        }

        public SqlInt32 SalePersonID
        {
            get
            {
                return _salesperson_Id;
            }
            set
            {
                SqlInt32 salespersonIdTmp = (SqlInt32)value;
                if (salespersonIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SalePersonID", "SalePersonID can't be NULL");
                }
                _salesperson_Id = value;
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

        public DataTable DetailData
        {
            get
            {
                return _detailData;
            }
            set
            {
                _detailData = value;
            }
        }

        #endregion

    }
}
