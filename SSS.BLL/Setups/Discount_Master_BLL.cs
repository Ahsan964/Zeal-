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
    public class Discount_Master_BLL : GridCommandBase
    {
        private Discount_Master_DAL objDiscountMasterDAL;
        private Discount_Master_Property objDiscountMasterProperty;

        public Discount_Master_BLL(Discount_Master_Property objDiscount_Master_Property)
        {
            objDiscountMasterProperty = objDiscount_Master_Property;
        }


        public bool Add()
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
           return objDiscountMasterDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectAll();
        }

        public DataSet SelectDiscountMasteAndSlabDetailByDiscountID()
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectAllByID();
        }

        public override void UpdateStatus()
        {
            Discount_Master_Property objDiscountMasterPropertyNew = new Discount_Master_Property();
            objDiscountMasterPropertyNew.ID = base.Id;
            objDiscountMasterPropertyNew.Status = base.Status;
            objDiscountMasterPropertyNew.Is_Active = false;
            objDiscountMasterPropertyNew.Active_Status = "0";
            objDiscountMasterPropertyNew.TableName = objDiscountMasterProperty.TableName;
            objDiscountMasterPropertyNew.Operated_By = objDiscountMasterProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterPropertyNew);
            objDiscountMasterDAL.UpdateStatus();
        }

        public bool Update()
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.Update();
        }

        public DataTable SelectCurrent_TradeOffer(int DistributorID)
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectCurrent_TradeOffer(DistributorID);
        }

        public DataTable SelectDistributor_TradeOffer(int DistributorID)
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectDistributor_TradeOffer(DistributorID);
        }

        public DataTable SelectDistributor_PrevTradeOffer(int DistributorID)
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectDistributor_PrevTradeOffer(DistributorID);
        }

        public DataTable SelectPrevious_TradeOffer(int DistributorID)
        {
            objDiscountMasterDAL = new Discount_Master_DAL(objDiscountMasterProperty);
            return objDiscountMasterDAL.SelectPrevious_TradeOffer(DistributorID);
        }
    }
}
