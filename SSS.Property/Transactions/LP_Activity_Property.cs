using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_Activity_Property
    {   [Required]
        public int typeIdx { get; set; }
        public int glIdx { get; set; } // Master Id 
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime DeliveryDate { get; set; }
        public string itemName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
      //  public int productionCheck { get; set; }

        public int idx { get; set; }
        public int orderIdx { get; set; }//salesOrderIdx or DisplayOrder
        public int productTypeIdx { get; set; }
        public int vendorCatIdx { get; set; }
        public int vendorIdx { get; set; }
        public int productIdx { get; set; }
        public decimal qty { get; set; }
        public string size { get; set; }
        public string activityDate { get; set; }
        public decimal exchangeRate { get; set; }
        public decimal activityPrice { get; set; }
        public decimal totalAmount { get; set; }
        public decimal subAmount { get; set; }
        public string description { get; set; }
        public string creationDate { get; set; }
        public int createdBy { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int status { get; set; }
        public List<Vendors_Property> vendorLST { get; set; }
        public List<Product_Property> productLST { get; set; }
        public List<Product_Type_Property> productTypeLST { get; set; }
        public List<LP_SalesOrder_Master_Property> salesOrderLST { get; set; }
        public List<LP_DisplayOrder_Master_Property> displayOrderLST { get; set; }//Added By Arsalan 07-04-21
        public List<Vendor_Category_Property> vendorCatLST { get; set; }
        public string reference { get; set; }
        public List<LP_Activity_Property> ActivityDetailLST { get; set; }


        private DataTable _detail_data;
        public DataTable DetailData
        {
            get
            {
                return _detail_data;
            }
            set
            {
                _detail_data = value;
            }
        }
        private string _tableName;
        public String TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
    }
}
