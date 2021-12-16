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
    public class Daily_Cash_Received_DAL : DBInteractionBase
    {
        private Daily_Cash_Received_Property objDailyCashRecProperty;
        private ErrorTracer objErrorTrace;

        public Daily_Cash_Received_DAL(Daily_Cash_Received_Property objDailyCashRec_Property)
        {
            objDailyCashRecProperty = objDailyCashRec_Property;
        }


        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Cash_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Cheque_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Personnel_ID. May be SqlString.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_CASH_RECIEVED_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCash_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 20, 4, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cash_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCheque_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 20, 4, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cheque_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posting_Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Posting_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                objDailyCashRecProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_CASH_RECIEVED_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_CASH_RECIEVED::Insert::Error occured.", ex);
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
        ///		 <LI>ID</LI>
        ///		 <LI>Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Cash_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Cheque_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Personnel_ID. May be SqlString.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_CASH_RECIEVED_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCash_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cash_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcCheque_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cheque_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posting_Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Posting_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_CASH_RECIEVED_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_CASH_RECIEVED::Update::Error occured.", ex);
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

        public bool UpdatePostingStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_CASH_RECIEVED_Update_POSTINGSTATUS]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posting_Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Posting_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_CASH_RECIEVED_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_CASH_RECIEVED::UpdatePostingStatus::Error occured.", ex);
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
        /// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        ///		 <LI>ID</LI>
        ///		 <LI>Date</LI>
        ///		 <LI>Cash_Amount</LI>
        ///		 <LI>Cheque_Amount</LI>
        ///		 <LI>Personnel_ID</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DAILY_CASH_RECIEVED_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DAILY_CASH_RECIEVED");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DAILY_CASH_RECIEVED_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objDailyCashRecProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objDailyCashRecProperty.Code = (string)toReturn.Rows[0]["Code"];
                    objDailyCashRecProperty.Date = toReturn.Rows[0]["Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Date"];
                    objDailyCashRecProperty.Cash_Amount = toReturn.Rows[0]["Cash_Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Cash_Amount"];
                    objDailyCashRecProperty.Cheque_Amount = toReturn.Rows[0]["Cheque_Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Cheque_Amount"];
                    objDailyCashRecProperty.Personnel_ID = toReturn.Rows[0]["Personnel_ID"] == System.DBNull.Value ? 0 : Convert.ToInt32(toReturn.Rows[0]["Personnel_ID"].ToString());
                    objDailyCashRecProperty.Posting_Status = toReturn.Rows[0]["Posting_Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Posting_Status"];
                    objDailyCashRecProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_CASH_RECIEVED::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_DAILY_CASH_RECIEVED_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DAILY_CASH_RECIEVED");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cash_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cash_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Cheque_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Cheque_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posting_Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Posting_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Distributor_ID));
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

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAILY_CASH_RECIEVED::SelectAll::Error occured.", ex);
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

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDailyCashRecProperty.Operated_By));

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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                objErrorTrace.Error_Msg = (SqlString)ex.Message;
                objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                objErrorTrace.Insert();
                HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                mailMessage.To.Add("ammar.ali@armtech.com.pk");
                mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                mailMessage.From = new MailAddress("Error@SSS.com");
                mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                mailMessage.Body = (String)objErrorTrace.Error_Msg;
                SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                smtpClient.Send(mailMessage);



                return false;

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
    }
}
