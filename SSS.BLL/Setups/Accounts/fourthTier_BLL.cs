using SSS.BLL.Setups.Accounts;
using SSS.DAL.Setups.Accounts;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups.Accounts
{
    public class fourthTier_BLL
    {
        private fourthTier_Property objfourthTierProperty;
        private fourthTier_DAL objfourthTierDAL;

        public fourthTier_BLL(fourthTier_Property obfourthTier_Property)
        {
            objfourthTierProperty = obfourthTier_Property;

        }
        public DataTable ViewAll()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.SelectAll();
        }

        public DataTable GetfourthTierById()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.SelectById();
        }
        public DataTable GetfourthTierBySubheadIdx()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.SelectBySubheadIdx();
        }
        public DataTable GetfourthTierByheadIdx()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.SelectByheadIdx();
        }
        public bool Insert()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.Insert();
        }
        public bool Update()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.Update();
        }
        public bool DeleteAccount()
        {
            objfourthTierDAL = new fourthTier_DAL(objfourthTierProperty);
            return objfourthTierDAL.DeleteAccounts();
        }
    }
}
