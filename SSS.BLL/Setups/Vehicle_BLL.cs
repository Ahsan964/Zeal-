using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class Vehicle_BLL
    {
        Vehicle_Property property;
        Vehicle_DAL objVehicle_DAL;

        public Vehicle_BLL (Vehicle_Property obj)
        {
            property = obj;
        }
        public DataTable SelectOne()
        {
           objVehicle_DAL = new Vehicle_DAL(property);
           return objVehicle_DAL.SelectOne();
        }

        public DataTable ViewAll()
        {
            objVehicle_DAL = new Vehicle_DAL(property);
            return objVehicle_DAL.SelectAll();
        }

        public DataTable GetGrid (int pageIndex, int pageSize, out int recordCount)
        {
            objVehicle_DAL = new Vehicle_DAL(property);
            return objVehicle_DAL.GetGrid (pageIndex, pageSize,out recordCount );
        }
        public bool Delete()
        {
            objVehicle_DAL = new Vehicle_DAL(property);
            return  objVehicle_DAL.Delete();
        }

        public int Insert()
        {
            objVehicle_DAL = new Vehicle_DAL(property);
            return objVehicle_DAL.Insert();
        }

        public int Update()
        {
            objVehicle_DAL = new Vehicle_DAL(property);
            return objVehicle_DAL.Update();
        }

    }
}
