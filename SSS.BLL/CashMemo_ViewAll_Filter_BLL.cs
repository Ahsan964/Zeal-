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
   public class CashMemo_ViewAll_Filter_BLL : GridCommandBase
    {
        private CashMemo_ViewAll_Filter_DAL objTransactionCMViewAllDAL;
        private Transaction_Master_Property objTransactionMasterProperty;

        public CashMemo_ViewAll_Filter_BLL(Transaction_Master_Property objTransaction_Master_Property)
        {
            objTransactionMasterProperty = objTransaction_Master_Property;
        }
        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

        public DataTable CashmemoViewAll_Filter()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CashMemoViewAllFilter();
        }

        public DataTable ViewAll_UnprocessedCM()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_CM();
        }
    }
}
