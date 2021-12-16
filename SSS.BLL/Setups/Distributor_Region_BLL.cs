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
    public class Distributor_Region_BLL : GridCommandBase
    {
        private Distributor_Region_DAL objDistributorRegionDAL;
        private Distributor_Region_Property objDistributorRegionProperty;

        public Distributor_Region_BLL(Distributor_Region_Property objDistributorRegion_Property)
        {
            objDistributorRegionProperty = objDistributorRegion_Property;
        }
        
        public int ADD()
        {
            objDistributorRegionDAL = new Distributor_Region_DAL(objDistributorRegionProperty);
            return objDistributorRegionDAL.Insert();
        }

        public int DeleteDistributorRegionByDistributorIdsBll()
        {
            objDistributorRegionDAL = new Distributor_Region_DAL(objDistributorRegionProperty);
            return objDistributorRegionDAL.DeleteDistributorRegionByDistributorIds();
        }
        
        public DataTable GetDistributorRegionByRegionIdBll()
        {
            objDistributorRegionDAL = new Distributor_Region_DAL(objDistributorRegionProperty);
            return objDistributorRegionDAL.GetDistributorRegionByRegionId();
        }

        public DataTable GetDistributorRegionByDistributorIdBll()
        {
            objDistributorRegionDAL = new Distributor_Region_DAL(objDistributorRegionProperty);
            return objDistributorRegionDAL.GetDistributorRegionByDistributorId();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
