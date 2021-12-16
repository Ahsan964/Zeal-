using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class FuelSetUp_Property
    {
        #region Class Member Declarations
			private SqlDateTime		_validFrom, _updationDate, _insertionDate, _validTo;
			private SqlDecimal		_consumptionInKm, _fuelRate;
			private SqlInt32		_insertBy, _updateBy, _fuelTypeId, _id;
			private SqlString		_status, _description;
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


            public SqlDecimal FuelRate
            {
                get
                {
                    return _fuelRate;
                }
                set
                {
                    _fuelRate = value;
                }
            }


            public SqlDecimal ConsumptionInKm
            {
                get
                {
                    return _consumptionInKm;
                }
                set
                {
                    _consumptionInKm = value;
                }
            }


            public SqlDateTime ValidFrom
            {
                get
                {
                    return _validFrom;
                }
                set
                {
                    _validFrom = value;
                }
            }


            public SqlDateTime ValidTo
            {
                get
                {
                    return _validTo;
                }
                set
                {
                    _validTo = value;
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


            public SqlInt32 UpdateBy
            {
                get
                {
                    return _updateBy;
                }
                set
                {
                    _updateBy = value;
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
            #endregion
    }
}
