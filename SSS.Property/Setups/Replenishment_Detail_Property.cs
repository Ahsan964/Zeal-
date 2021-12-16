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
    public class Replenishment_Detail_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate;
        private SqlDecimal _scmPrice, _dBRValue;
        private SqlInt32 _rDR, _safetyStock, _averageSales, _insertBy, _totalFinalDBR, _additionInOrder, _closing, _productId, _opening, _id, _replenishmentMasterId, _totalOnHandStock, _totalSecondarySales, _primarySales, _salesReturn;
        private SqlString _status;
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


        public SqlInt32 ReplenishmentMasterId
        {
            get
            {
                return _replenishmentMasterId;
            }
            set
            {
                _replenishmentMasterId = value;
            }
        }


        public SqlInt32 ProductId
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


        public SqlDecimal ScmPrice
        {
            get
            {
                return _scmPrice;
            }
            set
            {
                _scmPrice = value;
            }
        }


        public SqlInt32 Opening
        {
            get
            {
                return _opening;
            }
            set
            {
                _opening = value;
            }
        }


        public SqlInt32 PrimarySales
        {
            get
            {
                return _primarySales;
            }
            set
            {
                _primarySales = value;
            }
        }


        public SqlInt32 SalesReturn
        {
            get
            {
                return _salesReturn;
            }
            set
            {
                _salesReturn = value;
            }
        }


        public SqlInt32 TotalOnHandStock
        {
            get
            {
                return _totalOnHandStock;
            }
            set
            {
                _totalOnHandStock = value;
            }
        }


        public SqlInt32 TotalSecondarySales
        {
            get
            {
                return _totalSecondarySales;
            }
            set
            {
                _totalSecondarySales = value;
            }
        }


        public SqlInt32 Closing
        {
            get
            {
                return _closing;
            }
            set
            {
                _closing = value;
            }
        }


        public SqlInt32 AverageSales
        {
            get
            {
                return _averageSales;
            }
            set
            {
                _averageSales = value;
            }
        }


        public SqlInt32 SafetyStock
        {
            get
            {
                return _safetyStock;
            }
            set
            {
                _safetyStock = value;
            }
        }


        public SqlInt32 RDR
        {
            get
            {
                return _rDR;
            }
            set
            {
                _rDR = value;
            }
        }


        public SqlInt32 AdditionInOrder
        {
            get
            {
                return _additionInOrder;
            }
            set
            {
                _additionInOrder = value;
            }
        }


        public SqlInt32 TotalFinalDBR
        {
            get
            {
                return _totalFinalDBR;
            }
            set
            {
                _totalFinalDBR = value;
            }
        }


        public SqlDecimal DBRValue
        {
            get
            {
                return _dBRValue;
            }
            set
            {
                _dBRValue = value;
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
