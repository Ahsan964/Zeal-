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
    public class Registration_Type_BLL : GridCommandBase
    {
        private Registration_Type_DAL objRegTypeDAL;
        private Registration_Type_Property objRegTypeProperty;

        public Registration_Type_BLL()
        {
        }

        public Registration_Type_BLL(Registration_Type_Property objRegType_Property)
        {
            objRegTypeProperty = objRegType_Property;
        }

        public DataTable ViewAll()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.SelectAll();
        }

        public DataTable SelectOne()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.SelectOne();
        }
        public bool Insert()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.Insert();

        }

        public bool Update()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.Update();

        }
        public bool Update_Status()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.UpdateStatus();

        }
        public bool Delete()
        {
            objRegTypeDAL = new Registration_Type_DAL(objRegTypeProperty);
            return objRegTypeDAL.Delete();

        } 

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
