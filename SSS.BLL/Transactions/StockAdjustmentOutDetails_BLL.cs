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
    public class StockAdjustmentOutDetails_BLL : GridCommandBase
    {
        private StockAdjustmentOutDetails_DAL objStockAdjustmentOutDetailsDAL;

        public bool Add(DataTable detailsData)
        {
            objStockAdjustmentOutDetailsDAL = new StockAdjustmentOutDetails_DAL();
            return objStockAdjustmentOutDetailsDAL.Insert(detailsData);
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
