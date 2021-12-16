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
    public class Special_DiscountDetail_BLL 
    {

         //private Special_DiscountMasterDAL objSpecialDiscountMasterDAL;
        private Special_Discount_Detail_Property objSpecialDiscountDetailProperty;

        public Special_DiscountDetail_BLL(Special_Discount_Detail_Property objSpecial_Discount_Detail_Property)
        {
            objSpecialDiscountDetailProperty = objSpecial_Discount_Detail_Property;
        }

    }
}
