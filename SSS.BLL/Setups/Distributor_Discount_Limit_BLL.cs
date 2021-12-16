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
    public class Distributor_Discount_Limit_BLL : GridCommandBase
    {
        private Distributor_Discount_Limit_DAL objDistributorDiscountLimitDAL;
        private Distributor_Discount_Limit_Property objDistributorDiscountLimitProperty;

        public Distributor_Discount_Limit_BLL(Distributor_Discount_Limit_Property objDistributor_Discount_Limit_Property)
        {
            objDistributorDiscountLimitProperty = objDistributor_Discount_Limit_Property;
        }


        public bool Add()
        {
            objDistributorDiscountLimitDAL = new Distributor_Discount_Limit_DAL(objDistributorDiscountLimitProperty);
            return objDistributorDiscountLimitDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objDistributorDiscountLimitDAL = new Distributor_Discount_Limit_DAL(objDistributorDiscountLimitProperty);
            return objDistributorDiscountLimitDAL.SelectAll();
        }


        public override void UpdateStatus()
        {
            Distributor_Discount_Limit_Property objDistributorDiscountLimitPropertyNew = new Distributor_Discount_Limit_Property();
            objDistributorDiscountLimitPropertyNew.ID = base.Id;
            objDistributorDiscountLimitPropertyNew.Status = base.Status;
            objDistributorDiscountLimitPropertyNew.TableName = objDistributorDiscountLimitProperty.TableName;

            objDistributorDiscountLimitDAL = new Distributor_Discount_Limit_DAL(objDistributorDiscountLimitPropertyNew);
            objDistributorDiscountLimitDAL.UpdateStatus();
        }

        public bool Update()
        {
            objDistributorDiscountLimitDAL = new Distributor_Discount_Limit_DAL(objDistributorDiscountLimitProperty);
            return objDistributorDiscountLimitDAL.Update();
        }

        //public DataTable ViewAllByProductId()
        //{
        //    objBatchDAL = new Batch_DAL(objBatchSetupProperty);
        //    return objBatchDAL.SELECT_BY_PRODUCT_ID();
        //}

        //public DataTable ViewPriceByProductId()
        //{
        //    objBatchDAL = new Batch_DAL(objBatchSetupProperty);
        //    return objBatchDAL.SelectPricelistAndExpiry();
        //}
        
        //public bool AddNew()
        //{
        //    objBatchDAL = new Batch_DAL(objBatchSetupProperty);
        //    return objBatchDAL.InsertNew();
        //}
        
      

        
       

        //public DataTable View()
        //{
        //    objBatchDAL = new Batch_DAL(objBatchSetupProperty);
        //    return objBatchDAL.SelectOne();
        //}

    }
}
