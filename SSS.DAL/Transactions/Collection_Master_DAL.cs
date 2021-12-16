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

namespace SSS.DAL.Transactions
{
    public class Collection_Master_DAL : DBInteractionBase
    {
        private Collection_Master_Property objColMasterProperty;
        private ErrorTracer objErrorTrace;

        public Collection_Master_DAL(Collection_Master_Property objColMaster_Property)
        {
            objColMasterProperty = objColMaster_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>CashMemo_ID. May be SqlInt32.Null</LI>
        ///		 <LI>CashMemo_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Net_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Recieved_Amount. May be SqlDecimal.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iCashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@daCashMemo_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcNet_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRecieved_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PRP_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PersonnelRef_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
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
                objColMasterProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::Insert::Error occured.", ex);
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
        ///		 <LI>CashMemo_ID. May be SqlInt32.Null</LI>
        ///		 <LI>CashMemo_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Net_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Recieved_Amount. May be SqlDecimal.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@daCashMemo_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcNet_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRecieved_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Recieved_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PRP_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PersonnelRef_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Status));
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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::Update::Error occured.", ex);
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
        ///		 <LI>CashMemo_ID</LI>
        ///		 <LI>CashMemo_Date</LI>
        ///		 <LI>Net_Amount</LI>
        ///		 <LI>Recieved_Amount</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objColMasterProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objColMasterProperty.CashMemo_ID = toReturn.Rows[0]["CashMemo_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["CashMemo_ID"];
                    objColMasterProperty.CashMemo_Date = toReturn.Rows[0]["CashMemo_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["CashMemo_Date"];
                    objColMasterProperty.Net_Amount = toReturn.Rows[0]["Net_Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Net_Amount"];
                    objColMasterProperty.Recieved_Amount = toReturn.Rows[0]["Recieved_Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Recieved_Amount"];
                    objColMasterProperty.PRP_ID = toReturn.Rows[0]["PRP_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["PRP_ID"];
                    objColMasterProperty.Delivery_Man_ID = toReturn.Rows[0]["Delivery_Man_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Delivery_Man_ID"];
                    objColMasterProperty.Pos_ID = toReturn.Rows[0]["Pos_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Pos_ID"];
                    objColMasterProperty.PersonnelRef_ID = toReturn.Rows[0]["PersonnelRef_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["PersonnelRef_ID"];
                    objColMasterProperty.DeliveryDate = toReturn.Rows[0]["DeliveryDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["DeliveryDate"];
                    objColMasterProperty.Location_ID = toReturn.Rows[0]["Location_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Location_ID"];
                    objColMasterProperty.Distributor_ID = toReturn.Rows[0]["Distributor_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Distributor_ID"];
                    objColMasterProperty.Company_id = toReturn.Rows[0]["Company_id"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_id"];
                    objColMasterProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_SelectAllNet]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CashMemo_Date", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Net_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Recieved_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Recieved_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PRP_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PersonnelRef_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.TotalRowsNum));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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
        public DataTable SelectAllForDailyTran()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_SelectAllNetForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CashMemo_Date", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Net_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Net_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Recieved_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Recieved_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PRP_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.PersonnelRef_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.TotalRowsNum));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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

        
        public bool UpdateMasterAndDetails(DataTable updatedMastersData, List<List<object>> DetailsData)
        {
            SqlCommand cmdToExecuteDetails = new SqlCommand();
            cmdToExecuteDetails.CommandText = "[dbo].[sp_COLLECTION_DETAIL_SelectAll]";
            cmdToExecuteDetails.CommandType = CommandType.StoredProcedure;
            DataTable actualDetailsData = new DataTable("COLLECTION_DETAIL");
            SqlDataAdapter adapter = null;
            SqlCommandBuilder commandBuilder = null;
            DataTable updatedDetailsData = null;

            bool flag = false;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;


            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecuteDetails.Connection = _mainConnection;

            if (_mainConnectionIsCreatedLocal)
            {
                // Open connection.
                OpenConnection();
            }
            else
            {
                if (_mainConnectionProvider.IsTransactionPending)
                {
                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    cmdToExecuteDetails.Transaction = _mainConnectionProvider.CurrentTransaction;
                }
            }

            this.StartTransaction();
            cmdToExecute.Transaction = this.Transaction;
            cmdToExecuteDetails.Transaction = this.Transaction;

            try
            {
                for (int i = 0; i < updatedMastersData.Rows.Count; i++)
                {

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["CashMemo_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["CashMemo_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daCashMemo_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["CashMemo_Date"] == DBNull.Value ? SqlDateTime.Null : Convert.ToDateTime(updatedMastersData.Rows[i]["CashMemo_Date"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcNet_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Net_Amount"] == DBNull.Value ? SqlDecimal.Null : Convert.ToDecimal(updatedMastersData.Rows[i]["Net_Amount"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcRecieved_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Recieved_Amount"] == DBNull.Value ? SqlDecimal.Null : Convert.ToDecimal(updatedMastersData.Rows[i]["Recieved_Amount"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PRP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["PRP_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["PRP_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Delivery_Man_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["Delivery_Man_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Pos_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["Pos_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["PersonnelRef_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["PersonnelRef_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["DeliveryDate"] == DBNull.Value ? SqlDateTime.Null : Convert.ToDateTime(updatedMastersData.Rows[i]["DeliveryDate"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Location_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["Location_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Distributor_ID"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["Distributor_ID"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Company_id"] == DBNull.Value ? SqlInt32.Null : Convert.ToInt32(updatedMastersData.Rows[i]["Company_id"].ToString()))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, (updatedMastersData.Rows[i]["Status"] == DBNull.Value ? string.Empty : updatedMastersData.Rows[i]["Status"].ToString())));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)LLBLError.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                    }

                    adapter = new SqlDataAdapter(cmdToExecuteDetails);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    

                    AddParameters(cmdToExecuteDetails, Convert.ToInt32(updatedMastersData.Rows[i]["ID"].ToString()));

                    adapter.Fill(actualDetailsData);

                    for (int j = 0; j < DetailsData.Count; j++)
                        if ((int)DetailsData[j][0] == i)
                            updatedDetailsData = (DataTable)DetailsData[j][1];

                    adapter.Update(updatedDetailsData);
                    cmdToExecute.Parameters.Clear();
                    cmdToExecuteDetails.Parameters.Clear();
                }

                this.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::Update::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    CloseConnection();
                }
                cmdToExecute.Dispose();
                cmdToExecuteDetails.Dispose();
                adapter.Dispose();
                commandBuilder.Dispose();
            }

            return flag;
        }

        private void AddParameters(SqlCommand cmdToExecute, int Collection_Master_ID)
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Daily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Collection_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Collection_Master_ID));
            cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlDateTime.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlDecimal.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Checque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Checque_DueDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlDateTime.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 1));
            cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 99999));
            cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlString.Null));
            cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
        }


        public bool UpdateRecievedAmount()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateRecAmt_CollMaster]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iRecAmt", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Recieved_Amount));
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
                    throw new Exception("Stored Procedure 'sp_UpdateRecAmt_CollMaster' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Collection_RecievedAmount::UpdatePostingStatus::Error occured.", ex);
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

        public  DataTable SelectCreditCollection(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Credit]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                
                cmdToExecute.Parameters.Add(new SqlParameter("@Delivery_Man_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@company_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.TotalRowsNum));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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

        public DataTable GetOutstandingCashMemo(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_OutstandingCashmemoReport]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                //DistributorID
                cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryManID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@POSID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
               

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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
        public DataTable GetOutstandingCashMemoForDailyTran(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_OutstandingCashmemoReportForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                //DistributorID
                cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryManID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Delivery_Man_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@POSID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));


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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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

        
        public DataTable GetChequeStatusDetail(SqlDateTime DateFrom, SqlDateTime DateTo , String Chequestatus)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ChequeSatusDetailReport]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@POSID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Pos_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChequeStatus", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Chequestatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.Company_id));
               
                
               
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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::SelectAll::Error occured.", ex);
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


        public bool Update_RetnAmount()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Update_ReturnAmount]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@iCashMemo_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.CashMemo_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@retn_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Return_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@CMWRID", SqlDbType.Int, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Temp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@deliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColMasterProperty.DeliveryDate));

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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::Update::Error occured.", ex);
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

        public bool Update_RetnAmountForRWCM()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_MASTER_Update_ReturnAmountForRWCM]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@cashmemoNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColMasterProperty.DocumentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@retn_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Return_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@CMWRID", SqlDbType.Int, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Temp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColMasterProperty.Distributor_ID));
               
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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_MASTER::Update::Error occured.", ex);
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
