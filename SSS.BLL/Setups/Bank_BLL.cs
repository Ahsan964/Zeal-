using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class Bank_BLL
    {
        Bank_Property objbank;
        Bank_DAL objbankDAl;

        public Bank_BLL()
        {

        }
        public Bank_BLL(Bank_Property objbankproperty)
        {
            objbank = objbankproperty;
        }

        public bool Insert() {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.Insert();
        }
        public bool Update()
        {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.Update();
        }
        public DataTable ViewAll()
        {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.SelectAll();
        }
        public DataTable SelectOne()
        {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.SelectOne();
        }
        public int CheckBank()
        {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.CheckNoOfRecords();
        }
        public bool Delete(int? id)
        {
            objbankDAl = new Bank_DAL(objbank);
            return objbankDAl.Delete(id);
        }
    }
}
