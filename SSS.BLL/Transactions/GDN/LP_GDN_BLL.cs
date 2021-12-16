using SSS.DAL.Transactions.GDN_DAL;
using SSS.Property.Setups;
using SSS.Property.Setups.GDN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions.GDN
{
        public  class LP_GDN_BLL
    {
        LP_GDNMaster_Property _objGDNProperty;
        LP_GDN_DAL _objGDNDAL;

        public LP_GDN_BLL()
        {

        }
        public LP_GDN_BLL(LP_GDNMaster_Property objgdnproperty)
        {
            _objGDNProperty = objgdnproperty;
        }

        public bool Insert()
        {
            _objGDNDAL = new LP_GDN_DAL(_objGDNProperty);
            return _objGDNDAL.Insert();
        }

        public bool Delete()
        {
            _objGDNDAL = new LP_GDN_DAL(_objGDNProperty);
            return _objGDNDAL.Delete();
        }

        public DataTable SelectAll()
        {
            _objGDNDAL = new LP_GDN_DAL();
            return _objGDNDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            _objGDNDAL = new LP_GDN_DAL(_objGDNProperty);
            return _objGDNDAL.SelectOne();
        }
        public DataTable GetProcessedGRN()
        {
            _objGDNDAL = new LP_GDN_DAL();
            return _objGDNDAL.GetProcessedGRN();
        }

        public bool ProcessGDN()
        {
            _objGDNDAL = new LP_GDN_DAL(_objGDNProperty);
            return _objGDNDAL.ProcessGDN();
        }
        public string GenerateMRNNo(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            _objGDNDAL = new LP_GDN_DAL();
            DataTable dt = _objGDNDAL.GenerateMRNNo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "GDN-00" + TransactionNumber + "-" + objtransno.userid;


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
