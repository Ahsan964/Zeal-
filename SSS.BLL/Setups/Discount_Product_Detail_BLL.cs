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
   public  class Discount_Product_Detail_BLL:GridCommandBase
    {
       private Discount_Product_Detail_Property objDiscountProductDetailProperty;
       private Discount_Product_Detail_DAL objDiscountProductDetailDAL;


       public Discount_Product_Detail_BLL(Discount_Product_Detail_Property objDiscount_Product_Detail_Property)
        {
            objDiscountProductDetailProperty = objDiscount_Product_Detail_Property;

        }

       public DataTable ViewAllByDiscountID()
       {
           objDiscountProductDetailDAL = new Discount_Product_Detail_DAL(objDiscountProductDetailProperty);
           return objDiscountProductDetailDAL.SelectAllWDiscount_ID();
       }

       public bool Insert()
       {
           objDiscountProductDetailDAL = new Discount_Product_Detail_DAL(objDiscountProductDetailProperty);
           return objDiscountProductDetailDAL.Insert();
       }

       //Insert_Discount

    
       public override void UpdateStatus()
       {
           Discount_Product_Detail_Property objDiscount_Product_Detail_PropertyNew = new Discount_Product_Detail_Property();
           objDiscount_Product_Detail_PropertyNew.ID = base.Id;
           objDiscount_Product_Detail_PropertyNew.Status = base.Status;
           objDiscount_Product_Detail_PropertyNew.TableName = objDiscountProductDetailProperty.TableName;
           objDiscount_Product_Detail_PropertyNew.Operated_By = objDiscountProductDetailProperty.Operated_By;

           //if (objTransactionMasterPropertyNew.Status != null)
           //{
           objDiscountProductDetailDAL = new Discount_Product_Detail_DAL(objDiscount_Product_Detail_PropertyNew);
           objDiscountProductDetailDAL.UpdateStatus();
       }


       public void DeleteTOProdbyID()
       {
           objDiscountProductDetailDAL = new Discount_Product_Detail_DAL(objDiscountProductDetailProperty);
           objDiscountProductDetailDAL.DeleteTOProdbyID();
       }
    }
}
