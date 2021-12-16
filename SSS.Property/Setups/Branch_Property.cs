using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class Branch_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _companyIdx;
        public int companyIdx
        {
            get { return _companyIdx; }
            set { _companyIdx = value; }
        }

        private string _branchName;
        public string branchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        private string _headQuarter;
        public string headQuarter
        {
            get { return _headQuarter; }
            set { _headQuarter = value; }
        }

        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _contactNumber;
        public string contactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
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

        private int _isActive;
        public int isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private int _isMainBranch;
        public int isMainBranch
        {
            get { return _isMainBranch; }
            set { _isMainBranch = value; }
        }

    }
}
