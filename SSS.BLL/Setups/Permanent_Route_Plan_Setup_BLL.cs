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
    public class Permanent_Route_Plan_Setup_BLL : GridCommandBase
    {
        private Permanent_Route_Plan_Setup_Property objPermanentRoutePlanSetupProperty;
        private Permanent_Route_Plan_Setup_DAL objPermanentRoutePlanSetupDAL;

        public Permanent_Route_Plan_Setup_BLL(Permanent_Route_Plan_Setup_Property objPermanent_Route_Plan_Setup_Property)
        {
            objPermanentRoutePlanSetupProperty = objPermanent_Route_Plan_Setup_Property;

        }
        public DataTable ViewAll()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.SelectAll();
        }

        public DataTable ViewAllListing()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.SelectAllForListing();
        }

        public DataTable ViewAllPermanentRoute()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.SelectAllPermanentRoute();
        }
        public DataTable ViewAllPermanentRoute_New()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.SelectAllPermanentRoute_new();
        }
        public DataSet ViewAllMasterDetailByMasterID()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.SelectAllMasterDetailByMasterID();
        }

        public bool Add()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.Insert();
        }

        public bool Update()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.Update();
        }

        public override void UpdateStatus()
        {
            Permanent_Route_Plan_Setup_Property objPermanentRoutePlanSetupPropertyNew = new Permanent_Route_Plan_Setup_Property();
            objPermanentRoutePlanSetupPropertyNew.ID = base.Id;
            objPermanentRoutePlanSetupPropertyNew.Status = base.Status;
            objPermanentRoutePlanSetupPropertyNew.TableName = objPermanentRoutePlanSetupProperty.TableName;

            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupPropertyNew);
            objPermanentRoutePlanSetupDAL.UpdateStatus();
        }

        public string UpdatePermenantRoutPlanSetupXML()
        {
            objPermanentRoutePlanSetupDAL = new Permanent_Route_Plan_Setup_DAL(objPermanentRoutePlanSetupProperty);
            return objPermanentRoutePlanSetupDAL.UpdatePermenantRoutPlanSetupXML();
        }
    }
}
