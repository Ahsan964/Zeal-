using SSS.DAL.Transactions;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions
{
    public class LP_Activity_BLL
    {
        private LP_Activity_Property _objACTMasterProperty;
     
        private LP_Activity_DAL _objACTDAL;
        public LP_Activity_BLL()
        {

        }
        public LP_Activity_BLL(int id)
        {

        }
        public LP_Activity_BLL(LP_Activity_Property objACTMasterProperty)
        {
            _objACTMasterProperty = objACTMasterProperty;
        }

        public bool Delete()
        {
            _objACTDAL = new LP_Activity_DAL(_objACTMasterProperty);
            return _objACTDAL.Delete();
        }


        public bool Insert()
        {
            _objACTDAL = new LP_Activity_DAL(_objACTMasterProperty);
            return _objACTDAL.Insert();
        }
        public bool DeleteAndInsert()
        {
            _objACTDAL = new LP_Activity_DAL(_objACTMasterProperty);
            return _objACTDAL.DeleteAndInsert();
        }

        public DataTable getVendorPrice(int id)
        {
            _objACTDAL = new LP_Activity_DAL(_objACTMasterProperty);
            return _objACTDAL.selectVendorPrice(id);
        }
        public DataTable SelectAll()
        {
            _objACTDAL = new LP_Activity_DAL(_objACTMasterProperty);
            return _objACTDAL.SelectAll();
        }

        

    }
}
