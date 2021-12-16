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
    public class Permanent_Route_Plan_Setup_Property
    {
        #region Class Member Declarations
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private SqlInt32 _personnel_ID, _iD, _dIstributor_ID, _product_Setup_ID, operated_By;
        private SqlString _Personnel_ID_XML, _status, _pRP_Name, _pRP_Code, _tableName, _xmlOutput, _permenantRoutplanxml;
        private string _sortColumn, _record_Table_Name, _operation;
        private DateTime _operation_Date;
        private DataTable _detailData;
        private SqlBoolean _isSpotSeller;
        #endregion


        #region Class Property Declarations

        public SqlString XmlOutPut
        {
            get
            {
                return _xmlOutput;
            }
            set
            {
                _xmlOutput = value;
            }
        }
        public SqlString PermenantRoutPlanSetupxml
        {
            get
            {
                return _permenantRoutplanxml;
            }
            set
            {
                _permenantRoutplanxml = value;
            }
        }
       

        public SqlBoolean IsSpotSeller
        {
            get
            {
                return _isSpotSeller;
            }
            set
            {
                _isSpotSeller = value;
            }
        }
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


        public SqlString PRP_Code
        {
            get
            {
                return _pRP_Code;
            }
            set
            {
                SqlString pRP_CodeTmp = (SqlString)value;
                if (pRP_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PRP_Code", "PRP_Code can't be NULL");
                }
                _pRP_Code = value;
            }
        }


        public SqlString PRP_Name
        {
            get
            {
                return _pRP_Name;
            }
            set
            {
                _pRP_Name = value;
            }
        }

        public SqlString TableName
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

        public  SqlString  Personnel_ID_XML
        {
            get
            {
                return _Personnel_ID_XML;
            }
            set
            {
                _Personnel_ID_XML = value;
            }
        }
        public SqlInt32 Personnel_ID
        {
            get
            {
                return _personnel_ID;
            }
            set
            {
                _personnel_ID = value;
            }
        }

        public SqlInt32 DIstributor_ID
        {
            get
            {
                return _dIstributor_ID;
            }
            set
            {
                _dIstributor_ID = value;
            }
        }

        public SqlInt32 Product_Setup_ID
        {
            get
            {
                return _product_Setup_ID;
            }
            set
            {
                _product_Setup_ID = value;
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

        public DataTable DetailData
        {
            get
            {
                return _detailData;
            }
            set
            {
                _detailData = value;
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

        public string Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
            }
        }

        public string Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                _record_Table_Name = value;
            }
        }

        public DateTime Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                _operation_Date = value;
            }
        }
        #endregion
    }
}
