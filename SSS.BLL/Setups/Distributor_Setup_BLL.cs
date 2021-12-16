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
    public class Distributor_Setup_BLL : GridCommandBase
    {
        private Distributor_Setup_Property objDistSetupProperty;
        private Distributor_Setup_DAL objDistSetupDAL;

        public Distributor_Setup_BLL(Distributor_Setup_Property objDistSetup_Property)
        {
            objDistSetupProperty = objDistSetup_Property;
        }

        public DataTable ViewAll()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.SelectAll();
        }

        public DataTable GetById()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.SelectById();
        }

        public DataTable ViewAllDistributorWithoutRegion()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.SelectAllDistributorWithoutRegion();
        }

        public DataTable DISTRIBUTORName_CLOSING_DAY()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DISTRIBUTORName_CLOSING_DAY();
        }
        public DataTable DISTRIBUTORName_AllTransacStatusday(string datefrom1, string dateto1)
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DISTRIBUTORName_AllTransacStatusday(datefrom1, dateto1);
        }
        public DataTable DISTRIBUTORName_AllTransacStatusdayForToDays()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DISTRIBUTORName_AllTransacStatusdayForToDays();
        }
        public DataTable Select_Distributor_Setup_Prioity()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.Select_Distributor_Setup_Prioity();
        }
        
        public DataSet HOImportExportData()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.HOImportExportData();
        }

        public DataSet DistImportExportData()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DistImportExportData();
        }

        public DataTable ViewPOS(int types)
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.SelectAllPOSSetup(types);
        }

        public DataTable DamageExpiryReportBLL()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DamageExpiryReport();
        }

        public DataTable DamageExpiryReportBLLProductWise()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.DamageExpiryReportProductWise();
        }

        public bool Add()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.Insert();
        }

        public Distributor_Setup_BLL()
        {
        }

        public override void UpdateStatus()
        {
            Distributor_Setup_Property objDistSetupPropertyNew = new Distributor_Setup_Property();
            objDistSetupPropertyNew.ID = base.Id;
            objDistSetupPropertyNew.Status = base.Status;
            objDistSetupPropertyNew.TableName = objDistSetupProperty.TableName;
            objDistSetupPropertyNew.Operated_By = objDistSetupProperty.Operated_By;

            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupPropertyNew);
            objDistSetupDAL.UpdateStatus();


        }


        public bool Update()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.Update();
        }

        public DataTable View()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.SelectOne();
        }

        public bool InsertDistByDiscount()
        {
            objDistSetupDAL = new Distributor_Setup_DAL(objDistSetupProperty);
            return objDistSetupDAL.InsertDistByDiscount();
        }
    }
}
