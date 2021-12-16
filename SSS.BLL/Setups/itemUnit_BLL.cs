using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class itemUnit_BLL
    {
        private itemUnit_DAL objItemUnitDAL;
        private itemUnit_Property objItemUnitProperty;

        private int? id;
        public itemUnit_BLL(itemUnit_Property objItemUnit_Property)
        {
            objItemUnitProperty = objItemUnit_Property;

        }
        public itemUnit_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objItemUnitDAL = new itemUnit_DAL(objItemUnitProperty);
            return objItemUnitDAL.SelectAll();
        }
        public DataTable GetById(int? id)
        {
            objItemUnitDAL = new itemUnit_DAL(objItemUnitProperty);
            return objItemUnitDAL.SelectById(id);
        }
        public bool Insert()
        {
            objItemUnitDAL = new itemUnit_DAL(objItemUnitProperty);
            return objItemUnitDAL.Insert();
        }
        public bool Update()
        {
            objItemUnitDAL = new itemUnit_DAL(objItemUnitProperty);
            return objItemUnitDAL.Update();
        }
        public bool Delete(int? id)
        {
            objItemUnitDAL = new itemUnit_DAL(objItemUnitProperty);
            return objItemUnitDAL.Delete(id);
        }
    }
}
