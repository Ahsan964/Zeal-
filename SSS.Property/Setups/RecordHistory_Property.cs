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
    public class RecordHistory_Property
    {
        #region Class Member Declarations
        private SqlDateTime _expire_Date, _batch_Date;
        private SqlInt32 _batch_Index, _sale_Stop_Days, _sale_Alert_Days, _price_ID, _price_IDOld, _iD, _product_ID;
        private SqlString _batch_Code, _active_Status, _description;
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


        public SqlString Batch_Code
        {
            get
            {
                return _batch_Code;
            }
            set
            {
                SqlString batch_CodeTmp = (SqlString)value;
                if (batch_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Batch_Code", "Batch_Code can't be NULL");
                }
                _batch_Code = value;
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


        public SqlString Active_Status
        {
            get
            {
                return _active_Status;
            }
            set
            {
                _active_Status = value;
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


        public SqlInt32 Price_ID
        {
            get
            {
                return _price_ID;
            }
            set
            {
                _price_ID = value;
            }
        }
        public SqlInt32 Price_IDOld
        {
            get
            {
                return _price_IDOld;
            }
            set
            {
                _price_IDOld = value;
            }
        }


        public SqlInt32 Batch_Index
        {
            get
            {
                return _batch_Index;
            }
            set
            {
                _batch_Index = value;
            }
        }


        public SqlDateTime Batch_Date
        {
            get
            {
                return _batch_Date;
            }
            set
            {
                _batch_Date = value;
            }
        }


        public SqlDateTime Expire_Date
        {
            get
            {
                return _expire_Date;
            }
            set
            {
                _expire_Date = value;
            }
        }


        public SqlInt32 Sale_Alert_Days
        {
            get
            {
                return _sale_Alert_Days;
            }
            set
            {
                _sale_Alert_Days = value;
            }
        }


        public SqlInt32 Sale_Stop_Days
        {
            get
            {
                return _sale_Stop_Days;
            }
            set
            {
                _sale_Stop_Days = value;
            }
        }
        #endregion
    }
}
