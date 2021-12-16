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
    public class User_Region_BLL : GridCommandBase
    {
        private User_Region_DAL objUserRegionDAL;
        private User_Region_Property objUserRegionProperty;

        public User_Region_BLL(User_Region_Property objUserRegion_Property)
        {
            objUserRegionProperty = objUserRegion_Property;
        }
        
        public int ADD()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.Insert();
        }
        public int RegionadDiscountLogADD()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.RegionadDiscountLogInsert();
        }
        public int DeleteUserRegionByUserIdsBll()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.DeleteUserRegionByUserIds();
        }

        public DataTable GetUserRegionByRegionIdBll()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.GetUserRegionByRegionId();
        }

        public DataTable GetRegionalUserLocationByUserIdBLL()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.GetRegionalUserLocationByUserId();
        }

        public DataTable GetUserRegionsByUserIdBll()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.GetUserRegionsByUserId();
        }

        public DataTable GetRegionalUserDistributorByUserIdBLL()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.GetRegionalUserDistributorByUserId();
        }

        public DataTable SelectCurrentRegional_TradeOfferBLL()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.SelectCurrentRegional_TradeOffer();
        }

        public DataTable SelectPreviousRegional_TradeOfferBLL()
        {
            objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
            return objUserRegionDAL.SelectPreviousRegional_TradeOffer();
        }
        //public DataTable GetDistributorRegionByDistributorIdBll()
        //{
        //    objUserRegionDAL = new User_Region_DAL(objUserRegionProperty);
        //    return objUserRegionDAL.GetDistributorRegionByDistributorId();
        //}

        public override void UpdateStatus()
        {
            User_Region_Property objUserRegionPropertyNew = new User_Region_Property();
            //Discount_Master_Property objDiscountMasterPropertyNew = new Discount_Master_Property();
            objUserRegionPropertyNew.Id = base.Id;
            objUserRegionPropertyNew.Status = base.Status;
            //objUserRegionPropertyNew.Is_Active = false;
            //objUserRegionPropertyNew.Active_Status = "0";
            objUserRegionPropertyNew.TableName = objUserRegionProperty.TableName;
            objUserRegionPropertyNew.Operated_By = objUserRegionProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objUserRegionDAL = new User_Region_DAL(objUserRegionPropertyNew);
            objUserRegionDAL.UpdateStatus();
        }
    }
}
