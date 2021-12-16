using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class ClaimType_BLL : GridCommandBase
    {
        private ClaimType_DAL objClaimTypeDAL;
        private ClaimType_Property objClaimTypeProperty;

        public ClaimType_BLL(ClaimType_Property objClaimType_Property)
        {
            objClaimTypeProperty = objClaimType_Property;
        }

        public DataTable ViewAll()
        {
            objClaimTypeDAL = new ClaimType_DAL(objClaimTypeProperty);
            return objClaimTypeDAL.SelectAll();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
