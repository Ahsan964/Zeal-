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
    public class OrganogramLevel_BLL
    {

         private OrganogramLevel_Property objOrganogramlevelProperty;
         private OrganogramLevel_DAL objOrganogramlevelDAL;

         public OrganogramLevel_BLL(OrganogramLevel_Property objOrganogramlevel_Property)
        {
            objOrganogramlevelProperty = objOrganogramlevel_Property;
        }
    }
}
