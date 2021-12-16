using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Transactions
{
    public class PO_Master_Property
    {
        #region Class Member Declarations
        private SqlDateTime _document_Date;
        private SqlInt32 _document_No, _distributor_ID, _iD, _company_ID;
        private SqlString _status;
        #endregion
        public List<PO_Detail_Property> objPO_Detail_Property = new List<PO_Detail_Property>();

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


        public SqlInt32 Company_ID
        {
            get
            {
                return _company_ID;
            }
            set
            {
                SqlInt32 company_IDTmp = (SqlInt32)value;
                if (company_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Company_ID", "Company_ID can't be NULL");
                }
                _company_ID = value;
            }
        }


        public SqlInt32 Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }
            set
            {
                SqlInt32 distributor_IDTmp = (SqlInt32)value;
                if (distributor_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Distributor_ID", "Distributor_ID can't be NULL");
                }
                _distributor_ID = value;
            }
        }


        public SqlInt32 Document_No
        {
            get
            {
                return _document_No;
            }
            set
            {
                SqlInt32 document_NoTmp = (SqlInt32)value;
                if (document_NoTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Document_No", "Document_No can't be NULL");
                }
                _document_No = value;
            }
        }


        public SqlDateTime Document_Date
        {
            get
            {
                return _document_Date;
            }
            set
            {
                SqlDateTime document_DateTmp = (SqlDateTime)value;
                if (document_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Document_Date", "Document_Date can't be NULL");
                }
                _document_Date = value;
            }
        }

        public DateTime Document_FromDate;
        public DateTime Document_ToDate;
        
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
