using SSS.DAL.Setups.Accounts;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups.Accounts
{
    public class firstTier_BLL
    {
        private firstTier_Property objfirstTierProperty;
        private firstTier_DAL objfirstTierDAL;
        public firstTier_BLL(firstTier_Property obfirstTier_Property)
        {
            objfirstTierProperty = obfirstTier_Property;

        }
        public firstTier_BLL()
        {
            

        }
        public DataTable ViewAll()
        {
            objfirstTierDAL = new firstTier_DAL(objfirstTierProperty);
            return objfirstTierDAL.SelectAll();
        }
    }
}
