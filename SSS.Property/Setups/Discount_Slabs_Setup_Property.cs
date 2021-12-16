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
    public class Discount_Slabs_Setup_Property
    {
        #region Class Member Declarations
        private SqlInt32  _discount_ID, _discount_IDOld, _iD;
        private SqlDecimal _for_Each;
        private Int32?  _pageNum, _pageSize, _totalRowsNum, _sNo;
        private string _sortColumn;

        private SqlInt32 operated_By;
        private SqlString operation, _record_Table_Name, _tableName;
        private SqlDateTime _operation_Date;

        private SqlDecimal _discount,  _from_Value, _to_Value;
        private SqlString _status, _description, _short_Description;
        private SqlDecimal? _discount_Limit;
       
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


        public SqlDecimal From_Value
        {
            get
            {
                return _from_Value;
            }
            set
            {
                SqlDecimal from_ValueTmp = (SqlDecimal)value;
                if (from_ValueTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("From_Value", "From_Value can't be NULL");
                }
                _from_Value = value;
            }
        }


        public SqlDecimal To_Value
        {
            get
            {
                return _to_Value;
            }
            set
            {
                SqlDecimal to_ValueTmp = (SqlDecimal)value;
                if (to_ValueTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("To_Value", "To_Value can't be NULL");
                }
                _to_Value = value;
            }
        }


        public SqlDecimal For_Each
        {
            get
            {
                return _for_Each;
            }
            set
            {
                SqlDecimal for_EachTmp = (SqlDecimal)value;
                if (for_EachTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("For_Each", "For_Each can't be NULL");
                }
                _for_Each = value;
            }
        }


        public SqlDecimal? Discount_Limit
        {
            get
            {
                return _discount_Limit;
            }
            set
            {
                //SqlDecimal? discount_LimitTmp = (SqlDecimal)value;
                //if (discount_LimitTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Discount_Limit", "Discount_Limit can't be NULL");
                //}
                _discount_Limit = value;
            }
        }


        public SqlDecimal Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                SqlDecimal discountTmp = (SqlDecimal)value;
                if (discountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Discount", "Discount can't be NULL");
                }
                _discount = value;
            }
        }


        public SqlString Short_Description
        {
            get
            {
                return _short_Description;
            }
            set
            {
                SqlString short_DescriptionTmp = (SqlString)value;
                if (short_DescriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Short_Description", "Short_Description can't be NULL");
                }
                _short_Description = value;
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
    }
}
