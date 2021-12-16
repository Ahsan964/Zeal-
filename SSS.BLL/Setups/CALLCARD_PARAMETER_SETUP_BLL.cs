using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using SSS.Property;

namespace SSS.BLL.Setups
{
    public class CALLCARD_PARAMETER_SETUP_BLL : GridCommandBase
    {
        private CALLCARD_PARAMETER_SETUP_Property objCallCardProperty;
        private CALLCARD_PARAMETER_SETUP_DAL objCallCardDAL;

        public CALLCARD_PARAMETER_SETUP_BLL()
        { }
        public CALLCARD_PARAMETER_SETUP_BLL(CALLCARD_PARAMETER_SETUP_Property objCallCard_Property)
        {
            objCallCardProperty = objCallCard_Property;
        }

        public DataTable ViewAll()
        {
            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardProperty);
            return objCallCardDAL.SelectAll();
        }

        public DataTable GetAllCallCardCategory()
        {
            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardProperty);
            return objCallCardDAL.GetAllCallCardCategory();
        }
        public bool Add()
        {
            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardProperty);
            return objCallCardDAL.Insert();
        }

        public override void UpdateStatus()
        {
            CALLCARD_PARAMETER_SETUP_Property objCallCardPropertyNew = new CALLCARD_PARAMETER_SETUP_Property();
            objCallCardPropertyNew.ID = base.Id;
            objCallCardPropertyNew.Status = base.Status;
            objCallCardPropertyNew.TableName = objCallCardProperty.TableName;
            objCallCardPropertyNew.Operated_By = objCallCardProperty.Operated_By;

            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardPropertyNew);
            objCallCardDAL.UpdateStatus();


        }
        public DataTable View()
        {
            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardProperty);
            return objCallCardDAL.SelectOne();
        }

        public bool Update()
        {
            objCallCardDAL = new CALLCARD_PARAMETER_SETUP_DAL(objCallCardProperty);
            return objCallCardDAL.Update();
        }
    }
}
