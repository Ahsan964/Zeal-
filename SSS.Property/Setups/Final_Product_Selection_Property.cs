using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Setups
{
    public class Final_Product_Selection_Property
    {
        #region Class Member Declarations
        private SqlString _code, _category, _sku;
        private SqlInt32 _sale_rep_ID;
        private SqlBoolean? _isFinalProduct;
        #endregion

        #region Properties
        public SqlInt32 SaleRepID
        {
            get
            {
                return _sale_rep_ID;
            }
            set
            {
                _sale_rep_ID = value;
            }
        }

        public SqlString Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        public SqlBoolean? IsFinalProduct
        {
            get
            {
                return _isFinalProduct;
            }
            set
            {
                _isFinalProduct = value;
            }
        }

        public SqlString Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public SqlString Sku
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
            }
        }
        #endregion
    }
}
