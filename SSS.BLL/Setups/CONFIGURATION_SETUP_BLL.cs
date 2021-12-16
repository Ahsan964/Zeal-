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
   public class CONFIGURATION_SETUP_BLL : GridCommandBase
    {
        private CONFIGURATION_SETUP_Prperty objConfProperty;
        private CONFIGURATION_SETUP_DAL objConfDAL;

        public CONFIGURATION_SETUP_BLL()
        { }
        public CONFIGURATION_SETUP_BLL(CONFIGURATION_SETUP_Prperty objConf_Property)
        {
            objConfProperty = objConf_Property;
        }

        public DataTable ViewAll()
        {
            objConfDAL = new CONFIGURATION_SETUP_DAL(objConfProperty);
            return objConfDAL.SelectAll();
        }

        public bool Add()
        {
            objConfDAL = new CONFIGURATION_SETUP_DAL(objConfProperty);
            return objConfDAL.Insert();
        }

        public DataTable View()
        {
            objConfDAL = new CONFIGURATION_SETUP_DAL(objConfProperty);
            return objConfDAL.SelectOne();
        }

        public bool Update()
        {
            objConfDAL = new CONFIGURATION_SETUP_DAL(objConfProperty);
            return objConfDAL.Update();
        }

        public override void UpdateStatus()
        {
            CONFIGURATION_SETUP_Prperty objConfPropetyNew = new CONFIGURATION_SETUP_Prperty();
            objConfPropetyNew.ID = base.Id;
            objConfPropetyNew.Status = base.Status;
            objConfPropetyNew.TableName = objConfProperty.TableName;
            objConfPropetyNew.Operated_By = objConfProperty.Operated_By;

            objConfDAL = new CONFIGURATION_SETUP_DAL(objConfPropetyNew);
            objConfDAL.UpdateStatus();


        }
    }
}
