using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Product_SubCategory_BLL
    {
        private Product_SubCategory_DAL objProductSubCategory_DAL;
        private Product_SubCategory_Property objProductSubCategoryProperty;

        private int? id;
        public Product_SubCategory_BLL(Product_SubCategory_Property objProduct_Property)
        {
            objProductSubCategoryProperty = objProduct_Property;

        }
        public Product_SubCategory_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.SelectAll();
        }
        public DataTable ViewAllCategories()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.SelectAllCategories();
        }
        public DataTable GetById(int? id)
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.SelectById(id);
        }
        public bool Insert()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.Insert();
        }
        public bool Update()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.Update();
        }
        public bool Delete(int? id)
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.Delete(id);
        }
        public DataTable CheckForInsert()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.checkForInsert();
        }
        public DataTable CheckForUpdate()
        {
            objProductSubCategory_DAL = new Product_SubCategory_DAL(objProductSubCategoryProperty);
            return objProductSubCategory_DAL.checkForUpdate();
        }
    }
}
