using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Transactions;
using SSS.DAL;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using SSS.DAL.Transactions;

namespace SSS.BLL.Transactions
{
    public class Collection_Master_BLL : GridCommandBase
    {
        private Collection_Master_DAL objColMasterDAL;
        private Collection_Master_Property objColMasterProperty;

        public Collection_Master_BLL()
        {
        }

        public Collection_Master_BLL(Collection_Master_Property objColMaster_Property)
        {
            objColMasterProperty = objColMaster_Property;
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

        public DataTable ViewAll()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.SelectAll();
        }
        public DataTable ViewAllForDailyTran()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.SelectAllForDailyTran();
        }
        
        public DataTable View()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.SelectOne();
        }

        public bool ADD()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.Insert();
        }

        public bool Update()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.Update();
        }

        public bool UpdateMasterAndDetails(DataTable updatedMastersData, List<List<object>> DetailsData)
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.UpdateMasterAndDetails(updatedMastersData, DetailsData);
        }

        public bool UpdateRecieveAmount()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.UpdateRecievedAmount();
        }

        public DataTable ViewCreditCollection(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.SelectCreditCollection(DateFrom, DateTo);
        }

        public DataTable GetOutstandingCashMemo(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.GetOutstandingCashMemo(DateFrom, DateTo);
        }
        public DataTable GetOutstandingCashMemoForDailyTran(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.GetOutstandingCashMemoForDailyTran(DateFrom, DateTo);
        }
        
        public DataTable GetChequeStatusDetail(SqlDateTime DateFrom, SqlDateTime DateTo, String Chequestatus)
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.GetChequeStatusDetail(DateFrom, DateTo, Chequestatus);
        }

        public bool Update_RetnAmount()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.Update_RetnAmount();
        }
        public bool Update_RetnAmountForRWCM()
        {
            objColMasterDAL = new Collection_Master_DAL(objColMasterProperty);
            return objColMasterDAL.Update_RetnAmountForRWCM();
        }



    }

}
