using System;
using SSS.DAL.Setups;
using SSS.Property.Setups;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.BLL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class CompanyCurrency_BLL
    {
        companyCurrency_Property objcompanyCurrency;
        CompanyCurrency_DAL objcompanyCurrencyDAl;

     
        public CompanyCurrency_BLL(companyCurrency_Property objcompanyCurrencyproperty)
        {
            objcompanyCurrency = objcompanyCurrencyproperty;
        }

        public bool Insert()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.Insert();
        }
        public bool Update()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.Update();
        }
        public DataTable ViewAll()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.SelectAll();
        }
        public DataTable SelectOne()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.SelectOne();
        }
        public DataTable SelectAllCurrency()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.SelectAllCurrency();
        }
        public bool Delete()
        {
            objcompanyCurrencyDAl = new CompanyCurrency_DAL(objcompanyCurrency);
            return objcompanyCurrencyDAl.Delete();
        }


    }
}