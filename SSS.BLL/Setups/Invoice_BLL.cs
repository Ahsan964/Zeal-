using SSS.DAL.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Invoice_BLL
    {
        Invoice_DAL objinvoceDAL;

        public Invoice_BLL()
        {

        }

        public DataTable GenerateReport(int? id,int? query)
        {
            objinvoceDAL = new Invoice_DAL();
            return objinvoceDAL.GenerateReport(id, query);
        }
    }
}
