using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class TradeMarketingExpenseDetail_Property
    {
        #region Class Member Declarations
        private SqlDateTime _expenseDate, _transactionDate, _insertionDate, _updationDate;
        private SqlDecimal _expenseAmount;
        private SqlInt32 _claimStatus, _updateBy, _insertBy, _dataRefId, _tradeMarketingSetupId, _distributorId, _id;
        private SqlString _reciptNo, _status, _reasons, _details;
        #endregion


        #region Class Property Declarations
        public SqlInt32 Id
        {
            get
            {
                return _id;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _id = value;
            }
        }


        public SqlInt32 TradeMarketingSetupId
        {
            get
            {
                return _tradeMarketingSetupId;
            }
            set
            {
                _tradeMarketingSetupId = value;
            }
        }


        public SqlInt32 DistributorId
        {
            get
            {
                return _distributorId;
            }
            set
            {
                _distributorId = value;
            }
        }


        public SqlDateTime ExpenseDate
        {
            get
            {
                return _expenseDate;
            }
            set
            {
                _expenseDate = value;
            }
        }


        public SqlDateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
            }
        }


        public SqlString Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
            }
        }


        public SqlString Reasons
        {
            get
            {
                return _reasons;
            }
            set
            {
                _reasons = value;
            }
        }


        public SqlString ReciptNo
        {
            get
            {
                return _reciptNo;
            }
            set
            {
                _reciptNo = value;
            }
        }


        public SqlDecimal ExpenseAmount
        {
            get
            {
                return _expenseAmount;
            }
            set
            {
                _expenseAmount = value;
            }
        }


        public SqlInt32 ClaimStatus
        {
            get
            {
                return _claimStatus;
            }
            set
            {
                _claimStatus = value;
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


        public SqlInt32 DataRefId
        {
            get
            {
                return _dataRefId;
            }
            set
            {
                _dataRefId = value;
            }
        }


        public SqlInt32 InsertBy
        {
            get
            {
                return _insertBy;
            }
            set
            {
                _insertBy = value;
            }
        }


        public SqlDateTime InsertionDate
        {
            get
            {
                return _insertionDate;
            }
            set
            {
                _insertionDate = value;
            }
        }


        public SqlInt32 UpdateBy
        {
            get
            {
                return _updateBy;
            }
            set
            {
                _updateBy = value;
            }
        }


        public SqlDateTime UpdationDate
        {
            get
            {
                return _updationDate;
            }
            set
            {
                _updationDate = value;
            }
        }
        #endregion

    }
}
