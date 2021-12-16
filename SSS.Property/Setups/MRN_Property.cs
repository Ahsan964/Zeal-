using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class MRN_Property
    {
        public int idx { get; set; }
        public string mrNumber { get; set; }
        public string mrnDate { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public string status { get; set; }
    }
}
