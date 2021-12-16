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
    public class Business_Type_BLL : GridCommandBase
    {

        private Business_Type_DAL objBusTypeDAL;
        private Business_Type_Property objBusTypeProperty;

        public Business_Type_BLL()
        {
        }

        public Business_Type_BLL(Business_Type_Property objAccType_Property)
        {
            objBusTypeProperty = objAccType_Property;
        }

        public DataTable ViewAll()
        {
            objBusTypeDAL = new Business_Type_DAL(objBusTypeProperty);
            return objBusTypeDAL.SelectAll();
        }

        public bool ADD()
        {
            objBusTypeDAL = new Business_Type_DAL(objBusTypeProperty);
            return objBusTypeDAL.Insert();
        }
        public bool Update()
        {
            objBusTypeDAL = new Business_Type_DAL(objBusTypeProperty);
            return objBusTypeDAL.Update();
        }



        public override void UpdateStatus()
        {
            Business_Type_Property objBusiness_Type_Property = new Business_Type_Property();
            objBusiness_Type_Property.ID = base.Id;
            objBusiness_Type_Property.Status = base.Status;
            objBusiness_Type_Property.TableName = "BUSINESS_TYPE";

            objBusTypeDAL = new Business_Type_DAL(objBusiness_Type_Property);
            objBusTypeDAL.UpdateStatus();

        }
    }
}
