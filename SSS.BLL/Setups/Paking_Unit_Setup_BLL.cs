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
    public class Paking_Unit_Setup_BLL : GridCommandBase
    {
       private Paking_Unit_Setup_Property objPackingUnitProperty;
       private Paking_Unit_Setup_DAL objPackingUnitDAL;

        public Paking_Unit_Setup_BLL(Paking_Unit_Setup_Property objPacking_UnitProperty)
        {
            objPackingUnitProperty = objPacking_UnitProperty;

        }
        public DataTable ViewAll()
        {
            objPackingUnitDAL = new Paking_Unit_Setup_DAL(objPackingUnitProperty);
            return objPackingUnitDAL.SelectAll();
        }

        public bool ADD()
        {
            objPackingUnitDAL = new Paking_Unit_Setup_DAL(objPackingUnitProperty);
            return objPackingUnitDAL.Insert();
        }
        public bool Update()
        {
            objPackingUnitDAL = new Paking_Unit_Setup_DAL(objPackingUnitProperty);
            return objPackingUnitDAL.Update();
        }

        public override void UpdateStatus()
        {
            objPackingUnitDAL = new Paking_Unit_Setup_DAL(objPackingUnitProperty);
            objPackingUnitProperty.ID = base.Id;
            objPackingUnitProperty.Status = base.Status;
            objPackingUnitProperty.TableName = "PACKING_UNIT_SETUP";

            objPackingUnitDAL = new Paking_Unit_Setup_DAL(objPackingUnitProperty);
            objPackingUnitDAL.UpdateStatus();

        }
    }
}
