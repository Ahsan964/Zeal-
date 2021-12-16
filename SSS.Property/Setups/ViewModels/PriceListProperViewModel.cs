using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.ViewModels
{
   public class PriceListProperViewModel
    {
        #region Class Member Declarations

        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _tableName;

        private DateTime _expire_Date, _batch_Date;
        private int _batch_Index, _sale_Stop_Days, _sale_Alert_Days, _price_ID, _price_IDOld, _iD, _product_ID, operated_By, _errorcode, _companyid, _price_Index;
        private string _batch_Code, _active_Status, _description, _sortColumn;

        private decimal _mSRP, _retailPrice, _salePrice, _tradePrice, _primaryPrice;
        private int _taxID, _batch_ID, _batch_IDOld, _priceproduct_ID, _distributorID;
        private string _price_Code, _currency_Code, _currency_CodeOld, _priceliststatus, _pricelistactive_Status, _price_Title, _status;
        private string _tempID;


        #endregion

        #region Class Property Declarations

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





        public int ErrorCode
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







        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
               
                _iD = value;
            }
        }


        public string Batch_Code
        {
            get
            {
                return _batch_Code;
            }
            set
            {
                
                _batch_Code = value;
            }
        }


        public string Description
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

        public string Status
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


        public string Active_Status
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


        public int Product_ID
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


        public int Company_ID
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
        public int DistributorID
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



        public int Price_ID
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
        public int Price_IDOld
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


        public int Batch_Index
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

        public int Price_Index
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


        public DateTime Batch_Date
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


        public DateTime Expire_Date
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


        public int Sale_Alert_Days
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


        public int Sale_Stop_Days
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


        [Required]
        public int PriceProduct_ID
        {
            get
            {
                return _priceproduct_ID;
            }
            set
            {
               
                _priceproduct_ID = value;
            }
        }

        [Required]
        public string Price_Code
        {
            get
            {
                return _price_Code;
            }
            set
            {
                
                _price_Code = value;
            }
        }

        [Required]
        public string Price_Title
        {
            get
            {
                return _price_Title;
            }
            set
            {
              
                _price_Title = value;
            }
        }


        public string PricelistActive_Status
        {
            get
            {
                return _pricelistactive_Status;
            }
            set
            {
                
                _pricelistactive_Status = value;
            }
        }

        [Required]
        public string Currency_Code
        {
            get
            {
                return _currency_Code;
            }
            set
            {
                
                _currency_Code = value;
            }
        }
        public string Currency_CodeOld
        {
            get
            {
                return _currency_CodeOld;
            }
            set
            {
                
                _currency_CodeOld = value;
            }
        }

        [Required]
        public decimal TradePrice
        {
            get
            {
                return _tradePrice;
            }
            set
            {
                
                _tradePrice = value;
            }
        }
        [Required]
        public decimal PrimaryPrice
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

        public decimal SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                
                _salePrice = value;
            }
        }


        public decimal RetailPrice
        {
            get
            {
                return _retailPrice;
            }
            set
            {
                
                _retailPrice = value;
            }
        }


        public decimal MSRP
        {
            get
            {
                return _mSRP;
            }
            set
            {
                
                _mSRP = value;
            }
        }


        public string PriceListStatus
        {
            get
            {
                return _priceliststatus;
            }
            set
            {
                
                _priceliststatus = value;
            }
        }


        public int TaxID
        {
            get
            {
                return _taxID;
            }
            set
            {
                
                _taxID = value;
            }
        }


        public int Batch_ID
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
        public int Batch_IDOld
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

        public int Operated_By
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
