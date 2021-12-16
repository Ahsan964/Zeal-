using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Transactions
{
    public class DSRAdjustment_Property
    {
        #region Class Member Declarations
        private Int32? _pageNum, _pageSize, _totalRowsNum, _routeID;
        private SqlDateTime _adjustment_Date;
        private SqlDecimal _adjust_Amount;
        private SqlInt32 _daily_Cash_Recieved_ID, _personnel_ID, _iD, _distributor_ID, _company_ID, operated_By;
        private SqlString _adjustment_Type, _adjust_Amount_Type, _reason, _code, _status;
        private string _sortColumn, _tableName;
        private SqlDateTime? _FromDate, _ToDate;
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
                //SqlString codeTmp = (SqlString)value;
                //if (codeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Code", "Code can't be NULL");
                //}
                _code = value;
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


        public SqlInt32 Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }
            set
            {
                //SqlInt32 distributor_IDTmp = (SqlInt32)value;
                //if (distributor_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Distributor_ID", "Distributor_ID can't be NULL");
                //}
                _distributor_ID = value;
            }
        }


        public SqlInt32 Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                //SqlInt32 company_IDTmp = (SqlInt32)value;
                //if (company_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                //}
                _company_ID = value;
            }
        }


        public SqlInt32 Daily_Cash_Recieved_ID
        {
            get
            {
                return _daily_Cash_Recieved_ID;
            }
            set
            {
                //SqlInt32 daily_Cash_Recieved_IDTmp = (SqlInt32)value;
                //if (daily_Cash_Recieved_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Daily_Cash_Recieved_ID", "Daily_Cash_Recieved_ID can't be NULL");
                //}
                _daily_Cash_Recieved_ID = value;
            }
        }


        public SqlString Adjustment_Type
        {
            get
            {
                return _adjustment_Type;
            }
            set
            {
                //SqlString adjustment_TypeTmp = (SqlString)value;
                //if (adjustment_TypeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Adjustment_Type", "Adjustment_Type can't be NULL");
                //}
                _adjustment_Type = value;
            }
        }


        public SqlString Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                //SqlString reasonTmp = (SqlString)value;
                //if (reasonTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Reason", "Reason can't be NULL");
                //}
                _reason = value;
            }
        }


        public SqlDecimal Adjust_Amount
        {
            get
            {
                return _adjust_Amount;
            }
            set
            {
                //SqlDecimal adjust_AmountTmp = (SqlDecimal)value;
                //if (adjust_AmountTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Adjust_Amount", "Adjust_Amount can't be NULL");
                //}
                _adjust_Amount = value;
            }
        }


        public SqlString Adjust_Amount_Type
        {
            get
            {
                return _adjust_Amount_Type;
            }
            set
            {
                //SqlString adjust_Amount_TypeTmp = (SqlString)value;
                //if (adjust_Amount_TypeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Adjust_Amount_Type", "Adjust_Amount_Type can't be NULL");
                //}
                _adjust_Amount_Type = value;
            }
        }


        public SqlDateTime Adjustment_Date
        {
            get
            {
                return _adjustment_Date;
            }
            set
            {
                //SqlDateTime adjustment_DateTmp = (SqlDateTime)value;
                //if (adjustment_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Adjustment_Date", "Adjustment_Date can't be NULL");
                //}
                _adjustment_Date = value;
            }
        }


        public SqlInt32 Personnel_ID
        {
            get
            {
                return _personnel_ID;
            }
            set
            {
                //SqlInt32 personnel_IDTmp = (SqlInt32)value;
                //if (personnel_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Personnel_ID", "Personnel_ID can't be NULL");
                //}
                _personnel_ID = value;
            }
        }

        public int? RouteID
        {
            get
            {
                return _routeID;
            }
            set
            {
                _routeID = value;
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

        public SqlInt32 Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                operated_By = value;
            }
        }
        public SqlDateTime? From_Date
        {
            get
            {
                return _FromDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _FromDate = value;
            }
        }

        public SqlDateTime? TO_Date
        {
            get
            {
                return _ToDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _ToDate = value;
            }
        }

        #endregion
    }
}
