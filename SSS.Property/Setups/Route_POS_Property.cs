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
    public class Route_POS_Property
    {
        #region Class Member Declarations
        private SqlInt32 _pOS_ID, _pOS_IDOld, _route_ID, _route_IDOld, _iD;
        private SqlInt32? _priority;
        private Decimal? _kilometers;
        private SqlString _status;
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
                //SqlInt32 iDTmp = (SqlInt32)value;
                //if (iDTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                //}
                _iD = value;
            }
        }


        public SqlInt32 Route_ID
        {
            get
            {
                return _route_ID;
            }
            set
            {
                SqlInt32 route_IDTmp = (SqlInt32)value;
                if (route_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Route_ID", "Route_ID can't be NULL");
                }
                _route_ID = value;
            }
        }
        public SqlInt32 Route_IDOld
        {
            get
            {
                return _route_IDOld;
            }
            set
            {
                SqlInt32 route_IDOldTmp = (SqlInt32)value;
                if (route_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Route_IDOld", "Route_IDOld can't be NULL");
                }
                _route_IDOld = value;
            }
        }


        public SqlInt32 POS_ID
        {
            get
            {
                return _pOS_ID;
            }
            set
            {
                SqlInt32 pOS_IDTmp = (SqlInt32)value;
                if (pOS_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("POS_ID", "POS_ID can't be NULL");
                }
                _pOS_ID = value;
            }
        }
        public SqlInt32 POS_IDOld
        {
            get
            {
                return _pOS_IDOld;
            }
            set
            {
                SqlInt32 pOS_IDOldTmp = (SqlInt32)value;
                if (pOS_IDOldTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("POS_IDOld", "POS_IDOld can't be NULL");
                }
                _pOS_IDOld = value;
            }
        }

        public SqlInt32? Priority
        {
            get
            {
                return _priority;
            }
            set
            {                
                _priority = value;
            }
        }

        public Decimal? Kilometers
        {
            get
            {
                return _kilometers;
            }
            set
            {
                _kilometers = value;
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
                SqlString statusTmp = (SqlString)value;
                if (statusTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Status", "Status can't be NULL");
                }
                _status = value;
            }
        }
        #endregion

    }
}
