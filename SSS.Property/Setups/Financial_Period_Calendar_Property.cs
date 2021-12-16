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
    public class Financial_Period_Calendar_Property
    {
        #region Class Member Declarations
        private SqlDateTime _date;
        private SqlInt32 _dayNoOfMonth, _week, _dayNoOfWeek, _quarter, _iD, _financial_Period_ID, _month, operated_By;
        private SqlString _status, _monthName, _dayName;
        private string _sortColumn, _tableName;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        #endregion

        #region Class Property Declarations
        public SqlInt32 ID
        {
            get
            {
                return _iD;
            }
            set
            {
                SqlInt32 iDTmp = (SqlInt32)value;
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
                _iD = value;
            }
        }


        public SqlInt32 Financial_Period_ID
        {
            get
            {
                return _financial_Period_ID;
            }
            set
            {
                SqlInt32 financial_Period_IDTmp = (SqlInt32)value;
                if (financial_Period_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Financial_Period_ID", "Financial_Period_ID can't be NULL");
                }
                _financial_Period_ID = value;
            }
        }


        public SqlInt32 Quarter
        {
            get
            {
                return _quarter;
            }
            set
            {
                SqlInt32 quarterTmp = (SqlInt32)value;
                if (quarterTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Quarter", "Quarter can't be NULL");
                }
                _quarter = value;
            }
        }


        public SqlInt32 Month
        {
            get
            {
                return _month;
            }
            set
            {
                SqlInt32 monthTmp = (SqlInt32)value;
                if (monthTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Month", "Month can't be NULL");
                }
                _month = value;
            }
        }


        public SqlString MonthName
        {
            get
            {
                return _monthName;
            }
            set
            {
                SqlString monthNameTmp = (SqlString)value;
                if (monthNameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("MonthName", "MonthName can't be NULL");
                }
                _monthName = value;
            }
        }


        public SqlInt32 DayNoOfMonth
        {
            get
            {
                return _dayNoOfMonth;
            }
            set
            {
                SqlInt32 dayNoOfMonthTmp = (SqlInt32)value;
                if (dayNoOfMonthTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DayNoOfMonth", "DayNoOfMonth can't be NULL");
                }
                _dayNoOfMonth = value;
            }
        }


        public SqlInt32 Week
        {
            get
            {
                return _week;
            }
            set
            {
                SqlInt32 weekTmp = (SqlInt32)value;
                if (weekTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Week", "Week can't be NULL");
                }
                _week = value;
            }
        }


        public SqlInt32 DayNoOfWeek
        {
            get
            {
                return _dayNoOfWeek;
            }
            set
            {
                SqlInt32 dayNoOfWeekTmp = (SqlInt32)value;
                if (dayNoOfWeekTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DayNoOfWeek", "DayNoOfWeek can't be NULL");
                }
                _dayNoOfWeek = value;
            }
        }


        public SqlString DayName
        {
            get
            {
                return _dayName;
            }
            set
            {
                SqlString dayNameTmp = (SqlString)value;
                if (dayNameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("DayName", "DayName can't be NULL");
                }
                _dayName = value;
            }
        }


        public SqlDateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                SqlDateTime dateTmp = (SqlDateTime)value;
                if (dateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Date", "Date can't be NULL");
                }
                _date = value;
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
                SqlString statusTmp = (SqlString)value;
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
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

        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        public SqlInt32 Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                operated_By = value;
            }
        }
        #endregion


    }
}
