using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class Page_Property
    {
        #region Class Member Declarations

        private Int32? _pageNum, _pageSize, _totalRowsNum;
        private string _sortColumn, _tableName ;
       

        private         SqlBoolean _isVisibleInMenu;
        private SqlDateTime  _insertionDate;
        private SqlInt32  _linksOrder, _id, operated_By,     _parentPageIdOld, _insertBy;
        private SqlInt32? _parentPageId;

        private  SqlString _status,  _tracking, _title, _heading, _path, _description;
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


        public SqlString Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }


        public SqlString Heading
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
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


        public SqlString Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
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


        public SqlInt32? ParentPageId
        {
            get
            {
                return _parentPageId;
            }
            set
            {
                _parentPageId = value;
            }
        }
        public SqlInt32 ParentPageIdOld
        {
            get
            {
                return _parentPageIdOld;
            }
            set
            {
                _parentPageIdOld = value;
            }
        }


        public SqlInt32 LinksOrder
        {
            get
            {
                return _linksOrder;
            }
            set
            {
                _linksOrder = value;
            }
        }


        public SqlString Tracking
        {
            get
            {
                return _tracking;
            }
            set
            {
                _tracking = value;
            }
        }


        public         SqlBoolean IsVisibleInMenu
        {
            get
            {
                return _isVisibleInMenu;
            }
            set
            {
                _isVisibleInMenu = value;
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
