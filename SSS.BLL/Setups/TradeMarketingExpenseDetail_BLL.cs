using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class TradeMarketingExpenseDetail_BLL : GridCommandBase
    {
        private TradeMarketingExpenseDetail_Property objTradeMarketingExpenseDetailProperty;
        private TradeMarketingExpenseDetail_DAL objTradeMarketingExpenseDetailDAL;

        public TradeMarketingExpenseDetail_BLL()
        {
        }

        public TradeMarketingExpenseDetail_BLL(TradeMarketingExpenseDetail_Property objTradeMarketingExpenseDetail_Property)
        {
            objTradeMarketingExpenseDetailProperty = objTradeMarketingExpenseDetail_Property;
        }

        public int ADD()
        {
            objTradeMarketingExpenseDetailDAL = new TradeMarketingExpenseDetail_DAL(objTradeMarketingExpenseDetailProperty);
            return objTradeMarketingExpenseDetailDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objTradeMarketingExpenseDetailDAL = new TradeMarketingExpenseDetail_DAL(objTradeMarketingExpenseDetailProperty);
            return objTradeMarketingExpenseDetailDAL.SelectAll();
        }
        
        public int Update()
        {
            objTradeMarketingExpenseDetailDAL = new TradeMarketingExpenseDetail_DAL(objTradeMarketingExpenseDetailProperty);
            return objTradeMarketingExpenseDetailDAL.Update();
        }

        public DataTable SelectById()
        {
            objTradeMarketingExpenseDetailDAL = new TradeMarketingExpenseDetail_DAL(objTradeMarketingExpenseDetailProperty);
            return objTradeMarketingExpenseDetailDAL.SelectOne();
        }

        public int Delete()
        {
            objTradeMarketingExpenseDetailDAL = new TradeMarketingExpenseDetail_DAL(objTradeMarketingExpenseDetailProperty);
            return objTradeMarketingExpenseDetailDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
