using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using System.Web;

namespace SSS.BLL.Setups
{
    public class Permanent_Route_Plan_Detail_BLL : GridCommandBase
    {
        Permanent_Route_Plan_Detail_Property objPermanentRoutePlanProperty;
        Permanent_Route_Plan_Detail_DAL objPermanentRoutePlanDAL;

        public Permanent_Route_Plan_Detail_BLL(Permanent_Route_Plan_Detail_Property objPermanentRoutePlan_Property)
        {
            objPermanentRoutePlanProperty = objPermanentRoutePlan_Property;
        }

        public Permanent_Route_Plan_Detail_BLL()
        {

        }

        public DataTable ViewAll()
        {
            objPermanentRoutePlanDAL = new Permanent_Route_Plan_Detail_DAL(objPermanentRoutePlanProperty);
            return objPermanentRoutePlanDAL.SelectAll();
        }

        public DataTable View()
        {
            objPermanentRoutePlanDAL = new Permanent_Route_Plan_Detail_DAL(objPermanentRoutePlanProperty);
            return objPermanentRoutePlanDAL.SelectOne();
        }

        public bool ADD()
        {
            objPermanentRoutePlanDAL = new Permanent_Route_Plan_Detail_DAL(objPermanentRoutePlanProperty);
            return objPermanentRoutePlanDAL.Insert();
        }

        public bool Update()
        {
            objPermanentRoutePlanDAL = new Permanent_Route_Plan_Detail_DAL(objPermanentRoutePlanProperty);
            return objPermanentRoutePlanDAL.Update();
        }

        public override void UpdateStatus()
        {
            Permanent_Route_Plan_Detail_Property objPermanentRoutePlanPropertyNew = new Permanent_Route_Plan_Detail_Property();
            objPermanentRoutePlanPropertyNew.ID = base.Id;
            objPermanentRoutePlanPropertyNew.Status = base.Status;
            objPermanentRoutePlanPropertyNew.TableName = objPermanentRoutePlanProperty.TableName;

            objPermanentRoutePlanDAL = new Permanent_Route_Plan_Detail_DAL(objPermanentRoutePlanPropertyNew);
            objPermanentRoutePlanDAL.UpdateStatus();
        }
    }
}
