using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class PurchaseVM_BLL
    {
        private PurchaseVM_Property objPurchaseVM;
        private PuchaseVM_DAL objPurchaseDAL;
        private int? id;
        public PurchaseVM_BLL(PurchaseVM_Property obj_Purchase)
        {
            objPurchaseVM = obj_Purchase;

        }
        public int InsertMaster()
        {
            objPurchaseDAL = new PuchaseVM_DAL(objPurchaseVM);
            return objPurchaseDAL.Insert();
        }
        public bool InsertDetail()
        {
            objPurchaseDAL = new PuchaseVM_DAL(objPurchaseVM);
            return objPurchaseDAL.detailsInsert();
        }
    }
}
