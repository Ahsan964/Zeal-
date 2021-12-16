using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Utility
{
    public class TimestampInfo
    {

        public TimestampInfo(long ts, string desc)
        {
            this.Timestamp = ts;
            this.Description = desc;
        }

        private long _Timestamp;
        public long Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


    }
}
