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
    public class Region_BLL: GridCommandBase
    {
        private Region_DAL objRegionDAL;
        private Region_Property objRegionProperty;

        public Region_BLL(Region_Property objRegion_Property)
        {
            objRegionProperty = objRegion_Property;
        }

        public bool ADD()
        {
            objRegionDAL = new Region_DAL(objRegionProperty);
            return objRegionDAL.Insert();
        }
        public DataTable ViewAll()
        {
            objRegionDAL = new Region_DAL(objRegionProperty);
            return objRegionDAL.SelectAll();
        }
        public DataTable Select_RegionNodeName()
        {
            objRegionDAL = new Region_DAL(objRegionProperty);
            return objRegionDAL.SelectRegionNodeName();
        }
        public bool Update()
        {
            objRegionDAL = new Region_DAL(objRegionProperty);
            return objRegionDAL.Update();
        }

        public DataTable IS_RegionDelete()
        {
            objRegionDAL = new Region_DAL(objRegionProperty);
            return objRegionDAL.ISRegionDelete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
