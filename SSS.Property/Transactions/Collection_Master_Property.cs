using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Transactions
{
    [Serializable()]
    public class Collection_Master_Property
    {
        #region Class Member Declarations
        private SqlDateTime _cashMemo_Date;
        private SqlDateTime? _deliveryDate;
        private SqlDecimal _net_Amount, _recieved_Amount, _ret_Amount;
        private SqlInt32 _cashMemo_ID, _iD, _temp_ID;
        private SqlInt32? _posID, _personnelRef_ID, _location_ID, _distributor_ID, _company_id, _pRP_ID, _delivery_Man_ID;
        private SqlString _status;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _documentNo;
        
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

        public SqlInt32 CashMemo_ID
        {
            get
            {
                return _cashMemo_ID;
            }
            set
            {
                _cashMemo_ID = value;
            }
        }
        public SqlInt32 Temp_ID
        {
            get
            {
                return _temp_ID;
            }
            set
            {
                _temp_ID = value;
            }
        }


        public SqlDateTime CashMemo_Date
        {
            get
            {
                return _cashMemo_Date;
            }
            set
            {
                _cashMemo_Date = value;
            }
        }


        public SqlDecimal Net_Amount
        {
            get
            {
                return _net_Amount;
            }
            set
            {
                _net_Amount = value;
            }
        }


        public SqlDecimal Recieved_Amount
        {
            get
            {
                return _recieved_Amount;
            }
            set
            {
                _recieved_Amount = value;
            }
        }

        public SqlDecimal Return_Amount
        {
            get
            {
                return _ret_Amount;
            }
            set
            {
                _ret_Amount = value;
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

        public SqlInt32? Pos_ID
        {
            get
            {
                return _posID;
            }
            set
            {
                _posID = value;
            }
        }

        public SqlInt32? PersonnelRef_ID
        {
            get
            {
                return _personnelRef_ID;
            }
            set
            {
                _personnelRef_ID = value;
            }
        }

        public SqlInt32? Location_ID
        {
            get
            {
                return _location_ID;
            }
            set
            {
                _location_ID = value;
            }
        }

        public SqlInt32? Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }
            set
            {
                _distributor_ID = value;
            }
        }

        public SqlInt32? Company_id
        {
            get
            {
                return _company_id;
            }
            set
            {
                _company_id = value;
            }
        }

        public SqlInt32? PRP_ID
        {
            get
            {
                return _pRP_ID;
            }
            set
            {
                _pRP_ID = value;
            }
        }

        public SqlInt32? Delivery_Man_ID
        {
            get
            {
                return _delivery_Man_ID;
            }
            set
            {
                _delivery_Man_ID = value;
            }
        }

        public SqlDateTime? DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;
            }
        }

        public string DocumentNo
        {
            get
            {
                return _documentNo;
            }
            set
            {
                _documentNo = value;
            }
        }
        #endregion
    }
}
