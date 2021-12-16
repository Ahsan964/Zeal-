using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;




namespace SSS.BLL.Setups
{

    public class Discount_Pos_Detail_BLL
    {
        Discount_Pos_Detail_Property objDiscount_Pos_Detail_Property;
        Discount_Pos_Detail_DAL objDiscount_Pos_Detail_DAL;


        public Discount_Pos_Detail_BLL(Discount_Pos_Detail_Property obj_Discount_Pos_Detail_Property)
        {
            objDiscount_Pos_Detail_Property = obj_Discount_Pos_Detail_Property;
        }
        public bool Insert()
        {
            objDiscount_Pos_Detail_DAL = new Discount_Pos_Detail_DAL(objDiscount_Pos_Detail_Property);
            return objDiscount_Pos_Detail_DAL.Insert();
        }
        public bool InsertPOsType()
        {
            objDiscount_Pos_Detail_DAL = new Discount_Pos_Detail_DAL(objDiscount_Pos_Detail_Property);
            return objDiscount_Pos_Detail_DAL.InsertPosType();
        }
        public DataTable Select_DiscountPOS_BUS_DIST_POSTYPE()
        {
            objDiscount_Pos_Detail_DAL = new Discount_Pos_Detail_DAL(objDiscount_Pos_Detail_Property);
            return objDiscount_Pos_Detail_DAL.Select_DiscountPOS_BUS_DIST_POSTYPE();
        }
    }
}
