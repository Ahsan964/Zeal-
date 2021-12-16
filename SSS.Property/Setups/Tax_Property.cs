using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
   public class Tax_Property
    {
        public int ID { get; set; }
        public string TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public int RegID { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveFrom { get; set; }
    }
}
