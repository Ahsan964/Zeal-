using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
   public class LP_Transaction_Type_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _IsActive;
        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

    }
}
