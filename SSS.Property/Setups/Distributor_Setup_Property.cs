using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace SSS.Property.Setups
{
    [Serializable()]
    public class Distributor_Setup_Property
    {
        #region Class Member Declarations
        private SqlDateTime? _FromDate, _ToDate;
        private Int32? _DiscountId, _pageNum, _pageSize, _totalRowsNum, _fax_Number, _post_Code, _parent_ID, _TypeRecID, _Tax;
        private Decimal? _capital_Invest;
        private string _sortColumn, _tableName, operation;
        private SqlBoolean _transactionFlag, _is_Active;
        private SqlDateTime _date_Of_Join, _working_Date;
        private SqlDecimal  _current_Balance;
        private SqlInt32 _Price_ID, _Batch_ID, _registration_Type_ID, _registration_Type_IDOld, _location_Setup_ID, _iD, operated_By, _company_ID, _company_IDOld, _errorCode;
        private SqlString _railway_Station, _police_Station, _distributor_Name, _active_Status, _status, _distributor_Code, _day_Off, _mobile_No, _uAN_Number, _phone2, _tax_Number, _phone1, _address, _telegraph_Add, _uRL, _owner_Name, _email;
        
        private SqlString _DistXML, _Servername, _Dbname, _RouteXML, _BusnesXML, _POSXML, _LocationXML
            , _ProductXml, _Tempxml, _Personlxml;
        private int _typespos, _typespos_withSold, _toprecord, _fromQuantity, _toQuantity, _postypes;
        private SqlDateTime _Datefrompos, _datetopos, _dateFrom, _dateTo;
        private Decimal _Amounttopos , _Amountfrompos;
        #endregion

        #region Class Property Declarations
        public SqlDateTime datetopos
        {
            get
            {
                return _datetopos;
            }
            set
            {

                _datetopos = value;
            }
        }

        public int TyesPosWithSold
        {
            get
            {
                return _typespos_withSold;
            }
            set
            {

                _typespos_withSold = value;
            }
        }
        public SqlDateTime Datefrompos
        {
            get
            {
                return _Datefrompos;
            }
            set
            {

                _Datefrompos = value;
            }
        }
        
             public int PosTypes
        {
            get
            {
                return _postypes;
            }
            set
            {

                _postypes = value;
            }
        }
        public SqlDateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
            }
        }

        public SqlDateTime DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                _dateTo = value;
            }
        }

        public SqlString Servername
        {
            get
            {
                return _Servername;
            }
            set
            {

                _Servername = value;
            }
        }

        public SqlString Dbname
        {
            get
            {
                return _Dbname;
            }
            set
            {

                _Dbname = value;
            }
        }
        public int FromQuantity
        {
            get
            {
                return _fromQuantity;
            }
            set
            {

                _fromQuantity = value;
            }
        }
        public int ToQuantity
        {
            get
            {
                return _toQuantity;
            }
            set
            {

                _toQuantity = value;
            }
        }
        public int Toprecord
        {
            get
            {
                return _toprecord;
            }
            set
            {

                _toprecord = value;
            }
        }
        public Decimal Amountfrompos
        {
            get
            {
                return _Amountfrompos;
            }
            set
            {

                _Amountfrompos = value;
            }
        }
        public Decimal Amounttopos
        {
            get
            {
                return _Amounttopos;
            }
            set
            {

                _Amounttopos = value;
            }
        }
        public int  TyesPos
        {
            get
            {
                return _typespos;
            }
            set
            {

                _typespos = value;
            }
        }
        public SqlString LocationXML
        {
            get
            {
                return _LocationXML;
            }
            set
            {

                _LocationXML = value;
            }
        }

        public SqlString BusnesXML
        {
            get
            {
                return _BusnesXML;
            }
            set
            {

                _BusnesXML = value;
            }
        }
        public SqlString Personlxml
        {
            get
            {
                return _Personlxml;
            }
            set
            {

                _Personlxml = value;
            }
        }
        public SqlString ProductXml
        {
            get
            {
                return _ProductXml;
            }
            set
            {

                _ProductXml = value;
            }
        }
        public SqlString POSXML
        {
            get
            {
                return _POSXML;
            }
            set
            {

                _POSXML = value;
            }
        }
        public SqlString RouteXML
        {
            get
            {
                return _RouteXML;
            }
            set
            {

                _RouteXML = value;
            }
        }
        public SqlString DistXML
        {
            get
            {
                return _DistXML;
            }
            set
            {

                _DistXML = value;
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
        public SqlDateTime? From_Date
        {
            get
            {
                return _FromDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _FromDate = value;
            }
        }

        public SqlDateTime? TO_Date
        {
            get
            {
                return _ToDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _ToDate = value;
            }
        }


        public SqlString Distributor_Code
        {
            get
            {
                return _distributor_Code;
            }
            set
            {
                //SqlString distributor_CodeTmp = (SqlString)value;
                //if (distributor_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Distributor_Code", "Distributor_Code can't be NULL");
                //}
                _distributor_Code = value;
            }
        }

        public int? Parent_ID
        {
            get
            {
                return _parent_ID;
            }
            set
            {
                //SqlInt32 company_IDTmp = (SqlInt32)value;
                //if (company_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                //}
                _parent_ID = value;
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
                //SqlInt32 company_IDTmp = (SqlInt32)value;
                //if (company_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                //}
                _company_ID = value;
            }
        }

        public SqlInt32 Batch_ID
        {
            get
            {
                return _Batch_ID;
            }
            set
            {
                _Batch_ID = value;
            }
        }

        public SqlInt32 Price_ID
        {
            get
            {
                return _Price_ID;
            }
            set
            {
                _Price_ID = value;
            }
        }

        public SqlBoolean TransactionFlag
        {
            get
            {
                return _transactionFlag;
            }
            set
            {
                _transactionFlag = value;
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
                //SqlInt32 company_IDOldTmp = (SqlInt32)value;
                //if (company_IDOldTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Company_IDOld", "Company_IDOld can't be NULL");
                //}
                _company_IDOld = value;
            }
        }


        public SqlInt32 Location_Setup_ID
        {
            get
            {
                return _location_Setup_ID;
            }
            set
            {
                //SqlInt32 location_Setup_IDTmp = (SqlInt32)value;
                //if (location_Setup_IDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Location_Setup_ID", "Location_Setup_ID can't be NULL");
                //}
                _location_Setup_ID = value;
            }
        }


        public SqlString Distributor_Name
        {
            get
            {
                return _distributor_Name;
            }
            set
            {
                //SqlString distributor_NameTmp = (SqlString)value;
                //if (distributor_NameTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Distributor_Name", "Distributor_Name can't be NULL");
                //}
                _distributor_Name = value;
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
                //SqlString addressTmp = (SqlString)value;
                //if (addressTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Address", "Address can't be NULL");
                //}
                _address = value;
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
                //SqlString owner_NameTmp = (SqlString)value;
                //if (owner_NameTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Owner_Name", "Owner_Name can't be NULL");
                //}
                _owner_Name = value;
            }
        }


        public SqlInt32 Registration_Type_ID
        {
            get
            {
                return _registration_Type_ID;
            }
            set
            {
                SqlInt32 registration_Type_IDTmp = (SqlInt32)value;
                if (registration_Type_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Registration_Type_ID", "Registration_Type_ID can't be NULL");
                }
                _registration_Type_ID = value;
            }
        }
        public SqlInt32 Registration_Type_IDOld
        {
            get
            {
                return _registration_Type_IDOld;
            }
            set
            {
                //SqlInt32 registration_Type_IDOldTmp = (SqlInt32)value;
                //if (registration_Type_IDOldTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Registration_Type_IDOld", "Registration_Type_IDOld can't be NULL");
                //}
                _registration_Type_IDOld = value;
            }
        }


        public SqlString Tax_Number
        {
            get
            {
                return _tax_Number;
            }
            set
            {
                //SqlString tax_NumberTmp = (SqlString)value;
                //if (tax_NumberTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Tax_Number", "Tax_Number can't be NULL");
                //}
                _tax_Number = value;
            }
        }


        public SqlString Phone1
        {
            get
            {
                return _phone1;
            }
            set
            {
                //SqlString phone1Tmp = (SqlString)value;
                //if (phone1Tmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Phone1", "Phone1 can't be NULL");
                //}
                _phone1 = value;
            }
        }


        public SqlString Phone2
        {
            get
            {
                return _phone2;
            }
            set
            {
                //SqlString phone2Tmp = (SqlString)value;
                //if (phone2Tmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Phone2", "Phone2 can't be NULL");
                //}
                _phone2 = value;
            }
        }


        public SqlString Mobile_No
        {
            get
            {
                return _mobile_No;
            }
            set
            {
                //SqlString mobile_NoTmp = (SqlString)value;
                //if (mobile_NoTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Mobile_No", "Mobile_No can't be NULL");
                //}
                _mobile_No = value;
            }
        }


        public SqlString UAN_Number
        {
            get
            {
                return _uAN_Number;
            }
            set
            {
                //SqlString uAN_NumberTmp = (SqlString)value;
                //if (uAN_NumberTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("UAN_Number", "UAN_Number can't be NULL");
                //}
                _uAN_Number = value;
            }
        }


        public int? Fax_Number
        {
            get
            {
                return _fax_Number;
            }
            set
            {
                //SqlInt32 fax_NumberTmp = (SqlInt32)value;
                //if (fax_NumberTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Fax_Number", "Fax_Number can't be NULL");
                //}
                _fax_Number = value;
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
                //SqlString emailTmp = (SqlString)value;
                //if (emailTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Email", "Email can't be NULL");
                //}
                _email = value;
            }
        }
        public SqlString Tempxml
        {
            get
            {
                return _Tempxml;
            }
            set
            {

                _Tempxml = value;
            }
        }

        public SqlString URL
        {
            get
            {
                return _uRL;
            }
            set
            {
                //SqlString uRLTmp = (SqlString)value;
                //if (uRLTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("URL", "URL can't be NULL");
                //}
                _uRL = value;
            }
        }


        public int? Post_Code
        {
            get
            {
                return _post_Code;
            }
            set
            {
                //SqlInt32 post_CodeTmp = (SqlInt32)value;
                //if (post_CodeTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Post_Code", "Post_Code can't be NULL");
                //}
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
                //SqlString telegraph_AddTmp = (SqlString)value;
                //if (telegraph_AddTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Telegraph_Add", "Telegraph_Add can't be NULL");
                //}
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
                //SqlString railway_StationTmp = (SqlString)value;
                //if (railway_StationTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Railway_Station", "Railway_Station can't be NULL");
                //}
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
                //SqlString police_StationTmp = (SqlString)value;
                //if (police_StationTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Police_Station", "Police_Station can't be NULL");
                //}
                _police_Station = value;
            }
        }


        public decimal? Capital_Invest
        {
            get
            {
                return _capital_Invest;
            }
            set
            {
                //SqlDecimal capital_InvestTmp = (SqlDecimal)value;
                //if (capital_InvestTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Capital_Invest", "Capital_Invest can't be NULL");
                //}
                _capital_Invest = value;
            }
        }


        public SqlDecimal Current_Balance
        {
            get
            {
                return _current_Balance;
            }
            set
            {
                //SqlDecimal current_BalanceTmp = (SqlDecimal)value;
                //if (current_BalanceTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Current_Balance", "Current_Balance can't be NULL");
                //}
                _current_Balance = value;
            }
        }


        public SqlDateTime Date_Of_Join
        {
            get
            {
                return _date_Of_Join;
            }
            set
            {
                //SqlDateTime date_Of_JoinTmp = (SqlDateTime)value;
                //if (date_Of_JoinTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Date_Of_Join", "Date_Of_Join can't be NULL");
                //}
                _date_Of_Join = value;
            }
        }


        public SqlDateTime Working_Date
        {
            get
            {
                return _working_Date;
            }
            set
            {
                //SqlDateTime working_DateTmp = (SqlDateTime)value;
                //if (working_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Working_Date", "Working_Date can't be NULL");
                //}
                _working_Date = value;
            }
        }


        public SqlString Day_Off
        {
            get
            {
                return _day_Off;
            }
            set
            {
                //SqlString day_OffTmp = (SqlString)value;
                //if (day_OffTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Day_Off", "Day_Off can't be NULL");
                //}
                _day_Off = value;
            }
        }


        public SqlString Active_Status
        {
            get
            {
                return _active_Status;
            }
            set
            {
                //SqlString active_StatusTmp = (SqlString)value;
                //if (active_StatusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Active_Status", "Active_Status can't be NULL");
                //}
                _active_Status = value;
            }
        }


        public SqlBoolean Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                //SqlBoolean is_ActiveTmp = (SqlBoolean)value;
                //if (is_ActiveTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Is_Active", "Is_Active can't be NULL");
                //}
                _is_Active = value;
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
                //SqlString statusTmp = (SqlString)value;
                //if (statusTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                //}
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

        public int? TypeRecID
        {
            get
            {
                return _TypeRecID;
            }
            set
            {
                _TypeRecID = value;
            }
        }
        public int? Tax
        {
            get
            {
                return _Tax;
            }
            set
            {
                _Tax = value;
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

        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                SqlInt32 _errorCodeTmp = (SqlInt32)value;
                if (_errorCodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ErrorCode", "ErrorCode can't be NULL");
                }
                _errorCode = value;
            }
        }
        public int? DiscountId
        {
            get
            {
                return _DiscountId;
            }
            set
            {
                _DiscountId = value;
            }
        }

        #endregion
    }
}
