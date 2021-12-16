using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
   public class ProductTax_BLL
    {
       ProductTax_DAL objProductTax_DAL;
        ProductTax_Property objProductTax_Property;

        public ProductTax_BLL(ProductTax_Property obj_ProductTax_Property)
        {
            objProductTax_Property = obj_ProductTax_Property;
        }
        public bool Insert()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.Insert();
        }
        public bool Delete()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.Delete();
        }
        public bool Update()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.Update();
        }
        public DataTable SelectAll()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.SelectOne();
        }

        public DataTable GetProductbyTaxID()
        {
            objProductTax_DAL = new ProductTax_DAL(objProductTax_Property);
            return objProductTax_DAL.GetProductbyTaxID();
        }

    }
}
