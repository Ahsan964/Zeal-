using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class Product_Category_BLL
    {
        private Product_Category_DAL objProductCategoryDAL;
        private Product_Category_Property objProductCategoryProperty;

        private int? id;
        public Product_Category_BLL(Product_Category_Property objProductCategory_Property)
        {
            objProductCategoryProperty = objProductCategory_Property;

        }
        public Product_Category_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.SelectAll();
        }

        public DataTable CheckForInsert()
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.checkForInsert();
        }
        public DataTable CheckForUpdate()
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.checkForUpdate();
        }
        public DataTable GetById(int? id)
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.SelectById(id);
        }
        public bool Insert()
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.Insert();
        }
        public bool Update()
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.Update();
        }
        public bool Delete(int? id)
        {
            objProductCategoryDAL = new Product_Category_DAL(objProductCategoryProperty);
            return objProductCategoryDAL.Delete(id);
        }
    }
}
