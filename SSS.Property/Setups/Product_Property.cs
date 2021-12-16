using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using SSS.Property.Transactions;
using System.Web;

namespace SSS.Property.Setups
{
    [Serializable()]
    public class Product_Property
    {
      


        public int idx { get; set; }
        public int productTypeIdx { get; set; }
        public int productCatIdx { get; set; }
        public int productSubCatIdx { get; set; }
        public string HSCODE { get; set; }
        public string Category { get; set; }
        [Required]
        public string Reference { get; set; }// Added By Ahsan

        [Required]
        public string itemName { get; set; }
        public string itemCode { get; set; }
        public int unitIdx { get; set; }
        [Required]
        public string description { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }

        [Required(ErrorMessage = "Cost Price is Required")]
        public decimal costPrice { get; set; }
        [Required]
        public decimal salePrice { get; set; }
        [Required]
        public decimal productTax { get; set; }
        public int productIdx { get; set; }
        public List<Product_Property> ProductLST { get; set; }
        public string productName { get; set; }
        public decimal qty { get; set; }

        public string[] ProductPicPath { get; set; }



        public HttpPostedFileWrapper[] PicturePath { get; set; }
        public List<LP_ProductDetailsForCombo_Property> ProductDetailLST { get; set; }

        public List<LP_Products_Picture> ProductPictureList { get; set; }

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
