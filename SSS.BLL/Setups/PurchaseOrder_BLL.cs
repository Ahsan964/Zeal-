using SSS.BLL.Setups;
using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class PurchaseOrder_BLL:GridCommandBase
    {
        PurchaseOrder_DAL objPurchaseOrder_DAL;
        PurchaseOrderMaster objPurchaseOrderMaster;
        public PurchaseOrder_BLL()
        {

        }
        public PurchaseOrder_BLL(PurchaseOrderMaster objPurchaseOrderMasternew)
        {
            objPurchaseOrderMaster = objPurchaseOrderMasternew;
        }
        public bool Insert()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster);

            return objPurchaseOrder_DAL.Insert() ;
        }
        public string GetDocumentCode()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL();
            return objPurchaseOrder_DAL.GetDocumentCode();
        }

        public override void UpdateStatus()
        {
            Transaction_Master_Property objTransactionMasterPropertyNew = new Transaction_Master_Property();
            PurchaseOrderMaster objPurchaseOrderMaster_Propertynew = new PurchaseOrderMaster();
            objPurchaseOrderMaster_Propertynew.ID = base.Id;
            objPurchaseOrderMaster_Propertynew.Status = base.Status;
            objPurchaseOrderMaster_Propertynew.TableName = objPurchaseOrderMaster.TableName;
            // objPurchaseRequisitionMaster_Propertynew.Operated_By = objTransactionMasterProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster_Propertynew);
            objPurchaseOrder_DAL.UpdateStatus();
        }

        public DataTable SelectAllPO()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster);
            return objPurchaseOrder_DAL.SelectAllPO();
        }

        public DataSet SelectAllPurchaseOrders()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster);
            return objPurchaseOrder_DAL.SelectAllPurchaseOrders();
        }

        public DataSet SelectPurchaseOrdersByID()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster);
            return objPurchaseOrder_DAL.SelectPurchaseOrdersByID();
        }

        public bool Update()
        {
            objPurchaseOrder_DAL = new PurchaseOrder_DAL(objPurchaseOrderMaster);
            return objPurchaseOrder_DAL.Update();

        }

    }
}
