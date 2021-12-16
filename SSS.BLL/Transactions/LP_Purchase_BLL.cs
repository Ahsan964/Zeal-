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
   public class LP_Purchase_BLL
    {
        private LP_Purchase_Master_Property _objPOMasterProperty;
        private LP_Purchase_Detail_Property _objPODetailProperty;
        private LP_Purchase_DAL _objPurchaseDAL;
        public LP_Purchase_BLL()
        {

        }
        public LP_Purchase_BLL(LP_Purchase_Master_Property objPOMasterProperty)
        {
            _objPOMasterProperty = objPOMasterProperty;
        }
        public LP_Purchase_BLL(LP_Purchase_Detail_Property objPODetailProperty)
        {
            _objPODetailProperty = objPODetailProperty;
        }

        public bool Insert()
        {
            _objPurchaseDAL = new LP_Purchase_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.Insert();

        }

        // Delete PO
        public bool Delete()
        {
            _objPurchaseDAL = new LP_Purchase_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.Delete();
        }

        public  DataTable SelectAll()
        {
            _objPurchaseDAL = new LP_Purchase_DAL();
            return _objPurchaseDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objPurchaseDAL = new LP_Purchase_DAL(_objPOMasterProperty);
            return _objPurchaseDAL.SelectOne();
        }

        public string GeneratePO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objPurchaseDAL = new LP_Purchase_DAL();
            DataTable dt = _objPurchaseDAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "PO-00" + TransactionNumber + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "PO-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }
        
    }
}
