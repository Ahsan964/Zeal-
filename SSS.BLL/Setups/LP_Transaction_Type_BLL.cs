using SSS.DAL.Transactions;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class LP_Transaction_Type_BLL
    {
        private LP_Transaction_Type_Property _objtransactionTypeProperty;

        LP_Transaction_Type_DAL objLP_Transaction_Type_DAL;
        public LP_Transaction_Type_BLL()
        {

        }
        public LP_Transaction_Type_BLL(LP_Transaction_Type_Property objtransactionTypeProperty)
        {
            _objtransactionTypeProperty = objtransactionTypeProperty;
        }
        public  DataTable SelectAll()
        {
            objLP_Transaction_Type_DAL = new LP_Transaction_Type_DAL();
            return objLP_Transaction_Type_DAL.SelectAll();
        }
    }
}
