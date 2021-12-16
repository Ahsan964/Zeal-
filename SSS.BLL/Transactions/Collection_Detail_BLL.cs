using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class Collection_Detail_BLL : GridCommandBase
    {
        private Collection_Detail_DAL objColDetailDAL;
        private Collection_Detail_Property objColDetailProperty;

        public Collection_Detail_BLL()
        {
        }

        public Collection_Detail_BLL(Collection_Detail_Property objColDetail_Property)
        {
            objColDetailProperty = objColDetail_Property;
        }

        public DataTable ViewAll()
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.SelectAll();
        }

        public DataTable View()
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.SelectOne();
        }

        public bool ADD()
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.Insert();
        }

        public bool Update()
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.Update();
        }

        public override void UpdateStatus()
        {
            Collection_Detail_Property objColDetailPropertyNew = new Collection_Detail_Property();
            objColDetailPropertyNew.ID = base.Id;
            objColDetailPropertyNew.Status = base.Status;
            objColDetailPropertyNew.TableName = objColDetailProperty.TableName;

            objColDetailDAL = new Collection_Detail_DAL(objColDetailPropertyNew);
            objColDetailDAL.UpdateStatus();
        }

        public bool SelectAndUpdateDetails(DataTable updatedData)
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.SelectAndUpdateDetails(updatedData);
        }

        public DataTable GetCheque(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.GetCheque(DateFrom, DateTo);
        }


        public bool UpdateChequeStatus()
        {
            objColDetailDAL = new Collection_Detail_DAL(objColDetailProperty);
            return objColDetailDAL.UpdateChequeStatus();
        }
    }
}
