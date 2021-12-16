using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property
{
    public class Capability_Property
    {
        #region Class Member Declarations
        
        
        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName;  
        
        
        private SqlDateTime _insertionDate;
        private SqlInt32 _insertBy, _id, _accessTypeEnum, _pageId, _pageIdOld, operated_By, _userId;
        private SqlString _capabilityName, _status, _roles, _pagePath;
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
                //if (idTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Id", "Id can't be NULL");
                //}
                _id = value;
            }
        }


        public SqlString CapabilityName
        {
            get
            {
                return _capabilityName;
            }
            set
            {
                SqlString capabilityNameTmp = (SqlString)value;
                if (capabilityNameTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("CapabilityName", "CapabilityName can't be NULL");
                }
                _capabilityName = value;
            }
        }


        public SqlInt32 PageId
        {
            get
            {
                return _pageId;
            }
            set
            {
                SqlInt32 pageIdTmp = (SqlInt32)value;
                if (pageIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PageId", "PageId can't be NULL");
                }
                _pageId = value;
            }
        }
        public SqlInt32 PageIdOld
        {
            get
            {
                return _pageIdOld;
            }
            set
            {
                SqlInt32 pageIdOldTmp = (SqlInt32)value;
                if (pageIdOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PageIdOld", "PageIdOld can't be NULL");
                }
                _pageIdOld = value;
            }
        }


        public SqlInt32 AccessTypeEnum
        {
            get
            {
                return _accessTypeEnum;
            }
            set
            {
                SqlInt32 accessTypeEnumTmp = (SqlInt32)value;
                if (accessTypeEnumTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("AccessTypeEnum", "AccessTypeEnum can't be NULL");
                }
                _accessTypeEnum = value;
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

        public SqlString Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
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

        public SqlInt32 UserID
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

        public SqlString PagePath
        {
            get
            {
                return _pagePath;
            }
            set
            {
                _pagePath = value;
            }
        }


        #endregion
    }
}
