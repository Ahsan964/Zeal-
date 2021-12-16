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
    public class DistributorWise_BlockedDiscount_BLL
    {
        private DistributorWise_BlockedDiscount_DAL objDistributorWiseBlockedDiscountDAL;
        private DistributorWise_BlockedDiscount_Property objDistributorWiseBlockedDiscountProperty;

        public DistributorWise_BlockedDiscount_BLL(DistributorWise_BlockedDiscount_Property objDistributorWise_BlockedDiscount_Property)
        {
            objDistributorWiseBlockedDiscountProperty = objDistributorWise_BlockedDiscount_Property;
        }



        public Int32 Add()
        {
            objDistributorWiseBlockedDiscountDAL = new DistributorWise_BlockedDiscount_DAL(objDistributorWiseBlockedDiscountProperty);
            return objDistributorWiseBlockedDiscountDAL.InsertBlock();
        }

        public DataTable ViewAll()
        {
            objDistributorWiseBlockedDiscountDAL = new DistributorWise_BlockedDiscount_DAL(objDistributorWiseBlockedDiscountProperty);
            return objDistributorWiseBlockedDiscountDAL.SelectAll();
        }



        

    } 
}
