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
    public class Capability_BLL : GridCommandBase
    {

        private Capability_DAL objCapabilityDAL;
        private Capability_Property objCapabilityProperty;
        private int _errorcode;

        public Capability_BLL()
        {
        }

        public Capability_BLL(Capability_Property objCapability_Property)
        {
            objCapabilityProperty = objCapability_Property;
                 
        }

       

        public bool Add()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);

            //this.ErrorCode = Convert.ToInt32(objCapabilityDAL.ErrorCode); 
            return objCapabilityDAL.Insert();
        }


        public bool Update()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);

            this.ErrorCode = Convert.ToInt32(objCapabilityDAL.ErrorCode); 


            return objCapabilityDAL.Update();
        }


        public DataTable ViewAll()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.SelectAll();
        }


        public DataTable View()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.SelectOne();
        }


        public DataTable GetPrivilidgesForCurrentUserOnPage()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.GetPrivilidgesForCurrentUserOnPage();
        }


        public DataTable GetViewCapabilitiesByRole()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.GetViewCapabilitiesByRole();
        }

        public DataTable GetViewCapabilitiesByUser()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.GetViewCapabilitiesByuser();
        }
        public override void UpdateStatus()
        {
            Capability_Property objCapabilitySetupPropertyNew = new Capability_Property();
            objCapabilitySetupPropertyNew.Id = base.Id;
            objCapabilitySetupPropertyNew.Status = base.Status;
            objCapabilitySetupPropertyNew.TableName = objCapabilityProperty.TableName;
            objCapabilitySetupPropertyNew.Operated_By = objCapabilityProperty.Operated_By;

            objCapabilityDAL = new Capability_DAL(objCapabilitySetupPropertyNew);
            objCapabilityDAL.UpdateStatus();
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



        public int DeletePageAccessBulk()
        {

            

            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.DeletePageAccessBulk();

        }

        public int InsertPageAccessBulk()
        {

            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.InsertPageAccessBulk();

        }



        public DataTable ViewPagePrivileges()
        {
            objCapabilityDAL = new Capability_DAL(objCapabilityProperty);
            return objCapabilityDAL.SelectPagePrivileges();
        }







    }
}
