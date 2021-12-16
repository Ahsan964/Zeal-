using SSS.DAL.Setups;
using SSS.DAL.Transactions;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class LP_Purchase_Type_BLL
    {
        LP_Purchase_Type objPurchaseTypeProperty;
        LP_Purchase_Type_DAL objPurchaseTypeDAL;

        public LP_Purchase_Type_BLL()
        {

        }
        public LP_Purchase_Type_BLL(LP_Purchase_Type _objPurchaseTypeProperty)
        {
           objPurchaseTypeProperty= _objPurchaseTypeProperty;
        }

        public DataTable SelectAll()
        {
            objPurchaseTypeDAL = new LP_Purchase_Type_DAL();
           return objPurchaseTypeDAL.SelectAll();

        }

    }
}
