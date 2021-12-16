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
    public class Transaction_Master_BAL : GridCommandBase
    {
        private Transaction_Master_DAL objTransactionMasterDAL;
        private Transaction_Master_Property objTransactionMasterProperty;

        public Transaction_Master_BAL(Transaction_Master_Property objTransaction_Master_Property)
        {
            objTransactionMasterProperty = objTransaction_Master_Property;
        }

        public Transaction_Master_BAL()
        { }

        public DataTable ViewAllStockReport()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetStockReport();
        }

        // -------------------------------------------------------- Added by ASAD RAHIM KHAN ------------------------- Provided by M HARIS
        public bool SalesSummaryDelReEnterNationWise()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SalesSummaryDelReEnterNationWiseDAL();
        }
        // -------------------------------------------------------- Added by ASAD RAHIM KHAN ------------------------- Provided by M HARIS


        public DataTable ViewAllStocDocuments()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllStockDocuments();
        }

        public DataTable ViewAllStocDocumentsWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllStockDocumentsWithStChange();
        }

        public bool UpdateStatusTransactionStock()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateStatusOFStockDocuments();

        }

        public bool UpdateStatusTransactionStockWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateStatusOFStockDocumentsWithStChange();

        }

        public DataTable SelectAllDeliveryDate()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllDeliveryDate();
        }
        public DataTable SelectAllDeliveryDateForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllDeliveryDateForDailyTran();
        }
        
        public DataTable SelectAllOrderDate()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllOrderDate();
        }


        public DataTable ViewAll()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll();
        }

        public DataTable ViewAllWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllWithStChange();
        }
        
        public DataTable ViewAllForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllForDailyTran();
        }

        public DataTable ViewAllForDailyTran2()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllForDailyTran2();
        }
        

        public DataTable ViewAllCashmemoWithoutSTR()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CashmemoWithout_STR();
        }

        public DataTable ViewAllCashmemoWithoutSTRNewWithFlag()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CashmemoWithout_STR_NewWithFlag();
        }

        public DataTable ViewAllDeliverymanForSTR()//Select all deliveryman for Sale Return-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanFor_STR();
        }

        public DataTable ViewAllDeliverymanRouteForSTR()//Select all deliveryman's Route for Sale Return-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanRouteFor_STR();
        }
        

        //SelectAll_CashmemoWith_STRDesc
        public DataTable SelectAll_CashmemoWith_STRDesc()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CashmemoWith_STRDesc();
        }

        public DataTable SelectAll_CashmemoWith_STRDescWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CashmemoWith_STRDescWithStChange();
        }

        public DataTable SelectAll_CashmemoWith_STRDescForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CashmemoWith_STRDescForDailyTran();
        }
        
        public DataSet SelectCM_ForTypeByStrId_ForBLL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectCM_ForTypeByStrId();
        }

        public DataTable ViewAllDeliverymanForSTRViewListing()//Select all deliveryman for Sale Return View Listing Filter-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanFor_STRViewListing();
        }

        public DataTable ViewAllDeliverymanForSTRViewListingWithStChange()//Select all deliveryman for Sale Return View Listing Filter-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanFor_STRViewListingWithStChange();
        }

        public DataTable ViewAllDeliverymanForSTRViewListingForDailyTran()//Select all deliveryman for Sale Return View Listing Filter-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanFor_STRViewListingForDailyTran();
        }
        
        public DataTable ViewAllDeliverymanRouteForSTRViewListing()//Select all deliveryman's Route for Sale Return View Listing Filter-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanRouteFor_STRViewListing();
        }
        public DataTable ViewAllDeliverymanRouteForSTRViewListingForDailyTran()//Select all deliveryman's Route for Sale Return View Listing Filter-- M. Haris 17/04/2014
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanRouteFor_STRViewListingForDailyTran();
        }
        
        public DataTable NewFilter_SaleRetunView()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.NewFilter_SaleRetunView();
        }

       

        public DataTable ViewAllDeliverymanFromCashmemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_DeliverymanFromCashmemo();
        }
        //GetAllOrderBooker


        public DataTable GetAllOrderBooker()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllOrderBooker();
        }

        public DataTable GetAllOrderBookerWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllOrderBookerWithStChange();
        }
        
        public DataTable GetAllOrderBookerForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllOrderBookerForDailyTran();
        }
        

        public DataTable GetAllOrderBooker_SPOT()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllOrderBooker_SPOT();
        }

        public DataTable GetSalesRep()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesRep();
        }

        public DataTable GetSalesRep_WRCM()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesRep_WRCM();
        }

        public DataTable GetSalesRep_WRCMWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesRep_WRCMWithStChange();
        }

        public DataTable GetSalesRep_WRCMForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesRep_WRCMForDailyTran();
        }
        //sp_GetDeliveryMan
        public DataTable GetSalesRep_SPOT()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesRep_SPOT();
        }
        public DataTable GetAllDeliveryMan()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAllDeliveryMan();
        }
        public DataTable ViewAllEnterSalesReturn()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Select_EnterSalesReturn();
        }

        public bool DeleteSalesReturnForUpdate()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DeleteSalesReturnForUpdate();
        }

        public bool Add()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Insert();
        }

        public bool AddSalesReturn(bool IsSTRUpdate)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertSalesReturn(IsSTRUpdate);
        }

        public DataTable GetCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemo();
        }

        public DataSet GetAddSaleReturnDetail()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAddSaleReturnDetail();
        }

        public DataTable GetSalesReturnForEdit()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesReturnForEdit();
        }

        public DataTable GetCashMemoIdAgainstStockReturnId()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoIdAgainstStockReturnId();
        }
        public DataTable GetCashMemoIdAgainstStockReturnIdForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoIdAgainstStockReturnIdForDailyTran();
        }
        
        public override void UpdateStatus()
        {

            Transaction_Master_Property objTransactionMasterPropertyNew = new Transaction_Master_Property();
            objTransactionMasterPropertyNew.ID = base.Id;
            objTransactionMasterPropertyNew.Status = base.Status;
            objTransactionMasterPropertyNew.TableName = objTransactionMasterProperty.TableName;
            objTransactionMasterPropertyNew.Operated_By = objTransactionMasterProperty.Operated_By;

            //if (objTransactionMasterPropertyNew.Status != null)
            //{
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterPropertyNew);
            objTransactionMasterDAL.UpdateStatus();
            //}
        }

        public bool Update()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.Update();
        }
        public bool UpdateForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateForDailyTran();
        }

        public bool UpdateForDailyTranNew()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateForDailyTranNew();
        }

        public bool StockMasterUpdate()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateStockMaster();
        }

        public bool StockMasterUpdateWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateStockMasterWithStChange();
        }
        
        public bool StockMasterUpdate_SPOT()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateStockMaster_SPOT();
        }
        public DataSet AdjustTransactionalStock_SPOT()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.AdjustTransactionalStock_SPOT();
        }
        public DataSet GetTransactionMasterAndDetailByTransactionID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByTransactionID();
        }
        public DataSet GetTransactionMasterAndDetailByTransactionIDForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByTransactionIDForDailyTran();
        }

        public DataSet GetTransactionMasterAndDetailByTransactionIDForPrint()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByTransactionIDForPrint();
        }

        public DataSet GetTransactionMasterAndDetailByTransactionIDForPrintWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByTransactionIDForPrintWithStChange();
        }

        public DataSet GetTransactionMasterAndDetailByTransactionIDForPrintForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByTransactionIDForPrintForDailyTran();
        }
        

        public DataSet GetTransactionMasterAndDetailByGINID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterAndDetailByGINID();
        }

        public DataSet ProcessCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ProcessCashMemo();

        }

        public DataSet ProcessMultiCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ProcessMultiCashMemo();

        }

        public DataSet UnProcessCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ProcessCashMemo();

        }

        public DataSet ProcessStockReturn()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ProcessStockReturn();
        }
        public DataSet GetProcessGINSS()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetProcessGINSS();
        }
        public DataSet GetStockINandOUT_SpotSeller()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetStockINandOUT_SpotSeller();
        }
        public DataSet GetCashMemoByTransactionMaster()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoByTransactionMaster();

        }

        public DataSet GetCashMemoByTransactionMasterForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoByTransactionMasterForDailyTran();

        }

        
        public DataSet GetCashMemoByTransactionMasterReturn()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoByTransactionMasterReturn();

        }
        //PrintbulkCashMemo
        public DataSet PrintBulkCashMemo(string STRExists)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.PrintbulkCashMemo(STRExists);

        }
        public DataSet PrintBulkCashMemoForDailyTran(string STRExists)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.PrintbulkCashMemoForDailyTran(STRExists);

        }
        
        public DataTable SelectstockDocumentByDistributorID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.selectSTODocumentByDistributorID();
        }

        public DataTable SelectstockDocumentByDistributorIDWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.selectSTODocumentByDistributorIDWithStChange();
        }        

        public DataSet SelectAllByStockDocID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.selectStockDocById();
        }

        public DataSet SelectAllByStockDocIDWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.selectStockDocByIdWithStChange();
        }        

        public bool InsertStock()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertStock();
        }

        public bool InsertStockNewStockTables()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertStockNewStockTables();
        }

       public bool TransfrINDoc()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.TransfrINDoc();
        }

       public bool TransfrINDocWithStChange()
       {
           objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
           return objTransactionMasterDAL.TransfrINDocForStChange();
       }

        public bool Insert_GINSS()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Insert_GINSS();
        }
        public DataTable SelectAll_WithDecription()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_WithDecription();
        }

        public DataTable SelectAll_WithDecriptionWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_WithDecriptionWithStChange();
        }

        public DataTable SelectAll_WithDecriptionForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_WithDecriptionForDailyTran();
        }
        
        public DataSet  SelectAll_WithDecription_SPOT()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_WithDecription_SPOT();
        }

        public DataTable SelectAll_WithCashmemoReturn()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_WithCashmemoReturn();
        }
      //  SelectAllCashmemoDeliveryMan_WithDecription

        public DataTable SelectAllOrderBookerForChangeDeliveryMan_BLL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllOrderBookerForChangeDeliveryMan();
        }
        public DataTable SelectAllOrderBookerForChangeDeliveryMan_BLLForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllOrderBookerForChangeDeliveryManForDailyTran();
        }
        
        public DataTable SelectAllCashmemoDeliveryMan_WithDecription()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllCashmemoDeliveryMan_WithDecription();
        }
        public DataTable SelectAllCashmemoDeliveryMan_WithDecriptionForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllCashmemoDeliveryMan_WithDecriptionForDailyTran();
        }
        
        /****** Adeel Riaz *****/

        //For Get Delivery Man Name and Code
        public DataTable GetDeliveryMan()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllDeliveryMan();
        }
        //For Get Delivery Man Routes
        public DataTable GetDeliveryManRoutes()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllDeliveryManRoutes();
        }

        //For GIN or GRN Consolidate Report
        public DataSet GetTransactionMasterGINorGRNConsolidateReport()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterGINorGRN_ConsolidateReport();
        }
        public DataSet GetTransactionMasterGINorGRNConsolidateReportForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterGINorGRN_ConsolidateReportForDailyTran();
        }

        public DataSet GetTransactionMasterGINorGRNConsolidateReportForDailyTran2()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterGINorGRN_ConsolidateReportForDailyTran2();
        }
        
        //For Get All Delivery Man Names Filter By Date using in DSR Form 
        public DataTable GetDSRDeliveryMan()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDSR_DeliveryMan();
        }
        public DataTable GetDSRDeliveryManForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDSR_DeliveryManForDailyTran();
        }
        public DataTable GetDSRDeliveryManForDailyTran2()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDSR_DeliveryManForDailyTran2();
        }

        //Get GIN Report for DSR
        public DataSet GetTransactionMaster_DSRReport()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport();
        }

        public DataSet GetSalesSummaryNationWise_Report()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSalesSummaryNationWiseReport();
        }

        //Get GIN Report for DSR
        public DataSet GetTransactionMaster_DSRReport_NewReport()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport_NewReport();
        }

        //----------------------------------
        public DataSet GetTransactionMaster_DSRReport_ClaimableFreeSKUs()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport_ClaimableFreeSKUS();
        }
        //----------------------------------

        //----------------------------------
        public DataSet Get_ProposeJourneyPlanWithPOSTotal()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Get_ProposeJourneyPlanWithPOSTotal();
        }
        //----------------------------------

        public DataSet GetTransactionMaster_DSRReportWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReportWithStChange();
        }
        
        public DataSet GetTransactionMaster_DSRReportForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReportForDailyTran();
        }
        
        public DataSet GetTransactionMaster_DSRReport2()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport2();
        }
        public DataSet GetTransactionMaster_DSRReport2ForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport2ForDailyTran();
        }
        
        public DataSet GetTransactionMaster_DSRReport_PRoduct()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMaster_DSRReport_PRoduct();
        }
        public DataSet GetTransactionMaster_DSRReport_EachPersonal()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDSRReport_EachPersonnel();
        }
        //Update GIN or GRN Processed
        public bool UpdateGIN_OR_GRN_Processed()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateGINorGRNProcessed();
        }
        public bool UpdateGIN_OR_GRN_ProcessedForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateGINorGRNProcessedForDailyTran();
        }
        
        //Update GIN or GRN Processed
        public bool UpdateGIN_OR_GRN_Processed_ByRange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateGINorGRNProcessed_ByRange();
        }

        public bool UpdateGIN_OR_GRN_Processed_ByRangeFull()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateGINorGRNProcessed_ByRangeFull();
        }
        
        //UpdateChangeDeliveryMan

        public bool UpdateChangeDeliveryMan()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateChangeDeliveryMan();
        }
        public bool UpdateChangeDeliveryManForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateChangeDeliveryManForDailyTran();
        }
        
        //UpdateChangeDeliveryDate

        public bool UpdateChangeDeliveryDate()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateChangeDeliveryDate();
        }

        /**********/

        public DataSet GetStockByMasterId() 
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDetaiStock();
        }

        public DataSet GetStockByMasterIdWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterDetaiStockWithStChange();
        }

        public bool UpdateStiDateToNull()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            //objTransactionDetailDAL = new Transaction_Detail_DAL(objTransactionDetailProperty);
            return objTransactionMasterDAL.UpdateStiDateToNull();
        }


        public DataSet GetFinalGRN()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetFinalGRN();
        
        }
        public DataSet GetFinalGRNForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetFinalGRNForDailyTran();
        
        }
        
        public DataTable STR_MasterWithDesc()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.STR_MasterWithDesc();
         
        }
        public DataTable STR_MasterWithDescForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.STR_MasterWithDescForDailyTran();
         
        }
        
        //********Filter**********

        public DataTable Common_Filter()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.CommonFilter();
        }
        public DataTable Common_FilterForLockedSale()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.CommonFilterForLockedSale();
        }

        public DataTable Common_FilterForLockedSaleWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.CommonFilterForLockedSaleWithStChange();
        }

        public DataSet GetDeliveryManwithDay()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDeliveryManwithDay();

        }
        public DataSet GetSales_Transaction()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetSales_Transaction();

        }

        public bool AddConsolidate_GINORGRN()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Insert_ConsolidateGIN_OR_GRN();
        }
        public DataTable ViewAll_GINorGRN()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_Cosolidated_GINORGRN();
        }
        public DataTable ViewAll_GINorGRNWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_Cosolidated_GINORGRNWithStChange();
        }
        public DataTable ViewAll_GINorGRNForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_Cosolidated_GINORGRNForDailyTran();
        }
        
        //Get All GIN or GRN id's from CONSOLIDATED_GINORGRN table by Code
        public DataTable GetAllGINorGRNID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAll_GINorGRN_ID();
        }
        public DataTable GetAllGINorGRNIDForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetAll_GINorGRN_IDForDailyTran();
        }


        public bool DeleteAll_GINorGRNID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DeleteAll_GINorGRN_ID();
        }
        public bool DeleteAll_GINorGRNIDForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DeleteAll_GINorGRN_IDForDailyTran();
        }

        
        //Check GIN or GRNF is processed or not
        public bool Check_GINorGRNFProcessed()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Check_GINorGRNF_Processed();
        }
        public bool Check_GINorGRNFProcessedForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Check_GINorGRNF_ProcessedForDailyTran();
        }
        
        public bool ProcessedSpecialCashMemoWithoutTradeOffer()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ProcessedSpecialCashMemoWithoutTradeOffer();
        }

        public bool InsertSpecialCashmemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SpecialCashmemo();
        }

       


        public bool CalculateTaxonSpecialCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.CalculateTaxonSpecialCashMemo();
        
        }


        public int SpecialCMCheckIfNegativeBAL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SpecialCMCheckIfNegativeDAL();
        }

        public int SpecialCMCheckIfGINCreatedorNotBAL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SpecialCMCheckIfGINCreatedorNotDAL();
        }

        //new Methods
        public DataTable ViewAll_Unprocessed_GINorGRN()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_Unprocessed_GINORGRN();
        }
        public DataTable ViewAll_Unprocessed_GINorGRNForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_Unprocessed_GINORGRNForDailyTran();
        }
        
        public int InsertNPTDetail(string Personnel_Code, string Personnel_Ref_Code, string Route_Code, string Location_Code, string prp_Code, string POS_Code)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertNPTDetail(Personnel_Code, Personnel_Ref_Code, Route_Code, Location_Code, prp_Code, POS_Code);
        }


       
        public bool AddRetnWithoutCM()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertReturnWithoutCM();
        }
        //GetTranMasterInfo

        public DataTable GetTranMasterInfo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTranMasterInfo();
        }
        public DataTable GetTranMasterInfoForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTranMasterInfoForDailyTran();
        }
        

        public DataSet ConsolidatedStock_Filter()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ConsolidateStockFilter();
        }
        public DataSet ConsolidatedStock_FilterWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.ConsolidateStockFilterWithStChange();
        }
        

        public DataTable GetDiscountSlabByID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDiscountSlabByID();
        }

        public DataTable GetDiscountSlabByIDForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDiscountSlabByIDForDailyTran();
        }
        

        public DataTable GetDiscountSlabByIDforGRN()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDiscountSlabByIDforGRN();
        }
        public DataTable GetDiscountSlabByIDforGRNForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetDiscountSlabByIDforGRNForDailyTran();
        }
        
        public DataTable GetCashMemoTypebyID()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetCashMemoType();
        }

        public DataTable ViewGINProcess()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAllGINProcess();
        }

        public Int32 GetGINIdByCMId()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetGINIdByCMId();
        }

        public int GetTransactionMasterRefDocumentIdById()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterRefDocumentIdById_DAL();
        }
        public int GetTransactionMasterRefDocumentIdByIdForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetTransactionMasterRefDocumentIdById_DALForDailyTran();
        }
        
        public bool UnProcessedCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UnProcessedCashMemo();
        }

        public bool UnProcessedCashMemoBulk(string CMIDs)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UnProcessedCashMemoBulk(CMIDs);
        }

        //---------------------------------------
        public DataSet GetActualGRNTransactionMaster()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetActualGRNTransactionMaster();
        }
        public DataSet GetActualGRNTransactionMasterForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.GetActualGRNTransactionMasterForDailyTran();
        }

        
        public DataTable SelectAll_CMWithDecription()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CMWithDecription();
        }

        public DataTable SelectAll_CMWithDecriptionWithStChange()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CMWithDecriptionWithStChange();
        }

        public DataTable SelectAll_CMWithDecriptionForDailyTran()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.SelectAll_CMWithDecriptionForDailyTran();
        }
        
        public DataSet Configuration_CallParameters(int type)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.Configuration_CallParameters(type);
        }
        public DataTable CashmemoFilterBottomtoTop(string code)
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.CashmemoFilterBottomtoTop(code);
        }

        public int AddBulkCashMemo()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.InsertBulkCashMemo();
        }


        public bool Update_TblTransactionalStock_Allocated()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.UpdateTblTransactionalStockAllocated();
        }


        public bool DistributorStockAllocatedDifferenceCorrectionBAL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DistributorStockAllocatedDifferenceCorrectionDAL();
        }

        public bool DistributorWiseStockAdjustmentOutBAL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DistributorWiseStockAdjustmentOutDAL();
        }

        public bool DistributorDayCloseRollBackBAL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DistributorDayCloseRollBackDAL();
        }

        public bool IsRef_DocumentExists()  
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.IsRef_DocumentExists();
        }


        public DataSet DeleteSaleReturnBLL()
        {
            objTransactionMasterDAL = new Transaction_Master_DAL(objTransactionMasterProperty);
            return objTransactionMasterDAL.DeleteSaleReturnDAL();
        }
    }
}
