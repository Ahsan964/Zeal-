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
    public class Product_Form_BLL : GridCommandBase
    {

        private Product_Form_Property objProductFormProperty;
        private Product_Form_DAL objProductFormDAL;
        public Product_Form_BLL()
        { }

        public Product_Form_BLL(Product_Form_Property ProductForm_Property)
        {
            objProductFormProperty = ProductForm_Property;

        }
        public DataTable ViewAll()
        {
            objProductFormDAL = new Product_Form_DAL(objProductFormProperty);
            return objProductFormDAL.SelectAll();
        }
        public bool Add()
        {
            objProductFormDAL = new Product_Form_DAL(objProductFormProperty);
            return objProductFormDAL.Insert();
        }
        public bool Update()
        {
            objProductFormDAL = new Product_Form_DAL(objProductFormProperty);
            return objProductFormDAL.Update();
        }

        public DataTable View()
        {
            objProductFormDAL = new Product_Form_DAL(objProductFormProperty);
            return objProductFormDAL.SelectOne();
        }

        public override void UpdateStatus()
        {
            Product_Form_Property objProductFormPropertyNew = new Product_Form_Property();
            objProductFormPropertyNew.ID = base.Id;
            objProductFormPropertyNew.Status = base.Status;
            objProductFormPropertyNew.TableName = objProductFormProperty.TableName;
            objProductFormPropertyNew.Operated_By = objProductFormProperty.Operated_By;

            objProductFormDAL = new Product_Form_DAL(objProductFormPropertyNew);
            objProductFormDAL.UpdateStatus();


        }
    }
}

    
