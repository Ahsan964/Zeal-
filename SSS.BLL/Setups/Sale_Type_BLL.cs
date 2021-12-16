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
  public  class Sale_Type_BLL : GridCommandBase
    {
        private Sales_Type_Property objSaleTypProperty;
        private Sales_Type_DAL objSaleTypDAL;

        public Sale_Type_BLL()
        { }
        public Sale_Type_BLL(Sales_Type_Property objSaleTyp_Property)
        {
            objSaleTypProperty = objSaleTyp_Property;

        }

        public DataTable ViewAll()
        {
            objSaleTypDAL = new Sales_Type_DAL(objSaleTypProperty);
            return objSaleTypDAL.SelectAll();
        }
        public bool Add()
        {
            objSaleTypDAL = new Sales_Type_DAL(objSaleTypProperty);
            return objSaleTypDAL.Insert();
        }
        public bool Update()
        {
            objSaleTypDAL = new Sales_Type_DAL(objSaleTypProperty);
            return objSaleTypDAL.Update();
        }
        public DataTable View()
        {
            objSaleTypDAL = new Sales_Type_DAL(objSaleTypProperty);
            return objSaleTypDAL.SelectOne();
        }
        public override void UpdateStatus()
        {
            Sales_Type_Property objSaleTypPropertyNew = new Sales_Type_Property();
            objSaleTypPropertyNew.ID = base.Id;
            objSaleTypPropertyNew.Status = base.Status;
            objSaleTypPropertyNew.TableName = objSaleTypProperty.TableName;
            objSaleTypPropertyNew.Operated_By = objSaleTypProperty.Operated_By;

            objSaleTypDAL = new Sales_Type_DAL(objSaleTypPropertyNew);
            objSaleTypDAL.UpdateStatus();


        }

    }
}
