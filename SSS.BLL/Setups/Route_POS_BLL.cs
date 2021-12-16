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
    public class Route_POS_BLL : GridCommandBase
    {
        private Route_POS_Property objRoutePOSProperty;
        private Route_POS_DAL objRoutePOSDAL;
        public Route_POS_BLL()
        { }

        public Route_POS_BLL(Route_POS_Property objRoutePOS_Property)
        {
            objRoutePOSProperty = objRoutePOS_Property;
        }


        public DataTable ViewAll()
        {
            objRoutePOSDAL = new Route_POS_DAL(objRoutePOSProperty);
            return objRoutePOSDAL.SelectAll();
        }
        public bool Add()
        {
            objRoutePOSDAL = new Route_POS_DAL(objRoutePOSProperty);
            return objRoutePOSDAL.Insert();
        }
        public bool Update()
        {
            objRoutePOSDAL = new Route_POS_DAL(objRoutePOSProperty);
            return objRoutePOSDAL.Update();
        }
        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
