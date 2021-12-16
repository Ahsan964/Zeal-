using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.BLL
{
    public abstract class GridCommandBase
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        private int istatus;
        public int iStatus
        {
            get { return istatus; }
            set { istatus = value; }
        }




        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private int operationBy;
        public int OperationBy
        {
            get { return operationBy; }
            set { operationBy = value; }
        }

       public abstract void UpdateStatus();

    }
}
