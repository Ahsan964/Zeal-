using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class Sale_Category_Product_BLL : GridCommandBase
    {
        private Sale_Category_Product_DAL objSaleCategoryProductDAL;
        private Sale_Category_Product_Property objSaleCategoryProductProperty;

        public Sale_Category_Product_BLL()
        {
        }

        public Sale_Category_Product_BLL(Sale_Category_Product_Property objSaleCategoryProduct_Property)
        {
            objSaleCategoryProductProperty = objSaleCategoryProduct_Property;
        }

        public DataTable Add()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.SelectAll();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

        public DataTable ViewAll_SaleCategory_ProductParent()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.SelectAll_SaleCategory_ProductParent();
        }

        public DataTable ViewAll_Products_By_SaleCategory()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.SelectAll_Products_By_SaleCategory();
        }

        public bool AddNew()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.InsertNew();
        }

        public bool Update()
        {
            objSaleCategoryProductDAL = new Sale_Category_Product_DAL(objSaleCategoryProductProperty);
            return objSaleCategoryProductDAL.UpdateStatus();
        }
    }
}
