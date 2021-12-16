using SSS.DAL.Setups.Accounts;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups.Accounts
{
    public class thirdTier_BLL
    {
        private thirdTier_Property objthirdTierProperty;
        private thirdTier_DAL objthirdTierDAL;
        public thirdTier_BLL()
        {
        }
        public thirdTier_BLL(thirdTier_Property obthirdTier_Property)
        {
            objthirdTierProperty = obthirdTier_Property;

        }
        public DataTable ViewAll()
        {
            objthirdTierDAL = new thirdTier_DAL(objthirdTierProperty);
            return objthirdTierDAL.SelectAll();
        }

        public DataTable GetthirdTierById()
        {
            objthirdTierDAL = new thirdTier_DAL(objthirdTierProperty);
            return objthirdTierDAL.SelectById();
        }
        public bool Insert()
        {
            objthirdTierDAL = new thirdTier_DAL(objthirdTierProperty);
            return objthirdTierDAL.Insert();
        }
        public bool Update()
        {
            objthirdTierDAL = new thirdTier_DAL(objthirdTierProperty);
            return objthirdTierDAL.Update();
        }
        public bool DeleteAccount()
        {
            objthirdTierDAL = new thirdTier_DAL(objthirdTierProperty);
            return objthirdTierDAL.DeleteAccounts();
        }



    }
}
