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
   
    
    
    public  class Role_Capability_BLL
    {

        private Role_Capability_DAL     objRoleCapabilityDAL;
        private  Role_Capability_Property   objRoleCapabilityProperty;



        public Role_Capability_BLL(Role_Capability_Property objRoleCapability_Property)
            {
                objRoleCapabilityProperty = objRoleCapability_Property;
            }



        public bool ADD()
        {
            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.Insert();
        }



        public DataTable ViewAll()
        {
            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.SelectAll();
        }

        public DataTable View()
        {
            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.SelectOne();
        }



        public DataTable ViewRoleCapabilities()
        {
            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.SelectRoleCapabilites();
        }




        public int DeletePageAccessBulk()
        {

            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.DeletePageAccessBulk();

        }

        public int InsertPageAccessBulk()
        {

            objRoleCapabilityDAL = new Role_Capability_DAL(objRoleCapabilityProperty);
            return objRoleCapabilityDAL.InsertPageAccessBulk() ;

        }






    }
}
