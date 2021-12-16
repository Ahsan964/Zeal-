using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class CompanyBank_BLL
    {
        CompanyBank_Property objcompanybank;
        CompanyBank_DAL objcompanybankDAl;

        public CompanyBank_BLL()
        {

        }
        public CompanyBank_BLL(CompanyBank_Property objcompanybankproperty)
        {
            objcompanybank = objcompanybankproperty;
        }

        public bool Insert()
        {
            objcompanybankDAl = new CompanyBank_DAL(objcompanybank);
            return objcompanybankDAl.Insert();
        }
        public bool Update()
        {
            objcompanybankDAl = new CompanyBank_DAL(objcompanybank);
            return objcompanybankDAl.Update();
        }
        public DataTable ViewAll()
        {
            objcompanybankDAl = new CompanyBank_DAL(objcompanybank);
            return objcompanybankDAl.SelectAll();
        }
        public DataTable SelectOne()
        {
            objcompanybankDAl = new CompanyBank_DAL(objcompanybank);
            return objcompanybankDAl.SelectOne();
        }
        public bool Delete(int? id)
        {
            objcompanybankDAl = new CompanyBank_DAL(objcompanybank);
            return objcompanybankDAl.Delete(id);
        }

    }
}
