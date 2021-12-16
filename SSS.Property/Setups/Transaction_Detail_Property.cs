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
    public class Transaction_Detail_Property
    {
        #region Class Member Declarations
        private SqlDecimal _gST;
        private SqlDateTime? _operation_Date, _document_Date;
        private SqlInt32 _discount_ID, _warehouse_ID, _price_ListId, _price_ListIdOld, _batch_ID, _batch_IDOld, _transaction_Id, _transaction_IdOld, _iD, _product_ID,_product_IDOld, _sales_Type_ID, _sales_Type_IDOld, operated_By;
        private SqlDecimal _amount, _rate, _discount, _quantity, _sold_Quantity, _tax_Amount;
        private SqlString _Stock, _xmlOutput, _skuxml,_status, _product_Name, _sale_Type, _tableName, _wareHouseName, _record_Table_Name, operation, _price_code;
        private Int32? _pageNum, _pageSize, _totalRowsNum, _sNo;
        private SqlInt32? _distributor_ID, _document_Type_ID, _company_ID;
        private DataTable _detailData;
        private string _sortColumn, _documentNo;
        private string _tempID;
        #endregion



        #region Class Property Declarations

        public SqlString XmlOutPut
        {
            get
            {
                return _xmlOutput;
            }
            set
            {
                _xmlOutput = value;
            }
        }

        public SqlString Skuxml
        {
            get
            {
                return _skuxml;
            }
            set
            {
                _skuxml = value;
            }
        }

        public SqlInt32? Document_Type_ID
        {
            get
            {
                return _document_Type_ID;
            }
            set
            {
                _document_Type_ID = value;
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
                SqlInt32 iDTmp = (SqlInt32)value;
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
                _iD = value;
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

        public SqlString PriceCode
        {
            get
            {
                return _price_code;
            }
            set
            {
                _price_code = value;
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
        public SqlDateTime? Document_Date
        {
            get
            {
                return _document_Date;
            }
            set
            {
                _document_Date = value;
            }
        }


        public SqlInt32 Transaction_Id
        {
            get
            {
                return _transaction_Id;
            }
            set
            {
                SqlInt32 transaction_IdTmp = (SqlInt32)value;
                if (transaction_IdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Transaction_Id", "Transaction_Id can't be NULL");
                }
                _transaction_Id = value;
            }
        }
        public SqlInt32 Transaction_IdOld
        {
            get
            {
                return _transaction_IdOld;
            }
            set
            {
                SqlInt32 transaction_IdOldTmp = (SqlInt32)value;
                if (transaction_IdOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Transaction_IdOld", "Transaction_IdOld can't be NULL");
                }
                _transaction_IdOld = value;
            }
        }


        public SqlInt32 Sales_Type_ID
        {
            get
            {
                return _sales_Type_ID;
            }
            set
            {
                _sales_Type_ID = value;
            }
        }
        public SqlInt32 Sales_Type_IDOld
        {
            get
            {
                return _sales_Type_IDOld;
            }
            set
            {
                _sales_Type_IDOld = value;
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
                _product_ID = value;
            }
        }
        public SqlString  Stock
        {
            get
            {
                return _Stock;
            }
            set
            {
                _Stock = value;
            }
        }
        public SqlInt32 Product_IDOld
        {
            get
            {
                return _product_IDOld;
            }
            set
            {
                _product_IDOld = value;
            }
        }


        public SqlInt32 Batch_ID
        {
            get
            {
                return _batch_ID;
            }
            set
            {
                _batch_ID = value;
            }
        }
        public SqlInt32 Batch_IDOld
        {
            get
            {
                return _batch_IDOld;
            }
            set
            {
                _batch_IDOld = value;
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
                _discount_ID = value;
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
                _discount = value;
            }
        }


        public SqlDecimal Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }


        public SqlDecimal Sold_Quantity
        {
            get
            {
                return _sold_Quantity;
            }
            set
            {
                _sold_Quantity = value;
            }
        }

        public SqlDecimal Tax_Amount
        {
            get
            {
                return _tax_Amount;
            }
            set
            {
                _tax_Amount = value;
            }
        }


        public SqlInt32 Price_ListId
        {
            get
            {
                return _price_ListId;
            }
            set
            {
                _price_ListId = value;
            }
        }
        public SqlInt32 Price_ListIdOld
        {
            get
            {
                return _price_ListIdOld;
            }
            set
            {
                _price_ListIdOld = value;
            }
        }


        public SqlDecimal Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
            }
        }


        public SqlDecimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }


        public SqlDecimal GST
        {
            get
            {
                return _gST;
            }
            set
            {
                _gST = value;
            }
        }


        public SqlInt32 Warehouse_ID
        {
            get
            {
                return _warehouse_ID;
            }
            set
            {
                _warehouse_ID = value;
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

        public SqlString ProductName
        {
            get
            {
                return _product_Name;
            }
            set
            {
                _product_Name = value;
            }
        }

        public SqlString WareHouseName
        {
            get
            {
                return _wareHouseName;
            }
            set
            {
                _wareHouseName = value;
            }
        }
        public SqlString SaleType
        {
            get
            {
                return _sale_Type;
            }
            set
            {
                _sale_Type = value;
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

        public SqlInt32? Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                _company_ID = value;
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

        public SqlDateTime? Operation_Date
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
        public string TempID
        {
            get
            {
                return _tempID;
            }
            set
            {
                _tempID = value;
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
