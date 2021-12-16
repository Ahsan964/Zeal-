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
using SSS.Property.Transactions;
using SSS.Property;


namespace SSS.DAL.Transactions
{
    public class SS_Cashmemo_DAL : DBInteractionBase
    {
        private SS_Cashmemo_Property objSSCashmemoProperty;

        public SS_Cashmemo_DAL()
        {
        }
        public SS_Cashmemo_DAL(SS_Cashmemo_Property objSSCashmemo_Property)
        {
            objSSCashmemoProperty = objSSCashmemo_Property;
        }


        public DataTable SSCashmemoFilter()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSCashmemoFilter]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Sales_Rep_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@RouteID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Route_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Personnel_ID));
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

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_MASTER_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Payment_Terms", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Payment_Terms));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Net_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Received_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Received_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Processed));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.PersonnelRef_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Prp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Route_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Transactionid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));





                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));




                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Operation_Date));


                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    //   _mainConnection.Open();
                    OpenConnection();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (objSSCashmemoProperty.DetailData != null)
                {
                    foreach (DataRow row in objSSCashmemoProperty.DetailData.Rows)
                        row["Transaction_Id"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                    objSSCashmemoProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objSSCashmemoProperty.DetailData.TableName = "TRANSACTION_DETAIL";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add(3, 2);
                    sbc.ColumnMappings.Add(5, 3);
                    sbc.ColumnMappings.Add(8, 14);
                    sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add(7, 7);


                    sbc.DestinationTableName = objSSCashmemoProperty.DetailData.TableName;
                    sbc.WriteToServer(objSSCashmemoProperty.DetailData);

                }

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        public DataSet GetCashMemoByTransactionMaster()
        {
            //sp_GetCashMemoByTransactionMasterId
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetCashMemoByTransactionMasterId_SoptSeller]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));

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
                //objSSCashmemoProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterId' reported the ErrorCode: " + _errorCode);
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

        public DataSet ProcessCashMemo()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ProcessCashMemo_SoptSeller]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CashMemoID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Result));


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
                //objSSCashmemoProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterId' reported the ErrorCode: " + _errorCode);
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

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Operated_By));

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

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_MASTER_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDocument_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDocument_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDocument_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iLocation_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPayment_Terms", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Payment_Terms));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTotal_Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTotal_GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcNet_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcReceived_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Received_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sNarration", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@iIs_Active", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRef_Document", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRef_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document1));
                cmdToExecute.Parameters.Add(new SqlParameter("@bProcessed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Processed));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Prp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Route_ID));
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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Update::Error occured.", ex);
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

        public DataTable SelectAll_WithDecription()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_MASTER_SelectAll_SpotSellerDescription]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Payment_Terms", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Payment_Terms));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Total_GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Net_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Received_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objSSCashmemoProperty.Received_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document));
                cmdToExecute.Parameters.Add(new SqlParameter("@Ref_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Ref_Document1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Processed));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.Route_ID));


                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.From_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objSSCashmemoProperty.TO_Date));


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
                objSSCashmemoProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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

    }
}
