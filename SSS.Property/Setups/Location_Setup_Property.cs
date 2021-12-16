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
    public class Location_Setup_Property
    {
        #region Class Member Declarations
        private SqlBoolean _counter_Sale, _is_Location_POS;
        private SqlDecimal _amount_Limit, _total_Turnover, _company_Turnover;
        private SqlInt32 _sub_Pos_Type_ID, _pos_Type_ID, _pos_Type_IDOld, _parent_Location_ID, _iD, _company_ID, _company_IDOld, operated_By;
        private SqlString _email, _status, _owner_Name, _owner_NIC, _fax_No, _location_Name, _shop_No, _location_Code, _location_Short_Name, _market_Name, _post_Code, _phone_No, _street, _police_Station;
        private string _sortColumn, _tableName, operation;
        private int _pageNum, _pageSize, _totalRowsNum;
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


        public SqlString Location_Code
        {
            get
            {
                return _location_Code;
            }
            set
            {
                _location_Code = value;
            }
        }


        public SqlString Location_Short_Name
        {
            get
            {
                return _location_Short_Name;
            }
            set
            {
                _location_Short_Name = value;
            }
        }


        public SqlString Location_Name
        {
            get
            {
                return _location_Name;
            }
            set
            {
                SqlString location_NameTmp = (SqlString)value;
                if (location_NameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Location_Name", "Location_Name can't be NULL");
                }
                _location_Name = value;
            }
        }


        public SqlInt32 Parent_Location_ID
        {
            get
            {
                return _parent_Location_ID;
            }
            set
            {
                _parent_Location_ID = value;
            }
        }


        public SqlInt32 Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                _company_ID = value;
            }
        }
        public SqlInt32 Company_IDOld
        {
            get
            {
                return _company_IDOld;
            }
            set
            {
                _company_IDOld = value;
            }
        }


        public SqlInt32 Pos_Type_ID
        {
            get
            {
                return _pos_Type_ID;
            }
            set
            {
                _pos_Type_ID = value;
            }
        }
        public SqlInt32 Pos_Type_IDOld
        {
            get
            {
                return _pos_Type_IDOld;
            }
            set
            {
                _pos_Type_IDOld = value;
            }
        }


        public SqlInt32 Sub_Pos_Type_ID
        {
            get
            {
                return _sub_Pos_Type_ID;
            }
            set
            {
                _sub_Pos_Type_ID = value;
            }
        }


        public SqlString Shop_No
        {
            get
            {
                return _shop_No;
            }
            set
            {
                _shop_No = value;
            }
        }


        public SqlString Market_Name
        {
            get
            {
                return _market_Name;
            }
            set
            {
                _market_Name = value;
            }
        }


        public SqlString Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
            }
        }


        public SqlString Police_Station
        {
            get
            {
                return _police_Station;
            }
            set
            {
                _police_Station = value;
            }
        }


        public SqlString Post_Code
        {
            get
            {
                return _post_Code;
            }
            set
            {
                _post_Code = value;
            }
        }


        public SqlString Phone_No
        {
            get
            {
                return _phone_No;
            }
            set
            {
                _phone_No = value;
            }
        }


        public SqlString Fax_No
        {
            get
            {
                return _fax_No;
            }
            set
            {
                _fax_No = value;
            }
        }


        public SqlString Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }


        public SqlDecimal Company_Turnover
        {
            get
            {
                return _company_Turnover;
            }
            set
            {
                _company_Turnover = value;
            }
        }


        public SqlDecimal Total_Turnover
        {
            get
            {
                return _total_Turnover;
            }
            set
            {
                _total_Turnover = value;
            }
        }


        public SqlDecimal Amount_Limit
        {
            get
            {
                return _amount_Limit;
            }
            set
            {
                _amount_Limit = value;
            }
        }


        public SqlString Owner_Name
        {
            get
            {
                return _owner_Name;
            }
            set
            {
                _owner_Name = value;
            }
        }


        public SqlString Owner_NIC
        {
            get
            {
                return _owner_NIC;
            }
            set
            {
                _owner_NIC = value;
            }
        }


        public SqlBoolean Counter_Sale
        {
            get
            {
                return _counter_Sale;
            }
            set
            {
                _counter_Sale = value;
            }
        }


        public SqlBoolean Is_Location_POS
        {
            get
            {
                return _is_Location_POS;
            }
            set
            {
                _is_Location_POS = value;
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

        public int PageNum
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

        public int PageSize
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

        public int TotalRowsNum
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
        public string Operation
        {
            get
            {
                return operation;
            }
            set
            {

                operation = value;
            }
        }
        #endregion

    }
}
