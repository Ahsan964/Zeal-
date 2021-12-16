using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class TradeMarketingSetup_BLL : GridCommandBase
    {
        private TradeMarketingSetup_Property objTradeMarketingSetupProperty;
        private TradeMarketingSetup_DAL objTradeMarketingSetupDAL;

        public TradeMarketingSetup_BLL()
        {
        }

        public TradeMarketingSetup_BLL(TradeMarketingSetup_Property objTradeMarketingSetup_Property)
        {
            objTradeMarketingSetupProperty = objTradeMarketingSetup_Property;
        }

        public int ADD()
        {
            objTradeMarketingSetupDAL = new TradeMarketingSetup_DAL(objTradeMarketingSetupProperty);
            return objTradeMarketingSetupDAL.Insert();
        }

        public DataTable ViewAll()
        {
            objTradeMarketingSetupDAL = new TradeMarketingSetup_DAL(objTradeMarketingSetupProperty);
            return objTradeMarketingSetupDAL.SelectAll();
        }
        
        public int Update()
        {
            objTradeMarketingSetupDAL = new TradeMarketingSetup_DAL(objTradeMarketingSetupProperty);
            return objTradeMarketingSetupDAL.Update();
        }

        public DataTable SelectById()
        {
            objTradeMarketingSetupDAL = new TradeMarketingSetup_DAL(objTradeMarketingSetupProperty);
            return objTradeMarketingSetupDAL.SelectOne();
        }

        public int Delete()
        {
            objTradeMarketingSetupDAL = new TradeMarketingSetup_DAL(objTradeMarketingSetupProperty);
            return objTradeMarketingSetupDAL.Delete();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
