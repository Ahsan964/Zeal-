using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.DailyCollection.Master
{
     public class DailyCollection_property
     {

         #region Class Member Declarations
         private DateTime _deposit_Slip_Date, _deposit_Date;
         private Decimal _amount_Cheque, _amount_Cash;
         private int _personnel_ID, _personnel_IDOld, _distributor_ID, _distributor_IDOld;
         private string _deposit_Slip_No, _description;
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


         public DateTime Deposit_Date
         {
             get
             {
                 return _deposit_Date;
             }
             set
             {
                 DateTime deposit_DateTmp = (DateTime)value;
                 if (deposit_DateTmp == null)
                 {
                     throw new ArgumentOutOfRangeException("Deposit_Date", "Deposit_Date can't be NULL");
                 }
                 _deposit_Date = value;
             }
         }


         public string Description
         {
             get
             {
                 return _description;
             }
             set
             {
                 _description = value;
             }
         }


         public int Distributor_ID
         {
             get
             {
                 return _distributor_ID;
             }
             set
             {
                 _distributor_ID = value;
             }
         }
         public int Distributor_IDOld
         {
             get
             {
                 return _distributor_IDOld;
             }
             set
             {
                 _distributor_IDOld = value;
             }
         }


         public int Personnel_ID
         {
             get
             {
                 return _personnel_ID;
             }
             set
             {
                 _personnel_ID = value;
             }
         }
         public int Personnel_IDOld
         {
             get
             {
                 return _personnel_IDOld;
             }
             set
             {
                 _personnel_IDOld = value;
             }
         }


         public DateTime Deposit_Slip_Date
         {
             get
             {
                 return _deposit_Slip_Date;
             }
             set
             {
                 _deposit_Slip_Date = value;
             }
         }


         public Decimal Amount_Cash
         {
             get
             {
                 return _amount_Cash;
             }
             set
             {
                 _amount_Cash = value;
             }
         }


         public Decimal Amount_Cheque
         {
             get
             {
                 return _amount_Cheque;
             }
             set
             {
                 _amount_Cheque = value;
             }
         }
         #endregion


     }
}
