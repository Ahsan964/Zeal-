using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SSS.Property.Setups
{
    public class MiscellaneousSetup_Property
    {
        #region Class Member Declarations
			private SqlDateTime		 _updationDate, _insertionDate;
			private SqlInt32		_insertBy, _updateBy, _id, _datarefid;
            private SqlString       _status, _expenseName, _expenseDescription;
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


            public SqlString ExpenseName
            {
                get
                {
                    return _expenseName;
                }
                set
                {
                    _expenseName = value;
                }
            }


            public SqlString ExpenseDescription
            {
                get
                {
                    return _expenseDescription;
                }
                set
                {
                    _expenseDescription = value;
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

            public SqlInt32 DataRefID
            {
                get
                {
                    return _datarefid;
                }
                set
                {
                    _datarefid = value;
                }
            }

            #endregion
    }
}
