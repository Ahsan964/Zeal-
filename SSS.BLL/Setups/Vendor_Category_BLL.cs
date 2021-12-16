using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Vendor_Category_BLL
    {
        private Vendor_Category_DAL objVendorCategoryDAL;
        private Vendor_Category_Property objVendorCategoryProperty;

        private int? id;
        public Vendor_Category_BLL()
        {

        }
        public Vendor_Category_BLL(Vendor_Category_Property objVendorCategory_Property)
        {
            objVendorCategoryProperty = objVendorCategory_Property;

        }
        public Vendor_Category_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objVendorCategoryDAL = new Vendor_Category_DAL(objVendorCategoryProperty);
            return objVendorCategoryDAL.SelectAll();
        }
        public DataTable GetById(int? id)
        {
            objVendorCategoryDAL = new Vendor_Category_DAL(objVendorCategoryProperty);
            return objVendorCategoryDAL.SelectById(id);
        }
        public bool Insert()
        {
            objVendorCategoryDAL = new Vendor_Category_DAL(objVendorCategoryProperty);
            return objVendorCategoryDAL.Insert();
        }
        public bool Update()
        {
            objVendorCategoryDAL = new Vendor_Category_DAL(objVendorCategoryProperty);
            return objVendorCategoryDAL.Update();
        }
        public bool Delete(int? id)
        {
            objVendorCategoryDAL = new Vendor_Category_DAL(objVendorCategoryProperty);
            return objVendorCategoryDAL.Delete(id);
        }
    }
}
