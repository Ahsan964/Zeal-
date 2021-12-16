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

namespace SSS.DAL.Setups
{
    public class Daily_Collection_Dtl_DAL : DBInteractionBase
    {
        private Daily_Collection_Dtl_Property objDailyCollectionDtlProperty;
        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Deposit_Slip_No</LI>
        ///		 <LI>Serial_No</LI>
        ///		 <LI>Document_Type_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Document_No. May be SqlString.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Payment_Mode. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Bank. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Cheque_No. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Cash_Amount. May be SqlDecimal.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_COLLECTION_DTL_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sDeposit_Slip_No", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Deposit_Slip_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSerial_No", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Serial_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDocument_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDocument_No", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Document_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPayment_Mode", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Payment_Mode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_Bank", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Bank));
                cmdToExecute.Parameters.Add(new SqlParameter("@daCheque_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCheque_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCash_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cash_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_COLLECTION_DTL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_COLLECTION_DTL::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }


        /// <summary>
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Deposit_Slip_No</LI>
        ///		 <LI>Serial_No</LI>
        ///		 <LI>Document_Type_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Document_No. May be SqlString.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Payment_Mode. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Bank. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Cheque_No. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Cash_Amount. May be SqlDecimal.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_COLLECTION_DTL_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@sDeposit_Slip_No", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Deposit_Slip_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSerial_No", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Serial_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDocument_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDocument_No", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Document_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPayment_Mode", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Payment_Mode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_Bank", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Bank));
                cmdToExecute.Parameters.Add(new SqlParameter("@daCheque_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_No", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCheque_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cheque_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCash_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed,objDailyCollectionDtlProperty.Cash_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_COLLECTION_DTL_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_COLLECTION_DTL::Update::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
        

        /// <summary>
        /// Purpose: SelectAll method. This method will Select all rows from the table.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_COLLECTION_DTL_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DAILY_COLLECTION_DTL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_COLLECTION_DTL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_COLLECTION_DTL::SelectAll::Error occured.", ex);
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
