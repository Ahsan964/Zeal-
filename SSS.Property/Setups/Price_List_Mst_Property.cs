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
    public class Price_List_Mst_Property
    {
        #region Class Member Declarations

        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _tableName;

        private SqlDateTime _expire_Date, _batch_Date;
        private SqlInt32 _batch_Index, _sale_Stop_Days, _sale_Alert_Days, _price_ID, _price_IDOld, _iD, _product_ID, operated_By, _errorcode, _companyid, _price_Index;
        private SqlString _batch_Code, _active_Status, _description, _sortColumn;

        private SqlDecimal _mSRP, _retailPrice, _salePrice, _tradePrice, _primaryPrice;
        private SqlInt32 _taxID, _batch_ID, _batch_IDOld, _priceproduct_ID, _distributorID;
        private SqlString _price_Code, _currency_Code, _currency_CodeOld, _priceliststatus, _pricelistactive_Status, _price_Title, _status;
        private string _tempID;


        #endregion

        #region Class Property Declarations

        public SqlString SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                SqlString sortColumnTemp = (SqlString)value;
                if (sortColumnTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SortColumn", "SortColumn can't be NULL");
                }
                _sortColumn = value;
            }
        }





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


        public SqlInt32 Company_ID
        {
            get
            {
                return _companyid;
            }
            set
            {

                _companyid = value;
            }
        }
        public SqlInt32 DistributorID
        {
            get
            {
                return _distributorID;
            }
            set
            {

                _distributorID = value;
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

        public SqlInt32 Price_Index
        {
            get
            {
                return _price_Index;
            }
            set
            {
                _price_Index = value;
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







        #region Class Property Declarations



        public SqlInt32 PriceProduct_ID
        {
            get
            {
                return _priceproduct_ID;
            }
            set
            {
                SqlInt32 product_IDTmp = (SqlInt32)value;
                if (product_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Product_ID", "Product_ID can't be NULL");
                }
                _priceproduct_ID = value;
            }
        }


        public SqlString Price_Code
        {
            get
            {
                return _price_Code;
            }
            set
            {
                SqlString price_CodeTmp = (SqlString)value;
                if (price_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Price_Code", "Price_Code can't be NULL");
                }
                _price_Code = value;
            }
        }


        public SqlString Price_Title
        {
            get
            {
                return _price_Title;
            }
            set
            {
                SqlString price_TitleTmp = (SqlString)value;
                if (price_TitleTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Price_Title", "Price_Title can't be NULL");
                }
                _price_Title = value;
            }
        }


        public SqlString PricelistActive_Status
        {
            get
            {
                return _pricelistactive_Status;
            }
            set
            {
                SqlString active_StatusTmp = (SqlString)value;
                if (active_StatusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Active_Status", "Active_Status can't be NULL");
                }
                _pricelistactive_Status = value;
            }
        }


        public SqlString Currency_Code
        {
            get
            {
                return _currency_Code;
            }
            set
            {
                SqlString currency_CodeTmp = (SqlString)value;
                if (currency_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Currency_Code", "Currency_Code can't be NULL");
                }
                _currency_Code = value;
            }
        }
        public SqlString Currency_CodeOld
        {
            get
            {
                return _currency_CodeOld;
            }
            set
            {
                SqlString currency_CodeOldTmp = (SqlString)value;
                if (currency_CodeOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Currency_CodeOld", "Currency_CodeOld can't be NULL");
                }
                _currency_CodeOld = value;
            }
        }


        public SqlDecimal TradePrice
        {
            get
            {
                return _tradePrice;
            }
            set
            {
                SqlDecimal tradePriceTmp = (SqlDecimal)value;
                if (tradePriceTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TradePrice", "TradePrice can't be NULL");
                }
                _tradePrice = value;
            }
        }

        public SqlDecimal PrimaryPrice
        {
            get
            {
                return _primaryPrice;
            }
            set
            {
                _primaryPrice = value;
            }
        }

        public SqlDecimal SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                SqlDecimal salePriceTmp = (SqlDecimal)value;
                if (salePriceTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SalePrice", "SalePrice can't be NULL");
                }
                _salePrice = value;
            }
        }


        public SqlDecimal RetailPrice
        {
            get
            {
                return _retailPrice;
            }
            set
            {
                SqlDecimal retailPriceTmp = (SqlDecimal)value;
                if (retailPriceTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("RetailPrice", "RetailPrice can't be NULL");
                }
                _retailPrice = value;
            }
        }


        public SqlDecimal MSRP
        {
            get
            {
                return _mSRP;
            }
            set
            {
                SqlDecimal mSRPTmp = (SqlDecimal)value;
                if (mSRPTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MSRP", "MSRP can't be NULL");
                }
                _mSRP = value;
            }
        }


        public SqlString PriceListStatus
        {
            get
            {
                return _priceliststatus;
            }
            set
            {
                SqlString statusTmp = (SqlString)value;
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
                _priceliststatus = value;
            }
        }


        public SqlInt32 TaxID
        {
            get
            {
                return _taxID;
            }
            set
            {
                SqlInt32 taxIDTmp = (SqlInt32)value;
                if (taxIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("TaxID", "TaxID can't be NULL");
                }
                _taxID = value;
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
                SqlInt32 batch_IDTmp = (SqlInt32)value;
                if (batch_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Batch_ID", "Batch_ID can't be NULL");
                }
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
                SqlInt32 batch_IDOldTmp = (SqlInt32)value;
                if (batch_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Batch_IDOld", "Batch_IDOld can't be NULL");
                }
                _batch_IDOld = value;
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







        #endregion
    }
}
