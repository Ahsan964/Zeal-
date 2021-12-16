using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
   public class LP_CI_PurchaseDetails_Property
    {
        // Added By Ahsan
        public int idx { get; set; }
        public int purchaseIdx { get; set; }
        public int coaIdx { get; set; }
        public int vendorIdx { get; set; }
        public decimal amount { get; set; }
        public string vendorName { get; set; }
        public string childHeadName { get; set; }
        public string itemName { get; set; }
        //private int _idx;
        //public int idx
        //{
        //    get { return _idx; }
        //    set { _idx = value; }
        //}

        //private int _purchaseIdx;
        //public int purchaseIdx
        //{
        //    get { return _purchaseIdx; }
        //    set { _purchaseIdx = value; }
        //}

        private int _productTypeIdx;
        public int productTypeIdx
        {
            get { return _productTypeIdx; }
            set { _productTypeIdx = value; }
        }

        private int _itemIdx;
        public int itemIdx
        {
            get { return _itemIdx; }
            set { _itemIdx = value; }
        }

        private decimal _unitPrice;
        public decimal unitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        private decimal _qty;
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        //private decimal _amount;
        //public decimal amount
        //{
        //    get { return _amount; }
        //    set { _amount = value; }
        //}

        private DateTime _creationDate;
        public DateTime creationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        private int _createdByUserIdx;
        public int createdByUserIdx
        {
            get { return _createdByUserIdx; }
            set { _createdByUserIdx = value; }
        }

        private string _lastModificationDate;
        public string lastModificationDate
        {
            get { return _lastModificationDate; }
            set { _lastModificationDate = value; }
        }

        private int _lastModifiedByUserIdx;
        public int lastModifiedByUserIdx
        {
            get { return _lastModifiedByUserIdx; }
            set { _lastModifiedByUserIdx = value; }
        }

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private DateTime _DueDate;
        public DateTime DueDate
        {
            get { return _DueDate; }
            set { _DueDate = value; }
        }

        private decimal _openItem;
        public decimal openItem
        {
            get { return _openItem; }
            set { _openItem = value; }
        }

        private string _ItemDescription;
        public string ItemDescription
        {
            get { return _ItemDescription; }
            set { _ItemDescription = value; }
        }

        private decimal _DVRate;
        public decimal DVRate
        {
            get { return _DVRate; }
            set { _DVRate = value; }
        }

        private decimal _TDVRate;
        public decimal TDVRate
        {
            get { return _TDVRate; }
            set { _TDVRate = value; }
        }

        private decimal _ADVRate;
        public decimal ADVRate
        {
            get { return _ADVRate; }
            set { _ADVRate = value; }
        }

        private decimal _ASSVCI;
        public decimal ASSVCI
        {
            get { return _ASSVCI; }
            set { _ASSVCI = value; }
        }

        private decimal _Landing;
        public decimal Landing
        {
            get { return _Landing; }
            set { _Landing = value; }
        }

        private decimal _CDPercntage;
        public decimal CDPercntage
        {
            get { return _CDPercntage; }
            set { _CDPercntage = value; }
        }

        private decimal _RDPercentage;
        public decimal RDPercentage
        {
            get { return _RDPercentage; }
            set { _RDPercentage = value; }
        }

        private decimal _ACDPercentage;
        public decimal ACDPercentage
        {
            get { return _ACDPercentage; }
            set { _ACDPercentage = value; }
        }

        private decimal _ASTPercentage;
        public decimal ASTPercentage
        {
            get { return _ASTPercentage; }
            set { _ASTPercentage = value; }
        }

        private decimal _ITPercentage;
        public decimal ITPercentage
        {
            get { return _ITPercentage; }
            set { _ITPercentage = value; }
        }

        private decimal _TDTax;
        public decimal TDTax
        {
            get { return _TDTax; }
            set { _TDTax = value; }
        }

        private decimal _CleaningPrice;
        public decimal CleaningPrice
        {
            get { return _CleaningPrice; }
            set { _CleaningPrice = value; }
        }

        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }


        private decimal _STPercentage;
        public decimal STPercentage
        {
            get { return _STPercentage; }
            set { _STPercentage = value; }
        }
        private decimal _TotalASSVSCI;
        public decimal TotalASSVSCI
        {
            get { return _TotalASSVSCI; }
            set { _TotalASSVSCI = value; }
        }

        private decimal _TotalLanding;
        public decimal TotalLanding
        {
            get { return _TotalLanding; }
            set { _TotalLanding = value; }
        }

        private decimal _TotalCDValue;
        public decimal TotalCDValue
        {
            get { return _TotalCDValue; }
            set { _TotalCDValue = value; }
        }

        private decimal _TotalRDValue;
        public decimal TotalRDValue
        {
            get { return _TotalRDValue; }
            set { _TotalRDValue = value; }
        }

        private decimal _TotalACDValue;
        public decimal TotalACDValue
        {
            get { return _TotalACDValue; }
            set { _TotalACDValue = value; }
        }

        private decimal _TotalASTValue;
        public decimal TotalASTValue
        {
            get { return _TotalASTValue; }
            set { _TotalASTValue = value; }
        }

        private decimal _TotalITValue;
        public decimal TotalITValue
        {
            get { return _TotalITValue; }
            set { _TotalITValue = value; }
        }

        private decimal _TotalSTValue;
        public decimal TotalSTValue
        {
            get { return _TotalSTValue; }
            set { _TotalSTValue = value; }
        }

        public decimal clearingpercentage { get; set; }
        public decimal clearingExpensePerProduct { get; set; } //Added By Arsalan 11-06-21
        public decimal pricePerProduct { get; set; } //Added By Arsalan 11-06-21
        public decimal TotalAVPkr { get; set; }

    }
}
