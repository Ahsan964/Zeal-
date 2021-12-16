using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class VendorProcessVM_Property
    {
        public int ID { get; set; }
        public string itemName { get; set; }
        public int itemIdx { get; set; }

        public int vendorIdx { get; set; }
        public string vendorName { get; set; }

        public int vendorCatIdx { get; set; }
        public string vendorCategory { get; set; }

        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime creationDate { get; set; }
        public bool visible { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal activityPrice { get; set; }
        public List<Product_Property> ProductList { get; set; }
        public List<Vendors_Property> VendorLST { get; set; }
        public List<Vendor_Category_Property> VendorCatList { get; set; }
        public List<VendorProcessVM_Property> vendorDetailList { get; set; }

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
