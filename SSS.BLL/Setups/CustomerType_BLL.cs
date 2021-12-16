using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class CustomerType_BLL
    {
        private CustomerType_DAL objCustomerTypeDAL;
        private CustomerType_Property objCustomerCategoryProperty;
        private int? id;
        public CustomerType_BLL(CustomerType_Property objCustomerType_Property)
        {
            objCustomerCategoryProperty = objCustomerType_Property;

        }
        public CustomerType_BLL(int? id)
        {
            this.id = id;

        }
        public DataTable ViewAll()
        {
            objCustomerTypeDAL = new CustomerType_DAL(objCustomerCategoryProperty);
            return objCustomerTypeDAL.SelectAll();
        }
        public DataTable SelectById()
        {
            objCustomerTypeDAL = new CustomerType_DAL(objCustomerCategoryProperty);
            return objCustomerTypeDAL.SelectById();
        }
        public bool Insert()
        {
            objCustomerTypeDAL = new CustomerType_DAL(objCustomerCategoryProperty);
            return objCustomerTypeDAL.Insert();
        }
        public bool Update()
        {
            objCustomerTypeDAL = new CustomerType_DAL(objCustomerCategoryProperty);
            return objCustomerTypeDAL.Update();
        }
        public bool Delete(int? id)
        {
            objCustomerTypeDAL = new CustomerType_DAL(objCustomerCategoryProperty);
            return objCustomerTypeDAL.Delete(id);
        }
    }
}
