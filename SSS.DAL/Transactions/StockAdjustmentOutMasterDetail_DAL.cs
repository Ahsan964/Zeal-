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
using SSS.Property.Transactions;

namespace SSS.DAL.Transactions
{
    public class StockAdjustmentOutMasterDetail_DAL : DBInteractionBase
    {
        private StockAdjustmentOutMaster_Property objStockAdjOutProperty;
        private ErrorTracer objErrorTrace;

        public StockAdjustmentOutMasterDetail_DAL()
        {
        }

        public StockAdjustmentOutMasterDetail_DAL(StockAdjustmentOutMaster_Property objStockAdjOut_Property)
        {
            objStockAdjOutProperty = objStockAdjOut_Property;
            objErrorTrace = new ErrorTracer();
        }

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_StockAdjustmentOut_Master_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            cmdToExecute.Transaction = this.Transaction;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Document_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Sales_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Payment_Terms", SqlDbType.Int, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Payment_Terms));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_Discount", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 18, 2, "", DataRowVersion.Proposed, objStockAdjOutProperty.Total_Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_GST", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 18, 2, "", DataRowVersion.Proposed, objStockAdjOutProperty.Total_GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Net_Amount", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 18, 2, "", DataRowVersion.Proposed, objStockAdjOutProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Received_Amount", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 18, 2, "", DataRowVersion.Proposed, objStockAdjOutProperty.Received_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Ref_Document));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Ref_Document1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Processed));
                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.Operation_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //if (_mainConnectionIsCreatedLocal)
                //{
                //    // Open connection.
                //    _mainConnection.Open();
                //}
                //else
                //{
                
                //if (_mainConnectionProvider.IsTransactionPending)
                //{
                //    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                //}
                //}

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                if (_mainConnection.State == ConnectionState.Open)
                {
                    int j = 0;
                }
                else
                {
                    int j = 1;
                }
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                objStockAdjOutProperty.ID = (int)cmdToExecute.Parameters["@iID"].Value;

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
                objErrorTrace.Error_Proc = "sp_StockAdjustmentOut_Master_Insert";
                objErrorTrace.Insert();
                HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                mailMessage.To.Add("ammar.ali@armtech.com.pk");
                mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                mailMessage.From = new MailAddress("Error@SSS.com");
                mailMessage.Subject = "Error in sp_StockAdjustmentOut_Master_Insert";
                mailMessage.Body = (String)objErrorTrace.Error_Msg;
                SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                smtpClient.Send(mailMessage);



                return false;

            }
            finally
            {
                //if (_mainConnectionIsCreatedLocal)
                //{
                //    // Close connection.
                //    _mainConnection.Close();
                //}
                cmdToExecute.Dispose();
            }
        }

        public bool InsertDetails(DataTable detailsDT)
        {
            try
            {
                //if (_mainConnectionIsCreatedLocal)
                //{
                //    // Open connection.
                //    _mainConnection.Open();
                //}
                SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                sbc.DestinationTableName = detailsDT.TableName;
                sbc.WriteToServer(detailsDT);
                //transaction.Commit();
                return true;//true always
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                return false;
            }
        }

        public override bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_StockAdjustmentOut_Master_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objStockAdjOutProperty.ID));
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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

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
                objErrorTrace.Error_Proc = "sp_StockAdjustmentOut_Master_Insert";
                objErrorTrace.Insert();
                HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                mailMessage.To.Add("ammar.ali@armtech.com.pk");
                mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                mailMessage.From = new MailAddress("Error@SSS.com");
                mailMessage.Subject = "Error in sp_StockAdjustmentOut_Master_Insert";
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
