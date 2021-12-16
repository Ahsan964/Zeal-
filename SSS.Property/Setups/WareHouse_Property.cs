using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    //[Serializable()]
   public class WareHouse_Property
    {
        private int _Idx;
        public int Idx
        {
            get { return _Idx; }
            set { _Idx = value; }
        }

        private int _CompanyIdx;
        public int CompanyIdx
        {
            get { return _CompanyIdx; }
            set { _CompanyIdx = value; }
        }

        private int _BranchIdx;
        public int BranchIdx
        {
            get { return _BranchIdx; }
            set { _BranchIdx = value; }
        }

        private string _WareHouseName;
        public string WareHouseName
        {
            get { return _WareHouseName; }
            set { _WareHouseName = value; }
        }

        //private string  _CreationDate;
        //public string CreationDate
        //{
        //    get { return _CreationDate; }
        //    set { _CreationDate = value; }
        //}

        private DateTime _CreationDate;
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        private int _createdByUserIdx;
        public int createdByUserIdx
        {
            get { return _createdByUserIdx; }
            set { _createdByUserIdx = value; }
        }

        private int _lastModifiedByUserIdx;
        public int lastModifiedByUserIdx
        {
            get { return _lastModifiedByUserIdx; }
            set { _lastModifiedByUserIdx = value; }
        }

        private string _LastModificationDate;
        public string LastModificationDate
        {
            get { return _LastModificationDate; }
            set { _LastModificationDate = value; }
        }

        private bool _IsMainWareHouse;
        public bool IsMainWareHouse
        {
            get { return _IsMainWareHouse; }
            set { _IsMainWareHouse = value; }
        }

        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }

        public List<Branch_Property> BranchLists { get; set; }
    }
}
