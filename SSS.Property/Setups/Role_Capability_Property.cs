using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public  class Role_Capability_Property
    {

        #region Class Member Declarations

        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName;


        // private SqlBoolean _isVisibleInMenu;
        private SqlDateTime _insertionDate;


        private SqlInt32 _id, _roleid, _capabilityid, _insertBy, operated_By;

       
        #endregion
        #region Class Property Declarations

        public string XmlPageAccessBulkInsertion { get; set; }
        public string XmlPageAccessBulkDeletion { get; set; }



        public SqlInt32 Id
        {
            get
            {
                return _id;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                }
                _id = value;
            }
        }

        public SqlInt32 RoleId
        {
            get
            {
                return _roleid;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("roleid", "roleid can't be NULL");
                }
                _roleid = value;
            }
        }



        public SqlInt32 CapabilityId
        {
            get
            {
                return _capabilityid;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("roleid", "roleid can't be NULL");
                }
                _capabilityid = value;
            }
        }










        public SqlInt32 InsertBy
        {
            get
            {
                return _insertBy;
            }
            set
            {
                _insertBy = value;
            }
        }


        public SqlDateTime InsertionDate
        {
            get
            {
                return _insertionDate;
            }
            set
            {
                _insertionDate = value;
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
