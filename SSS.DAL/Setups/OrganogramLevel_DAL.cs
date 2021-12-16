using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using FluentValidation;
using SNDDAL;
using SSS.Property.Setups;

namespace SSS.DAL.Setups
{
   public class OrganogramLevel_DAL
    {

       private OrganogramLevel_Property objOrganogramlevelProperty;

       public OrganogramLevel_DAL(OrganogramLevel_Property objOrganogramlevel_Property)
        {
            objOrganogramlevelProperty = objOrganogramlevel_Property;
        }

    }
}
