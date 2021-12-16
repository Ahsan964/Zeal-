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
    public class Sales_Rep_Type_BLL : GridCommandBase
    {
        private Sales_Rep_Type_DAL objSalesRepTypeDAL;
        private Sales_Rep_Type_Property objSalesRepTypeProperty;

        public Sales_Rep_Type_BLL()
        {
        }

        public Sales_Rep_Type_BLL(Sales_Rep_Type_Property objSalesRepType_Property)
        {
            objSalesRepTypeProperty = objSalesRepType_Property;
        }

        public DataTable ViewAll()
        {
            objSalesRepTypeDAL = new Sales_Rep_Type_DAL(objSalesRepTypeProperty);
            return objSalesRepTypeDAL.SelectAll();
        }

        public bool Add()
        {
            objSalesRepTypeDAL = new Sales_Rep_Type_DAL(objSalesRepTypeProperty);
            return objSalesRepTypeDAL.Insert();
        }

        public bool Update()
        {
            objSalesRepTypeDAL = new Sales_Rep_Type_DAL(objSalesRepTypeProperty);
            return objSalesRepTypeDAL.Update();
        }

        public DataTable View()
        {
            objSalesRepTypeDAL = new Sales_Rep_Type_DAL(objSalesRepTypeProperty);
            return objSalesRepTypeDAL.SelectOne();
        }
        public override void UpdateStatus()
        {
            Sales_Rep_Type_Property objSaleRepTypPropertyNew = new Sales_Rep_Type_Property();
            objSaleRepTypPropertyNew.ID = base.Id;
            objSaleRepTypPropertyNew.Status = base.Status;
            objSaleRepTypPropertyNew.TableName = objSalesRepTypeProperty.TableName;
            objSaleRepTypPropertyNew.Operated_By = objSalesRepTypeProperty.Operated_By;

            objSalesRepTypeDAL = new Sales_Rep_Type_DAL(objSaleRepTypPropertyNew);
            objSalesRepTypeDAL.UpdateStatus();
        }
    }
}
