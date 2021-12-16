using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    
   public class PurchaseRequisition_BLL:GridCommandBase
    {
        private PurchaseRequisitionMaster_Property objPurchaseRequisitionMaster_Property;
        private PurchaseRequisition_DAL objPurchaseRequisition_DAL;
        public PurchaseRequisition_BLL()
        {

        }
        public PurchaseRequisition_BLL(PurchaseRequisitionMaster_Property objPurchaseRequisitionMasterProperty)
        {
            objPurchaseRequisitionMaster_Property = objPurchaseRequisitionMasterProperty;
        }
        public DataTable GetLocation()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL();
            return objPurchaseRequisition_DAL.GetLocation();
        }
        public DataTable GetDocumentType()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL();
           return objPurchaseRequisition_DAL.GetDocumentType();
        }
        public bool Insert()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Property);
            return objPurchaseRequisition_DAL.Insert();
        }

        public DataTable SelectAllPr()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Property);
            return objPurchaseRequisition_DAL.SelectAllPr();
        }
        public string GetDocumentCode()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL();
            return objPurchaseRequisition_DAL.GetDocumentCode();
        }
        public DataTable GetDepartments()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL();
            return objPurchaseRequisition_DAL.GetDepartments();
        }
        public DataTable GetPackingUnits()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL();
            return objPurchaseRequisition_DAL.GetPackingUnits();
        }
        public override void UpdateStatus()
        {
            Transaction_Master_Property objTransactionMasterPropertyNew = new Transaction_Master_Property();
             PurchaseRequisitionMaster_Property objPurchaseRequisitionMaster_Propertynew=new PurchaseRequisitionMaster_Property();
            objPurchaseRequisitionMaster_Propertynew.ID = base.Id;
            objPurchaseRequisitionMaster_Propertynew.Status = base.Status;
            objPurchaseRequisitionMaster_Propertynew.TableName = objPurchaseRequisitionMaster_Property.TableName;
            // objPurchaseRequisitionMaster_Propertynew.Operated_By = objTransactionMasterProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Propertynew);
            objPurchaseRequisition_DAL.UpdateStatus();
        }

        public DataSet GetPurchaseRequisitionByID()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Property);
            return objPurchaseRequisition_DAL.GetPurchaseRequisitionById();
        }
        public bool UpdatePurchaseRequisition()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Property);
            return objPurchaseRequisition_DAL.UpdatePurchaseRequisition();
        }
        public DataSet GetBulkPurchaseRequisitionById()
        {
            objPurchaseRequisition_DAL = new PurchaseRequisition_DAL(objPurchaseRequisitionMaster_Property);
            return objPurchaseRequisition_DAL.GetBulkPurchaseRequisitionById();
        }
        
    }
}
