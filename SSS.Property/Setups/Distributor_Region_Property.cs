using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class Distributor_Region_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertionDate, _updationDate;
        private SqlInt32 _insertBy, _updationBy, _id, _distributorId;
        private SqlString _status, _regionId;
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


        public SqlInt32 DistributorId
        {
            get
            {
                return _distributorId;
            }
            set
            {
                _distributorId = value;
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
