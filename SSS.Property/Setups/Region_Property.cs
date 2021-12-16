using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class Region_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate, _updationDate;
        private SqlInt32 _insertBy, _updationBy, _id, _parentRegionId, operated_By;
        private SqlString _status, _description, _name, _code;
        private string _sortColumn, _tableName;
        #endregion


        #region Class Property Declarations
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

        public SqlInt32 ParentRegionId
        {
            get
            {
                return _parentRegionId;
            }
            set
            {
                SqlInt32 idTmp = (SqlInt32)value;
                if (idTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ParentRegionId", "ParentRegionId can't be NULL");
                }
                _parentRegionId = value;
            }
        }

        public SqlString Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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

        public SqlString Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
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


        public SqlDateTime UpdationDate
        {
            get
            {
                return _updationDate;
            }
            set
            {
                _updationDate = value;
            }
        }


        public SqlInt32 UpdationBy
        {
            get
            {
                return _updationBy;
            }
            set
            {
                _updationBy = value;
            }
        }
        #endregion
    }
}
