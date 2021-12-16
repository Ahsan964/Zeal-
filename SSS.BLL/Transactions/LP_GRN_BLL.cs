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
   public class LP_GRN_BLL
    {
        LP_GRN_Master_Property _objgrnproperty;
       LP_GRN_DAL _objGRNDAL;

        public LP_GRN_BLL()
        {

        }
        public LP_GRN_BLL(LP_GRN_Master_Property objgrnproperty)
        {
            _objgrnproperty = objgrnproperty;
        }

        public bool Delete()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.Delete();
        }
        public bool Insert()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.Insert();
        }

        public DataTable SelectAll()
        {
            _objGRNDAL = new LP_GRN_DAL();
            return _objGRNDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.SelectOne();
        }
        public DataTable GetProcessedGRN()
        {
            _objGRNDAL = new LP_GRN_DAL();
            return _objGRNDAL.GetProcessedGRN();
        }

        public bool ProcessGRN()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.ProcessGRN();
        }
        public bool Insertinventory()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.Insertinventory();

        }

        public DataTable SelectDataForInv()
        {
            _objGRNDAL = new LP_GRN_DAL(_objgrnproperty);
            return _objGRNDAL.SelectDataForInv();
        }

        public string GenerateMRNNo(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objGRNDAL = new LP_GRN_DAL();
            DataTable dt = _objGRNDAL.GenerateMRNNo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "GRN-00" + TransactionNumber + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "GRN-001-" + objtransno.userid;

                return TransactionNumber;
            }
            //return _objMRNDAL.GenerateMRNNo(objtransno);
        }
    }
}
