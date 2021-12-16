using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.DAL;
using SSS.DAL.Setups;
using SSS.DAL.Transactions;
using System.Data;
using FluentValidation;

namespace SSS.BLL.Transactions
{
    public class StockAdjustmentOutMasterDetail_BLL : GridCommandBase
    {
        private StockAdjustmentOutMasterDetail_DAL objStockAdjustmentOutMasterDetailDAL;
        private StockAdjustmentOutDetails_DAL objStockAdjustmentOutDetailsDAL;
        private StockAdjustmentOutMaster_Property objStockAdjustmentOutMasterProperty;
        private bool flag;

        public StockAdjustmentOutMasterDetail_BLL(StockAdjustmentOutMaster_Property objStockAdjustmentOutMaster_Property)
        {
            objStockAdjustmentOutMasterProperty = objStockAdjustmentOutMaster_Property;
        }

        public bool StockAdjustmentOutMasterDetailInsert(DataTable detailsDT)
        {
            objStockAdjustmentOutMasterDetailDAL = new StockAdjustmentOutMasterDetail_DAL(objStockAdjustmentOutMasterProperty);

            try
            {
                objStockAdjustmentOutMasterDetailDAL.OpenConnection();
                objStockAdjustmentOutMasterDetailDAL.StartTransaction();
                flag = objStockAdjustmentOutMasterDetailDAL.Insert();

                if (!flag)
                    throw new Exception();

                int id = objStockAdjustmentOutMasterProperty.ID;

                foreach (DataRow row in detailsDT.Rows)
                    row["Transaction_Id"] = id;

                detailsDT.AcceptChanges();

                //objStockAdjustmentOutDetailsDAL = new StockAdjustmentOutDetails_DAL();
                flag = objStockAdjustmentOutMasterDetailDAL.InsertDetails(detailsDT);

                if (!flag)
                    throw new Exception();

                objStockAdjustmentOutMasterDetailDAL.Commit();
                return true;
            }
            catch (Exception)
            {
                objStockAdjustmentOutMasterDetailDAL.RollBack();
                return false;
            }
            finally
            {
                objStockAdjustmentOutMasterDetailDAL.CloseConnection();
            }


        }


        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
