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
    public class ProductivityandExecution_Report_BLL
    {

        private ProductivityandExecution_Report_DAL objProductivityandExecutionReportDAL;
        private ProductivityandExecution_Report_Property objProductivityandExecutionReportProperty;


        public ProductivityandExecution_Report_BLL(ProductivityandExecution_Report_Property objProductivityandExecution_Property)
        {
            objProductivityandExecutionReportProperty = objProductivityandExecution_Property;
        }



        public DataSet ViewAll(string OrederBookerID,int type = 0)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.SelectAll(OrederBookerID, type);
        }

        public DataSet ViewAllForDailyTran(string OrederBookerID, int type = 0)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.SelectAllForDailyTran(OrederBookerID, type);
        }
        

        public DataTable GetSKUProductivity(string OrderbookerID, string ProductID)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.GetSKUProductivity(OrderbookerID, ProductID);

        }


        public DataSet GetSKUProdCategory(string OrderbookerID, string ProductID)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.GetSKUProdCategory(OrderbookerID, ProductID);

        }
        public DataSet GetSKUProdCategoryNew(string OrderbookerID, string ProductID)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.GetSKUProdCategoryNew(OrderbookerID, ProductID);
        }

        public DataSet GetSKUProdCategoryNewWithSoldSales(string OrderbookerID, string ProductID)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.GetSKUProdCategoryNewWithSoldSales(OrderbookerID, ProductID);
        }

        public DataSet GetSKUProdCategoryPOS(string OrderbookerID, string ProductID)
        {
            objProductivityandExecutionReportDAL = new ProductivityandExecution_Report_DAL(objProductivityandExecutionReportProperty);
            return objProductivityandExecutionReportDAL.GetSKUProdCategoryPOS(OrderbookerID, ProductID);

        }
    }
}
