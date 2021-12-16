using SSS.DAL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions
{
    public  class LP_SalesOrder_BLL
    {
        private LP_SalesOrder_Master_Property _objSOMasterProperty;
        private LP_SalesOrder_Detail_Property _objSODetailProperty;
        private LP_SalesOrder_DAL _objPurchaseDAL;
        public LP_SalesOrder_BLL()
        {

        }
        public LP_SalesOrder_BLL(LP_SalesOrder_Master_Property objSOMasterProperty)
        {
            _objSOMasterProperty = objSOMasterProperty;
        }
        public LP_SalesOrder_BLL(LP_SalesOrder_Detail_Property objSODetailProperty)
        {
            _objSODetailProperty = objSODetailProperty;
        }
        public bool ProcessSalesInvoice()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.ProcessSalesInvoice();
        }
        public bool Insert()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.Insert();

        }
        public DataTable GetStockandPrice(int productid)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.GetStockandPrice(productid);
        }
        public DataTable GetStockandPriceBranchWise(SalesOrderVM_Property objSale)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.GetStockandPriceBranchWise(objSale);
        }
        public DataTable SelectAll()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.SelectAll();
        }
        public DataTable SelectAllForDDL()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.SelectForDropDown();
        }
        public DataTable SelectOne()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.SelectOne();
        }
        public DataTable SelectOne(int productIdx)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.SelectOne();
        }
        public DataTable SelectAllSalesInvoiceDetails(int id)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.SelectAllInvoiceDetails(id);
        }
        public string GenerateSO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            DataTable dt = _objPurchaseDAL.GenerateSONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "SO-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "SO-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }
        public bool Delete()
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL(_objSOMasterProperty);
            return _objPurchaseDAL.Delete();
        }

        public DataTable SelectSIByDate(LP_Voucher_ViewModel objvoucherinvoice)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.SelectSIBYDate(objvoucherinvoice);
        }

        public DataTable SelectSalesForSalesReturn(int salesIdx)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.getSalesForReturn(salesIdx);
        }

        public DataTable CheckProductInInventory(int salesIdx)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.getSalesForReturn(salesIdx);
        }

        public DataSet SelectSIWithDetailData(int id)
        {
            _objPurchaseDAL = new LP_SalesOrder_DAL();
            return _objPurchaseDAL.SelectAllSIDetailsDataById(id);
        }
    }
}
