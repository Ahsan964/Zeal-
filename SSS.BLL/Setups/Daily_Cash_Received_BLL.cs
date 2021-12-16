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
    public class Daily_Cash_Received_BLL : GridCommandBase
    {
        private Daily_Cash_Received_Property objDailyCashRecProperty;
        private Daily_Cash_Received_DAL objDailyCashRecDAL;

        public Daily_Cash_Received_BLL(Daily_Cash_Received_Property objDailyCashRec_Property)
        {
            objDailyCashRecProperty = objDailyCashRec_Property;

        }

        public Daily_Cash_Received_BLL()
        {

        }

        public DataTable ViewAll()
        {
            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecProperty);
            return objDailyCashRecDAL.SelectAll();
        }

        public DataTable View()
        {
            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecProperty);
            return objDailyCashRecDAL.SelectOne();
        }

        public bool ADD()
        {
            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecProperty);
            return objDailyCashRecDAL.Insert();
        }

        public bool Update()
        {
            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecProperty);
            return objDailyCashRecDAL.Update();
        }

        public bool UpdatePostingStatus()
        {
            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecProperty);
            return objDailyCashRecDAL.UpdatePostingStatus();
        }

        public override void UpdateStatus()
        {
            Daily_Cash_Received_Property objDailyCashRecPropertyNew = new Daily_Cash_Received_Property();
            objDailyCashRecPropertyNew.ID = base.Id;
            objDailyCashRecPropertyNew.Status = base.Status;
            objDailyCashRecPropertyNew.TableName = objDailyCashRecProperty.TableName;

            objDailyCashRecDAL = new Daily_Cash_Received_DAL(objDailyCashRecPropertyNew);
            objDailyCashRecDAL.UpdateStatus();

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
    }
}
