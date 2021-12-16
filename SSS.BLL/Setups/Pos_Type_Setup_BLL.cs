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
    public class Pos_Type_Setup_BLL : GridCommandBase
    {
        private Pos_Type_Setup_DAL objPOSTypeDAL;
        private Pos_Type_Setup_Property objPOSTypeProperty;

        public Pos_Type_Setup_BLL()
        {
        }

        public Pos_Type_Setup_BLL(Pos_Type_Setup_Property objPOSType_Property)
        {
            objPOSTypeProperty = objPOSType_Property;
        }

        public DataTable ViewAll()
        {
            objPOSTypeDAL = new Pos_Type_Setup_DAL(objPOSTypeProperty);
            return objPOSTypeDAL.SelectAll();
        }
        public bool ADD()
        {
            objPOSTypeDAL = new Pos_Type_Setup_DAL(objPOSTypeProperty);
            return objPOSTypeDAL.Insert();
        }
        public bool Update()
        {
            objPOSTypeDAL = new Pos_Type_Setup_DAL(objPOSTypeProperty);
            return objPOSTypeDAL.Update();
        }



        public override void UpdateStatus()
        {
            Pos_Type_Setup_Property objPOSType_Property = new Pos_Type_Setup_Property();
            objPOSType_Property.ID = base.Id;
            objPOSType_Property.Status = base.Status;
            objPOSType_Property.TableName = "POS_TYPE_SETUP";

            objPOSTypeDAL = new Pos_Type_Setup_DAL(objPOSType_Property);
            objPOSTypeDAL.UpdateStatus();
            
        }
    }
}
