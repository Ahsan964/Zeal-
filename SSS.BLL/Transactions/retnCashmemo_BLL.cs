using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Transactions;
using SSS.DAL.Setups;
using System.Data;


namespace SSS.BLL.Transactions
{
    public class retnCashmemo_BLL : GridCommandBase
    {
        private retnCashmemo_DAL objretnCashmemoDAL;
        private Transaction_Master_Property objTransactionMasterProperty;

        public retnCashmemo_BLL(Transaction_Master_Property objTransaction_Master_Property)
        {
            objTransactionMasterProperty = objTransaction_Master_Property;
        }

        public retnCashmemo_BLL()
        { }

        public DataTable PRP_Filter()
        {
            objretnCashmemoDAL = new retnCashmemo_DAL(objTransactionMasterProperty);
            return objretnCashmemoDAL.PRP_Filter();
        }
        public DataTable PRP_Filter_Edit()
        {
            objretnCashmemoDAL = new retnCashmemo_DAL(objTransactionMasterProperty);
            return objretnCashmemoDAL.PRP_Filter_Edit();
        }

        public DataTable Get_CMWRDetail()
        {
            objretnCashmemoDAL = new retnCashmemo_DAL(objTransactionMasterProperty);
            return objretnCashmemoDAL.Get_CMWRDetail();
        }
        public DataTable Get_CMWRDetailForDailyTran()
        {
            objretnCashmemoDAL = new retnCashmemo_DAL(objTransactionMasterProperty);
            return objretnCashmemoDAL.Get_CMWRDetailForDailyTran();
        }
        
        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

      

       
    }
}
