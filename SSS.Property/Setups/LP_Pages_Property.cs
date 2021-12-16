using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class LP_Pages_Property
    {
        public int ID { get; set; }
        public string PageName { get; set; }
        public string PagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
