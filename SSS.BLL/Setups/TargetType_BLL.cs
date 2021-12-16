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
    
    public class TargetType_BLL  
    {
       private TargetType_Property objTargetTypeProperty;
       private TargetType_DAL objTargetTypeDAL;
         
       public TargetType_BLL(TargetType_Property objTargetType_Property)
        {
            objTargetTypeProperty = objTargetType_Property;
        }

       public DataTable GetTargetType()
       {
           objTargetTypeDAL = new TargetType_DAL(objTargetTypeProperty);
           return objTargetTypeDAL.GetTargetType();
       }
    }
}
