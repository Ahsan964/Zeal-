using SSS.DAL.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class Payment_Terms_BLL
    {
        Payment_Term_DAL objPaymentTermDAl = new Payment_Term_DAL();
        public Payment_Terms_BLL()
        {

       } 
        public DataTable GetPayemntTermsAll()
        {

            return objPaymentTermDAl.Payment_Term_SelectAll();

        }
        
    }
}