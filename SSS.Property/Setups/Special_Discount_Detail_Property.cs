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
    public class Special_Discount_Detail_Property
    {

        #region Class Member Declarations
        private SqlDecimal _processed_Discount_Amount, _processed_Percentage_Amount, _special_Pecentage, _special_Discount_Amount, _rate;
        private SqlInt32 _special_Free_Peices, _processed_FreePeices, _specialDiscountMasterId, _id, _productId, _saleUnit, _batchID, _priceListId;
        private SqlString _status;
        #endregion


        #region Class Property Declarations
        public SqlInt32 Id
        {
            get
            {
                return _id;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _id = value;
            }
        }

        public SqlInt32 PriceListId
        {
            get
            {
                return _priceListId;
            }
            set
            {
                SqlInt32 priceListIdTmp = (SqlInt32)value;
                if (priceListIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("priceListIdTmp", "priceListIdTmp can't be NULL");
                }
                _priceListId = value;
            }
        }


        public SqlInt32 SpecialDiscountMasterId
        {
            get
            {
                return _specialDiscountMasterId;
            }
            set
            {
                SqlInt32 specialDiscountMasterIdTmp = (SqlInt32)value;
                if (specialDiscountMasterIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SpecialDiscountMasterId", "SpecialDiscountMasterId can't be NULL");
                }
                _specialDiscountMasterId = value;
            }
        }


        public SqlInt32 ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                SqlInt32 productIdTmp = (SqlInt32)value;
                if (productIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ProductId", "ProductId can't be NULL");
                }
                _productId = value;
            }
        }


        public SqlInt32 BatchID
        {
            get
            {
                return _batchID;
            }
            set
            {
                SqlInt32 batchIDTmp = (SqlInt32)value;
                if (batchIDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("BatchID", "BatchID can't be NULL");
                }
                _batchID = value;
            }
        }


        public SqlInt32 SaleUnit
        {
            get
            {
                return _saleUnit;
            }
            set
            {
                SqlInt32 saleUnitTmp = (SqlInt32)value;
                if (saleUnitTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SaleUnit", "SaleUnit can't be NULL");
                }
                _saleUnit = value;
            }
        }


        public SqlInt32 Processed_FreePeices
        {
            get
            {
                return _processed_FreePeices;
            }
            set
            {
                SqlInt32 processed_FreePeicesTmp = (SqlInt32)value;
                if (processed_FreePeicesTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Processed_FreePeices", "Processed_FreePeices can't be NULL");
                }
                _processed_FreePeices = value;
            }
        }


        public SqlDecimal Processed_Discount_Amount
        {
            get
            {
                return _processed_Discount_Amount;
            }
            set
            {
                SqlDecimal processed_Discount_AmountTmp = (SqlDecimal)value;
                if (processed_Discount_AmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Processed_Discount_Amount", "Processed_Discount_Amount can't be NULL");
                }
                _processed_Discount_Amount = value;
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
                SqlDecimal rateTmp = (SqlDecimal)value;
                if (rateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("rateTmp", "rateTmp can't be NULL");
                }
                _rate = value;
            }
        }


        public SqlDecimal Processed_Percentage_Amount
        {
            get
            {
                return _processed_Percentage_Amount;
            }
            set
            {
                SqlDecimal processed_Percentage_AmountTmp = (SqlDecimal)value;
                if (processed_Percentage_AmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Processed_Percentage_Amount", "Processed_Percentage_Amount can't be NULL");
                }
                _processed_Percentage_Amount = value;
            }
        }


        public SqlInt32 Special_Free_Peices
        {
            get
            {
                return _special_Free_Peices;
            }
            set
            {
                SqlInt32 special_Free_PeicesTmp = (SqlInt32)value;
                if (special_Free_PeicesTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Special_Free_Peices", "Special_Free_Peices can't be NULL");
                }
                _special_Free_Peices = value;
            }
        }


        public SqlDecimal Special_Discount_Amount
        {
            get
            {
                return _special_Discount_Amount;
            }
            set
            {
                SqlDecimal special_Discount_AmountTmp = (SqlDecimal)value;
                if (special_Discount_AmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Special_Discount_Amount", "Special_Discount_Amount can't be NULL");
                }
                _special_Discount_Amount = value;
            }
        }


        public SqlDecimal Special_Pecentage
        {
            get
            {
                return _special_Pecentage;
            }
            set
            {
                SqlDecimal special_PecentageTmp = (SqlDecimal)value;
                if (special_PecentageTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Special_Pecentage", "Special_Pecentage can't be NULL");
                }
                _special_Pecentage = value;
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
        #endregion

    }
}
