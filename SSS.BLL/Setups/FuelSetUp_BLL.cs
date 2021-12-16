using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class FuelSetUp_BLL : GridCommandBase
    {
        private FuelSetUp_Property objFuelSetUpProperty;
        private FuelSetUp_DAL objFuelSetUpDAL;

        public FuelSetUp_BLL()
        {
        }

        public FuelSetUp_BLL(FuelSetUp_Property objFuelSetUp_Property)
        {
            objFuelSetUpProperty = objFuelSetUp_Property;
        }

        public int ADD()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.SelectAll();
        }
        
        public int Update()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.Update();
        }

        public DataTable SelectById()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.SelectOne();
        }

        public DataTable SelectFuelSetupByTransactionDateAndFuelTypeIdBLL()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.SelectFuelSetupByTransactionDateAndFuelTypeId();
        }

        public bool Delete()
        {
            objFuelSetUpDAL = new FuelSetUp_DAL(objFuelSetUpProperty);
            return objFuelSetUpDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
