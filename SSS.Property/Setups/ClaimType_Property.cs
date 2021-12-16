using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class ClaimType_Property
    {

        #region Class Member Declarations
        private SqlDateTime _insertedOn, _updatedOn;
        private SqlInt32 _insertedBy, _updatedBy, _id, _claimTypeId;
        private SqlString _status, _description, _claimType;
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


        public SqlInt32 ClaimTypeId
        {
            get
            {
                return _claimTypeId;
            }
            set
            {
                _claimTypeId = value;
            }
        }


        public SqlString ClaimType
        {
            get
            {
                return _claimType;
            }
            set
            {
                _claimType = value;
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


        public SqlInt32 InsertedBy
        {
            get
            {
                return _insertedBy;
            }
            set
            {
                _insertedBy = value;
            }
        }


        public SqlDateTime InsertedOn
        {
            get
            {
                return _insertedOn;
            }
            set
            {
                _insertedOn = value;
            }
        }


        public SqlInt32 UpdatedBy
        {
            get
            {
                return _updatedBy;
            }
            set
            {
                _updatedBy = value;
            }
        }


        public SqlDateTime UpdatedOn
        {
            get
            {
                return _updatedOn;
            }
            set
            {
                _updatedOn = value;
            }
        }
        #endregion
	
    }
}
