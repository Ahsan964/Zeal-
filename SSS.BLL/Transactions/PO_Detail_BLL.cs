using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class PO_Detail_BLL
    {
        private PO_Detail_Property objPO_Detail;
        public PO_Detail_BLL(PO_Detail_Property objPO)
        {
            objPO_Detail = objPO;
        }
        
        public bool Insert()
        {
            PO_Detail_DAL objPO_Detail_DAL = new PO_Detail_DAL(objPO_Detail);
            return objPO_Detail_DAL.Insert();
        }
        public DataTable SelectAll()
        {
            PO_Detail_DAL objPO_Detail_DAL = new PO_Detail_DAL(objPO_Detail);
            return objPO_Detail_DAL.SelectAll();
        }
    }
}
