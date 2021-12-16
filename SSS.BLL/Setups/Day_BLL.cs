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
    public class Day_BLL : GridCommandBase
    {
        private Day_DAL objDayDAL;
        private Day_Property objDayProperty;

        public Day_BLL()
        {
        }

        public Day_BLL(Day_Property objDay_Property)
        {
            objDayProperty = objDay_Property;
        }

        public DataTable ViewAll()
        {
            objDayDAL = new Day_DAL(objDayProperty);
            return objDayDAL.SelectAll();
        }

        public DataTable View()
        {
            objDayDAL = new Day_DAL(objDayProperty);
            return objDayDAL.SelectOne();
        }

        public bool ADD()
        {
            objDayDAL = new Day_DAL(objDayProperty);
            return objDayDAL.Insert();
        }

        public bool Update()
        {
            objDayDAL = new Day_DAL(objDayProperty);
            return objDayDAL.Update();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
