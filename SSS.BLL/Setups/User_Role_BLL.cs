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
    public  class User_Role_BLL
    {

        private User_Role_DAL  objUserRoleDAL;
        private User_Role_Property  objUserRoleProperty;



        public User_Role_BLL(User_Role_Property objUserRole_Property)
            {
                objUserRoleProperty = objUserRole_Property;
            }




        public DataTable ViewAll()
        {
            objUserRoleDAL = new User_Role_DAL(objUserRoleProperty);
            return objUserRoleDAL.SelectAll();
        }

        public DataTable View()
        {
            objUserRoleDAL = new User_Role_DAL(objUserRoleProperty);
            return objUserRoleDAL.SelectOne();
        }


        public DataTable ViewUserRoles()
        {
            objUserRoleDAL = new User_Role_DAL(objUserRoleProperty);
            return objUserRoleDAL.SelectUserRoles();
        }






        public int DeletePageAccessBulk()
        {

            objUserRoleDAL = new User_Role_DAL(objUserRoleProperty);
            return objUserRoleDAL.DeletePageAccessBulk();

        }

        public int InsertPageAccessBulk()
        {

            objUserRoleDAL = new User_Role_DAL(objUserRoleProperty);
            return objUserRoleDAL.InsertPageAccessBulk();

        }








    }
}
