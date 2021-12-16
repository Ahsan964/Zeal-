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
    public class Distributor_Closing_Day_BLL
    {
        private Distributor_Closing_Day_Property objDisClosingDayProperty;
        private Distributor_Closing_Day_DAL objDisClosingDayDAL;

        public Distributor_Closing_Day_BLL(Distributor_Closing_Day_Property objDisClosingDay_Property)
        {
            objDisClosingDayProperty = objDisClosingDay_Property;
        }

        public DataTable GetCurrentTransactionDate()
        {
            objDisClosingDayDAL = new Distributor_Closing_Day_DAL(objDisClosingDayProperty);
            return objDisClosingDayDAL.GetCurrentTransactionDate();
        }

        public bool ADD()
        {
            objDisClosingDayDAL = new Distributor_Closing_Day_DAL(objDisClosingDayProperty);
            return objDisClosingDayDAL.Insert();
        }

        public DataTable ProcessCloseDay()
        {
            objDisClosingDayDAL = new Distributor_Closing_Day_DAL(objDisClosingDayProperty);
            return objDisClosingDayDAL.ProcessCloseDay();
        }
    }
}
