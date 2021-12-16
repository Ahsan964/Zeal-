using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class currency_Property
    {
        public string nameCode { get; set; }//Added By Arsalan 20-01-21
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _code;
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        
    }
}
