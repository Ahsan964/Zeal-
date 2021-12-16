using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class PO_Master_BLL : GridCommandBase
    {
        private PO_Master_Property objPO_Master;
        public PO_Master_BLL()
        { }
        public PO_Master_BLL(PO_Master_Property objPO)
        {
            objPO_Master = objPO;
        }

        public bool Insert()
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            return objPO_Master_DAL.Insert();
        }

        public DataTable SelectAll()
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            return objPO_Master_DAL.SelectAll();
        }

        public override void UpdateStatus()
        {

            //Transaction_Master_Property objTransactionMasterPropertyNew = new Transaction_Master_Property();
            //objTransactionMasterPropertyNew.ID = base.Id;
            //objTransactionMasterPropertyNew.Status = base.Status;
            //objTransactionMasterPropertyNew.TableName = objTransactionMasterProperty.TableName;
            //objTransactionMasterPropertyNew.Operated_By = objTransactionMasterProperty.Operated_By;

            ////if (objTransactionMasterPropertyNew.Status != null)
            ////{
            //objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterPropertyNew);
            //objTransactionMasterDAL.UpdateStatus();
            //}
        }


        public DataSet selectPO()
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            return objPO_Master_DAL.selectPO();           
        }

        public String Export()
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            DataTable dt = objPO_Master_DAL.export();
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.AppendLine(dr[0].ToString());
                }
                return sb.ToString();
            }
            else
                return "";
        }

        public Boolean delete()
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            return objPO_Master_DAL.delete();
           
        }

        public DataSet PO_Filters(DateTime? From, DateTime? To, int? compID, int? DisID)
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL();
            return objPO_Master_DAL.PO_Filters(From, To, compID, DisID);
        }
        public DataSet ConsolidatePO_Report(string tempID)
        {
            PO_Master_DAL objPO_Master_DAL = new PO_Master_DAL(objPO_Master);
            return objPO_Master_DAL.PO_Consolidated_Report(tempID);
        }

    }
}
