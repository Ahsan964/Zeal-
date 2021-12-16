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
    public class Batch_Setup_BLL : GridCommandBase
    {
        private Batch_DAL objBatchDAL;
        private Batch_Setup_Property objBatchSetupProperty;

        public Batch_Setup_BLL(Batch_Setup_Property objBatch_Setup_Property)
        {
            objBatchSetupProperty = objBatch_Setup_Property;
        }

        public DataTable ViewAllByProductId()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.SELECT_BY_PRODUCT_ID();
        }

        public DataTable ViewPriceByProductId()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.SelectPricelistAndExpiry();
        }


        public bool Add()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.Insert();
        }

        public bool AddNew()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.InsertNew();
        }



        public bool Update()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.Update() ;
        }




        public DataTable ViewAll()
        {
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.SelectAll();
        }


        public override void UpdateStatus()
        {
            Batch_Setup_Property objBatchSetupPropertyNew = new Batch_Setup_Property();
            objBatchSetupPropertyNew.ID = base.Id;
            objBatchSetupPropertyNew.Status = base.Status;
            objBatchSetupPropertyNew.TableName = objBatchSetupProperty.TableName;

            objBatchDAL = new Batch_DAL(objBatchSetupPropertyNew);
            objBatchDAL.UpdateStatus();


        }


        public DataTable View()
        {
            
            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.SelectOne();
        }


        public DataTable SelectTopBatch()
        {

            objBatchDAL = new Batch_DAL(objBatchSetupProperty);
            return objBatchDAL.SelectTopBatch();
        }


    }
}
