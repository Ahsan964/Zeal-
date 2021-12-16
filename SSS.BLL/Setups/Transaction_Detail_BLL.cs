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
    public class Transaction_Detail_BLL : GridCommandBase
    {
        private Transaction_Detail_DAL objTransactionDetailDAL;
        private Transaction_Detail_Property objTransactionDetailProperty;

        public Transaction_Detail_BLL()
        {}

        public Transaction_Detail_BLL(Transaction_Detail_Property objTransaction_Detail_Property)
        {
            objTransactionDetailProperty = objTransaction_Detail_Property;
        }
        public DataTable ViewAll()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.SelectAll();
        }

        public DataTable Stock_Doc_PrintView()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Stock_Doc_PrintView();
        }
        public DataTable Stock_Doc_PrintViewWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Stock_Doc_PrintViewWithStChange();
        }
        
        public DataTable ViewAllProductDetails()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.SelectAll_ProductDetail();
        }
        public override void UpdateStatus()
        {
            Transaction_Detail_Property objTransactionDetailPropertyNew = new Transaction_Detail_Property();
            objTransactionDetailPropertyNew.ID = objTransactionDetailProperty.ID;
            objTransactionDetailPropertyNew.Status = objTransactionDetailProperty.Status;
            objTransactionDetailPropertyNew.TableName = objTransactionDetailProperty.TableName;
            objTransactionDetailPropertyNew.Operated_By = objTransactionDetailProperty.Operated_By;

            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailPropertyNew);
            objTransactionDetailDAL.UpdateStatus();
        }
        public bool UpdateCashMemo()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.UpdateCashMemo();
        }
        public bool UpdateSaleReturn()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.UpdateSalesReturn();
        }

        public DataSet GetTransactionMasterAndDetailByTransactionID()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.GetTransactionMasterAndDetailByTransactionID();
        }
        public DataSet GetTransactionMasterAndDetailByTransactionIDForDailyTran()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.GetTransactionMasterAndDetailByTransactionIDForDailyTran();
        }
        
        public DataTable SelectStockInHand()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.SelectInHandStock();
        }

        public DataTable SelectAllByDetailId()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.selectAllByDetailId();
        }

        public DataTable SelectAllStockDetailByDetailIdWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.selectAllStockDetailByDetailIdWithStChange();
        }

        public bool Insert()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Insert();
        }
        public bool Update_STI()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Update_STI();
        }

        public bool Update_STIWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Update_STIWithStChange();
        }

        public bool UpdateStock()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Update();
        }

        public bool UpdateStockDetailWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.UpdateStockDetailWithStChange();
        }
        
        public bool Stock_edit_Insert()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Transaction_stockedit_Insert();
        }

        public bool DeleteSti()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.DeleteSti();
        }

        public bool DeleteStiWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.DeleteStiWithStChange();
        }
        
        public bool DeleteAllSockInDetail()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.DeleteAllSockInDetail();
        }

        public bool DeleteAllSockInDetailWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.DeleteAllSockInDetailWithStChange();
        }

        public bool InsertSpecialTranDetail(string DiscountTypeTitle)
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.InsertSpecialTranDetail(DiscountTypeTitle);
        }


        

        public DataSet ViewAll_ReturnProduct()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.SelectAll_ReturnProduct();
        }
        public DataSet ViewAll_ReturnProductForDailyTran()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.SelectAll_ReturnProductForDailyTran();
        }
        
        public int InsertDetailForNPT(string Product_Code)
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.InsertDetailForNPT(Product_Code);
        }

        public bool UpdateCashMemo_ReturnProduct()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.UpdateCashMemo_ReturnProduct();
        }

        //Consolidated Stock Receipt Report
        public DataSet Consolidated_StockReceiptReport()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Consolidated_StockReceiptReport();
        }

        public DataSet Consolidated_StockReceiptReportWithStChange()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Consolidated_StockReceiptReportWithStChange();
        }

        //Get TAX and Price of Particular Product
        public DataTable Get_TaxofProduct()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Get_TaxofProduct();
        }

        public DataTable Get_TaxProduct_Price()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Get_TaxProduct_Price();
        }
        public DataTable Get_TaxProduct_PriceForWRCM()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Get_TaxProduct_PriceForWRCM();
        }
        public DataTable Get_TaxProduct_PriceForWRCMForWRCMFromTranId()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.Get_TaxProduct_PriceForWRCMFromTranId();
        }
        
        public string UpdateSkuXML()
        {
            objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionDetailDAL.UpdateSKUXML();
        }




    }
}
