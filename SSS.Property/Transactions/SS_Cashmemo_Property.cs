using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Transactions
{
   public class SS_Cashmemo_Property
    {
        #region Class Member Declarations
        private SqlBoolean _processed;
        private SqlDateTime? _document_Date, _operation_Date, _FromDate, _ToDate;
        private SqlDateTime? _deliveryDate;
        private SqlDecimal _total_GST, _net_Amount, _total_Discount, _received_Amount;
        private SqlInt32 _iD, _is_Active, _company_ID, _personnel_ID, operated_By, _PageNum, _PageSize, _pos_ID, _PersonnelRef_ID, _Prp_ID, _Route_ID;
        private SqlString _status, _ref_Document, _ref_Document1, _payment_Terms, _document_No, _record_Table_Name, operation, _narration, _sortColumn, _tableName;
        private DataTable _detailData;

        private SqlInt32? _document_Type_ID, _distributor_ID2, _location_ID, _distributor_ID, _sales_rep_type, _result;
        private int? _TotalRowsNum;
        private string _tempID;
        #endregion



        #region Class Property Declarations

        public SqlInt32? Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public string TempID
        {
            get
            {
                return _tempID;
            }
            set
            {
                _tempID = value;
            }
        }
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

        public SqlDateTime? From_Date
        {
            get
            {
                return _FromDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _FromDate = value;
            }
        }

        public SqlDateTime? TO_Date
        {
            get
            {
                return _ToDate;
            }
            set
            {
                //SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                //if (operation_Date_DateTmp.IsNull)
                //{
                //    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                //}
                _ToDate = value;
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
                _company_ID = value;
            }
        }


        public SqlInt32? Document_Type_ID
        {
            get
            {
                return _document_Type_ID;
            }
            set
            {
                SqlInt32 document_Type_IDTmp = (SqlInt32)value;
                if (document_Type_IDTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Document_Type_ID", "Document_Type_ID can't be NULL");
                }
                _document_Type_ID = value;
            }
        }


        public SqlString Document_No
        {
            get
            {
                return _document_No;
            }
            set
            {
                SqlString document_NoTmp = (SqlString)value;
                if (document_NoTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Document_No", "Document_No can't be NULL");
                }
                _document_No = value;
            }
        }


        public SqlDateTime? Document_Date
        {
            get
            {
                return _document_Date;
            }
            set
            {
                _document_Date = value;
            }
        }


        public SqlInt32? Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }
            set
            {
                _distributor_ID = value;
            }
        }

        public SqlInt32? Distributor_ID2
        {
            get
            {
                return _distributor_ID2;
            }
            set
            {
                _distributor_ID2 = value;
            }
        }


        public SqlInt32 Personnel_ID
        {
            get
            {
                return _personnel_ID;
            }
            set
            {
                _personnel_ID = value;
            }
        }


        public SqlInt32? Location_ID
        {
            get
            {
                return _location_ID;
            }
            set
            {
                _location_ID = value;
            }
        }

        public SqlInt32? Sales_Rep_Type
        {
            get
            {
                return _sales_rep_type;
            }
            set
            {
                _sales_rep_type = value;
            }
        }


        public SqlString Payment_Terms
        {
            get
            {
                return _payment_Terms;
            }
            set
            {
                _payment_Terms = value;
            }
        }


        public SqlDecimal Total_Discount
        {
            get
            {
                return _total_Discount;
            }
            set
            {
                _total_Discount = value;
            }
        }


        public SqlDecimal Total_GST
        {
            get
            {
                return _total_GST;
            }
            set
            {
                _total_GST = value;
            }
        }


        public SqlDecimal Net_Amount
        {
            get
            {
                return _net_Amount;
            }
            set
            {
                _net_Amount = value;
            }
        }


        public SqlDecimal Received_Amount
        {
            get
            {
                return _received_Amount;
            }
            set
            {
                _received_Amount = value;
            }
        }


        public SqlString Narration
        {
            get
            {
                return _narration;
            }
            set
            {
                _narration = value;
            }
        }


        public SqlInt32 Is_Active
        {
            get
            {
                return _is_Active;
            }
            set
            {
                _is_Active = value;
            }
        }


        public SqlString Ref_Document
        {
            get
            {
                return _ref_Document;
            }
            set
            {
                _ref_Document = value;
            }
        }


        public SqlString Ref_Document1
        {
            get
            {
                return _ref_Document1;
            }
            set
            {
                _ref_Document1 = value;
            }
        }

        public SqlString TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        public SqlBoolean Processed
        {
            get
            {
                return _processed;
            }
            set
            {
                _processed = value;
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

        public DataTable DetailData
        {
            get
            {
                return _detailData;
            }
            set
            {
                _detailData = value;
            }
        }


        ///// Extra Properties


        public SqlInt32 Operated_By
        {
            get
            {
                return operated_By;
            }
            set
            {
                SqlInt32 Operated_ByTmp = (SqlInt32)value;
                if (Operated_ByTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operated_By", "Operated_By can't be NULL");
                }
                operated_By = value;
            }
        }



        public SqlInt32 PageNum
        {
            get
            {
                return _PageNum;
            }
            set
            {
                SqlInt32 PageNumTmp = (SqlInt32)value;
                if (PageNumTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PageNum", "PageNum can't be NULL");
                }
                _PageNum = value;
            }
        }

        public SqlInt32 PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                SqlInt32 PageSizeTmp = (SqlInt32)value;
                if (PageSizeTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("PageSize", "PageSize can't be NULL");
                }
                _PageSize = value;
            }
        }

        public int? TotalRowsNum
        {
            get
            {
                return _TotalRowsNum;
            }
            set
            {

                _TotalRowsNum = value;
            }
        }

        public SqlString Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                SqlString record_Table_NameTemp = (SqlString)value;
                if (record_Table_NameTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Record_Table_Name", "Record Table Name can't be NULL");
                }
                _record_Table_Name = value;
            }
        }

        public SqlString Operation
        {
            get
            {
                return operation;
            }
            set
            {
                SqlString OperationTemp = (SqlString)value;
                if (OperationTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operation", "Operation can't be NULL");
                }
                operation = value;
            }
        }

        public SqlString SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                SqlString sortColumnTemp = (SqlString)value;
                if (sortColumnTemp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("SortColumn", "SortColumn can't be NULL");
                }
                _sortColumn = value;
            }
        }







        public SqlDateTime? Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                SqlDateTime operation_Date_DateTmp = (SqlDateTime)value;
                if (operation_Date_DateTmp.IsNull)
                {
                    throw new ArgumentOutOfRangeException("Operation_Date", "Operation_Date can't be NULL");
                }
                _operation_Date = value;
            }
        }


        public SqlInt32 Pos_ID
        {
            get
            {
                return _pos_ID;
            }
            set
            {
                _pos_ID = value;
            }
        }

        public SqlInt32 PersonnelRef_ID
        {
            get
            {
                return _PersonnelRef_ID;
            }
            set
            {
                _PersonnelRef_ID = value;
            }
        }

        public SqlInt32 Route_ID
        {
            get
            {
                return _Route_ID;
            }
            set
            {
                _Route_ID = value;
            }
        }
        public SqlInt32 Prp_ID
        {
            get
            {
                return _Prp_ID;
            }
            set
            {
                _Prp_ID = value;
            }
        }

        public SqlDateTime? DeliveryDate
        {
            get
            {
                return _deliveryDate;
            }
            set
            {
                _deliveryDate = value;
            }
        }







        #endregion
    }
}
