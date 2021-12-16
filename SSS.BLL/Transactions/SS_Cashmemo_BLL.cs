using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using SSS.DAL.Transactions;
using System.Data;

namespace SSS.BLL.Transactions
{
    public class SS_Cashmemo_BLL : GridCommandBase
    {
        private SS_Cashmemo_DAL objSSCashmemoDAL;
        private SS_Cashmemo_Property objCashmemoProperty;

        public SS_Cashmemo_BLL()
        { }

        public SS_Cashmemo_BLL(SS_Cashmemo_Property objCashmemo_Property)
        {
            objCashmemoProperty = objCashmemo_Property;
        }

        public DataTable SSCashmemoFilter()
        {
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.SSCashmemoFilter();
        }

        public bool Add()
        {
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.Insert();
        }
        public DataSet GetCashMemoByTransactionMaster()        {
            
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.GetCashMemoByTransactionMaster();

        }
        public DataSet ProcessCashMemo()
        {
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.ProcessCashMemo();

        }
        public override void UpdateStatus()
        {

            SS_Cashmemo_Property objCashmemoPropertyNew = new SS_Cashmemo_Property();
            objCashmemoPropertyNew.ID = base.Id;
            objCashmemoPropertyNew.Status = base.Status;
            objCashmemoPropertyNew.TableName = objCashmemoProperty.TableName;
            objCashmemoPropertyNew.Operated_By = objCashmemoProperty.Operated_By;

            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoPropertyNew);
            objSSCashmemoDAL.UpdateStatus();
            
        }


        public bool Update()
        {
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.Update();
        }
        public DataTable SelectAll_WithDecription()
        {
            objSSCashmemoDAL = new SS_Cashmemo_DAL(objCashmemoProperty);
            return objSSCashmemoDAL.SelectAll_WithDecription();
        }
        
    }
}
