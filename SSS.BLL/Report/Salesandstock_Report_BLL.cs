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
    public  class Salesandstock_Report_BLL
    {

        private Salesandstock_Report_DAL objSalesandstockReportDAL;
         private Salesandstock_Report_Property objSalesandstockReportProperty;


         public Salesandstock_Report_BLL(Salesandstock_Report_Property objSalesandstockReport_Property)
        {
            objSalesandstockReportProperty = objSalesandstockReport_Property;
        }


         public DataSet ViewAll()
        {
            objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
            return objSalesandstockReportDAL.SelectAll();
        }

         public DataSet ViewAllNew()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.SelectAllNew();
         }

         public DataSet GetClosing_BLL()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.GetClosing();
         }

         public DataSet ViewReport_SaleAndStock()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_SaleAndStock();
         }

         public DataSet ViewReport_DisProductivityPlan()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_DisProductivityPlan();
         }

         public DataSet ViewReport_DSRSKUBLL(int chk)
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_DSRSKU(chk);
         }

         public DataSet ViewReport_DSRCategoryBLL(int chk)
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_DSRCategory(chk);
         }

         public DataSet ViewReport_DSRBrandBLL(int chk)
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_DSRBrand(chk);
         }

         public DataSet ViewReport_ZonalProductivityPlan()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_ZonalProductivityPlan();
         }

         public DataSet ViewReport_RegionalProductivityPlan()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_RegionalProductivityPlan();
         }
        
         public DataSet ViewReport_SaleAndStockWithStChange()
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.Report_SaleAndStockWithStChange();
         }        

         public DataTable SelectSaleReport(int DistributorID,int PeriodID ,int ProductID)
         {
             objSalesandstockReportDAL = new Salesandstock_Report_DAL(objSalesandstockReportProperty);
             return objSalesandstockReportDAL.SelectSaleReport(DistributorID , PeriodID , ProductID);
         }

    }
}
