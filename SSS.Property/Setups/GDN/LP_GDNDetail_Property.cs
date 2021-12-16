using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.GDN
{
   public class LP_GDNDetail_Property
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _GRN_MasterId;
        public int GRN_MasterId
        {
            get { return _GRN_MasterId; }
            set { _GRN_MasterId = value; }
        }

        private bool _Is_Quarantine;
        public bool Is_Quarantine
        {
            get { return _Is_Quarantine; }
            set { _Is_Quarantine = value; }
        }

        private int _Product_Id;
        public int Product_Id
        {
            get { return _Product_Id; }
            set { _Product_Id = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private int _DepartmentI_d;
        public int DepartmentI_d
        {
            get { return _DepartmentI_d; }
            set { _DepartmentI_d = value; }
        }

        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private decimal _Rate;
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }

        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        private decimal _Discount;
        public decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        private decimal _Net_Amount;
        public decimal Net_Amount
        {
            get { return _Net_Amount; }
            set { _Net_Amount = value; }
        }

        private decimal _Tax_Amount;
        public decimal Tax_Amount
        {
            get { return _Tax_Amount; }
            set { _Tax_Amount = value; }
        }

        private decimal _PurchaseCharges1;
        public decimal PurchaseCharges1
        {
            get { return _PurchaseCharges1; }
            set { _PurchaseCharges1 = value; }
        }

        private decimal _PurchaseCharges2;
        public decimal PurchaseCharges2
        {
            get { return _PurchaseCharges2; }
            set { _PurchaseCharges2 = value; }
        }

        private decimal _PenaltyCharges;
        public decimal PenaltyCharges
        {
            get { return _PenaltyCharges; }
            set { _PenaltyCharges = value; }
        }

        private int _PenaltyType;
        public int PenaltyType
        {
            get { return _PenaltyType; }
            set { _PenaltyType = value; }
        }

        private string _Penalty_Reason;
        public string Penalty_Reason
        {
            get { return _Penalty_Reason; }
            set { _Penalty_Reason = value; }
        }

        private int _PC_Type;
        public int PC_Type
        {
            get { return _PC_Type; }
            set { _PC_Type = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _BRANCHID;
        public int BRANCHID
        {
            get { return _BRANCHID; }
            set { _BRANCHID = value; }
        }

    }
}
