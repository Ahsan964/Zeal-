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
   public class TargetPeriod_BLL : GridCommandBase
    {
    
       private TargetPeriod_Property objTargetPeriodProperty;
       private TargetPeriod_DAL objTargetPeriodDAL;

       public TargetPeriod_BLL(TargetPeriod_Property objTargetPeriod_Property)
        {
            objTargetPeriodProperty = objTargetPeriod_Property;
        }



       public DataTable GetTargetPeriodbyID()
       {

           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.GetTargetPeriodByID();
       }

       public DataTable GetTargetPeriodbyParentID()
       {

           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.GetTargetPeriodByParentID();
       }

       public DataSet GetTargetbyPeriodBokrID()
       {

           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.GetTargetbyPeriodBokrID();
       }


       public DataSet GetTargetSaleSumaryXml()
       {

           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.GetTargetSaleSumaryXml();
       }
       public DataTable GetTopTargetPeriod()
       {

           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.GetTopTargetPeriods();
       }

       public int Insert()
       {
           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.InsertPeriod();
       }

       public bool Update()
       {
           objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodProperty);
           return objTargetPeriodDAL.Update();
       }

           public override void UpdateStatus()
        {

            TargetPeriod_Property objTargetPeriodPropertyNew = new TargetPeriod_Property();
            objTargetPeriodPropertyNew.ID = base.Id;
            objTargetPeriodPropertyNew.Status = base.Status;
            objTargetPeriodPropertyNew.TableName = objTargetPeriodProperty.TableName;
            objTargetPeriodPropertyNew.Operated_By = objTargetPeriodProperty.Operated_By;

            objTargetPeriodDAL = new TargetPeriod_DAL(objTargetPeriodPropertyNew);
            objTargetPeriodDAL.UpdateStatus();
            
        }
    }
}
