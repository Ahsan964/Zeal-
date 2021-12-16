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
   public  class Special_DiscountMaster//: GridCommandBase
    {

        private Special_DiscountMasterDAL objSpecialDiscountMasterDAL;
        private Special_Discount_Master_Property objSpecialDiscountMasterProperty;

        public Special_DiscountMaster(Special_Discount_Master_Property objSpecial_Discount_Master_Property)
        {
            objSpecialDiscountMasterProperty = objSpecial_Discount_Master_Property;
        }


        public bool Add()
        {
            objSpecialDiscountMasterDAL = new Special_DiscountMasterDAL(objSpecialDiscountMasterProperty);
            return objSpecialDiscountMasterDAL.Insert();
        }

    }
}
