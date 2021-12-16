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
    public class Replenishment_Master_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate, _datefrom, _dateto, _transactionDate;
        private SqlInt32 _insertBy, _id, _distributorId;
        private SqlString _replenishmentNo, _status, _productId, _distributorCode, _distributorIdsMultiple;
        private DataTable _detailData;
        #endregion

        #region Class Property Declarations
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


        public SqlString ReplenishmentNo
        {
            get
            {
                return _replenishmentNo;
            }
            set
            {
                _replenishmentNo = value;
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

        public SqlString ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        public SqlString DistributorCode
        {
            get
            {
                return _distributorCode;
            }
            set
            {
                _distributorCode = value;
            }
        }

        public SqlString DistributorIdsMultiple
        {
            get
            {
                return _distributorIdsMultiple;
            }
            set
            {
                _distributorIdsMultiple = value;
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


        public SqlDateTime Datefrom
        {
            get
            {
                return _datefrom;
            }
            set
            {
                _datefrom = value;
            }
        }


        public SqlDateTime Dateto
        {
            get
            {
                return _dateto;
            }
            set
            {
                _dateto = value;
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
        #endregion
	
    }
}
