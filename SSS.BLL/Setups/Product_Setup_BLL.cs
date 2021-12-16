using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using FluentValidation;

namespace SSS.BLL.Setups
{
    public class Product_Setup_BLL 
    {
        //private Product_Setup_DAL objProductSetupDAL;
        //private Product_Property objProductSetupProperty;


        //public Product_Setup_BLL()
        //{ }


        //public Product_Setup_BLL(Product_Property objProductSetup_Property)
        //{
        //    objProductSetupProperty = objProductSetup_Property;
        //}

        //public bool Add()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //   return objProductSetupDAL.Insert();
        //}

        //public DataTable ViewAll()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.SelectAll();
        //}

        //public DataTable ViewSalesCategory()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.SelectSalesCategory();
        //}

        //public override void UpdateStatus()
        //{
        //    Product_Property objProductSetupPropertyNew = new Product_Property();
        //    objProductSetupPropertyNew.ID = base.Id;
        //    objProductSetupPropertyNew.Status = base.Status;
        //    objProductSetupPropertyNew.TableName = objProductSetupProperty.TableName;
        //    objProductSetupPropertyNew.Operated_By = objProductSetupProperty.Operated_By;

        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupPropertyNew);
        //    objProductSetupDAL.UpdateStatus();

            
        //}

        //public DataTable View()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.SelectOne();
        //}

        //public DataTable ViewProductByProduct_Index()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.ViewProductByProduct_Index();
        //}

        

        //public bool Update()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.Update();
        //}


        //public DataSet ViewParentProduct()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.SelectParentProduct();
        //}


        //public DataTable ViewMaxProductIndex()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.ViewMaxProductIndex();
        //}



        //public DataTable GetCatgProduct()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetAllCategProducts();
        //}


        ///////////////

        //public DataSet ViewProductByProduct_Index_ReturnCashmemo()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.ViewProductByProduct_Index_ReturnCashmemo();
        //}
        //public DataSet ViewProductByProduct_Index_ReturnCashmemoNew()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.ViewProductByProduct_Index_ReturnCashmemoNew();
        //}

        //public DataTable ViewProductAndBatch()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.ViewProductAndBatch();
        //}

        //public Int32 StockAutoEntry(string fileText)
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.StockAutoEntry(fileText);
        //}

        //public Int32 StockAutoEntryWithStChange(string fileText)
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.StockAutoEntryWithStChange(fileText);
        //}
        
        //public DataTable GetCategory()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetAllCategory();
        //}

        //public DataTable GetCategory_WithSalePrice()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetAllCategory_WithSalePrice();
        //}
        //public DataTable GetProductbyCetgoryID()
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetProductsbyCategoryID();
        //}

        //public DataTable GetSTockForText(int DistID,DateTime FromDate, DateTime ToDate)
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetSTockForText(DistID, FromDate, ToDate);
        //}

        //public DataTable GetCustForText(int DistID, DateTime FromDate, DateTime ToDate)
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetCustForText(DistID, FromDate, ToDate);
        //}

        //public DataTable GetInvForText(int DistID,DateTime FromDate,DateTime ToDate)
        //{
        //    objProductSetupDAL = new Product_Setup_DAL(objProductSetupProperty);
        //    return objProductSetupDAL.GetInvForText(DistID, FromDate, ToDate);
        //}
    }
}