using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class VehicleSharingDetail_Property
    {
        #region Class Member Declarations
			private SqlDateTime		_insertedOn, _updatedOn;
			private SqlDecimal		_monthlyRent, _percentage, _amount;
			private SqlInt32		_updatedBy, _insertedBy, _distributorId, _id, _vehicleID, _deliveryManId;
			private SqlString		_vehicleNo, _status, _claimstatus;
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


            public SqlInt32 DeliveryManId
            {
                get
                {
                    return _deliveryManId;
                }
                set
                {
                    _deliveryManId = value;
                }
            }


            public SqlInt32 VehicleID
            {
                get
                {
                    return _vehicleID;
                }
                set
                {
                    _vehicleID = value;
                }
            }


            public SqlString VehicleNo
            {
                get
                {
                    return _vehicleNo;
                }
                set
                {
                    _vehicleNo = value;
                }
            }


            public SqlDecimal MonthlyRent
            {
                get
                {
                    return _monthlyRent;
                }
                set
                {
                    _monthlyRent = value;
                }
            }


            public SqlDecimal Percentage
            {
                get
                {
                    return _percentage;
                }
                set
                {
                    _percentage = value;
                }
            }


            public SqlDecimal Amount
            {
                get
                {
                    return _amount;
                }
                set
                {
                    _amount = value;
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

            public SqlString ClaimStatus
            {
                get
                {
                    return _claimstatus;
                }
                set
                {
                    _claimstatus = value;
                }
            }

            #endregion
	
    }
}
