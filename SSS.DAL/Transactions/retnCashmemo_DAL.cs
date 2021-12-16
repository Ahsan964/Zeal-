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
  public  class retnCashmemo_DAL : DBInteractionBase
    {
         private Transaction_Master_Property ObjTransactionMasterProperty;
         public retnCashmemo_DAL()
         { }
         public retnCashmemo_DAL(Transaction_Master_Property objTransaction_Master_Property)
        {
            ObjTransactionMasterProperty = objTransaction_Master_Property;
        }

         public DataTable PRP_Filter()
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[sp_FilterReturnCashmomo]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;
             DataTable toReturn = new DataTable("TRANSACTION_MASTER");
             SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                 cmdToExecute.Parameters.Add(new SqlParameter("@prpID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@companyID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Company_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@routeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Route_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@posID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));

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
                 //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                 if (_errorCode != (int)LLBLError.AllOk)
                 {
                     // Throw error.
                     throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_SelectAll' reported the ErrorCode: " + _errorCode);
                 }

                 return toReturn;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("TRANSACTION_MASTER::SelectAll::Error occured.", ex);
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

         public DataTable PRP_Filter_Edit()
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[sp_FilterReturnCashmomo_Edit]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;
             DataTable toReturn = new DataTable("TRANSACTION_MASTER");
             SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                 cmdToExecute.Parameters.Add(new SqlParameter("@prpID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@companyID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Company_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@routeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Route_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@posID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));

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
                 //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                 if (_errorCode != (int)LLBLError.AllOk)
                 {
                     // Throw error.
                     throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_SelectAll' reported the ErrorCode: " + _errorCode);
                 }

                 return toReturn;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("TRANSACTION_MASTER::SelectAll::Error occured.", ex);
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

         public DataTable Get_CMWRDetail()
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[sp_Get_CMWR_Detail]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;
             DataTable toReturn = new DataTable("TRANSACTION_MASTER");
             SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                 cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

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
                 //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                 if (_errorCode != (int)LLBLError.AllOk)
                 {
                     // Throw error.
                     throw new Exception("Stored Procedure 'sp_Get_CMWR_Detail' reported the ErrorCode: " + _errorCode);
                 }

                 return toReturn;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("sp_Get_CMWR_Detail::Error occured.", ex);
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
         public DataTable Get_CMWRDetailForDailyTran()
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[sp_Get_CMWR_DetailForDailyTran]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;
             DataTable toReturn = new DataTable("TRANSACTION_MASTER");
             SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                 cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

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
                 //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                 if (_errorCode != (int)LLBLError.AllOk)
                 {
                     // Throw error.
                     throw new Exception("Stored Procedure 'sp_Get_CMWR_Detail' reported the ErrorCode: " + _errorCode);
                 }

                 return toReturn;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("sp_Get_CMWR_Detail::Error occured.", ex);
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
