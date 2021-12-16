using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.DailyCollection.Detail
{
     public class DailyCollection_property
    {


        #region Class Member Declarations
        private DateTime _cheque_Date;
        private Decimal _amount, _cheque_Amount, _cash_Amount;
        private int _document_Type_ID, _document_Type_IDOld;
        private Decimal _serial_No;
        private string _deposit_Slip_No, _cheque_No, _document_No, _payment_Mode, _cheque_Bank;
        #endregion


        #region Class Property Declarations
        public string Deposit_Slip_No
        {
            get
            {
                return _deposit_Slip_No;
            }
            set
            {
                string deposit_Slip_NoTmp = (string)value;
                if (deposit_Slip_NoTmp == null)
                {
                    throw new ArgumentOutOfRangeException("Deposit_Slip_No", "Deposit_Slip_No can't be NULL");
                }
                _deposit_Slip_No = value;
            }
        }


        public Decimal Serial_No
        {
            get
            {
                return _serial_No;
            }
            set
            {
                Decimal serial_NoTmp = (Decimal)value;
                //if (serial_NoTmp == "")
                //{
                //    throw new ArgumentOutOfRangeException("Serial_No", "Serial_No can't be NULL");
                //}
                _serial_No = value;
            }
        }


        public int Document_Type_ID
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
        public int Document_Type_IDOld
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


        public string Document_No
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


        public Decimal Amount
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


        public string Payment_Mode
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


        public string Cheque_Bank
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


        public DateTime Cheque_Date
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


        public string Cheque_No
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


        public Decimal Cheque_Amount
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


        public Decimal Cash_Amount
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
