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
    public class DistributorWise_BlockedDiscountHistory_BLL : GridCommandBase
    {
        private DistributorWise_HistoryBlockedDiscount_DAL objDistributorWiseHistoryBlockedDiscountDAL;
        private DistributorWise_BlockedDiscountHistory_Property objDistributorWiseBlockedDiscountHistoryProperty;


        public DistributorWise_BlockedDiscountHistory_BLL(DistributorWise_BlockedDiscountHistory_Property objDistributorWise_BlockedDiscountHistory_Property)
        {
            objDistributorWiseBlockedDiscountHistoryProperty = objDistributorWise_BlockedDiscountHistory_Property;
        }

        public bool Add()
        {
            objDistributorWiseHistoryBlockedDiscountDAL = new DistributorWise_HistoryBlockedDiscount_DAL(objDistributorWiseBlockedDiscountHistoryProperty);
            return objDistributorWiseHistoryBlockedDiscountDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objDistributorWiseHistoryBlockedDiscountDAL = new DistributorWise_HistoryBlockedDiscount_DAL(objDistributorWiseBlockedDiscountHistoryProperty);
            return objDistributorWiseHistoryBlockedDiscountDAL.SelectAll();
        }

        public override void UpdateStatus()
        {
            DistributorWise_BlockedDiscountHistory_Property objBlockedDiscountHistoryPropertyNew = new DistributorWise_BlockedDiscountHistory_Property();
            objBlockedDiscountHistoryPropertyNew.ID = base.Id;
            objBlockedDiscountHistoryPropertyNew.Status = base.Status;
         // objBlockedDiscountHistoryPropertyNew.Is_Active = false;
            //objBlockedDiscountHistoryPropertyNew.Active_Status = "0";
            objBlockedDiscountHistoryPropertyNew.TableName = objDistributorWiseBlockedDiscountHistoryProperty.TableName;
            objBlockedDiscountHistoryPropertyNew.Operated_By = objDistributorWiseBlockedDiscountHistoryProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objDistributorWiseHistoryBlockedDiscountDAL = new DistributorWise_HistoryBlockedDiscount_DAL(objBlockedDiscountHistoryPropertyNew);
            //objDistributorWiseHistoryBlockedDiscountDAL.UpdateStatus();
        }
    }
}
