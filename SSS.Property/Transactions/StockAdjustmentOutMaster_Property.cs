using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SSS.Property.Transactions
{
    public class StockAdjustmentOutMaster_Property : AbstractValidator<StockAdjustmentOutMaster_Property>
    {
        #region Class Member Declarations

        int _id;
        int _document_Type_ID;
        string _document_No;
        DateTime? _document_Date;
        int? _distributor_ID;
        int? _personnel_ID;
        int? _location_ID;
        string _sales_Type;
        string _payment_Terms;
        decimal? _total_Discount;
        decimal? _total_GST;
        decimal? _net_Amount;
        decimal? _received_Amount;
        string _narration;
        int? _is_Active;
        string _ref_Document;
        string _ref_Document1;
        bool? _processed;
        int? _pageNum;
        int? _pageSize;
        int? _totalRowsNum;
        string _sortColumn;
        string _record_Table_Name;
        string _operation;
        int? _operated_By;
        DateTime? _operation_Date;
        private bool _isValid = true;

        FluentValidation.Results.ValidationResult validationResult;
        List<FluentValidation.Results.ValidationFailure> _errors = new List<FluentValidation.Results.ValidationFailure>();

        #endregion

        #region Properties

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int Document_Type_ID
        {
            get
            {
                return _document_Type_ID;
            }

            set
            {
                _document_Type_ID = value;
            }
        }

        public string Document_No
        {
            get
            {
                return _document_No;
            }

            set
            {
                _document_No = value;
            }
        }

        public DateTime? Document_Date
        {
            get
            {
                return _document_Date;
            }

            set
            {
                _document_Date = value;

                RuleFor(stockajdout => stockajdout.Document_Date).NotEmpty().WithMessage("Document Date is must");
                validationResult = this.Validate(this, "Document_Date");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public int? Distributor_ID
        {
            get
            {
                return _distributor_ID;
            }

            set
            {
                _distributor_ID = value;

                RuleFor(stockajdout => stockajdout.Distributor_ID).NotEmpty().WithMessage("Distributor ID is must");
                validationResult = this.Validate(this, "Distributor_ID");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public int? Personnel_ID
        {
            get
            {
                return _personnel_ID;
            }

            set
            {
                _personnel_ID = value;

                RuleFor(stockajdout => stockajdout.Personnel_ID).NotEmpty().WithMessage("Personnel ID is must");
                validationResult = this.Validate(this, "Personnel_ID");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public int? Location_ID
        {
            get
            {
                return _location_ID;
            }

            set
            {
                _location_ID = value;

                RuleFor(stockajdout => stockajdout.Location_ID).NotEmpty().WithMessage("Location ID is must");
                validationResult = this.Validate(this, "Location_ID");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public string Sales_Type
        {
            get
            {
                return _sales_Type;
            }

            set
            {
                _sales_Type = value;

                RuleFor(stockajdout => stockajdout.Sales_Type).NotEmpty().WithMessage("Sales Type is must").Length(1, 3).WithMessage("Sales Type should be in range of 1 to 3 characters"); ;
                validationResult = this.Validate(this, "Sales_Type");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public string Payment_Terms
        {
            get
            {
                return _payment_Terms;
            }

            set
            {
                _payment_Terms = value;

                RuleFor(stockajdout => stockajdout.Payment_Terms).NotEmpty().WithMessage("Payment Terms is must").Length(1, 3).WithMessage("Payment Terms should be in range of 1 to 3 characters"); ;
                validationResult = this.Validate(this, "Payment_Terms");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public decimal? Total_Discount
        {
            get
            {
                return _total_Discount;
            }

            set
            {
                _total_Discount = value;

                RuleFor(stockajdout => stockajdout.Total_Discount).NotEmpty().WithMessage("Total Discount is must");
                validationResult = this.Validate(this, "Total_Discount");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public decimal? Total_GST
        {
            get
            {
                return _total_GST;
            }

            set
            {
                _total_GST = value;

                RuleFor(stockajdout => stockajdout.Total_GST).NotEmpty().WithMessage("Total GST is must");
                validationResult = this.Validate(this, "Total_GST");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public decimal? Net_Amount
        {
            get
            {
                return _net_Amount;
            }

            set
            {
                _net_Amount = value;

                RuleFor(stockajdout => stockajdout.Net_Amount).NotEmpty().WithMessage("Net Amount is must");
                validationResult = this.Validate(this, "Net_Amount");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public decimal? Received_Amount
        {
            get
            {
                return _received_Amount;
            }

            set
            {
                _received_Amount = value;

                RuleFor(stockajdout => stockajdout.Received_Amount).NotEmpty().WithMessage("Received Amount is must");
                validationResult = this.Validate(this, "Received_Amount");
                if (!validationResult.IsValid)
                {
                    _isValid = false;
                    foreach (FluentValidation.Results.ValidationFailure failure in validationResult.Errors)
                        _errors.Add(failure);
                }
            }
        }

        public string Narration
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

        public int? Is_Active
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

        public string Ref_Document
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

        public string Ref_Document1
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

        public bool? Processed
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

        public int? PageNum
        {
            get
            {
                return _pageNum;
            }
            set
            {
                _pageNum = value;
            }
        }

        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int? TotalRowsNum
        {
            get
            {
                return _totalRowsNum;
            }
            set
            {
                _totalRowsNum = value;
            }
        }

        public string SortColumn
        {
            get
            {
                return _sortColumn;
            }
            set
            {
                _sortColumn = value;
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        public List<FluentValidation.Results.ValidationFailure> Errors
        {
            get
            {
                return (_errors.Count > 0 ? _errors : null);
            }
        }

        public string Record_Table_Name
        {
            get
            {
                return _record_Table_Name;
            }
            set
            {
                _record_Table_Name = value;
            }
        }

        public string Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
            }
        }

        public int? Operated_By
        {
            get
            {
                return _operated_By;
            }
            set
            {
                _operated_By = value;
            }
        }

        public DateTime? Operation_Date
        {
            get
            {
                return _operation_Date;
            }
            set
            {
                _operation_Date = value;
            }
        }

        //string _record_Table_Name;
        //string _operation;
        //int? _operated_By;
        //DateTime _operation_Date;

        #endregion


    }
}
