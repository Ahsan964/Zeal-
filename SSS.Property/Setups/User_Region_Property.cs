using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class User_Region_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate, _updationDate;
        private SqlInt32 _insertBy, _updationBy, _id, _userId, _discountId, operated_By;
        private SqlString _status, _regionId, _description, _tableName;
        private Int32? _pageNum, _pageSize, _totalRowsNum, _sNo;
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

       
        public int? SNo
        {
            get
            {
                return _sNo;
            }
            set
            {
                _sNo = value;
            }
        }
        public SqlString TableName
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
                SqlInt32 Operated_ByTmp = (SqlInt32)value;
                if (Operated_ByTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                }
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


        public SqlString RegionId
        {
            get
            {
                return _regionId;
            }
            set
            {
                _regionId = value;
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
        public SqlInt32 DiscountId
        {
            get
            {
                return _discountId;
            }
            set
            {
                _discountId = value;
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

        public SqlString Description
        {
            get
            {
                return _description;
            }
            set
            {
                SqlString descriptionTmp = (SqlString)value;
                if (descriptionTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Description", "Description can't be NULL");
                }
                _description = value;
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
