using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SSS.DAL.Setups;
using SSS.Property.Setups;

namespace SSS.BLL.Setups
{
    public class SalesPerson_BLL
    {
        private SalesPerson_Property objSalesPersonProperty;
        private SalesPerson_DAL ObjSalesPersonDAL;

        private int? id;
        public SalesPerson_BLL()
        {

        }

        public SalesPerson_BLL(SalesPerson_Property ObjSalesPerson_Property)
        {
            objSalesPersonProperty = ObjSalesPerson_Property;
        }

        public SalesPerson_BLL(int? id)
        {
            this.id = id;
        }

        // Inssert
        public bool Insert()
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.Insert();
        }

        // Listing
        public DataTable ViewAllCustomers()
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.SelectAll();
        }

        // Edit
        public DataTable GetSalesPersonById()
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.SelectById();
        }

        // Update
        public bool Update()
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.Update();
        }

        // Delete
        public bool Delete(int? id)
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.Delete(id);
        }

        // Dropdown
        public DataTable ViewAll()
        {
            ObjSalesPersonDAL = new SalesPerson_DAL(objSalesPersonProperty);
            return ObjSalesPersonDAL.SelectAll();
        }
    }
}