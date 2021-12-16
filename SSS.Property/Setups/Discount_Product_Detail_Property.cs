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
    public class Discount_Product_Detail_Property
    {
        #region Class Member Declarations
        private SqlInt32 _free_Product_ID, _alternate_Product_ID, _product_ID, _iD, _discount_ID, _discount_IDOld;
        private SqlString _status, _narration;

        private SqlInt32 operated_By;
        private SqlString operation, _record_Table_Name ,_tableName;
        private SqlDateTime _operation_Date; 
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


        public SqlInt32 Discount_ID
        {
            get
            {
                return _discount_ID;
            }
            set
            {
                SqlInt32 discount_IDTmp = (SqlInt32)value;
                if (discount_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_ID", "Discount_ID can't be NULL");
                }
                _discount_ID = value;
            }
        }
        public SqlInt32 Discount_IDOld
        {
            get
            {
                return _discount_IDOld;
            }
            set
            {
                SqlInt32 discount_IDOldTmp = (SqlInt32)value;
                if (discount_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount_IDOld", "Discount_IDOld can't be NULL");
                }
                _discount_IDOld = value;
            }
        }


        public SqlInt32 Product_ID
        {
            get
            {
                return _product_ID;
            }
            set
            {
                SqlInt32 product_IDTmp = (SqlInt32)value;
                if (product_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Product_ID", "Product_ID can't be NULL");
                }
                _product_ID = value;
            }
        }


        public SqlInt32 Free_Product_ID
        {
            get
            {
                return _free_Product_ID;
            }
            set
            {
                SqlInt32 free_Product_IDTmp = (SqlInt32)value;
                if (free_Product_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Free_Product_ID", "Free_Product_ID can't be NULL");
                }
                _free_Product_ID = value;
            }
        }


        public SqlInt32 Alternate_Product_ID
        {
            get
            {
                return _alternate_Product_ID;
            }
            set
            {
                SqlInt32 alternate_Product_IDTmp = (SqlInt32)value;
                if (alternate_Product_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Alternate_Product_ID", "Alternate_Product_ID can't be NULL");
                }
                _alternate_Product_ID = value;
            }
        }


        public SqlString Narration
        {
            get
            {
                return _narration;
            }
            set
            {
                SqlString narrationTmp = (SqlString)value;
                if (narrationTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Narration", "Narration can't be NULL");
                }
                _narration = value;
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
    }
}
