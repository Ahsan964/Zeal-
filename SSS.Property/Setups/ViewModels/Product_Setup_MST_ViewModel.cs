using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.ViewModels
{
    public class Product_Setup_MST_ViewModel
    {
        #region Class Member Declarations
        private bool _gST_Free_SKU, _is_Active, _is_Final_Product;
        private DateTime _defined_Date, _operation_Date;
        private decimal _purchase_Price, _value_Limit, _sale_Price;
        private Int32? _distributorId, _conversion_UOM_Width, _conversion_Weight, _conversion_UOM_Length, _small_Unit, _product_index, _small_Weight, _dozen_UOM_Height, _small_UOM_Width, _conversion_UOM_Height, _product_Conversion, _dozen_Weight, _small_UOM_Length, _small_UOM_Height, _dozen_UOM_Width, _dozen_UOM_Length;
        private Int32? _conversion_Unit, _stop_Days, _qty_Limit, _sale_Days, _gST, _gST_Schedule_ID, _packing_Unit_ID, _packing_Unit_IDOld, _product_Level, _iD, _product_Parent_Code, _dozen_Unit, operated_By, _PageNum, _PageSize, _TotalRowsNum, _errorCode, _txaApplicable;
        private Int32 _product_Type, _product_Form_ID;
        private string _product_Code, _status, _defined_By, _narration, _priceApplyOn, _product_Name, _sKU_Previous_Code, _record_Table_Name, operation, _sortColumn, _product_ParentName;
        private string _tableName, _documentNo;
        #endregion

        #region Class Property Declarations
        public Int32? ID
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

        public int? DistributorId
        {
            get
            {
                return _distributorId;
            }
            set
            {
                _distributorId = value;
            }
        }

        public Int32? ErrorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                
                _errorCode = value;
            }
        }
        public Int32 Product_Form_ID
        {
            get
            {
                return _product_Form_ID;
            }
            set
            {
                //Int32 Product_Form_Tmp = (Int32)value;
                //if (Product_Form_Tmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Form_ID", "Product_Form_ID can't be NULL");
                //}
                _product_Form_ID = value;
            }
        }
        public Int32? TAX_Applicable
        {
            get
            {
                return _txaApplicable;
            }
            set
            {
                //Int32 Product_Form_Tmp = (Int32)value;
                //if (Product_Form_Tmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Form_ID", "Product_Form_ID can't be NULL");
                //}
                _txaApplicable = value;
            }
        }

        public string Product_Code
        {
            get
            {
                return _product_Code;
            }
            set
            {
                //string product_CodeTmp = (string)value;
                //if (product_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Code", "Product_Code can't be NULL");
                //}
                _product_Code = value;
            }
        }


        public string Product_Name
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

        public string Product_ParentName
        {
            get
            {
                return _product_ParentName;
            }
            set
            {
                //string product_NameTmp = (string)value;
                //if (product_NameTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Name", "Product_Name can't be NULL");
                //}
                _product_ParentName = value;
            }
        }


        public Int32? Product_Parent_Code
        {
            get
            {
                return _product_Parent_Code;
            }
            set
            {
                //Int32 product_Parent_CodeTmp = (Int32)value;
                //if (product_Parent_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Parent_Code", "Product_Parent_Code can't be NULL");
                //}
                _product_Parent_Code = value;
            }
        }


        public int? Product_Conversion
        {
            get
            {
                return _product_Conversion;
            }
            set
            {
                //Int32 product_ConversionTmp = (Int32)value;
                //if (product_ConversionTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Conversion", "Product_Conversion can't be NULL");
                //}
                _product_Conversion = value;
            }
        }


        public Int32? Product_Level
        {
            get
            {
                return _product_Level;
            }
            set
            {
                //Int32 product_LevelTmp = (Int32)value;
                //if (product_LevelTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Level", "Product_Level can't be NULL");
                //}
                _product_Level = value;
            }
        }


        public string Narration
        {
            get
            {
                return _narration;
            }
            set
            {
                //string narrationTmp = (string)value;
                //if (narrationTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Narration", "Narration can't be NULL");
                //}
                _narration = value;
            }
        }


        public Int32 Product_Type
        {
            get
            {
                return _product_Type;
            }
            set
            {
                //Int32 product_TypeTmp = (Int32)value;
                //if (product_TypeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Product_Type", "Product_Type can't be NULL");
                //}
                _product_Type = value;
            }
        }


        public Int32? Packing_Unit_ID
        {
            get
            {
                return _packing_Unit_ID;
            }
            set
            {
                //Int32 packing_Unit_IDTmp = (Int32)value;
                //if (packing_Unit_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Packing_Unit_ID", "Packing_Unit_ID can't be NULL");
                //}
                _packing_Unit_ID = value;
            }
        }
        public Int32? Packing_Unit_IDOld
        {
            get
            {
                return _packing_Unit_IDOld;
            }
            set
            {
                //Int32 packing_Unit_IDOldTmp = (Int32)value;
                //if (packing_Unit_IDOldTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Packing_Unit_IDOld", "Packing_Unit_IDOld can't be NULL");
                //}
                _packing_Unit_IDOld = value;
            }
        }
        public int? Small_Unit
        {
            get
            {
                return _small_Unit;
            }
            set
            {
                _small_Unit = value;
            }
        }


        public int? Product_index
        {
            get
            {
                return _product_index;
            }
            set
            {
                //Int32 small_WeightTmp = (Int32)value;
                //if (small_WeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Small_Weight", "Small_Weight can't be NULL");
                //}
                _product_index = value;
            }
        }

        //public Int32? Small_Unit
        //{
        //    get
        //    {
        //        return _small_Unit;
        //    }
        //    set
        //    {
        //        //Int32 small_UnitTmp = (Int32)value;
        //        //if (small_UnitTmp.IsNull)
        //        //{
        //        //    throw new ArgumentOutOfRangeException("Small_Unit", "Small_Unit can't be NULL");
        //        //}
        //        _small_Unit = value;
        //    }
        //}






        public int? Small_Weight
        {
            get
            {
                return _small_Weight;
            }
            set
            {
                //Int32 small_WeightTmp = (Int32)value;
                //if (small_WeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Small_Weight", "Small_Weight can't be NULL");
                //}
                _small_Weight = value;
            }
        }
        //public Int32? Small_Weight
        //{
        //    get
        //    {
        //        return _small_Weight;
        //    }
        //    set
        //    {
        //        //Int32 small_WeightTmp = (Int32)value;
        //        //if (small_WeightTmp.IsNull)
        //        //{
        //        //    throw new ArgumentOutOfRangeException("Small_Weight", "Small_Weight can't be NULL");
        //        //}
        //        _small_Weight = value;
        //    }
        //}


        public int? Small_UOM_Length
        {
            get
            {
                return _small_UOM_Length;
            }
            set
            {
                //Int32 small_UOM_LengthTmp = (Int32)value;
                //if (small_UOM_LengthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Small_UOM_Length", "Small_UOM_Length can't be NULL");
                //}
                _small_UOM_Length = value;
            }
        }




        public int? Small_UOM_Width
        {
            get
            {
                return _small_UOM_Width;
            }
            set
            {
                //Int32 small_UOM_WidthTmp = (Int32)value;
                //if (small_UOM_WidthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Small_UOM_Width", "Small_UOM_Width can't be NULL");
                //}
                _small_UOM_Width = value;
            }
        }
        //public Int32? Small_UOM_Width
        //{
        //    get
        //    {
        //        return _small_UOM_Width;
        //    }
        //    set
        //    {
        //        //Int32 small_UOM_WidthTmp = (Int32)value;
        //        //if (small_UOM_WidthTmp.IsNull)
        //        //{
        //        //    throw new ArgumentOutOfRangeException("Small_UOM_Width", "Small_UOM_Width can't be NULL");
        //        //}
        //        _small_UOM_Width = value;
        //    }
        //}


        public int? Small_UOM_Height
        {
            get
            {
                return _small_UOM_Height;
            }
            set
            {
                //Int32 small_UOM_HeightTmp = (Int32)value;
                //if (small_UOM_HeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Small_UOM_Height", "Small_UOM_Height can't be NULL");
                //}
                _small_UOM_Height = value;
            }
        }


        public Int32? Dozen_Unit
        {
            get
            {
                return _dozen_Unit;
            }
            set
            {
                //Int32 dozen_UnitTmp = (Int32)value;
                //if (dozen_UnitTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Dozen_Unit", "Dozen_Unit can't be NULL");
                //}
                _dozen_Unit = value;
            }
        }


        public int? Dozen_Weight
        {
            get
            {
                return _dozen_Weight;
            }
            set
            {
                //Int32 dozen_WeightTmp = (Int32)value;
                //if (dozen_WeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Dozen_Weight", "Dozen_Weight can't be NULL");
                //}
                _dozen_Weight = value;
            }
        }


        public int? Dozen_UOM_Length
        {
            get
            {
                return _dozen_UOM_Length;
            }
            set
            {
                //Int32 dozen_UOM_LengthTmp = (Int32)value;
                //if (dozen_UOM_LengthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Dozen_UOM_Length", "Dozen_UOM_Length can't be NULL");
                //}
                _dozen_UOM_Length = value;
            }
        }


        public int? Dozen_UOM_Width
        {
            get
            {
                return _dozen_UOM_Width;
            }
            set
            {
                //Int32 dozen_UOM_WidthTmp = (Int32)value;
                //if (dozen_UOM_WidthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Dozen_UOM_Width", "Dozen_UOM_Width can't be NULL");
                //}
                _dozen_UOM_Width = value;
            }
        }


        public int? Dozen_UOM_Height
        {
            get
            {
                return _dozen_UOM_Height;
            }
            set
            {
                //Int32 dozen_UOM_HeightTmp = (Int32)value;
                //if (dozen_UOM_HeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Dozen_UOM_Height", "Dozen_UOM_Height can't be NULL");
                //}
                _dozen_UOM_Height = value;
            }
        }


        //public Int32? Dozen_UOM_Height
        //{
        //    get
        //    {
        //        return _dozen_UOM_Height;
        //    }
        //    set
        //    {
        //        //Int32 dozen_UOM_HeightTmp = (Int32)value;
        //        //if (dozen_UOM_HeightTmp.IsNull)
        //        //{
        //        //    throw new ArgumentOutOfRangeException("Dozen_UOM_Height", "Dozen_UOM_Height can't be NULL");
        //        //}
        //        _dozen_UOM_Height = value;
        //    }
        //}


        public Int32? Conversion_Unit
        {
            get
            {
                return _conversion_Unit;
            }
            set
            {
                //Int32 conversion_UnitTmp = (Int32)value;
                //if (conversion_UnitTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Conversion_Unit", "Conversion_Unit can't be NULL");
                //}
                _conversion_Unit = value;
            }
        }


        public int? Conversion_Weight
        {
            get
            {
                return _conversion_Weight;
            }
            set
            {
                //Int32 conversion_WeightTmp = (Int32)value;
                //if (conversion_WeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Conversion_Weight", "Conversion_Weight can't be NULL");
                //}
                _conversion_Weight = value;
            }
        }


        public int? Conversion_UOM_Length
        {
            get
            {
                return _conversion_UOM_Length;
            }
            set
            {
                //Int32 conversion_UOM_LengthTmp = (Int32)value;
                //if (conversion_UOM_LengthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Conversion_UOM_Length", "Conversion_UOM_Length can't be NULL");
                //}
                _conversion_UOM_Length = value;
            }
        }


        public int? Conversion_UOM_Width
        {
            get
            {
                return _conversion_UOM_Width;
            }
            set
            {
                //Int32 conversion_UOM_WidthTmp = (Int32)value;
                //if (conversion_UOM_WidthTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Conversion_UOM_Width", "Conversion_UOM_Width can't be NULL");
                //}
                _conversion_UOM_Width = value;
            }
        }


        public int? Conversion_UOM_Height
        {
            get
            {
                return _conversion_UOM_Height;
            }
            set
            {
                //Int32 conversion_UOM_HeightTmp = (Int32)value;
                //if (conversion_UOM_HeightTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Conversion_UOM_Height", "Conversion_UOM_Height can't be NULL");
                //}
                _conversion_UOM_Height = value;
            }
        }


        public string PriceApplyOn
        {
            get
            {
                return _priceApplyOn;
            }
            set
            {
                //string priceApplyOnTmp = (string)value;
                //if (priceApplyOnTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PriceApplyOn", "PriceApplyOn can't be NULL");
                //}
                _priceApplyOn = value;
            }
        }


        public string SKU_Previous_Code
        {
            get
            {
                return _sKU_Previous_Code;
            }
            set
            {
                //string sKU_Previous_CodeTmp = (string)value;
                //if (sKU_Previous_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("SKU_Previous_Code", "SKU_Previous_Code can't be NULL");
                //}
                _sKU_Previous_Code = value;
            }
        }


        public Int32? GST
        {
            get
            {
                return _gST;
            }
            set
            {
                //Int32 gSTTmp = (Int32)value;
                //if (gSTTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("GST", "GST can't be NULL");
                //}
                _gST = value;
            }
        }

        public bool Is_Final_Product
        {
            get
            {
                return _is_Final_Product;
            }
            set
            {
                //bool gST_Free_SKUTmp = (bool)value;
                //if (gST_Free_SKUTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("GST_Free_SKU", "GST_Free_SKU can't be NULL");
                //}
                _is_Final_Product = value;
            }
        }

        public bool GST_Free_SKU
        {
            get
            {
                return _gST_Free_SKU;
            }
            set
            {
                //bool gST_Free_SKUTmp = (bool)value;
                //if (gST_Free_SKUTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("GST_Free_SKU", "GST_Free_SKU can't be NULL");
                //}
                _gST_Free_SKU = value;
            }
        }


        public Int32? GST_Schedule_ID
        {
            get
            {
                return _gST_Schedule_ID;
            }
            set
            {
                //Int32 gST_Schedule_IDTmp = (Int32)value;
                //if (gST_Schedule_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("GST_Schedule_ID", "GST_Schedule_ID can't be NULL");
                //}
                _gST_Schedule_ID = value;
            }
        }


        public decimal Sale_Price
        {
            get
            {
                return _sale_Price;
            }
            set
            {
                //decimal sale_PriceTmp = (decimal)value;
                //if (sale_PriceTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Sale_Price", "Sale_Price can't be NULL");
                //}
                _sale_Price = value;
            }
        }


        public decimal Purchase_Price
        {
            get
            {
                return _purchase_Price;
            }
            set
            {
                //decimal purchase_PriceTmp = (decimal)value;
                //if (purchase_PriceTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Purchase_Price", "Purchase_Price can't be NULL");
                //}
                _purchase_Price = value;
            }
        }


        public Int32? Sale_Days
        {
            get
            {
                return _sale_Days;
            }
            set
            {
                //Int32 sale_DaysTmp = (Int32)value;
                //if (sale_DaysTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Sale_Days", "Sale_Days can't be NULL");
                //}
                _sale_Days = value;
            }
        }


        public Int32? Stop_Days
        {
            get
            {
                return _stop_Days;
            }
            set
            {
                //Int32 stop_DaysTmp = (Int32)value;
                //if (stop_DaysTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Stop_Days", "Stop_Days can't be NULL");
                //}
                _stop_Days = value;
            }
        }


        public Int32? Qty_Limit
        {
            get
            {
                return _qty_Limit;
            }
            set
            {
                //Int32 qty_LimitTmp = (Int32)value;
                //if (qty_LimitTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Qty_Limit", "Qty_Limit can't be NULL");
                //}
                _qty_Limit = value;
            }
        }


        public decimal Value_Limit
        {
            get
            {
                return _value_Limit;
            }
            set
            {
                //decimal value_LimitTmp = (decimal)value;
                //if (value_LimitTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Value_Limit", "Value_Limit can't be NULL");
                //}
                _value_Limit = value;
            }
        }


        public bool Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                //bool is_ActiveTmp = (bool)value;
                //if (is_ActiveTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Is_Active", "Is_Active can't be NULL");
                //}
                _is_Active = value;
            }
        }


        public DateTime Defined_Date
        {
            get
            {
                return _defined_Date;
            }
            set
            {
                //DateTime defined_DateTmp = (DateTime)value;
                //if (defined_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Defined_Date", "Defined_Date can't be NULL");
                //}
                _defined_Date = value;
            }
        }


        public string Defined_By
        {
            get
            {
                return _defined_By;
            }
            set
            {
                //string defined_ByTmp = (string)value;
                //if (defined_ByTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Defined_By", "Defined_By can't be NULL");
                //}
                _defined_By = value;
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
                //string statusTmp = (string)value;
                //if (statusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                //}
                _status = value;
            }
        }


        ///// Extra Properties


        public Int32? Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                //Int32 Operated_ByTmp = (Int32)value;
                //if (Operated_ByTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                //}
                operated_By = value;
            }
        }



        public Int32? PageNum
        {
            get
            {
                return _PageNum;
            }
            set
            {
                //Int32 PageNumTmp = (Int32)value;
                //if (PageNumTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PageNum", "PageNum can't be NULL");
                //}
                _PageNum = value;
            }
        }

        public Int32? PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                //Int32 PageSizeTmp = (Int32)value;
                //if (PageSizeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("PageSize", "PageSize can't be NULL");
                //}
                _PageSize = value;
            }
        }

        public Int32? TotalRowsNum
        {
            get
            {
                return _TotalRowsNum;
            }
            set
            {
                //Int32 TotalRowsNumTmp = (Int32)value;
                //if (TotalRowsNumTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("TotalRowsNum", "TotalRowsNum can't be NULL");
                //}
                _TotalRowsNum = value;
            }
        }




        public string Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                //string record_Table_NameTemp = (string)value;
                //if (record_Table_NameTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Record_Table_Name", "Record Table Name can't be NULL");
                //}
                _record_Table_Name = value;
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
                //string OperationTemp = (string)value;
                //if (OperationTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation", "Operation can't be NULL");
                //}
                operation = value;
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
                //string sortColumnTemp = (string)value;
                //if (sortColumnTemp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("SortColumn", "SortColumn can't be NULL");
                //}
                _sortColumn = value;
            }
        }





        public DateTime Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                //DateTime operation_Date_DateTmp = (DateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _operation_Date = value;
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
