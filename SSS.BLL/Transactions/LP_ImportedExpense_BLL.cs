using SSS.BLL.Transactions;
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
    public class LP_ImportedExpense_BLL
    {
        private LP_ImportedExpense_Master_Property _objIEMasterProperty;
        private LP_ImportedExpense_Details_Property _objIEDetailProperty;
        private LP_ImportedExpense_DAL _objIEDAL;
        public LP_ImportedExpense_BLL()
        {

        }
        public LP_ImportedExpense_BLL(LP_ImportedExpense_Master_Property objPOMasterProperty)
        {
            _objIEMasterProperty = objPOMasterProperty;
        }
        public LP_ImportedExpense_BLL(LP_ImportedExpense_Details_Property objPODetailProperty)
        {
            _objIEDetailProperty = objPODetailProperty;
        }
        public DataTable SelectAllForDDL()
        {
            _objIEDAL = new LP_ImportedExpense_DAL();
            return _objIEDAL.SelectForDropDown();
        }
        public bool Insert()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.Insert();

        }

        // Insert Inventory
        public bool Insertinventory()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.Insertinventory();

        }

        // Delete
        public bool DeleteIE()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.DeleteIE();
        }

        public DataTable SelectQS()
        {
            _objIEDAL = new LP_ImportedExpense_DAL();
            return _objIEDAL.SelectQS();
        }
        public DataTable SelectAll()
        {
            _objIEDAL = new LP_ImportedExpense_DAL();
            return _objIEDAL.SelectAll();
        }

        public DataTable SelectOne()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.SelectOne();
        }

        //Added By Ahsan
        public DataTable SelectItemsData()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.SelectOneItem();
        }


        public DataTable SelectTax()
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.SelectTaxOnQS();
        }
        public string GeneratePO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objIEDAL = new LP_ImportedExpense_DAL();
            DataTable dt = _objIEDAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "IE-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "IE-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }

        public DataTable SelectAllSalesInvoiceIEDetails(int id)
        {
            _objIEDAL = new LP_ImportedExpense_DAL(_objIEMasterProperty);
            return _objIEDAL.SelectAllInvoiceDODetails(id);
        }
    }
}
