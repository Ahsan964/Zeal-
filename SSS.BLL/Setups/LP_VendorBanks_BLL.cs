using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class LP_VendorBanks_BLL
    {
        LP_VendorBanks_Property objbank;
        LP_VendorBanks_DAL objbankDAl;

        public LP_VendorBanks_BLL()
        {

        }
        public LP_VendorBanks_BLL(LP_VendorBanks_Property objbankproperty)
        {
            objbank = objbankproperty;
        }

        public bool Insert()
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.Insert();
        }
        public bool Update()
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.Update();
        }
        public DataTable ViewAll()
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.SelectAll();
        }
        public DataTable SelectOne()
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.SelectOne();
        }
        public int CheckBank()
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.CheckNoOfRecords();
        }
        public bool Delete(int? id)
        {
            objbankDAl = new LP_VendorBanks_DAL(objbank);
            return objbankDAl.Delete(id);
        }
    }
}
