using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Report
{
    public  class LP_Inv_Report
    {
        public int branchid { get; set; }
        public int productid { get; set; }
        public decimal stock  { get; set; }
        [DataType(DataType.Date)]
        public DateTime fromdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime todate { get; set; }
        public List<Product_Property> ProductList { get; set; }
        public List<Branch_Property> BranchList { get; set; }
    }
}
