using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
namespace SSS.Property.Setups
{
    public class Special_Discount_Master_Property
    {

        #region Class Member Declarations
        private SqlDecimal _overAll_Discount_Amount, _overAll_Percentage_Amount;
        private SqlInt32 _overAll_Free_Peices, _id, _cashMemoId, _distributor_Id;
        private SqlString _status;
        private DataTable _detailData;
        #endregion



        #region Class Property Declarations
        public SqlInt32 Id
        {
            get
            {
                return _id;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _id = value;
            }
        }


        public SqlInt32 CashMemoId
        {
            get
            {
                return _cashMemoId;
            }
            set
            {
                SqlInt32 cashMemoIdTmp = (SqlInt32)value;
                if (cashMemoIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("CashMemoId", "CashMemoId can't be NULL");
                }
                _cashMemoId = value;
            }
        }


        public SqlInt32 Distributor_Id
        {
            get
            {
                return _distributor_Id;
            }
            set
            {
                SqlInt32 distributor_IdTmp = (SqlInt32)value;
                if (distributor_IdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Distributor_Id", "Distributor_Id can't be NULL");
                }
                _distributor_Id = value;
            }
        }


        public SqlInt32 OverAll_Free_Peices
        {
            get
            {
                return _overAll_Free_Peices;
            }
            set
            {
                SqlInt32 overAll_Free_PeicesTmp = (SqlInt32)value;
                if (overAll_Free_PeicesTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OverAll_Free_Peices", "OverAll_Free_Peices can't be NULL");
                }
                _overAll_Free_Peices = value;
            }
        }


        public SqlDecimal OverAll_Discount_Amount
        {
            get
            {
                return _overAll_Discount_Amount;
            }
            set
            {
                SqlDecimal overAll_Discount_AmountTmp = (SqlDecimal)value;
                if (overAll_Discount_AmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OverAll_Discount_Amount", "OverAll_Discount_Amount can't be NULL");
                }
                _overAll_Discount_Amount = value;
            }
        }


        public SqlDecimal OverAll_Percentage_Amount
        {
            get
            {
                return _overAll_Percentage_Amount;
            }
            set
            {
                SqlDecimal overAll_Percentage_AmountTmp = (SqlDecimal)value;
                if (overAll_Percentage_AmountTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("OverAll_Percentage_Amount", "OverAll_Percentage_Amount can't be NULL");
                }
                _overAll_Percentage_Amount = value;
            }
        }


        public SqlString Status
        {
            get
            {
                return _status;
            }
            set
            {
                SqlString statusTmp = (SqlString)value;
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
                _status = value;
            }
        }


        public DataTable DetailData
        {
            get
            {
                return _detailData;
            }
            set
            {
                _detailData = value;
            }
        }

        #endregion
    }
}
