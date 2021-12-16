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

        public DataTable CashmemoViewAll_FilterWithStChange()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CashMemoViewAllFilterWithStChange();
        }

        public DataTable CashmemoViewAll_FilterForDailyTran()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CashMemoViewAllFilterForDailyTran();
        }

        public DataTable CashmemoViewAll_FilterForDailyTranForPrintAll()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CashMemoViewAllFilterForDailyTranForPrintAll();
        }

       
        public DataTable CashmemoViewAll_Filter_UnPGIN()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CashMemoViewAllFilter_UPGIN();
        }

        public DataTable NormaltoSpecialCM_Filter()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.NormaltoSpecialCM_Filter();
        }

        public DataTable ViewAll_UnprocessedCM()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_CM();
        }
        public DataTable ViewAll_UnprocessedCMForDailyTran()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_CMForDailyTran();
        }

       
        public DataTable CheckCM_ProcessedorNot()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.CheckCM_ProcessedorNot();
        }

        public DataTable ViewAll_processedCM()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_PCM();
        }

        public DataTable SelectProcessedNormalCashMemo()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.SelectProcessedNormalCashMemo();
        }

        public DataTable ViewAll_processedCMGIN()
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_PCM_GIN();
        }

        public DataTable ViewAll_PrintCM(string STRExists)
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_PrintCM(STRExists);
        }
        public DataTable ViewAll_PrintCMWithStChange(string STRExists)
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_PrintCMWithStChange(STRExists);
        }
        public DataTable ViewAll_PrintCMForDailyTran(string STRExists)
        {
            objTransactionCMViewAllDAL = new CashMemo_ViewAll_Filter_DAL(objTransactionMasterProperty);
            return objTransactionCMViewAllDAL.ViewAll_PrintCMForDailyTran(STRExists);
        }
       
    }
}
