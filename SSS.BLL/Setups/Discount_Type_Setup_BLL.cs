using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
     public class Discount_Type_Setup_BLL
    {
        private Discount_Type_Setup_Property objDiscountTypeProperty;
        private Discount_Type_Setup_DAL objDiscountTypeDAL;

        public Discount_Type_Setup_BLL(Discount_Type_Setup_Property objDiscountType_Property)
        {
            objDiscountTypeProperty = objDiscountType_Property;

        }
        public DataTable ViewAll()
        {
            objDiscountTypeDAL = new Discount_Type_Setup_DAL(objDiscountTypeProperty);
            return objDiscountTypeDAL.SelectAll();
        }
    }
}
