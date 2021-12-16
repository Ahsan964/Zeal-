using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace SSS.Property.Transactions
{
    public class PO_Detail_Property
    {
        #region Class Member Declarations
		private SqlInt32	_product_ID, _quantity, _iD, _pO_Master_ID;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public PO_Detail_Property()
		{
			// Nothing for now.
		}
        #region Class Property Declarations
		public SqlInt32 ID
		{
			get
			{
				return _iD;
			}
			set
			{
				SqlInt32 iDTmp = (SqlInt32)value;
				if(iDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
				}
				_iD = value;
			}
		}


        public SqlInt32 PO_Master_ID
		{
			get
			{
                return _pO_Master_ID;
			}
			set
			{
				SqlInt32 pO_IDTmp = (SqlInt32)value;
				if(pO_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PO_ID", "PO_ID can't be NULL");
				}
                _pO_Master_ID = value;
			}
		}


		public SqlInt32 Product_ID
		{
			get
			{
				return _product_ID;
			}
			set
			{
				SqlInt32 product_IDTmp = (SqlInt32)value;
				if(product_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Product_ID", "Product_ID can't be NULL");
				}
				_product_ID = value;
			}
		}


		public SqlInt32 Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				SqlInt32 quantityTmp = (SqlInt32)value;
				if(quantityTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Quantity", "Quantity can't be NULL");
				}
				_quantity = value;
			}
		}
		#endregion
    }
}
