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
   
   public class Target_Setting_Master_BLL
    {

       private Target_Setting_Master_Property objTRSMproperty;
       private Target_Setting_Master_DAL objTRSMDAL;

       public Target_Setting_Master_BLL(Target_Setting_Master_Property objTRSM_property)
       {
           objTRSMproperty = objTRSM_property;
       }

       public int Insert()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.InsertMaster();
       }


       public DataTable GetTargetMasterbyParam()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.GetTargetMasterbyParam();
           
       }

       public DataTable GetTargetsReportBLL()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.GetTargetsReportDll();
       }

       public DataTable GetTargetsReportBLLChannelWise()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.GetTargetsReportDllChannelWise();
       }

       public DataTable GetTargetSettingMasterByOrderBookerAndTargetPeriodIdsBLL()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.GetTargetSettingMasterByOrderBookerAndTargetPeriodIdsDll();
       }

       public DataTable GetProductiveCallsAchievementBLL()
       {
           objTRSMDAL = new Target_Setting_Master_DAL(objTRSMproperty);
           return objTRSMDAL.GetProductiveCallsAchievementDll();
       }
       
    }
}
