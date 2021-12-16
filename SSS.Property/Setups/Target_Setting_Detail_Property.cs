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
    public class Target_Setting_Detail_Property
    {

        #region Class Member Declarations

        private SqlDateTime _insertion_date;
        private SqlInt32 _iD, _targetSetting_MasterID, _prod_CategoryID, _productID, _inserted_by;
        private SqlDecimal _maxtarget_Amt, _mintarget_Amt, _maxtarget_Qty, _mintarget_Qty, _numberofShops;
        private SqlString _status;
        private SqlBoolean _isCategory;

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

        public SqlInt32 TargetSetting_MasterID
        {
            get
            {
                return _targetSetting_MasterID;
            }
            set
            {
                SqlInt32 _targetSetting_MasterIDTmp = (SqlInt32)value;
                if (_targetSetting_MasterIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TargetSetting_MasterID", "TargetSetting_MasterID can't be NULL");
                }
                _targetSetting_MasterID = value;
            }
        }

        public SqlInt32 Prod_CategoryID
        {
            get
            {
                return _prod_CategoryID;
            }
            set
            {
                SqlInt32 _prod_CategoryIDTmp = (SqlInt32)value;
                if (_prod_CategoryIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Prod_CategoryID", "Prod_CategoryID can't be NULL");
                }
                _prod_CategoryID = value;
            }
        }

        public SqlInt32 ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                SqlInt32 _productIDTmp = (SqlInt32)value;
                if (_productIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ProductID", "ProductID can't be NULL");
                }
                _productID = value;
            }
        }

        public SqlDecimal NumberofShops
        {
            get
            {
                return _numberofShops;
            }
            set
            {
                SqlDecimal _numberofShopsTemp = (SqlDecimal)value;
                if (_numberofShopsTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("NumberofShops", "NumberofShops can't be NULL");
                }
                _numberofShops = value;
            }
        }

        public SqlDecimal MaxTarget_Qty
        {
            get
            {
                return _maxtarget_Qty;
            }
            set
            {
                SqlDecimal _maxtarget_QtyTmp = (SqlDecimal)value;
                if (_maxtarget_QtyTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MaxTarget_Qty", "MaxTarget_Qty can't be NULL");
                }
                _maxtarget_Qty = value;
            }
        }

        public SqlDecimal MinTarget_Qty
        {
            get
            {
                return _mintarget_Qty;
            }
            set
            {
                SqlDecimal _orderbookerIDTmp = (SqlDecimal)value;
                if (_orderbookerIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MinTarget_Qty", "MinTarget_Qty can't be NULL");
                }
                _mintarget_Qty = value;
            }
        }

        public SqlDecimal MaxTarget_Amt
        {
            get
            {
                return _maxtarget_Amt;
            }
            set
            {
                SqlDecimal _maxtarget_AmtTmp = (SqlInt32)value;
                if (_maxtarget_AmtTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MaxTarget_Amt", "MaxTarget_Amt can't be NULL");
                }
                _maxtarget_Amt = value;
            }
        }

        public SqlDecimal MinTarget_Amt
        {
            get
            {
                return _mintarget_Amt;
            }
            set
            {
                SqlDecimal _mintarget_AmtTmp = (SqlInt32)value;
                if (_mintarget_AmtTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MinTarget_Amt", "MinTarget_Amt can't be NULL");
                }
                _mintarget_Amt = value;
            }
        }


        public SqlBoolean IsCategory
        {
            get
            {
                return _isCategory;
            }
            set
            {
                SqlDecimal _isCategoryTmp = (SqlInt32)value;
                if (_isCategoryTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("IsCategory", "IsCategory can't be NULL");
                }
                _isCategory = value;
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


        #endregion

    }
}
