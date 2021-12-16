using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class Company_Bank_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _bankIdx;
        public int bankIdx
        {
            get { return _bankIdx; }
            set { _bankIdx = value; }
        }

        private string _accountTitle;
        public string accountTitle
        {
            get { return _accountTitle; }
            set { _accountTitle = value; }
        }

        private string _Branch;
        public string Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }

        private string _accountNumber;
        public string accountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

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

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
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
        private int _coaidx;
        public int coaidx
        {
            get { return _coaidx; }
            set { _coaidx = value; }
        }

        private string _branchCode;
        public string branchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        private string _swiftCode;
        public string swiftCode
        {
            get { return _swiftCode; }
            set { _swiftCode = value; }
        }
    }
}
