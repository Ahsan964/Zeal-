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
    public class Organogram_Setup_BLL : GridCommandBase
    {
        private Organogram_Setup_DAL objOrganogramSetupDAL;
        private Organogram_Property objOrganogramSetupProperty;

        public Organogram_Setup_BLL()
        {
        }

        public Organogram_Setup_BLL(Organogram_Property objOrganogramSetup_Property)
        {
            objOrganogramSetupProperty = objOrganogramSetup_Property;
        }

        public DataTable ViewAll()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.SelectAll();
        }

        public bool Add()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.Insert();
        }

        public bool Update()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.Update();
        }

        public DataTable View()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.SelectOne();
        }

        public DataTable ISOrganogram_Deleted()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.ISOrganogramDelete();
        }

        public override void UpdateStatus()
        {
            Organogram_Property objOrganogramSetupPropertyNew = new Organogram_Property();
            objOrganogramSetupPropertyNew.ID = base.Id;
            objOrganogramSetupPropertyNew.Status = base.Status;
            objOrganogramSetupPropertyNew.TableName = objOrganogramSetupProperty.TableName;
            objOrganogramSetupPropertyNew.Operated_By = objOrganogramSetupProperty.Operated_By;

            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupPropertyNew);
            objOrganogramSetupDAL.UpdateStatus();


        }

        public DataTable GetOrganogrambyParentID()
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.GetOrganogrambyParentID();
        }

        public DataTable GetOrderBookerByOrganogam(String OrgID, int DistributorID)
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.GetOrderBookerByOrganogam(OrgID, DistributorID);
        }


        public DataTable GetOrganogamByOBID(String OBID)
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.GetOrganogamByOBID(OBID);
        }

        public DataTable GetOrderBookerByOBID(String OBID ,DateTime DateFrom , DateTime DateTo)
        {
            objOrganogramSetupDAL = new Organogram_Setup_DAL(objOrganogramSetupProperty);
            return objOrganogramSetupDAL.GetOrderbookerByOBID(OBID, DateFrom, DateTo);
        }

    }

}
