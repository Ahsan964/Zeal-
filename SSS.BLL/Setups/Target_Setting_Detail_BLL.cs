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
    public class Target_Setting_Detail_BLL
    {
       private Target_Setting_Detail_Property objTRSDproperty;
       private Target_Setting_Detail_DAL objTRSDDAL;

       public Target_Setting_Detail_BLL(Target_Setting_Detail_Property objTRSD_property)
       {
           objTRSDproperty = objTRSD_property;
       }

       public bool Insert()
       {
           objTRSDDAL = new Target_Setting_Detail_DAL(objTRSDproperty);
           return objTRSDDAL.Insert();
       }


       public DataTable ViewbyMasterID()
       {
           
           objTRSDDAL = new Target_Setting_Detail_DAL(objTRSDproperty);
           return objTRSDDAL.GetTargetSetting_Detail_byMasterID();

       }
    }
}
