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
    public  class LP_Quotation_BLL
    {
        private LP_Quotation_Master_Property _objPOMasterProperty;
        private LP_Quotation_Detail_Property _objPODetailProperty;
        private LP_Quotation_DAL _objPurchaseDAL;
        public LP_Quotation_BLL()
        {

        }
        public LP_Quotation_BLL(LP_Quotation_Master_Property objPOMasterProperty)
        {
            _objPOMasterProperty = objPOMasterProperty;
        }
        public LP_Quotation_BLL(LP_Quotation_Detail_Property objPODetailProperty)
        {
            _objPODetailProperty = objPODetailProperty;
        }

        public bool Delete()
        {
            _objPurchaseDAL = new LP_Quotation_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.Delete();
        }

        public bool Insert()
        {
            _objPurchaseDAL = new LP_Quotation_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.Insert();

        }
        public DataTable SelectQS()
        {
            _objPurchaseDAL = new LP_Quotation_DAL();
            return _objPurchaseDAL.SelectQS();
        }
        public DataTable SelectAll()
        {
            _objPurchaseDAL = new LP_Quotation_DAL();
            return _objPurchaseDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objPurchaseDAL = new LP_Quotation_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.SelectOne();
        }
        public DataTable SelectTax()
        {
            _objPurchaseDAL = new LP_Quotation_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.SelectTaxOnQS();
        }
        public string GeneratePO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objPurchaseDAL = new LP_Quotation_DAL();
            DataTable dt = _objPurchaseDAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "QS-00" + (int.Parse(TransactionNumber)+1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "QS-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }
    }
}
