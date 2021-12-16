using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using FluentValidation;
using SNDDAL;
using SSS.Property.Setups;
using SSS.Property;

namespace SSS.DAL.Transactions
{
    public class DCR_DAL : DBInteractionBase
    {
        private Transaction_Master_Property ObjTransactionMasterProperty;
        public DCR_DAL()
        {
        }
        public DCR_DAL(Transaction_Master_Property objTransaction_Master_Property)
        {
            ObjTransactionMasterProperty = objTransaction_Master_Property;
        }

        public DataSet DCR_Report()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DailyCollectionSummary]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryManID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistrobutorID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.From_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.TO_Date));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                // ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DailyCollectionSummary' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("sp_DailyCollectionSummary::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
         public DataSet DCR_ReportForDailyTran()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DailyCollectionSummaryForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryManID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistrobutorID", SqlDbType.Int, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.From_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.TO_Date));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                adapter.Fill(toReturn);
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                // ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DailyCollectionSummary' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("sp_DailyCollectionSummary::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
   
    }
}
