using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data;
using SSS.DAL.Transactions;
using SSS.DAL.Report;
using SSS.Property.Report;

namespace SSS.BLL.Report
{
     public class ConsolidateSalesSummary_Report_BLL 
    {
         private ConsolidatedSalesSummary_Report_DAL objConsolidatedSalesSummaryReportDAL;
         private ConsolidateSalesSummary_Report_Property objConsolidatedSalesSummaryReportProperty;

         public ConsolidateSalesSummary_Report_BLL(ConsolidateSalesSummary_Report_Property objConsolidatedSalesSummaryReportProperty_Property)
        {
            objConsolidatedSalesSummaryReportProperty = objConsolidatedSalesSummaryReportProperty_Property;
        }

        public DataSet ViewAll(string OrederBookerID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAll(OrederBookerID);
        }

        
            public DataSet ViewAll_CategoryWise(string OrederBookerID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAll_CategoryWise(OrederBookerID);
        }


        public DataSet ViewAllWithStChange(string OrederBookerID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllWithStChange(OrederBookerID);
        }

        public DataSet ViewAllForDailyTran(string OrederBookerID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllForDailyTran(OrederBookerID);
        }
         
        public DataTable ViewAllbyPOS(string PosIDs)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllbyPOS(PosIDs);
        }

        public DataSet ViewShopWiseSaleReport_New(int ShopIds)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.ShopWiseSaleReport(ShopIds);
        }
        public DataTable ViewAllbyPOSForDailyTran(string PosIDs)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllbyPOSForDailyTran(PosIDs);
        }
         
        public DataSet ViewAll()
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAll();
        }

         public DataSet ViewAllbyDM(string DeliveryManID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllbyDM(DeliveryManID);
        }

         public DataSet ViewAllbyDMForDailyTran(string DeliveryManID)
        {
            objConsolidatedSalesSummaryReportDAL = new ConsolidatedSalesSummary_Report_DAL(objConsolidatedSalesSummaryReportProperty);
            return objConsolidatedSalesSummaryReportDAL.SelectAllbyDMForDailyTran(DeliveryManID);
        }      

    }
}
