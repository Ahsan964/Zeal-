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
    [Serializable()]
  public  class Product_Form_Property
    {

        #region Class Member Declarations
        private SqlInt32 _iD;
        private SqlString _product_Form_Description, _status, _product_Form_Code, _product_Form_Name;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName, operation;
        private SqlInt32 operated_By;
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
                //SqlInt32 iDTmp = (SqlInt32)value;
                //if (iDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                //}
                _iD = value;
            }
        }


        public SqlString Product_Form_Code
        {
            get
            {
                return _product_Form_Code;
            }
            set
            {
                //SqlString product_Form_CodeTmp = (SqlString)value;
                //if (product_Form_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Form_Code", "Product_Form_Code can't be NULL");
                //}
                _product_Form_Code = value;
            }
        }


        public SqlString Product_Form_Name
        {
            get
            {
                return _product_Form_Name;
            }
            set
            {
                //SqlString product_Form_NameTmp = (SqlString)value;
                //if (product_Form_NameTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Form_Name", "Product_Form_Name can't be NULL");
                //}
                _product_Form_Name = value;
            }
        }


        public SqlString Product_Form_Description
        {
            get
            {
                return _product_Form_Description;
            }
            set
            {
                //SqlString product_Form_DescriptionTmp = (SqlString)value;
                //if (product_Form_DescriptionTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Form_Description", "Product_Form_Description can't be NULL");
                //}
                _product_Form_Description = value;
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

      //***********//
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
        public string Operation
        {
            get
            {
                return operation;
            }
            set
            {

                operation = value;
            }
        }

        #endregion
    }
}
