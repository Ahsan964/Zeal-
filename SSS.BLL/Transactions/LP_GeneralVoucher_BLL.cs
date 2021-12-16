using SSS.DAL.Setups.Accounts;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions
{
    public  class LP_GeneralVoucher_BLL
    {
        private LP_GeneralVoucher_Property _objGVProperty;
        //private LP_SalesOrder_Detail_Property _objSODetailProperty;
        private LP_GeneralVoucher_DAL _objGVDAL;
        public LP_GeneralVoucher_BLL()
        {

        }
        public LP_GeneralVoucher_BLL(LP_GeneralVoucher_Property objSOMasterProperty)
        {
            _objGVProperty = objSOMasterProperty;
        }
        //public LP_SalesOrder_BLL(LP_SalesOrder_Detail_Property objSODetailProperty)
        //{
        //    _objSODetailProperty = objSODetailProperty;
        //}
        public bool ProcessSalesInvoice()
        {
            _objGVDAL = new LP_GeneralVoucher_DAL(_objGVProperty);
            return _objGVDAL.ProcessSalesInvoice();
        }
        public bool Insert()
        {
            _objGVDAL = new LP_GeneralVoucher_DAL(_objGVProperty);
            return _objGVDAL.Insert();

        }
        public DataTable GetStockandPrice(int productid)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL();
            return _objGVDAL.GetStockandPrice(productid);
        }
        public DataTable SelectAll()
        {
            _objGVDAL = new LP_GeneralVoucher_DAL();
            return _objGVDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objGVDAL = new LP_GeneralVoucher_DAL(_objGVProperty);
            return _objGVDAL.SelectOne();
        }
        public DataTable SelectOne(int productIdx)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL(_objGVProperty);
            return _objGVDAL.SelectOne();
        }
        public DataTable SelectAllSalesInvoiceDetails(int id)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL(_objGVProperty);
            return _objGVDAL.SelectAllInvoiceDetails(id);
        }
        public string GenerateSO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objGVDAL = new LP_GeneralVoucher_DAL();
            DataTable dt = _objGVDAL.GenerateSONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "GV-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "SO-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }

        //public DataTable SelectSIByDate(LP_Voucher_ViewModel objvoucherinvoice)
        //{
        //    _objGVDAL = new LP_SalesOrder_DAL();
        //    return _objGVDAL.SelectSIBYDate(objvoucherinvoice);
        //}

        public DataTable SelectSalesForSalesReturn(int salesIdx)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL();
            return _objGVDAL.getSalesForReturn(salesIdx);
        }

        public DataTable CheckProductInInventory(int salesIdx)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL();
            return _objGVDAL.getSalesForReturn(salesIdx);
        }

        public DataSet SelectSIWithDetailData(int id)
        {
            _objGVDAL = new LP_GeneralVoucher_DAL();
            return _objGVDAL.SelectAllSIDetailsDataById(id);
        }
    }
}
