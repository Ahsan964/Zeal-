using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class VehicleSharing_BLL : GridCommandBase
    {
        private VehicleSharingDetail_Property objVehicleSharingDetailProperty;
        private VehicleSharing_DAL objVehicleSharingDAL;

        public VehicleSharing_BLL(VehicleSharingDetail_Property objVehicleSharingDetail_Property)
        {
            objVehicleSharingDetailProperty = objVehicleSharingDetail_Property;
        }

        public int ADD()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.Insert();
        }

        public int Update()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.Update();
        }


        public DataTable ViewAll()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.SelectAll();
        }

        public DataTable SelectById()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.SelectOne();
        }

        public DataTable GetVehicleSharingDetailByDeliverManId_BLL()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.GetVehicleSharingDetailByDeliverManId();
        }

        public int Delete()
        {
            objVehicleSharingDAL = new VehicleSharing_DAL(objVehicleSharingDetailProperty);
            return objVehicleSharingDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
