using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Report
{
    public class ConsolidateSalesSummary_Report_Property
    {
     

        #region Class Member Declarations
        private SqlDateTime _fromDate;
        private SqlDateTime _toDate;
        private SqlInt32  _distributorid;
        private SqlInt32 _orderbookerid;
        private string _productId;




      
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

        public string ProductIds
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
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


        public SqlInt32 DistributorId
        {
            get
            {
                return _distributorid;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _distributorid = value;
            }
        }



        public SqlInt32 OrderBookerId
        {
            get
            {
                return _orderbookerid;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _orderbookerid = value;
            }
        }







       
        #endregion



    }
}
