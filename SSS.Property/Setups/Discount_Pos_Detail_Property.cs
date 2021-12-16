using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
   public class Discount_Pos_Detail_Property
    {
        public int? ID { get; set; }
        public int? DiscountId { get; set; }
        public int? POS_ID { get; set; }
        public int? POS_TypeID { get; set; }
        public int? Type { get; set; }
        public string Status { get; set; }

    }
}
