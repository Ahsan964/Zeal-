using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Sales_Category_BLL : GridCommandBase
    {
        private Sales_Category_DAL objSalesCategoryDAL;
        private Sales_Category_Property objSalesCategoryProperty;

        public Sales_Category_BLL()
        {
        }

        public Sales_Category_BLL(Sales_Category_Property objSalesCategory_Property)
        {
            objSalesCategoryProperty = objSalesCategory_Property;
        }

        public bool ADD()
        {
            objSalesCategoryDAL = new Sales_Category_DAL(objSalesCategoryProperty);
            return objSalesCategoryDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objSalesCategoryDAL = new Sales_Category_DAL(objSalesCategoryProperty);
            return objSalesCategoryDAL.SelectAll();
        }


        public DataTable View()
        {
            objSalesCategoryDAL = new Sales_Category_DAL(objSalesCategoryProperty);
            return objSalesCategoryDAL.SelectOne();
        }


        public override void UpdateStatus()
        {
            //throw new NotImplementedException();
            Sales_Category_Property objSaleCategorySetupPropertyNew = new Sales_Category_Property();
            objSaleCategorySetupPropertyNew.ID = base.Id;
            objSaleCategorySetupPropertyNew.Status = base.Status;
            objSaleCategorySetupPropertyNew.TableName = objSalesCategoryProperty.TableName;
            objSaleCategorySetupPropertyNew.Operated_By = objSaleCategorySetupPropertyNew.Operated_By;

            objSalesCategoryDAL = new Sales_Category_DAL(objSaleCategorySetupPropertyNew);
            objSalesCategoryDAL.UpdateStatus();
        }
    }
}
