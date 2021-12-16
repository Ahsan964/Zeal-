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
    public class Batch_Setup_Property
    {
        #region Class Member Declarations
        private SqlDateTime _batch_Date, _expire_Date;
        private SqlInt32 _price_ID, _price_IDOld, _batch_Index, _sale_Alert_Days, _sale_Stop_Days, _product_ID, _iD, _company_ID, _distributor_ID, operated_By, _iErrorCode, _PageNum, _PageSize, _TotalRowsNum, _errorcode;
        private SqlString _status, _description, _batch_Code, _active_Status, _record_Table_Name, operation, _sortColumn;



        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string  _tableName;



        #endregion

        #region Class Property Declarations



        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorcode;
            }
            set
            {

                _errorcode = value;
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






        public SqlInt32 ID
        {
            get
            {
                return _iD;
            }
            set
            {
                //SqlInt32 iDTmp = (SqlInt32)value;
                //if (iDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                //}
                _iD = value;
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
                SqlInt32 company_IDTmp = (SqlInt32)value;
                //if (company_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                //}
                _company_ID = value;
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
                //SqlInt32 Operated_ByTmp = (SqlInt32)value;
                //if (Operated_ByTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                //}
                operated_By = value;
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

        public SqlInt32 iErrorCode
        {
            get
            {
                return _iErrorCode;
            }
            set
            {
                SqlInt32 iErrorCodeTmp = (SqlInt32)value;
                if (iErrorCodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("iErrorCode", "iErrorCode can't be NULL");
                }
                _iErrorCode = value;
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
                //SqlString batch_CodeTmp = (SqlString)value;
                //if (batch_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Batch_Code", "Batch_Code can't be NULL");
                //}
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
                //SqlString descriptionTmp = (SqlString)value;
                //if (descriptionTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                //}
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
                //SqlString active_StatusTmp = (SqlString)value;
                //if (active_StatusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Active_Status", "Active_Status can't be NULL");
                //}
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
                //SqlInt32 product_IDTmp = (SqlInt32)value;
                //if (product_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_ID", "Product_ID can't be NULL");
                //}
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
                //SqlInt32 price_IDTmp = (SqlInt32)value;
                //if (price_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Price_ID", "Price_ID can't be NULL");
                //}
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
                //SqlInt32 price_IDOldTmp = (SqlInt32)value;
                //if (price_IDOldTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Price_IDOld", "Price_IDOld can't be NULL");
                //}
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
                //SqlInt32 batch_IndexTmp = (SqlInt32)value;
                //if (batch_IndexTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Batch_Index", "Batch_Index can't be NULL");
                //}
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
                //SqlDateTime batch_DateTmp = (SqlDateTime)value;
                //if (batch_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Batch_Date", "Batch_Date can't be NULL");
                //}
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
                //SqlDateTime expire_DateTmp = (SqlDateTime)value;
                //if (expire_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Expire_Date", "Expire_Date can't be NULL");
                //}
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
                //SqlInt32 sale_Alert_DaysTmp = (SqlInt32)value;
                //if (sale_Alert_DaysTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Sale_Alert_Days", "Sale_Alert_Days can't be NULL");
                //}
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
                //SqlInt32 sale_Stop_DaysTmp = (SqlInt32)value;
                //if (sale_Stop_DaysTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Sale_Stop_Days", "Sale_Stop_Days can't be NULL");
                //}
                _sale_Stop_Days = value;
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
                //SqlString statusTmp = (SqlString)value;
                //if (statusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                //}
                _status = value;
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
                //SqlString  record_Table_NameTemp = (SqlString)value;
                //if (record_Table_NameTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Record_Table_Name", "Record Table Name can't be NULL");
                //}
                _record_Table_Name = value;
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
                //SqlString OperationTemp = (SqlString)value;
                //if (OperationTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation", "Operation can't be NULL");
                //}
                operation = value;
            }
        }

        public SqlString SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                //SqlString sortColumnTemp = (SqlString)value;
                //if (sortColumnTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("SortColumn", "SortColumn can't be NULL");
                //}
                _sortColumn = value;
            }
        }
        #endregion
    }
}
