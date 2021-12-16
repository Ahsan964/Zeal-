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
    public class Discount_Master_Property
    {

        #region Class Member Declarations
        private SqlBoolean _claimable, _is_Active, _user_Rights, _Location, _BT, _POS, _POST, _DIST;

        private Int32? _pageNum, _pageSize, _totalRowsNum, _sNo;
        private string _sortColumn;

        private SqlInt32 operated_By;
        private SqlString operation, _record_Table_Name, _tableName;
        private SqlDateTime _operation_Date;

        private SqlDateTime _valid_To_Date, _valid_From_Date;
        private SqlInt32 _iD, _discount_Type_ID, _discount_Type_IDOld;
       
        private SqlString _discount_Code, _status, _active_Status, _circular_No, _description; 
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


        public SqlInt32 Discount_Type_ID
        {
            get
            {
                return _discount_Type_ID;
            }
            set
            {
                SqlInt32 discount_Type_IDTmp = (SqlInt32)value;
                if (discount_Type_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_Type_ID", "Discount_Type_ID can't be NULL");
                }
                _discount_Type_ID = value;
            }
        }
        public SqlInt32 Discount_Type_IDOld
        {
            get
            {
                return _discount_Type_IDOld;
            }
            set
            {
                SqlInt32 discount_Type_IDOldTmp = (SqlInt32)value;
                if (discount_Type_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_Type_IDOld", "Discount_Type_IDOld can't be NULL");
                }
                _discount_Type_IDOld = value;
            }
        }


        public SqlString Discount_Code
        {
            get
            {
                return _discount_Code;
            }
            set
            {
                SqlString discount_CodeTmp = (SqlString)value;
                if (discount_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_Code", "Discount_Code can't be NULL");
                }
                _discount_Code = value;
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
                SqlString descriptionTmp = (SqlString)value;
                if (descriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                }
                _description = value;
            }
        }


        public SqlString Active_Status
        {
            get
            {
                return _active_Status;
            }
            set
            {
                SqlString active_StatusTmp = (SqlString)value;
                if (active_StatusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Active_Status", "Active_Status can't be NULL");
                }
                _active_Status = value;
            }
        }


        public SqlDateTime Valid_From_Date
        {
            get
            {
                return _valid_From_Date;
            }
            set
            {
                SqlDateTime valid_From_DateTmp = (SqlDateTime)value;
                if (valid_From_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Valid_From_Date", "Valid_From_Date can't be NULL");
                }
                _valid_From_Date = value;
            }
        }


        public SqlDateTime Valid_To_Date
        {
            get
            {
                return _valid_To_Date;
            }
            set
            {
                SqlDateTime valid_To_DateTmp = (SqlDateTime)value;
                if (valid_To_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Valid_To_Date", "Valid_To_Date can't be NULL");
                }
                _valid_To_Date = value;
            }
        }


        public SqlString Circular_No
        {
            get
            {
                return _circular_No;
            }
            set
            {
                SqlString circular_NoTmp = (SqlString)value;
                if (circular_NoTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Circular_No", "Circular_No can't be NULL");
                }
                _circular_No = value;
            }
        }


        public SqlBoolean Claimable
        {
            get
            {
                return _claimable;
            }
            set
            {
                SqlBoolean claimableTmp = (SqlBoolean)value;
                if (claimableTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Claimable", "Claimable can't be NULL");
                }
                _claimable = value;
            }
        }


        public SqlBoolean User_Rights
        {
            get
            {
                return _user_Rights;
            }
            set
            {
                SqlBoolean user_RightsTmp = (SqlBoolean)value;
                if (user_RightsTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("User_Rights", "User_Rights can't be NULL");
                }
                _user_Rights = value;
            }
        }


        public SqlBoolean Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                SqlBoolean is_ActiveTmp = (SqlBoolean)value;
                if (is_ActiveTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Is_Active", "Is_Active can't be NULL");
                }
                _is_Active = value;
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
        public SqlDateTime Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                if (operation_Date_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                }
                _operation_Date = value;
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


        public SqlBoolean Location
        {
            get
            {
                return _Location;
            }
            set
            {
                SqlBoolean LocationTmp = (SqlBoolean)value;
                if (LocationTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Location", "Location can't be NULL");
                }
                _Location = value;
            }
        }
        public SqlBoolean BusinessType
        {
            get
            {
                return _BT;
            }
            set
            {
                SqlBoolean claimableTmp = (SqlBoolean)value;
                if (claimableTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("BusinessType", "BusinessType can't be NULL");
                }
                _BT = value;
            }
        }
        public SqlBoolean POS
        {
            get
            {
                return _POS;
            }
            set
            {
                SqlBoolean claimableTmp = (SqlBoolean)value;
                if (claimableTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("POS", "POS can't be NULL");
                }
                _POS = value;
            }
        }
        public SqlBoolean POSType
        {
            get
            {
                return _POST;
            }
            set
            {
                SqlBoolean claimableTmp = (SqlBoolean)value;
                if (claimableTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("POSType", "POSType can't be NULL");
                }
                _POST = value;
            }
        }
        public SqlBoolean Distributor
        {
            get
            {
                return _DIST;
            }
            set
            {
                SqlBoolean claimableTmp = (SqlBoolean)value;
                if (claimableTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Distributor", "Distributor can't be NULL");
                }
                _DIST = value;
            }
        }
    }
}
