using SSS.DAL.Transactions;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions
{
    public class LP_FinishProduct_BLL
    {
        private LP_FinsihProduct_Property _objACTMasterProperty;

        private LP_FinishProduct_DAL _objACTDAL;
        public LP_FinishProduct_BLL()
        {

        }
        public LP_FinishProduct_BLL(LP_FinsihProduct_Property objACTMasterProperty)
        {
            _objACTMasterProperty = objACTMasterProperty;
        }
        public bool Insert()
        {
            _objACTDAL = new LP_FinishProduct_DAL(_objACTMasterProperty);
            return _objACTDAL.Insert();
        }
        public DataTable SelectAll()
        {
            _objACTDAL = new LP_FinishProduct_DAL();
            return _objACTDAL.SelectAll();
        }
        public DataTable SelectAllActivityOnSoNumber(int id)
        {
            _objACTDAL = new LP_FinishProduct_DAL();
            return _objACTDAL.SelectAllActivityByOrder(id);
        }
    }
}
