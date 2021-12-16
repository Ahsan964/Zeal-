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
    public class StockAdjustmentOutMaster_BLL : GridCommandBase
    {
        private StockAdjustmentOutMaster_DAL objStockAdjustmentOutMasterDAL;
        private StockAdjustmentOutMaster_Property objStockAdjustmentOutMasterProperty;

        public StockAdjustmentOutMaster_BLL()
        {
        }

        public StockAdjustmentOutMaster_BLL(StockAdjustmentOutMaster_Property objStockAdjustmentOutMaster_Property)
        {
            objStockAdjustmentOutMasterProperty = objStockAdjustmentOutMaster_Property;
        }

        public bool Add()
        {
            objStockAdjustmentOutMasterDAL = new StockAdjustmentOutMaster_DAL(objStockAdjustmentOutMasterProperty);
            return objStockAdjustmentOutMasterDAL.Insert();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
