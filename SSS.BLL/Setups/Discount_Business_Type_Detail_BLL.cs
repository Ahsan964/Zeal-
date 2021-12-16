using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;

namespace SSS.BLL.Setups
{
    public class Discount_Business_Type_Detail_BLL
    {
        Discount_Business_Type_Detail_Property objDiscount_Business_Type_Detail_Property;
        Discount_Business_Type_Detail_DAL objDiscount_Business_Type_Detail_DAL;

        public Discount_Business_Type_Detail_BLL(Discount_Business_Type_Detail_Property obj_Discount_Business_Type_Detail_Property)
        {
            objDiscount_Business_Type_Detail_Property = obj_Discount_Business_Type_Detail_Property;
        }

        public bool Insert()
        {
            objDiscount_Business_Type_Detail_DAL = new Discount_Business_Type_Detail_DAL(objDiscount_Business_Type_Detail_Property);
            return objDiscount_Business_Type_Detail_DAL.Insert();
        }

    }
}
