using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class DCR_BLL
    {
        private DCR_DAL objDCR_DAL;
        private Transaction_Master_Property objTransactionMasterProperty;

        public DCR_BLL()
        { }
        public DCR_BLL(Transaction_Master_Property objTransaction_Master_Property)
        {
            objTransactionMasterProperty = objTransaction_Master_Property;
        }

        public DataSet GetDCR_Report()
        {
            objDCR_DAL = new DCR_DAL(objTransactionMasterProperty);
            return objDCR_DAL.DCR_Report();
        }

        public DataSet GetDCR_ReportForDailyTran()
        {
            objDCR_DAL = new DCR_DAL(objTransactionMasterProperty);
            return objDCR_DAL.DCR_ReportForDailyTran();
        }
        
        
    }
}
