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
    public class DistributorWise_BlockedDiscountHistory_Property
    {
        #region Class Member Declarations

        private Int32? _pageNum, _pageSize, _totalRowsNum, _sNo;

        private string _sortColumn;
        
        private SqlString operation, _record_Table_Name, _tableName;

        private SqlDateTime _operatedOn;

        private SqlInt32 _iD, operated_By, _distributorWise_Blocked_DiscountId;

        private SqlString  _status;

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


        public SqlInt32 DistributorWiseBlockedDiscountId
        {
            get
            {
                return _distributorWise_Blocked_DiscountId;
            }
            set
            {
                SqlInt32 discount_IDTmp = (SqlInt32)value;
                if (discount_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DistributorWise_Blocked_DiscountId", "DistributorWise_Blocked_DiscountId can't be NULL");
                }
                _distributorWise_Blocked_DiscountId = value;
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
                SqlString statusTmp = (SqlString)value;
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
                _status = value;
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

        public SqlDateTime OperatedOn
        {
            get
            {
                return _operatedOn;
            }
            set
            {
                SqlDateTime operatedon_DateTmp = (SqlDateTime)value;
                if (operatedon_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                }
                _operatedOn = value;
            }
        }

        public SqlString Operation
        {
            get
            {
                return operation;
            }
            set
            {
                SqlString OperationTemp = (SqlString)value;
                if (OperationTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operation", "Operation can't be NULL");
                }
                operation = value;
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

        public SqlString Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                SqlString record_Table_NameTemp = (SqlString)value;
                if (record_Table_NameTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Record_Table_Name", "Record Table Name can't be NULL");
                }
                _record_Table_Name = value;
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

        #endregion
    }
}