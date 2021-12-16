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
    public class Target_Setting_Master_Property
    {

        #region Class Member Declarations

        private SqlDateTime  _insertion_date;
        private SqlInt32 _iD, _targetAnnual_PeriodID, _targetPeriodID, _distributorID, _orderbookerID, _inserted_by, _organogramLevel, _targetTypeId;
        private SqlString _status, _orderBookersMultipleIDs, _productsMultipleIDs;
        private SqlDecimal _productivityTarget, _inputAchievement;
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

        public SqlInt32 TargetAnnualPeriodID
        {
            get
            {
                return _targetAnnual_PeriodID;
            }
            set
            {
                SqlInt32 _targetAnnual_PeriodIDTmp = (SqlInt32)value;
                if (_targetAnnual_PeriodIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetAnnualPeriodID", "TargetAnnualPeriodID can't be NULL");
                }
                _targetAnnual_PeriodID = value;
            }
        }

        public SqlInt32 TargetPeriodID
        {
            get
            {
                return _targetPeriodID;
            }
            set
            {
                SqlInt32 _targetPeriodIDTmp = (SqlInt32)value;
                if (_targetPeriodIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetPeriodID", "TargetPeriodID can't be NULL");
                }
                _targetPeriodID = value;
            }
        }

        public SqlInt32 DistributorID
        {
            get
            {
                return _distributorID;
            }
            set
            {
                SqlInt32 _distributorIDTmp = (SqlInt32)value;
                if (_distributorIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DistributorID", "DistributorID can't be NULL");
                }
                _distributorID = value;
            }
        }


        public SqlDecimal ProductivityTarget
        {
            get
            {
                return _productivityTarget;
            }
            set
            {
                SqlDecimal _productivityTargetTmp = (SqlDecimal)value;
                if (_productivityTargetTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetProductivity%", "TargetProductivity can't be NULL");
                }
                _productivityTarget = value;
            }
        }

        public SqlDecimal InputAchievement
        {
            get
            {
                return _inputAchievement;
            }
            set
            {
                _inputAchievement = value;
            }
        }
        
        public SqlInt32 OrderBookerID
        {
            get
            {
                return _orderbookerID;
            }
            set
            {
                SqlInt32 _orderbookerIDTmp = (SqlInt32)value;
                if (_orderbookerIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OrderBookerID", "OrderBookerID can't be NULL");
                }
                _orderbookerID = value;
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

        public SqlString OrderBookersMultipleIDs
        {
            get
            {
                return _orderBookersMultipleIDs;
            }
            set
            {
                _orderBookersMultipleIDs = value;
            }
        }

        public SqlString ProductsMultipleIDs
        {
            get
            {
                return _productsMultipleIDs;
            }
            set
            {
                _productsMultipleIDs = value;
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

        public SqlInt32 OrganogramLevel
        {
            get
            {
                return _organogramLevel;
            }
            set
            {
                _organogramLevel = value;
            }
        }

        public SqlInt32 TargetTypeId
        {
            get
            {
                return _targetTypeId;
            }
            set
            {
                _targetTypeId = value;
            }
        }
        
        #endregion
    }
}
