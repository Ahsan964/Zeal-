using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class SalesPerson_Property
    {
        public int idx { get; set; }
        public int branchIdx  { get; set; }
        public int warehouseIdx { get; set; }
        public string SalesPersonName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public bool IsActive { get; set; }

        public List<WareHouse_Property> WareHouseList { get; set; }

        public List<Branch_Property> BranchList { get; set; }
    }
}
