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
    public class POS_Setup_BLL : GridCommandBase
    {
        private POS_Setup_Property objPOSProperty;
        private POS_Setup_DAL objPOSDAL;

        public POS_Setup_BLL(POS_Setup_Property objPOS_Property)
        {
            objPOSProperty = objPOS_Property;
        }

        public POS_Setup_BLL()
        {

        }

        public DataTable ViewAll()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll();
        }

        public string UpdatePOSSetupXML()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.UpdatePOSSetupXML();
        }

        public DataTable ViewAll_BY_Routes()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll_BY_Route();
        }

        public DataTable ViewAll_POS_SETUP_LocID()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll_POS_SETUP_LocID();
        }


        public DataTable ViewAll_POS_SETUP_ByRouteID()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll_POS_SETUP_ByRouteID();
        }
        
        
        public DataTable ViewAll_POS_SETUP_OnlyByLocationID()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll_POS_SETUP_OnlyByLocationID();
        }

        public DataTable ViewAll_POS_SETUP_BusinessType()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAll_BY_BusinessType();
        }

        public DataTable ViewAllPOS_SETUPRoute()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectAllPOS_SETUPROUTE();
        }
        public DataTable View()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SelectOne();
        }

        public int SSSCodesVerification()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.SSSCodesVerificationDAL();
        }

        public bool ADD()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.Insert();
        }

        public bool Update()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.Update();
        }
        public bool MultipleAdd()
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.Multiple();
        }


        public override void UpdateStatus()
        {
            POS_Setup_Property objPOSPropertyNew = new POS_Setup_Property();
            objPOSPropertyNew.ID = base.Id;
            objPOSPropertyNew.Status = base.Status;
            objPOSPropertyNew.TableName = objPOSProperty.TableName;

            objPOSDAL = new POS_Setup_DAL(objPOSPropertyNew);
            objPOSDAL.UpdateStatus();
            
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


        public DataTable ViewPOSbyLocation_Business_PosType(String LocationIDs,  String PosTypeIDs, String BusTypeIDs)
        {
            objPOSDAL = new POS_Setup_DAL(objPOSProperty);
            return objPOSDAL.ViewPOSbyLocation_Business_PosType(LocationIDs, PosTypeIDs, BusTypeIDs);
        }
    }
}
