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
   public class AchivementProductDetail_Property
    {
        #region Class Member Declarations

        private SqlDateTime _insertion_date;
        private SqlInt32 _iD, _inserted_by, _achivement_MasterId, _product_Id;
        private SqlString _description, _status;

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
                SqlInt32 iDTmp = (SqlInt32)value;
                if (iDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
                }
                _iD = value;
            }
        }

        public SqlInt32 AchivementMasterID
        {
            get
            {
                return _achivement_MasterId;
            }
            set
            {
                SqlInt32 achivementMasterIdTmp = (SqlInt32)value;
                if (achivementMasterIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("AchivementMasterID", "Achivement_MasterId can't be NULL");
                }
                _achivement_MasterId = value;
            }
        }

        public SqlInt32 ProductID
        {
            get
            {
                return _product_Id;
            }
            set
            {
                SqlInt32 productIdTmp = (SqlInt32)value;
                if (productIdTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("ProductID", "Achivement_MasterId can't be NULL");
                }
                _product_Id = value;
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
                return _inserted_by;
            }
            set
            {
                _inserted_by = value;
            }
        }

        public SqlDateTime InsertionDate
        {
            get
            {
                return _insertion_date;
            }
            set
            {
                _insertion_date = value;
            }
        }

        #endregion
    }
}
