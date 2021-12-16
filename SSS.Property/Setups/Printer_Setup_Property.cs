using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
namespace SSS.Property.Setups
{
   public class Printer_Setup_Property
    {
        #region Class Member Declarations

        private Int32? _iD,_distributorID,_pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn;
        private SqlString _status;
        private SqlBoolean _fullPagePrinting;
        #endregion

        #region Class Property Declarations

        public Int32? ID
        {
            get
            {
                return _iD;
            }
            set
            {

                _iD = value;
            }
        }

        public Int32? DistributorID
        {
            get
            {
                return _distributorID;
            }
            set
            {

                _distributorID = value;
            }
        }


        public SqlBoolean FullPagePrinting
        {
            get
            {
                return _fullPagePrinting;
            }
            set
            {
                _fullPagePrinting = value;
            }
        }

        public SqlString Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public int? PageNum
        {
            get
            {
                return _pageNum;
            }
            set
            {
                _pageNum = value;
            }
        }

        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int? TotalRowsNum
        {
            get
            {
                return _totalRowsNum;
            }
            set
            {
                _totalRowsNum = value;
            }
        }

        public string SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                _sortColumn = value;
            }
        }
        #endregion
      

    }
}
