using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.BLL.Transactions.ViewModels
{
   public class LP_GRN_ViewModel
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private DateTime _Date_Created;
        public DateTime Date_Created
        {
            get { return _Date_Created; }
            set { _Date_Created = value; }
        }

        private string _Doc_No;
        public string Doc_No
        {
            get { return _Doc_No; }
            set { _Doc_No = value; }
        }

        private int _Supplier_ID;
        public int Supplier_ID
        {
            get { return _Supplier_ID; }
            set { _Supplier_ID = value; }
        }

        private string _Supplier_Name;
        public string Supplier_Name
        {
            get { return _Supplier_Name; }
            set { _Supplier_Name = value; }
        }

        private int _Gatepass_Type_ID;
        public int Gatepass_Type_ID
        {
            get { return _Gatepass_Type_ID; }
            set { _Gatepass_Type_ID = value; }
        }

        private int _Gatepass_ID;
        public int Gatepass_ID
        {
            get { return _Gatepass_ID; }
            set { _Gatepass_ID = value; }
        }

        private string _Narration;
        public string Narration
        {
            get { return _Narration; }
            set { _Narration = value; }
        }

        private string _Ref1;
        public string Ref1
        {
            get { return _Ref1; }
            set { _Ref1 = value; }
        }

        private string _Ref2;
        public string Ref2
        {
            get { return _Ref2; }
            set { _Ref2 = value; }
        }

        private string _Ref3;
        public string Ref3
        {
            get { return _Ref3; }
            set { _Ref3 = value; }
        }

        private int _Parent_DocID;
        public int Parent_DocID
        {
            get { return _Parent_DocID; }
            set { _Parent_DocID = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _User_ID;
        public int User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }
    }
}
