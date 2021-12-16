using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Report
{
    public class ProductivityandExecution_Report_Property
    {
        #region Class Member Declarations
        private SqlDateTime _fromDate;
        private SqlDateTime _toDate;
        private SqlInt32  _DistributorID;
        private SqlInt32 _OrderBookerID;

        #endregion


        #region Class Property Declarations


        public SqlDateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
            }
        }


        public SqlDateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
            }
        }

        public SqlInt32 DistributorID
        {
            get
            {
                return _DistributorID;
            }
            set
            {
                _DistributorID = value;
            }
        }

        public SqlInt32 OrderBookerID
        {
            get
            {
                return _OrderBookerID;
            }
            set
            {
                _OrderBookerID = value;
            }
        }


        #endregion
    }
}
