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
    public class Personnel_Setup_BLL : GridCommandBase
    {
        private Personnel_Setup_Property objPersonnelSetupProperty;
        private Personnel_Setup_DAL objPersonnelSetupDAL;

        public Personnel_Setup_BLL(Personnel_Setup_Property objPersonnelSetup_Property)
        {
            objPersonnelSetupProperty = objPersonnelSetup_Property;

        }

        public DataTable ViewAll()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectAll();
        }

        //public DataTable SelectAll_OrderBookers()
        //{
        //    objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
        //    return objPersonnelSetupDAL.SelectAll_OrderBookers();
        //}

        public DataTable ViewAllForFuelSharing()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectAllForFuelSharing();
        }

        public DataTable ViewAllForVehicleSharing()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectAllForVehicleSharing();
        }

        public DataTable ViewAllBYPRP_PersonnelID()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectAllbyPRP_PersonnelID();
        }
        //Get_SalesRep


        //Get Distributor ID by CNIC
        public int GetDistributorCodebyCNIC()
        {
            //objPersonnelSetupProperty.NIC = (System.Data.SqlTypes.SqlString)CNIC.ToString();
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.getDistributorCodeByCNIC();
        }

        public int GetDistributorIDByCNIC()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.getDistributorIDByCNIC();
 
        }


        public DataTable Get_SalesRep()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.Get_SalesRep();
        }

        public DataTable Select_All_OrderBookerbyDistributorID()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.Select_All_OrderBookerbyDistributorID();
        }

        public DataTable View()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectOne();
        }

        public override void UpdateStatus()
        {
            Personnel_Setup_Property objPersonnelSetupPropertyNew = new Personnel_Setup_Property();
            objPersonnelSetupPropertyNew.ID = base.Id;
            objPersonnelSetupPropertyNew.Status = base.Status;
            objPersonnelSetupPropertyNew.TableName = objPersonnelSetupProperty.TableName;

            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupPropertyNew);
            objPersonnelSetupDAL.UpdateStatus();

            //Transaction_Master_Property objTransactionMasterPropertyNew = new Transaction_Master_Property();
            //objTransactionMasterPropertyNew.ID = base.Id;
            //objTransactionMasterPropertyNew.Status = base.Status;
            //objTransactionMasterPropertyNew.TableName = objTransactionMasterProperty.TableName;
            //objTransactionMasterPropertyNew.Operated_By = objTransactionMasterProperty.Operated_By;

            ////if (objTransactionMasterPropertyNew.Status != null)
            ////{
            //objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterPropertyNew);
            //objTransactionMasterDAL.UpdateStatus();
        }

        public bool ADD()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.Insert();
        }

        public bool Update()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.Update();
        }


        public DataTable SelectExistingSR_PR()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.SelectExistingSR_PRP();
        }

        public string UpdatePersonnelSetupXMLbyCNIC()
        {
            objPersonnelSetupDAL = new Personnel_Setup_DAL(objPersonnelSetupProperty);
            return objPersonnelSetupDAL.UpdatePersonnelSetupXMLbyNIC();
        }

    }
}
