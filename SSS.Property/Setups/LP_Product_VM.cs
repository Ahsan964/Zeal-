using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SSS.Property.Setups
{
   public class LP_Product_VM
    {
        public int idx { get; set; }
        public int productTypeIdx { get; set; }
        public int productCatIdx { get; set; }
        public int productSubCatIdx { get; set; }
        public string HSCODE { get; set; }
        public string itemName { get; set; }
        public string itemCode { get; set; }
        public int unitIdx { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public int visible { get; set; }
        public decimal costPrice { get; set; }
        public decimal salePrice { get; set; }
        public decimal productTax { get; set; }
        public int productIdx { get; set; }
        public List<Product_Property> ProductLST { get; set; }
        public string productName { get; set; }
        public decimal qty { get; set; }

        public HttpPostedFileWrapper[] PicturePath { get; set; }
        public List<LP_ProductDetailsForCombo_Property> ProductDetailLST { get; set; }

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
