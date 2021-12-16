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
   public class Discount_Location_Detail_BLL:GridCommandBase
    {

       private Discount_Location_Detail_Property objDiscountLocationDetailProperty;
       private Discount_Location_Detail_DAL objDiscountLocationDetailDAL;

        public Discount_Location_Detail_BLL(Discount_Location_Detail_Property Discount_Location_Detail_Property)
        {
            objDiscountLocationDetailProperty = Discount_Location_Detail_Property;

        }
        public DataTable ViewAllByDiscountID()
        {
            objDiscountLocationDetailDAL = new Discount_Location_Detail_DAL(objDiscountLocationDetailProperty);
            return objDiscountLocationDetailDAL.SelectAllWDiscount_ID();
        }

        public bool Insert() 
        {
            objDiscountLocationDetailDAL = new Discount_Location_Detail_DAL(objDiscountLocationDetailProperty);
            return objDiscountLocationDetailDAL.Insert();
        }
        public override void UpdateStatus()
        {
            Discount_Location_Detail_Property objDiscountLocationDetailPropertyNew = new Discount_Location_Detail_Property();
            objDiscountLocationDetailPropertyNew.ID = base.Id;
            objDiscountLocationDetailPropertyNew.Status = base.Status;
            objDiscountLocationDetailPropertyNew.TableName = objDiscountLocationDetailProperty.TableName;
            objDiscountLocationDetailPropertyNew.Operated_By = objDiscountLocationDetailProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objDiscountLocationDetailDAL = new Discount_Location_Detail_DAL(objDiscountLocationDetailPropertyNew);
            objDiscountLocationDetailDAL.UpdateStatus();
        }
    }
}
