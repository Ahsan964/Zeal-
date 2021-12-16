using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class DSRAdjustment_BLL : GridCommandBase
    {
        private DSRAdjustment_DAL objDSRAjdustmentDAL;
        private DSRAdjustment_Property objDSRAjdustmentProperty;

        public DSRAdjustment_BLL()
        {
        }

        public DSRAdjustment_BLL(DSRAdjustment_Property DSRAdjustment_Property)
        {
            objDSRAjdustmentProperty = DSRAdjustment_Property;
        }

        public bool ADD()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentProperty);
            return objDSRAjdustmentDAL.Insert();
        }


        public override void UpdateStatus()
        {
            DSRAdjustment_Property objDSRAjdustmentPropertyNew = new DSRAdjustment_Property();
            objDSRAjdustmentPropertyNew.ID = base.Id;
            objDSRAjdustmentPropertyNew.Status = base.Status;
            objDSRAjdustmentPropertyNew.TableName = objDSRAjdustmentProperty.TableName;
            objDSRAjdustmentPropertyNew.Operated_By = objDSRAjdustmentProperty.Operated_By;
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentPropertyNew);
            objDSRAjdustmentDAL.UpdateStatus();
        }

        // New Development
        public DataTable AdjustmentType()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL();
            return objDSRAjdustmentDAL.GetAdjustmentType();
        }
        public DataTable SelectAll_Adjustment()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentProperty);
            return objDSRAjdustmentDAL.SelectAll_Adjustment();
        }

        public DataTable View()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentProperty);
            return objDSRAjdustmentDAL.SelectOne();
        }
        public bool Update()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentProperty);
            return objDSRAjdustmentDAL.Update();
        }


        public DataTable SelectAdjustment_DSID()
        {
            objDSRAjdustmentDAL = new DSRAdjustment_DAL(objDSRAjdustmentProperty);
            return objDSRAjdustmentDAL.SelectAdjustment_DSID();
        }

        
    }
}
