using SSS.DAL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions
{
    public class LP_MRN_BLL
    {
        private LP_MRN_Master_Property _objMRMasterProperty;
        private LP_MRN_Detail_Property _objMRDetailProperty;
        private LP_MRN_DAL _objMRNDAL;
        public LP_MRN_BLL()
        {

        }
        public LP_MRN_BLL(LP_MRN_Master_Property objMRMasterProperty)
        {
            _objMRMasterProperty = objMRMasterProperty;
        }
        public LP_MRN_BLL(LP_MRN_Detail_Property objMRDetailProperty)
        {
            _objMRDetailProperty = objMRDetailProperty;
        }

        public bool Insert()
        {
            _objMRNDAL = new LP_MRN_DAL(_objMRMasterProperty);
            return _objMRNDAL.Insert();

        }
        public DataTable SelectAll()
        {
            _objMRNDAL = new LP_MRN_DAL();
            return _objMRNDAL.SelectAll();
        }
        public DataTable SelectMRN()
        {
            _objMRNDAL = new LP_MRN_DAL();
            return _objMRNDAL.SelectMRN();
        }
        
        public DataTable SelectById()
        {
            _objMRNDAL = new LP_MRN_DAL(_objMRMasterProperty);
            return _objMRNDAL.SelectOne();
        }

        public string GenerateMRNNo(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objMRNDAL = new LP_MRN_DAL();
            DataTable dt= _objMRNDAL.GenerateMRNNo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "MRN-00" + TransactionNumber + "-" + objtransno.userid;

                    
                }
                return TransactionNumber;
            }
            else
            {
                
                TransactionNumber = "MRN-001-" + objtransno.userid;

                return TransactionNumber;
            }
            //return _objMRNDAL.GenerateMRNNo(objtransno);
        }
    }
}
