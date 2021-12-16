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
    public class Personel_Setup_Property
    {
        #region Class Member Declarations
        private SqlBoolean _is_Active, _counter_Sale;
        private SqlDateTime _dOB, _dOA;
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private SqlInt32 _working_Nature, _iD, _sales_Rep_Type_ID, _sales_Rep_Type_IDOld, _parent_ID;
        private SqlString _status, _mobile_No, _blood_Group, _dLicense_No, _phone_No, _personnel_Name, _father_Name, _personnel_Code, _short_Name, _nIC, _address1, _address2, _vehicle_ID, _qualificationID;
        private string _sortColumn;
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


        public SqlString Personnel_Code
        {
            get
            {
                return _personnel_Code;
            }
            set
            {
                _personnel_Code = value;
            }
        }


        public SqlString Short_Name
        {
            get
            {
                return _short_Name;
            }
            set
            {
                _short_Name = value;
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
