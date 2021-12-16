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
    public class WH_Location_BLL : GridCommandBase
    {
       private Wh_Location_DAL objWhLocationDAL;
       private Wh_Location_Property ObjWhLocationProperty;

       public WH_Location_BLL(Wh_Location_Property objWh_Location_Property)
        {
            ObjWhLocationProperty = objWh_Location_Property;
        }

       public DataTable ViewAll()
       {
           objWhLocationDAL = new Wh_Location_DAL(ObjWhLocationProperty);
           return objWhLocationDAL.SelectAll();
       }
       public bool Add()
       {
           objWhLocationDAL = new Wh_Location_DAL(ObjWhLocationProperty);
           return objWhLocationDAL.Insert();
       }
       public bool Update()
       {
           objWhLocationDAL = new Wh_Location_DAL(ObjWhLocationProperty);
           return objWhLocationDAL.Update();
       }
       public DataTable View()
       {
           objWhLocationDAL = new Wh_Location_DAL(ObjWhLocationProperty);
           return objWhLocationDAL.SelectOne();
       }
       public override void UpdateStatus()
       {
           Wh_Location_Property ObjWhLocationPropertyNew = new Wh_Location_Property();
           ObjWhLocationPropertyNew.ID = base.Id;
           ObjWhLocationPropertyNew.Status = base.Status;
           ObjWhLocationPropertyNew.TableName = ObjWhLocationProperty.TableName;
           ObjWhLocationPropertyNew.Operated_By = ObjWhLocationProperty.Operated_By;

           objWhLocationDAL = new Wh_Location_DAL(ObjWhLocationPropertyNew);
           objWhLocationDAL.UpdateStatus();


       }
    }
}
