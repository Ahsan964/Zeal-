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
    public class Personnel_Setup_Property
    {
        #region Class Member Declarations
        private SqlBoolean _is_Active, _counter_Sale;
        private SqlDateTime _dOB, _dOA, _dateFrom, _dateTo;
        private SqlInt32 _sales_Rep_Type_ID, _sales_Rep_Type_IDOld, _iD, _distributor_Mst_Setup_ID, _distributor_Mst_Setup_IDOld, _company_ID, _company_IDOld, _parent_ID, _parent_IDOld, _working_Nature, _operated_By;
        private SqlString _qualificationID,_personnelsetupxml,_xmlOutput, _blood_Group, _status, _dLicense_No, _vehicle_ID, _address1, _address2, _father_Name, _personnel_Code, _personnel_Name, _email, _police_Station, _mobile_No, _nIC, _phone_No;
        private string _sortColumn, _tableName;
        private Int32 _pageNum, _pageSize, _totalRowsNum;
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



        public SqlString PersonnelSetupxml
        {
            get
            {
                return _personnelsetupxml;
            }
            set
            {
                _personnelsetupxml = value;
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
                SqlInt32 company_IDOldTmp = (SqlInt32)value;
                if (company_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Company_IDOld", "Company_IDOld can't be NULL");
                }
                _company_IDOld = value;
            }
        }


        public SqlInt32 Distributor_Mst_Setup_ID
        {
            get
            {
                return _distributor_Mst_Setup_ID;
            }
            set
            {
                _distributor_Mst_Setup_ID = value;
            }
        }
        public SqlInt32 Distributor_Mst_Setup_IDOld
        {
            get
            {
                return _distributor_Mst_Setup_IDOld;
            }
            set
            {
                SqlInt32 distributor_Mst_Setup_IDOldTmp = (SqlInt32)value;
                if (distributor_Mst_Setup_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Distributor_Mst_Setup_IDOld", "Distributor_Mst_Setup_IDOld can't be NULL");
                }
                _distributor_Mst_Setup_IDOld = value;
            }
        }


        public SqlInt32 Parent_ID
        {
            get
            {
                return _parent_ID;
            }
            set
            {
                _parent_ID = value;
            }
        }
        public SqlInt32 Parent_IDOld
        {
            get
            {
                return _parent_IDOld;
            }
            set
            {
                SqlInt32 parent_IDOldTmp = (SqlInt32)value;
                if (parent_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Parent_IDOld", "Parent_IDOld can't be NULL");
                }
                _parent_IDOld = value;
            }
        }


        public SqlString Personnel_Code
        {
            get
            {
                return _personnel_Code;
            }
            set
            {
                SqlString personnel_CodeTmp = (SqlString)value;
                if (personnel_CodeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Personnel_Code", "Personnel_Code can't be NULL");
                }
                _personnel_Code = value;
            }
        }


        public SqlString Personnel_Name
        {
            get
            {
                return _personnel_Name;
            }
            set
            {
                SqlString personnel_NameTmp = (SqlString)value;
                if (personnel_NameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Personnel_Name", "Personnel_Name can't be NULL");
                }
                _personnel_Name = value;
            }
        }


        public SqlInt32 Sales_Rep_Type_ID
        {
            get
            {
                return _sales_Rep_Type_ID;
            }
            set
            {
                SqlInt32 sales_Rep_Type_IDTmp = (SqlInt32)value;
                if (sales_Rep_Type_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Sales_Rep_Type_ID", "Sales_Rep_Type_ID can't be NULL");
                }
                _sales_Rep_Type_ID = value;
            }
        }
        public SqlInt32 Sales_Rep_Type_IDOld
        {
            get
            {
                return _sales_Rep_Type_IDOld;
            }
            set
            {
                SqlInt32 sales_Rep_Type_IDOldTmp = (SqlInt32)value;
                if (sales_Rep_Type_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Sales_Rep_Type_IDOld", "Sales_Rep_Type_IDOld can't be NULL");
                }
                _sales_Rep_Type_IDOld = value;
            }
        }


        public SqlString Father_Name
        {
            get
            {
                return _father_Name;
            }
            set
            {
                _father_Name = value;
            }
        }


        public SqlString Address1
        {
            get
            {
                return _address1;
            }
            set
            {
                _address1 = value;
            }
        }


        public SqlString Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                _address2 = value;
            }
        }


        public SqlString NIC
        {
            get
            {
                return _nIC;
            }
            set
            {
                _nIC = value;
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


        public SqlString Mobile_No
        {
            get
            {
                return _mobile_No;
            }
            set
            {
                _mobile_No = value;
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


        public SqlDateTime DOB
        {
            get
            {
                return _dOB;
            }
            set
            {
                _dOB = value;
            }
        }


        public SqlDateTime DOA
        {
            get
            {
                return _dOA;
            }
            set
            {
                _dOA = value;
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


        public SqlString QualificationID
        {
            get
            {
                return _qualificationID;
            }
            set
            {
                _qualificationID = value;
            }
        }


        public SqlString Vehicle_ID
        {
            get
            {
                return _vehicle_ID;
            }
            set
            {
                _vehicle_ID = value;
            }
        }


        public SqlString DLicense_No
        {
            get
            {
                return _dLicense_No;
            }
            set
            {
                _dLicense_No = value;
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


        public SqlBoolean Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                _is_Active = value;
            }
        }


        public SqlString Blood_Group
        {
            get
            {
                return _blood_Group;
            }
            set
            {
                _blood_Group = value;
            }
        }


        public SqlInt32 Working_Nature
        {
            get
            {
                return _working_Nature;
            }
            set
            {
                _working_Nature = value;
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
                return _operated_By;
            }
            set
            {
                _operated_By = value;
            }
        }
        #endregion


    }
}
