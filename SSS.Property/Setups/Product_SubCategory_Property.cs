using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    public class Product_SubCategory_Property
    {
        private int _idx;
        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }

        private int _product_catIdx;
        public int product_catIdx
        {
            get { return _product_catIdx; }
            set { _product_catIdx = value; }
        }

        private string _subCategory;
        public string subCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        private string _HS_CodeSub;
        public string HS_CodeSub
        {
            get { return _HS_CodeSub; }
            set { _HS_CodeSub = value; }
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
