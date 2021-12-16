using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class MiscellaneousExpenseDetail_BLL : GridCommandBase
    {
        private MiscellaneousExpenseDetail_Property objMiscellaneousExpenseDetailProperty;
        private MiscellaneousExpenseDetail_DAL objMiscellaneousExpenseDetailDAL;

        public MiscellaneousExpenseDetail_BLL()
        {
        }

        public MiscellaneousExpenseDetail_BLL(MiscellaneousExpenseDetail_Property objMiscellaneousExpenseDetail_Property)
        {
            objMiscellaneousExpenseDetailProperty = objMiscellaneousExpenseDetail_Property;
        }

        public int ADD()
        {
            objMiscellaneousExpenseDetailDAL = new MiscellaneousExpenseDetail_DAL(objMiscellaneousExpenseDetailProperty);
            return objMiscellaneousExpenseDetailDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objMiscellaneousExpenseDetailDAL = new MiscellaneousExpenseDetail_DAL(objMiscellaneousExpenseDetailProperty);
            return objMiscellaneousExpenseDetailDAL.SelectAll();
        }
        
        public int Update()
        {
            objMiscellaneousExpenseDetailDAL = new MiscellaneousExpenseDetail_DAL(objMiscellaneousExpenseDetailProperty);
            return objMiscellaneousExpenseDetailDAL.Update();
        }

        public DataTable SelectById()
        {
            objMiscellaneousExpenseDetailDAL = new MiscellaneousExpenseDetail_DAL(objMiscellaneousExpenseDetailProperty);
            return objMiscellaneousExpenseDetailDAL.SelectOne();
        }

        public int Delete()
        {
            objMiscellaneousExpenseDetailDAL = new MiscellaneousExpenseDetail_DAL(objMiscellaneousExpenseDetailProperty);
            return objMiscellaneousExpenseDetailDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
