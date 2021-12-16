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
    public class LP_DisplayOrder_BLL
    {
        private LP_DisplayOrder_Master_Property _objDOMasterProperty;
        private LP_DisplayOrder_Details_Property _objDODetailProperty;
        private LP_DisplayOrder_DAL _objDODAL;
        public LP_DisplayOrder_BLL()
        {

        }
        public LP_DisplayOrder_BLL(LP_DisplayOrder_Master_Property objPOMasterProperty)
        {
            _objDOMasterProperty = objPOMasterProperty;
        }
        public LP_DisplayOrder_BLL(LP_DisplayOrder_Details_Property objPODetailProperty)
        {
            _objDODetailProperty = objPODetailProperty;
        }
        public DataTable SelectAllForDDL()
        {
            _objDODAL = new LP_DisplayOrder_DAL();
            return _objDODAL.SelectForDropDown();
        }

        public bool Delete()
        {
            _objDODAL = new LP_DisplayOrder_DAL(_objDOMasterProperty);
            return _objDODAL.Delete();
        }

        public bool Insert()
        {
            _objDODAL = new LP_DisplayOrder_DAL(_objDOMasterProperty);
            return _objDODAL.Insert();

        }
        public DataTable SelectQS()
        {
            _objDODAL = new LP_DisplayOrder_DAL();
            return _objDODAL.SelectQS();
        }
        public DataTable SelectAll()
        {
            _objDODAL = new LP_DisplayOrder_DAL();
            return _objDODAL.SelectAll();
        }
      
        public DataTable SelectOne()
        {
            _objDODAL = new LP_DisplayOrder_DAL(_objDOMasterProperty);
            return _objDODAL.SelectOne();
        }
        public DataTable SelectTax()
        {
            _objDODAL = new LP_DisplayOrder_DAL(_objDOMasterProperty);
            return _objDODAL.SelectTaxOnQS();
        }
        public string GeneratePO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objDODAL = new LP_DisplayOrder_DAL();
            DataTable dt = _objDODAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "DO-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "DO-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }

        public DataTable SelectAllSalesInvoiceDODetails(int id)
        {
            _objDODAL = new LP_DisplayOrder_DAL(_objDOMasterProperty);
            return _objDODAL.SelectAllInvoiceDODetails(id);
        }
    }
}
