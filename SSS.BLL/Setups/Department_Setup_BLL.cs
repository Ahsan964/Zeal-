using SSS.BLL.Setups;
using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
   public class Department_Setup_BLL:GridCommandBase
    {
        Department_Setup_Property objDepartmentProperty;
        Department_DAL objDepartmentDAL;
        public Department_Setup_BLL()
        {
        }

        public Department_Setup_BLL(Department_Setup_Property objDepartment_Property)
        {
            objDepartmentProperty = objDepartment_Property;
        }
        public bool Insert()
        {
            objDepartmentDAL = new Department_DAL(objDepartmentProperty);
            return objDepartmentDAL.Insert();
        }
        public int CheckNoOfRecords()
        {
            objDepartmentDAL = new Department_DAL(objDepartmentProperty);
            return objDepartmentDAL.CheckNoOfRecords();
        }
        public DataTable ViewAll()
        {
            objDepartmentDAL = new Department_DAL();
            return objDepartmentDAL.SelectAll();
        }
        public override void UpdateStatus()
        {
            Department_Setup_Property objDepartmentPropertyNew = new  Department_Setup_Property();
            objDepartmentPropertyNew.Department_Id = base.Id;
            objDepartmentPropertyNew.Status = base.Status;
            objDepartmentPropertyNew.TableName = objDepartmentProperty.TableName;
            objDepartmentPropertyNew.Operated_By = objDepartmentProperty.Operated_By;
            objDepartmentDAL = new Department_DAL(objDepartmentPropertyNew);
            objDepartmentDAL.UpdateStatus();


        }

        public DataTable View()
        {
            objDepartmentDAL = new Department_DAL(objDepartmentProperty);
            return objDepartmentDAL.SelectOne();
        }

        public bool Update()
        {
            objDepartmentDAL = new Department_DAL(objDepartmentProperty);
            return objDepartmentDAL.Update();
        }
    }
}
