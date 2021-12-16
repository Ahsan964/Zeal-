using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class MiscellaneousSetup_BLL : GridCommandBase
    {
        private MiscellaneousSetup_Property objMiscellaneousSetupProperty;
        private MiscellaneousSetup_DAL objMiscellaneousSetupDAL;

        public MiscellaneousSetup_BLL()
        {
        }

        public MiscellaneousSetup_BLL(MiscellaneousSetup_Property objMiscellaneousSetup_Property)
        {
            objMiscellaneousSetupProperty = objMiscellaneousSetup_Property;
        }

        public int ADD()
        {
            objMiscellaneousSetupDAL = new MiscellaneousSetup_DAL(objMiscellaneousSetupProperty);
            return objMiscellaneousSetupDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objMiscellaneousSetupDAL = new MiscellaneousSetup_DAL(objMiscellaneousSetupProperty);
            return objMiscellaneousSetupDAL.SelectAll();
        }
        
        public int Update()
        {
            objMiscellaneousSetupDAL = new MiscellaneousSetup_DAL(objMiscellaneousSetupProperty);
            return objMiscellaneousSetupDAL.Update();
        }

        public DataTable SelectById()
        {
            objMiscellaneousSetupDAL = new MiscellaneousSetup_DAL(objMiscellaneousSetupProperty);
            return objMiscellaneousSetupDAL.SelectOne();
        }

        public int Delete()
        {
            objMiscellaneousSetupDAL = new MiscellaneousSetup_DAL(objMiscellaneousSetupProperty);
            return objMiscellaneousSetupDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
