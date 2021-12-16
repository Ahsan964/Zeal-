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
    public class AchivementMaster_BLL
    {

        private AchivementMaster_Property objAchivementMasterProperty;
        private AchivementMaster_DAL objAchivementMasterDAL;

        public AchivementMaster_BLL(AchivementMaster_Property objAchivementMaster_Property)
        {
            objAchivementMasterProperty = objAchivementMaster_Property;
        }

        public DataTable GetAchivementMaster()
        {
            objAchivementMasterDAL = new AchivementMaster_DAL(objAchivementMasterProperty);
            return objAchivementMasterDAL.GetAchivementMaster();
        }

        public int Insert()
        {
            objAchivementMasterDAL = new AchivementMaster_DAL(objAchivementMasterProperty);
            return objAchivementMasterDAL.InsertMaster();
        }


        public int StatusUpdate(string tableName)
        {
            objAchivementMasterDAL = new AchivementMaster_DAL(objAchivementMasterProperty);
            return objAchivementMasterDAL.StatusUpdate(tableName);
        }


        public int UpdateMaster()
        {
            objAchivementMasterDAL = new AchivementMaster_DAL(objAchivementMasterProperty);
            return objAchivementMasterDAL.UpdateMaster();
        }

        public DataTable GetTargetPerson()
        {
            objAchivementMasterDAL = new AchivementMaster_DAL(objAchivementMasterProperty);
            return objAchivementMasterDAL.GetTargetPerson();
        }

    }
}
