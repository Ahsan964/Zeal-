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
    public class Discount_Slab_Setup_BLL
    {
        private Discount_Slabs_Setup_Property objDiscountSlabsSetupProperty;
        private Discount_Slabs_Setup_DAL objDiscountSlabsSetupDAL;

        public Discount_Slab_Setup_BLL(Discount_Slabs_Setup_Property objDiscount_Slabs_Setup_Property)
        {
            objDiscountSlabsSetupProperty = objDiscount_Slabs_Setup_Property;

        }

        public bool Update()
        {
            objDiscountSlabsSetupDAL = new Discount_Slabs_Setup_DAL(objDiscountSlabsSetupProperty);
            return objDiscountSlabsSetupDAL.Update();
        }

        public bool Insert()
        {
            objDiscountSlabsSetupDAL = new Discount_Slabs_Setup_DAL(objDiscountSlabsSetupProperty);
            return objDiscountSlabsSetupDAL.Insert();
        }


        public DataTable DiscountSlabDetailselectByID()
        {
            objDiscountSlabsSetupDAL = new Discount_Slabs_Setup_DAL(objDiscountSlabsSetupProperty);
            return objDiscountSlabsSetupDAL.SelectAllByID();
        }

        public bool validateSlab(int discountID, int slabID, decimal fromQty, decimal toQty)
        {
            objDiscountSlabsSetupDAL = new Discount_Slabs_Setup_DAL(objDiscountSlabsSetupProperty);
            return objDiscountSlabsSetupDAL.validateSlab(discountID, slabID, fromQty, toQty);
        }

    }
}
