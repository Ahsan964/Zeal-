using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
     public class mrnDetails_Property
    {
        public int idx { get; set; }
        public int mrnIdx { get; set; }
        public int productTypeIdx { get; set; }
        public int itemIdx { get; set; }
        public decimal qty { get; set; }
        public decimal openQty { get; set; }
        public decimal amount { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
    }
}
