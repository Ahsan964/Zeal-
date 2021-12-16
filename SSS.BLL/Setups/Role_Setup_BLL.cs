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
    public class Role_Setup_BLL : GridCommandBase
    {

        private Role_Setup_DAL   objRoleDAL;
        private Role_Setup_Property  objRoleProperty;
        private int _errorcode;

         public Role_Setup_BLL()
            {
            }

             public Role_Setup_BLL(Role_Setup_Property objRole_Property)
            {
                objRoleProperty = objRole_Property;
            }


             public DataTable ViewAll()
             {
                 objRoleDAL = new  Role_Setup_DAL(objRoleProperty);
                 return objRoleDAL.SelectAll();
             }

             public DataTable View()
             {
                 objRoleDAL = new Role_Setup_DAL(objRoleProperty);
                 return objRoleDAL.SelectOne();
             }

             public bool ADD()
             {
                 objRoleDAL = new Role_Setup_DAL(objRoleProperty);

                 //this.ErrorCode = Convert.ToInt32(objRoleDAL.ErrorCode); 


                 return objRoleDAL.Insert();
             }

             public bool Update()
             {
                 objRoleDAL = new Role_Setup_DAL(objRoleProperty);

                 this.ErrorCode = Convert.ToInt32(objRoleDAL.ErrorCode); 

                 return objRoleDAL.Update();
             }

             public override void UpdateStatus()
             {
                 Role_Setup_Property objRoleSetupPropertyNew = new Role_Setup_Property();
                 objRoleSetupPropertyNew.Id = base.Id;
                 objRoleSetupPropertyNew.Status = base.Status;
                 objRoleSetupPropertyNew.TableName = objRoleProperty.TableName;
                 objRoleSetupPropertyNew.Operated_By = objRoleProperty.Operated_By;

                 objRoleDAL = new Role_Setup_DAL(objRoleSetupPropertyNew);
                 objRoleDAL.UpdateStatus();
             }




             public int ErrorCode
             {

                 get
                 {
                     return _errorcode;
                 }
                 set
                 {
                     _errorcode = value;
                 }



             }




    }
}
