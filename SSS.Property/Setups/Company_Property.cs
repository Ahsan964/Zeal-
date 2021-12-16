using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace SSS.Property.Setups
{
    public class Company_Property
    {
        public int idx { get; set; }
        public string companyName { get; set; }
        public string ownerName { get; set; }
        public string STRN { get; set; }
        public string NTN { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string companyLogo { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int isActive { get; set; }
        public int visible { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Financial Year")]
        public string financialYearFrom { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Financial Year")]
        public string financialYearTo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Tax Year")]
        public string taxYearFrom { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Tax Year")]
        public string taxYearTo { get; set; }


    }
}
