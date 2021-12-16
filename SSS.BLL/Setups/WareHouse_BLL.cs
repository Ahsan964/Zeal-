using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class WareHouse_BLL
    {
        private WareHouse_Property objwarehouse;
        private WareHouse_DAL objwarehousedal;

        public WareHouse_BLL()
        {
            //objwarehouse = objwarehouseProperty;
        }
        public WareHouse_BLL(WareHouse_Property objwarehouseProperty)
        {
            objwarehouse = objwarehouseProperty;
        }

        public bool AddUpdate()
        {
            objwarehousedal = new WareHouse_DAL(objwarehouse);
            return objwarehousedal.Insert();
        }

        // Delete
        public bool Delete()
        {
            objwarehousedal = new WareHouse_DAL(objwarehouse);
            return objwarehousedal.Delete();
        }

        public DataTable SelectAll()
        {
            objwarehousedal = new WareHouse_DAL(objwarehouse);
            return objwarehousedal.SelectAll();
        }
        public DataTable SelectOne()
        {
            objwarehousedal = new WareHouse_DAL(objwarehouse);
            return objwarehousedal.SelectOne();
        }


    }
}
