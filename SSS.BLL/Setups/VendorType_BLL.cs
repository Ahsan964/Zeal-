using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class VendorType_BLL
    {
        private VendorType_DAL objVendorTypeDAL;
        private VendorType_Property objVendorCategoryProperty;
        public VendorType_BLL(VendorType_Property objVendorType_Property)
        {
            objVendorCategoryProperty = objVendorType_Property;

        }
        public DataTable ViewAll()
        {
            objVendorTypeDAL = new VendorType_DAL(objVendorCategoryProperty);
            return objVendorTypeDAL.SelectAll();
        }
    }
}
