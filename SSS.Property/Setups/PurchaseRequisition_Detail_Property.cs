using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    [Serializable()]
  public   class PurchaseRequisition_Detail_Property
    {
        #region Class Member Declarations

        private int _iD, _PurchaseMaster_Id, _Product_id, _Quantity, _Pack_Unit_Id, _Department_Id,_srNo;
        private string _Product_Code, _Product_Name, _status, _Description,_department_name;
        private DateTime _document_datetime, _deliverydate;
        private decimal _Total_Price, _rate,_total_amount, _discount, _net_amount;

        #endregion

        #region Class Property Declarations

        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        }
        public int PurchaseMasterId
        {
            get
            {
                return _PurchaseMaster_Id;
            }
            set
            {
                _PurchaseMaster_Id = value;
            }
        }
        public int ProductId
        {
            get
            {
                return _Product_id;
            }
            set
            {
                _Product_id = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        public int Pack_Unit_Id
        {
            get
            {
                return _Pack_Unit_Id;
            }
            set
            {
                _Pack_Unit_Id = value;
            }
        }

        public int Department_Id
        {
            get
            {
                return _Department_Id;
            }
            set
            {
                _Department_Id = value;
            }
        }
        public int SNo
        {
            get
            {
                return _srNo;
            }
            set
            {
                _srNo = value;
            }
        }
        public string Product_Code
        {
            get
            {
                return _Product_Code;
            }
            set
            {
                _Product_Code = value;
            }
        }
        public string Product_Name
        {
            get
            {
                return _Product_Name;
            }
            set
            {
                _Product_Name = value;
            }
        }
       
        public string Status
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
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public string DepartmentName
        {
            get
            {
                return _department_name;
            }
            set
            {
                _department_name = value;
            }
        }
        public DateTime DocumentDateTime
        {
            get
            {
                return _document_datetime;
            }
            set
            {
                _document_datetime = value;
            }
        }
        public DateTime DeliveryDate
        {
            get
            {
                return _deliverydate;
            }
            set
            {
                _deliverydate = value;
            }
        }
    
        public decimal Total_Price
        {
            get
            {
                return _Total_Price;
            }
            set
            {

                _Total_Price = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return _rate;
            }
            set
            {

                _rate = value;
            }
        }


        #endregion
    }
}
