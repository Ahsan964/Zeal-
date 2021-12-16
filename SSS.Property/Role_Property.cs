using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property
{
    public class Role_Property
    {
        #region Class Member Declarations


        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName;


        private SqlDateTime _insertionDate;
        private SqlInt32  _insertBy, _id, _userId, operated_By;
        private SqlString _status,  _active, _roleName;
        #endregion


        #region Class Property Declarations


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

        public SqlInt32 UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }


        public SqlString RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                SqlString roleNameTmp = (SqlString)value;
                if (roleNameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("RoleName", "RoleName can't be NULL");
                }
                _roleName = value;
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


        public SqlString Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        #endregion

    }
}
