using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.Accounts
{
    public class fourthTier_Property
    {
        public int idx { get; set; }
        public int subHeadIdx { get; set; }
        public int headIdx { get; set; }
        public string childHeadName { get; set; }
        public string childHeadCode { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lasModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public List<thirdTier_Property> headLST { get; set; }

    }
}
