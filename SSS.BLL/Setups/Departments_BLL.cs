using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class Departments_BLL
    {
        private Departments_DAL objDepartmentDAL;
        private Departments_property objDepartmentproperty;

        public Departments_BLL()
        {
            

        }
        public Departments_BLL(Departments_property objDepartment_property)
        {
            objDepartmentproperty = objDepartment_property;

        }
        public DataTable ViewAll()
        {
            objDepartmentDAL = new Departments_DAL(objDepartmentproperty);
            return objDepartmentDAL.SelectAll();
        }
        public bool Insert()
        {
            objDepartmentDAL = new Departments_DAL(objDepartmentproperty);
            return objDepartmentDAL.Insert();
        }
        public bool Update()
        {
            objDepartmentDAL = new Departments_DAL(objDepartmentproperty);
            return objDepartmentDAL.Update();
        }

        public  bool DeleteDepartment()
        {
            objDepartmentDAL = new Departments_DAL(objDepartmentproperty);
            return objDepartmentDAL.Delete();
        }
        public  DataTable GetById(int? id)
        {
            objDepartmentDAL = new Departments_DAL(objDepartmentproperty);
            return objDepartmentDAL.SelectById();
        }

     

        public object Update(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
