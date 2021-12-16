using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.Reports
{
   public class LP_Report_Property
    {
        [Required(ErrorMessage = "Select Reeport")]
        public int ReportID { get; set; }

        
        public string ReportName { get; set; }
        [Required(ErrorMessage = "Select Date")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "Select Date")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

    }
}
