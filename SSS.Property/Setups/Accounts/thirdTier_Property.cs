using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.Accounts
{
    public class thirdTier_Property
    {
        public int idx { get; set; }
        public int headIdx { get; set; }
        public string subHeadName { get; set; }
        public string subHeadCode { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lasModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public List<firstTier_Property>  headLST{ get; set; }
    }
}
