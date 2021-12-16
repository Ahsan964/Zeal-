using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
namespace SSS.Property.Setups
{
    public  class User_Role_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate;
        private SqlInt32 _insertBy, _id, _userId, _userIdOld, _roleId, _roleIdOld;
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


        public SqlInt32 UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                SqlInt32 userIdTmp = (SqlInt32)value;
                if (userIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("UserId", "UserId can't be NULL");
                }
                _userId = value;
            }
        }
        public SqlInt32 UserIdOld
        {
            get
            {
                return _userIdOld;
            }
            set
            {
                SqlInt32 userIdOldTmp = (SqlInt32)value;
                if (userIdOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("UserIdOld", "UserIdOld can't be NULL");
                }
                _userIdOld = value;
            }
        }


        public SqlInt32 RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                SqlInt32 roleIdTmp = (SqlInt32)value;
                if (roleIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("RoleId", "RoleId can't be NULL");
                }
                _roleId = value;
            }
        }
        public SqlInt32 RoleIdOld
        {
            get
            {
                return _roleIdOld;
            }
            set
            {
                SqlInt32 roleIdOldTmp = (SqlInt32)value;
                if (roleIdOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("RoleIdOld", "RoleIdOld can't be NULL");
                }
                _roleIdOld = value;
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
                SqlInt32 insertByTmp = (SqlInt32)value;
                if (insertByTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("InsertBy", "InsertBy can't be NULL");
                }
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
                SqlDateTime insertionDateTmp = (SqlDateTime)value;
                if (insertionDateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("InsertionDate", "InsertionDate can't be NULL");
                }
                _insertionDate = value;
            }
        }
        #endregion


    }
}
