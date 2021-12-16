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
   public class Daily_Collection_Dtl_Property
    {
        #region Class Member Declarations
        private SqlDateTime _cheque_Date;
        private SqlDecimal _cheque_Amount, _amount, _cash_Amount;
        private SqlInt32 _document_Type_ID, _document_Type_IDOld;
        private SqlDecimal _serial_No;
        private SqlString _cheque_No, _document_No, _deposit_Slip_No, _cheque_Bank, _payment_Mode;
        #endregion

        #region Class Property Declarations
        public SqlString Deposit_Slip_No
        {
            get
            {
                return _deposit_Slip_No;
            }
            set
            {
                SqlString deposit_Slip_NoTmp = (SqlString)value;
                if (deposit_Slip_NoTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Deposit_Slip_No", "Deposit_Slip_No can't be NULL");
                }
                _deposit_Slip_No = value;
            }
        }


        public SqlDecimal Serial_No
        {
            get
            {
                return _serial_No;
            }
            set
            {
                SqlDecimal serial_NoTmp = (SqlDecimal)value;
                if (serial_NoTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Serial_No", "Serial_No can't be NULL");
                }
                _serial_No = value;
            }
        }


        public SqlInt32 Document_Type_ID
        {
            get
            {
                return _document_Type_ID;
            }
            set
            {
                _document_Type_ID = value;
            }
        }
        public SqlInt32 Document_Type_IDOld
        {
            get
            {
                return _document_Type_IDOld;
            }
            set
            {
                _document_Type_IDOld = value;
            }
        }


        public SqlString Document_No
        {
            get
            {
                return _document_No;
            }
            set
            {
                _document_No = value;
            }
        }


        public SqlDecimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }


        public SqlString Payment_Mode
        {
            get
            {
                return _payment_Mode;
            }
            set
            {
                _payment_Mode = value;
            }
        }


        public SqlString Cheque_Bank
        {
            get
            {
                return _cheque_Bank;
            }
            set
            {
                _cheque_Bank = value;
            }
        }


        public SqlDateTime Cheque_Date
        {
            get
            {
                return _cheque_Date;
            }
            set
            {
                _cheque_Date = value;
            }
        }


        public SqlString Cheque_No
        {
            get
            {
                return _cheque_No;
            }
            set
            {
                _cheque_No = value;
            }
        }


        public SqlDecimal Cheque_Amount
        {
            get
            {
                return _cheque_Amount;
            }
            set
            {
                _cheque_Amount = value;
            }
        }


        public SqlDecimal Cash_Amount
        {
            get
            {
                return _cash_Amount;
            }
            set
            {
                _cash_Amount = value;
            }
        }
        #endregion
    }
}
