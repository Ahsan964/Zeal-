using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.DAL;
using SSS.Property;
using SSS.DAL;
using System.Data;

namespace SSS.BLL
{
    public class Role_BLL : GridCommandBase
    {
        private Role_DAL objRoleDAL;
        private Role_Property objRoleProperty;

        public Role_BLL()
        {
        }

        public Role_BLL(Role_Property objRole_Property)
        {
            objRoleProperty = objRole_Property;
        }

       

        public void Add()
        {
            objRoleDAL = new Role_DAL(objRoleProperty);
            objRoleDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objRoleDAL = new Role_DAL(objRoleProperty);
            return objRoleDAL.SelectAll();
        }

        public DataTable GetRolesByUser()
        {
            objRoleDAL = new Role_DAL(objRoleProperty);
            return objRoleDAL.GetRolesByUser();
        }



        public override void UpdateStatus()
        {
            Role_Property objRoleSetupPropertyNew = new Role_Property();
            objRoleSetupPropertyNew.Id = base.Id;
            objRoleSetupPropertyNew.Status = base.Status;
            objRoleSetupPropertyNew.TableName = objRoleProperty.TableName;
            objRoleSetupPropertyNew.Operated_By = objRoleProperty.Operated_By;

            objRoleDAL = new Role_DAL(objRoleSetupPropertyNew);
            objRoleDAL.UpdateStatus();
        }

        public bool ValidateUserPage(string url)
        {
            objRoleDAL = new Role_DAL(objRoleProperty);
            return objRoleDAL.ValidateUserPage(url);
        }
    }
}
