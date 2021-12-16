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
    [Serializable()]
    public class POS_Setup_Property
    {
        #region Class Member Declarations
        private Int32? _pageNum, _pageSize, _totalRowsNum, _routeID, _error_Code;

        private SqlBoolean _cheque_Allowed, _freezer, _counter_Sale, _credit_Allowed, _cool_Cab, _air_Conditioner, _refrigerator;
        private SqlInt32 _business_Type, _pOS_Type_ID, _distributorid, _pOS_Type_IDOld, _iD, _area_Type, _location_ID, _location_IDOld, operated_By, _pOS_Registration, _pos_Category;
        private SqlDecimal _p_UAN_Number, _p_FAX_Number, _p_Phone_Number, _p_Mobile_Number, _post_Code;
        private SqlString _nic, _code, _pOS_Type, _busns_type, _areaa_type, _pOS_reg, _pOS_catg, _xmlOutput, _PosSetupxml, _credit_Amount_Limit, _owner_Name, _detail_Description, _cheque_Amount_Limit, _short_Description, _address, _market_Name, _p_URL, _pOS_Rank, _police_Station, _p_Email_Address, _telegraph_Add, _railway_Station, _pOS_Turn_Over, _company_Rank, _company_Turn_Over, _status, _p_Tex_Number, _distributor_Code, _sss_Code, locationIDs;
        private string _sortColumn, _tableName;
        private bool _isValid = true;
        private DataTable _detailData;

        FluentValidation.Results.ValidationResult validationResult;
        List<FluentValidation.Results.ValidationFailure> _errors = new List<FluentValidation.Results.ValidationFailure>();

        #endregion

        #region Class Property Declarations


        public int? ErrorCode
        {
            get
            {
                return _error_Code;
            }
            set
            {
                _error_Code = value;
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


        public SqlString SssCode
        {
            get { return _sss_Code; }
            set { _sss_Code = value; }

        }

        public SqlString POSType
        {
            get { return _pOS_Type; }
            set { _pOS_Type = value; }

        }

        public SqlInt32 POS_Type_ID
        {
            get
            {
                return _pOS_Type_ID;
            }
            set
            {
                _pOS_Type_ID = value;
            }
        }

        public SqlString BusinessType
        {
            get { return _busns_type; }
            set { _busns_type = value; }

        }

        public SqlString AreaType
        {
            get { return _areaa_type; }
            set { _areaa_type = value; }

        }

        public SqlString POSRegistration
        {
            get { return _pOS_reg; }
            set { _pOS_reg = value; }

        }

        public SqlString POSCategory
        {
            get { return _pOS_catg; }
            set { _pOS_catg = value; }

        }

        public SqlString DistributorCode
        {
            get { return _distributor_Code; }
            set { _distributor_Code = value; }

        }

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
        public SqlString nic
        {
            get { return _nic; }
            set { _nic = value; }

        }
        public SqlString PosSetupxml
        {
            get
            {
                return _PosSetupxml;
            }
            set
            {
                _PosSetupxml = value;
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
                _iD = value;
            }
        }

        public SqlInt32 Location_ID
        {
            get
            {
                return _location_ID;
            }
            set
            {
                _location_ID = value;
            }
        }

        public SqlString Short_Description
        {
            get
            {
                return _short_Description;
            }
            set
            {
                _short_Description = value;
            }
        }

        public SqlString Detail_Description
        {
            get
            {
                return _detail_Description;
            }
            set
            {
                _detail_Description = value;
            }
        }


        public SqlString Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
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


        public SqlDecimal P_Phone_Number
        {
            get
            {
                return _p_Phone_Number;
            }
            set
            {
                _p_Phone_Number = value;
            }
        }


        public SqlDecimal P_Mobile_Number
        {
            get
            {
                return _p_Mobile_Number;
            }
            set
            {
                _p_Mobile_Number = value;
            }
        }


        public SqlDecimal P_UAN_Number
        {
            get
            {
                return _p_UAN_Number;
            }
            set
            {
                _p_UAN_Number = value;
            }
        }


        public SqlDecimal P_FAX_Number
        {
            get
            {
                return _p_FAX_Number;
            }
            set
            {
                _p_FAX_Number = value;
            }
        }


        public SqlString P_Email_Address
        {
            get
            {
                return _p_Email_Address;
            }
            set
            {
                _p_Email_Address = value;
            }
        }


        public SqlString P_URL
        {
            get
            {
                return _p_URL;
            }
            set
            {
                _p_URL = value;
            }
        }


        public SqlString P_Tex_Number
        {
            get
            {
                return _p_Tex_Number;
            }
            set
            {
                _p_Tex_Number = value;
            }
        }


        public SqlDecimal Post_Code
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


        public SqlString Telegraph_Add
        {
            get
            {
                return _telegraph_Add;
            }
            set
            {
                _telegraph_Add = value;
            }
        }


        public SqlString Railway_Station
        {
            get
            {
                return _railway_Station;
            }
            set
            {
                _railway_Station = value;
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

        public SqlInt32 Business_Type
        {
            get
            {
                return _business_Type;
            }
            set
            {
                _business_Type = value;
            }
        }
        public   string Business_TypeStr { get; set; }

        public SqlInt32 Area_Type
        {
            get
            {
                return _area_Type;
            }
            set
            {
                _area_Type = value;
            }
        }

        public SqlInt32 POS_Registration
        {
            get
            {
                return _pOS_Registration;
            }
            set
            {
                _pOS_Registration = value;
            }
        }

        public SqlInt32 POS_Category
        {
            get
            {
                return _pos_Category;
            }
            set
            {
                _pos_Category = value;
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


        public SqlString Company_Turn_Over
        {
            get
            {
                return _company_Turn_Over;
            }
            set
            {
                _company_Turn_Over = value;
            }
        }


        public SqlString POS_Turn_Over
        {
            get
            {
                return _pOS_Turn_Over;
            }
            set
            {
                _pOS_Turn_Over = value;
            }
        }


        public SqlString Company_Rank
        {
            get
            {
                return _company_Rank;
            }
            set
            {
                _company_Rank = value;
            }
        }


        public SqlString POS_Rank
        {
            get
            {
                return _pOS_Rank;
            }
            set
            {
                _pOS_Rank = value;
            }
        }


        public SqlBoolean Credit_Allowed
        {
            get
            {
                return _credit_Allowed;
            }
            set
            {
                _credit_Allowed = value;
            }
        }


        public SqlString Credit_Amount_Limit
        {
            get
            {
                return _credit_Amount_Limit;
            }
            set
            {
                _credit_Amount_Limit = value;
            }
        }


        public SqlBoolean Cheque_Allowed
        {
            get
            {
                return _cheque_Allowed;
            }
            set
            {
                _cheque_Allowed = value;
            }
        }


        public SqlString Cheque_Amount_Limit
        {
            get
            {
                return _cheque_Amount_Limit;
            }
            set
            {
                _cheque_Amount_Limit = value;
            }
        }


        public SqlBoolean Freezer
        {
            get
            {
                return _freezer;
            }
            set
            {
                _freezer = value;
            }
        }


        public SqlBoolean Cool_Cab
        {
            get
            {
                return _cool_Cab;
            }
            set
            {
                _cool_Cab = value;
            }
        }


        public SqlBoolean Refrigerator
        {
            get
            {
                return _refrigerator;
            }
            set
            {
                _refrigerator = value;
            }
        }


        public SqlBoolean Air_Conditioner
        {
            get
            {
                return _air_Conditioner;
            }
            set
            {
                _air_Conditioner = value;
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

        public SqlString Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        public int? RouteID
        {
            get
            {
                return _routeID;
            }
            set
            {
                _routeID = value;
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

        public SqlString LocationIDs
        {
            get
            {
                return locationIDs;
            }
            set
            {
                locationIDs = value;
            }
        }
        #endregion
    }
}
