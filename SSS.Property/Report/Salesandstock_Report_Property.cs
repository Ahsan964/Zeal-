using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;


namespace SSS.Property.Report
{
    public class Salesandstock_Report_Property
    {

        #region Class Member Declarations
        private SqlInt32 _distributorid, _companyid, _flag, _targetPeriodId, _targetMonthId;
        private SqlDateTime _fromDate;
        private SqlDateTime _toDate;
        private SqlString _productGroup, _saletypeid, _channel;

        #endregion


        #region Class Property Declarations

        public SqlString Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                _channel = value;
            }
        }
        public SqlString SaleTypeID
        {
            get
            {
                return _saletypeid;
            }
            set
            {
                _saletypeid = value;
            }
        }
        public SqlInt32 TargetMonthId
        {
            get
            {
                return _targetMonthId;
            }
            set
            {
                _targetMonthId = value;
            }
        }
        public SqlInt32 TargetPeriodId
        {
            get
            {
                return _targetPeriodId;
            }
            set
            {
                _targetPeriodId = value;
            }
        }
        public SqlInt32 DistributorID
        {
            get
            {
                return _distributorid;
            }
            set
            {
                _distributorid = value;
            }
        }

        public SqlInt32 CompanyID
        {
            get
            {
                return _companyid;
            }
            set
            {
                _companyid = value;
            }
        }

        public SqlInt32 Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }





        public SqlString ProductGroup
        {
            get
            {
                return _productGroup;
            }
            set
            {
                _productGroup = value;
            }
        }






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



        #endregion



    }
}
