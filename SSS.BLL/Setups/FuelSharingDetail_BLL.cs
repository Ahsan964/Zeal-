using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class FuelSharingDetail_BLL : GridCommandBase
    { 
        private FuelSharingDetail_Property objFuelSharingDetailProperty;
        private FuelSharingDetail_DAL objFuelSharingDetailDAL;

        public FuelSharingDetail_BLL(FuelSharingDetail_Property objFuelSharingDetail_Property)
        {
            objFuelSharingDetailProperty = objFuelSharingDetail_Property;
        }

        public DataSet GetFuelSharingDetailBLL()
        {
            objFuelSharingDetailDAL = new FuelSharingDetail_DAL(objFuelSharingDetailProperty);
            return objFuelSharingDetailDAL.GetFuelSharingDetailDAL();
        }

        public bool ADD()
        {
            objFuelSharingDetailDAL = new FuelSharingDetail_DAL(objFuelSharingDetailProperty);
            return objFuelSharingDetailDAL.Insert();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
