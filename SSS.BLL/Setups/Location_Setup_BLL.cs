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
    public class Location_Setup_BLL : GridCommandBase
    {
        private Location_Setup_DAL objLocationSetupDAL;
        private Location_Setup_Property objLocationSetupProperty;

        public Location_Setup_BLL()
        {
        }
        public Location_Setup_BLL(Location_Setup_Property objLocationSetup_Property)
        {
            objLocationSetupProperty = objLocationSetup_Property;
        }
        public DataTable ViewAll()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectAll();
        }
        public DataTable ViewAllWLocation()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectAllWLocation();
        }
        public DataTable Select_LocationNodeName()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectLocationNodeName();
        }
        //public DataTable LocationForBulkPOS()
        //{
        //    objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
        //    return objLocationSetupDAL.LocationForBulkPOS();
        //}
        public DataTable SelectThirdLevelLocationBAL()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectThirdLevelLocationDAL();
        }
        public bool Add()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.Insert();
        }
        public bool Update()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.Update();
        }
        public DataTable View()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectOne();
        }
        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
        public DataTable IS_LocationDelete()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.ISLocationDelete();
        }
        public DataTable Select_LocationNodeName2()
        {
            objLocationSetupDAL = new Location_Setup_DAL(objLocationSetupProperty);
            return objLocationSetupDAL.SelectLocationNodeName2();
        }
    }
}
