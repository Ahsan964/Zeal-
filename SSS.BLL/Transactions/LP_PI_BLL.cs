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
    public class LP_PI_BLL
    {
        private LP_ImportedExpense_Master_Property _objIEMaster; 

        private LP_Performa_Invoice_Property _objPerformaMaster;
        private LP_Performa_Invoice_Details_Property _objPerformaDetail;

        private LP_CI_PurchaseOrder_Property _objCIMaster;
        private LP_CI_PurchaseDetails_Property _objCIDetail;

        private LP_Consigment_Property _objconsigment_Property;
        private LP_ConsigmentDetails _objconsigment_Deatil;


        private LP_PI_DAL _objPIDAL;

        public LP_PI_BLL()
        {

        }
        public LP_PI_BLL(LP_CI_PurchaseOrder_Property objci)
        {
            _objCIMaster = objci;
        }

        public LP_PI_BLL(LP_ImportedExpense_Master_Property objie)
        {
            _objIEMaster = objie;
        }


        public LP_PI_BLL(LP_Consigment_Property objConsigment)
        {
            _objconsigment_Property = objConsigment;
        }
        public LP_PI_BLL(LP_Performa_Invoice_Property objpinvoice)
        {
            _objPerformaMaster = objpinvoice;
        }

        public bool Insert()
        {
            _objPIDAL = new LP_PI_DAL(_objPerformaMaster);
            return _objPIDAL.Insert();
        }

        // Delete Performa Invoice
        public bool Delete()
        {
            _objPIDAL = new LP_PI_DAL(_objPerformaMaster);
            return _objPIDAL.Delete();
        }

        // Delete Commercial Invoice
        public bool DeleteCI()
        {
            _objPIDAL = new LP_PI_DAL(_objCIMaster);
            return _objPIDAL.DeleteCI();
        }

      
        public DataTable SelectAllDT()
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectAllDT();
        }

        public DataTable SelectAllIE()
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectAllIE();
        }
        public DataTable SelectAll()
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objPIDAL = new LP_PI_DAL(_objPerformaMaster);
            return _objPIDAL.SelectOne();
        }

        public DataTable SelectPIBYID(int id)
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectPIBYID(id);
        }

        
        public string GeneratePINo(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objPIDAL = new LP_PI_DAL();
            DataTable dt = _objPIDAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "PRI-00" + TransactionNumber + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "PRI-001-" + objtransno.userid;

                return TransactionNumber;
            }
            //return _objMRNDAL.GenerateMRNNo(objtransno);
        }

        #region CIPO
        public string GenerateCINo(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objPIDAL = new LP_PI_DAL();
            DataTable dt = _objPIDAL.GeneratePONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "CI-00" + TransactionNumber + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "CI-001-" + objtransno.userid;

                return TransactionNumber;
            }
            //return _objMRNDAL.GenerateMRNNo(objtransno);
        }

        // Added By Ahsan
        public DataTable SelectOneCI()
        {
            _objPIDAL = new LP_PI_DAL(_objCIMaster);
            return _objPIDAL.SelectOneCI();
        }

        public bool InsertCIPO()
        {
            _objPIDAL = new LP_PI_DAL(_objCIMaster);
            return _objPIDAL.InsertCIPO();
        }
        public DataTable SelectAllCIPO()
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectAllCIPO();
        }
        public DataTable SelectCIBYID(int id)
        {
            _objPIDAL = new LP_PI_DAL();
            return _objPIDAL.SelectCIBYID(id);
        }
        #endregion


        #region Consigment
        public bool InsertConsigment()
        {
            _objPIDAL = new LP_PI_DAL(_objconsigment_Property);
            return _objPIDAL.InsertConsigment();
        }
        #endregion
    }
}
