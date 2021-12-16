using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Utility
{
   public class DateMasking
    {
        private string _myFormattedDate;


        public string DTNow
        {
            get
            {
                DateTime _myDate = DateTime.Now;
                _myFormattedDate = String.Format("{0:dddd, MM/dd/yyyy hh:mm:ss tt}", _myDate);
                return _myFormattedDate;
            }
            set
            {
                _myFormattedDate = value;
            }
        }



        private DateTime _mySettedDate;

        public DateTime MySettedDate
        {
            get { return _mySettedDate; }
            set
            {
                string _mySDate = String.Format("{0:dddd, MM/dd/yyyy hh:mm:ss tt}", MySettedDate);
                _mySettedDate = value;
            }
        }
    }
}
