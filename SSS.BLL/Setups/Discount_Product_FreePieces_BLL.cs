using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;

namespace SSS.BLL.Setups
{
    public class Discount_Product_FreePieces_BLL
    {
        private Discount_Product_FreePieces_Property objDiscountProductFreePiecesProperty;
       private Discount_Product_FreePieces_DAL objDiscountProductFreePiecesDAL;


       public Discount_Product_FreePieces_BLL(Discount_Product_FreePieces_Property objDiscount_Product_FreePieces_Property)
        {
            objDiscountProductFreePiecesProperty = objDiscount_Product_FreePieces_Property;

        }
        public bool Insert_Discount()
        {
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            return objDiscountProductFreePiecesDAL.Insert_Discount();
        }

        public bool Insert_FreeSKUDiscount()
        {
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            return objDiscountProductFreePiecesDAL.Insert_FreeSKUDiscount();
        }

        public bool UpdateDistributorWisePriority()
        {
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            return objDiscountProductFreePiecesDAL.UpdateDistributorWisePriority();
        }
        
        public System.Data.DataTable getFreeSKUByDiscountID()
        {
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            return objDiscountProductFreePiecesDAL.getFreeSKUByDiscountID();
        }

        public bool Update_FreeSKUDiscount()
        { 
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            return objDiscountProductFreePiecesDAL.Update_FreeSKUDiscount();
        }

        public void DeleteTOFreePiecebyID()
        {
            objDiscountProductFreePiecesDAL = new Discount_Product_FreePieces_DAL(objDiscountProductFreePiecesProperty);
            objDiscountProductFreePiecesDAL.DeleteTOFreePiecebyID();
        }
    }
}
