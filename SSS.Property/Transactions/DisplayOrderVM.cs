using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class DisplayOrderVM
    {

        public int idx { get; set; }
        public string doNumber { get; set; }
        public int Productioncheck { get; set; }
      
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime orderDate { get; set; }
        public string description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal totalAmount { get; set; }
        public decimal netAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balanceAmount { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
      
        public string status { get; set; }
        public int isPaid { get; set; }       
        public string itemName { get; set; }
        public int itemIdx { get; set; }
        public decimal salePrice { get; set; }
        public decimal qty { get; set; }
        public decimal costPrice { get; set; } //Added By Arsalan
        public decimal stock { get; set; } //Added By Arsalan
        public decimal amount { get; set; }       
        public List<Product_Property> ProductList { get; set; }     
        public List<LP_DisplayOrder_Details_Property> DisplayOrderDetailLST { get; set; }//make a model for quotation Detail
        public string reference { get; set; }
        public string subject { get; set; }
        // Added By Ahsan
        public string ItemDescription { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime DeliveryDate { get; set; }
    }
}
