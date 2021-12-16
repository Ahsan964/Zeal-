using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class Product_Category_Property
    {
        public string productSubCatIdx { get; set; }
        public string productCatIdx { get; set; }
        public string subCategory { get; set; }
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private string _Category;
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private string _HSCodeCat;
        public string HSCodeCat
        {
            get { return _HSCodeCat; }
            set { _HSCodeCat = value; }
        }

        private int _CreatedByUserIdx;
        public int CreatedByUserIdx
        {
            get { return _CreatedByUserIdx; }
            set { _CreatedByUserIdx = value; }
        }

        private DateTime _CreationDate;
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        private int _visible;
        public int visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

    }
}
