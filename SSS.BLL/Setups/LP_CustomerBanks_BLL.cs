using SSS.DAL;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class LP_CustomerBanks_BLL
    {
        LP_CustomerBanks_Property objbank;
        LP_CustomerBanks_DAL objbankDAl;

        public LP_CustomerBanks_BLL()
        {

        }
        public LP_CustomerBanks_BLL(LP_CustomerBanks_Property objbankproperty)
        {
            objbank = objbankproperty;
        }

        public bool Insert()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.Insert();
        }
        public bool Update()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.Update();
        }
        public DataTable ViewAll()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.SelectAll();
        }
        public DataTable SelectOne()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.SelectOne();
        }
        public DataTable SelectByCustomerIdx()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.SelectByCustomerIdx();
        }
        public int CheckBank()
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.CheckNoOfRecords();
        }
        public bool Delete(int? id)
        {
            objbankDAl = new LP_CustomerBanks_DAL(objbank);
            return objbankDAl.Delete(id);
        }
    }
}
