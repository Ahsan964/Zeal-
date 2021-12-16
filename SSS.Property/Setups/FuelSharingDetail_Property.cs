using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class FuelSharingDetail_Property
    {
        #region Class Member Declarations
        private SqlDateTime _insertedOn, _closingDate, _updatedOn;
        private SqlDecimal _totalFuelAmount, _totalTravelingInKm;
        private SqlInt32 _updatedBy, _id, _insertedBy, _endReading, _distributorId, _vehicleId, _deliveryManId, _startReading, _fuelTypeId;
        private SqlString _vehicleNo, _status;
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


        public SqlInt32 VehicleId
        {
            get
            {
                return _vehicleId;
            }
            set
            {
                _vehicleId = value;
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


        public SqlDateTime ClosingDate
        {
            get
            {
                return _closingDate;
            }
            set
            {
                _closingDate = value;
            }
        }


        public SqlInt32 FuelTypeId
        {
            get
            {
                return _fuelTypeId;
            }
            set
            {
                _fuelTypeId = value;
            }
        }


        public SqlInt32 StartReading
        {
            get
            {
                return _startReading;
            }
            set
            {
                _startReading = value;
            }
        }


        public SqlInt32 EndReading
        {
            get
            {
                return _endReading;
            }
            set
            {
                _endReading = value;
            }
        }


        public SqlDecimal TotalTravelingInKm
        {
            get
            {
                return _totalTravelingInKm;
            }
            set
            {
                _totalTravelingInKm = value;
            }
        }


        public SqlDecimal TotalFuelAmount
        {
            get
            {
                return _totalFuelAmount;
            }
            set
            {
                _totalFuelAmount = value;
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
