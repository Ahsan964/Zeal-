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
    public class Route_BLL : GridCommandBase
    {
        private Route_DAL objRouteDAL;
        private Route_Property objRouteProperty;

        public Route_BLL()
        {
        }

        public Route_BLL(Route_Property objRoute_Property)
        {
            objRouteProperty = objRoute_Property;
        }

        public DataTable ViewAll()
        {
            objRouteDAL = new Route_DAL(objRouteProperty);
            return objRouteDAL.SelectAll();
        }

        public DataTable View()
        {
            objRouteDAL = new Route_DAL(objRouteProperty);
            return objRouteDAL.SelectOne();
        }

        public bool ADD()
        {
            objRouteDAL = new Route_DAL(objRouteProperty);
            return objRouteDAL.Insert();
        }

        public bool Update()
        {
            objRouteDAL = new Route_DAL(objRouteProperty);
            return objRouteDAL.Update();
        }

        public override void UpdateStatus()
        {
            Route_Property objRouteSetupPropertyNew = new Route_Property();
            objRouteSetupPropertyNew.ID = base.Id;
            objRouteSetupPropertyNew.Status = base.Status;
            objRouteSetupPropertyNew.TableName = objRouteProperty.TableName;
            objRouteSetupPropertyNew.Operated_By = objRouteProperty.Operated_By;

            objRouteDAL = new Route_DAL(objRouteSetupPropertyNew);
            objRouteDAL.UpdateStatus();
        }
    }
}
