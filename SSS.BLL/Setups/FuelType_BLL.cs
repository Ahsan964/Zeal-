using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class FuelType_BLL : GridCommandBase
    {
        private FuelType_Property objFuelTypeProperty;
        private FuelType_DAL objFuelTypeDAL;

        public FuelType_BLL()
        {
        }

        public FuelType_BLL(FuelType_Property objFuelType_Property)
        {
            objFuelTypeProperty = objFuelType_Property;
        }

        public int ADD()
        {
            objFuelTypeDAL = new FuelType_DAL(objFuelTypeProperty);
            return objFuelTypeDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objFuelTypeDAL = new FuelType_DAL(objFuelTypeProperty);
            return objFuelTypeDAL.SelectAll();
        }

        public int Update()
        {
            objFuelTypeDAL = new FuelType_DAL(objFuelTypeProperty);
            return objFuelTypeDAL.Update();
        }

        public int Delete()
        {
            objFuelTypeDAL = new FuelType_DAL(objFuelTypeProperty);
            return objFuelTypeDAL.Delete();
        }

        public DataTable SelectById()
        {
            objFuelTypeDAL = new FuelType_DAL(objFuelTypeProperty);
            return objFuelTypeDAL.SelectOne();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

    }
}
