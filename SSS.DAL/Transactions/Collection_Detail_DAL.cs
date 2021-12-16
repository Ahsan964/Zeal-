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
    public class Collection_Detail_DAL : DBInteractionBase
    {

        private Collection_Detail_Property objColDetailProperty;
        private ErrorTracer objErrorTrace;

        public Collection_Detail_DAL(Collection_Detail_Property objColDetail_Property)
        {
            objColDetailProperty = objColDetail_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Distributor_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Daily_Cash_Recieved_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Collection_Master_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Bank_Name. May be SqlString.Null</LI>
        ///		 <LI>Checque_No. May be SqlString.Null</LI>
        ///		 <LI>Branch. May be SqlString.Null</LI>
        ///		 <LI>Checque_DueDate. May be SqlDateTime.Null</LI>
        ///		 <LI>Type. May be SqlString.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_DETAIL_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDaily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCollection_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Collection_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal,18, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, objColDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcChqAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, objColDetailProperty.ChqAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Bank_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sChecque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBranch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@daChecque_DueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_DueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
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
                objColDetailProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_COLLECTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_DETAIL::Insert::Error occured.", ex);
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
        ///		 <LI>Distributor_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Daily_Cash_Recieved_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Collection_Master_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Bank_Name. May be SqlString.Null</LI>
        ///		 <LI>Checque_No. May be SqlString.Null</LI>
        ///		 <LI>Branch. May be SqlString.Null</LI>
        ///		 <LI>Checque_DueDate. May be SqlDateTime.Null</LI>
        ///		 <LI>Type. May be SqlString.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_DETAIL_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDaily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCollection_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Collection_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcChqAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 4, "", DataRowVersion.Proposed, objColDetailProperty.ChqAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Bank_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sChecque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBranch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@daChecque_DueDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_DueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sType", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Status));
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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_DETAIL::Update::Error occured.", ex);
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
        ///		 <LI>Distributor_ID</LI>
        ///		 <LI>Company_ID</LI>
        ///		 <LI>Daily_Cash_Recieved_ID</LI>
        ///		 <LI>Collection_Master_ID</LI>
        ///		 <LI>Date</LI>
        ///		 <LI>Amount</LI>
        ///		 <LI>Bank_Name</LI>
        ///		 <LI>Checque_No</LI>
        ///		 <LI>Branch</LI>
        ///		 <LI>Checque_DueDate</LI>
        ///		 <LI>Type</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COLLECTION_DETAIL_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_COLLECTION_DETAIL_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objColDetailProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objColDetailProperty.Distributor_ID = toReturn.Rows[0]["Distributor_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Distributor_ID"];
                    objColDetailProperty.Company_ID = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
                    objColDetailProperty.Daily_Cash_Recieved_ID = toReturn.Rows[0]["Daily_Cash_Recieved_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Daily_Cash_Recieved_ID"];
                    objColDetailProperty.Collection_Master_ID = toReturn.Rows[0]["Collection_Master_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Collection_Master_ID"];
                    objColDetailProperty.Date = toReturn.Rows[0]["Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Date"];
                    objColDetailProperty.Amount = toReturn.Rows[0]["Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Amount"];
                    objColDetailProperty.ChqAmount = toReturn.Rows[0]["ChqAmount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["ChqAmount"];
                    objColDetailProperty.Bank_Name = toReturn.Rows[0]["Bank_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Bank_Name"];
                    objColDetailProperty.Checque_No = toReturn.Rows[0]["Checque_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Checque_No"];
                    objColDetailProperty.Branch = toReturn.Rows[0]["Branch"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Branch"];
                    objColDetailProperty.Checque_DueDate = toReturn.Rows[0]["Checque_DueDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Checque_DueDate"];
                    objColDetailProperty.Type = toReturn.Rows[0]["Type"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Type"];
                    objColDetailProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_DETAIL::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "[dbo].[sp_COLLECTION_DETAIL_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Daily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Collection_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Collection_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChqAmount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ChqAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Bank_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Checque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@Checque_DueDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_DueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.TotalRowsNum));

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
                throw new Exception("COLLECTION_DETAIL::SelectAll::Error occured.", ex);
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

        public bool SelectAndUpdateDetails(DataTable updatedData)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "[dbo].[sp_COLLECTION_DETAIL_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable actualData = new DataTable("COLLECTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Daily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Collection_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Collection_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChqAmount", SqlDbType.Decimal, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ChqAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Bank_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Bank_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Checque_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Branch));
                cmdToExecute.Parameters.Add(new SqlParameter("@Checque_DueDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Checque_DueDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.TotalRowsNum));

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

                adapter.Fill(actualData);
                adapter.Update(updatedData);

                return true;

            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COLLECTION_DETAIL::SelectAll::Error occured.", ex);
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
                commandBuilder.Dispose();
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Operated_By));

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

        public DataTable GetCheque(SqlDateTime DateFrom, SqlDateTime DateTo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetChequebySatusType]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COLLECTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Distributor_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.TotalRowsNum));

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

                adapter.Fill(toReturn);
        
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

        public bool UpdateChequeStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateChequeStatus]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objColDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusType", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objColDetailProperty.Type));
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
                    throw new Exception("Stored Procedure 'sp_UpdateChequeStatus' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Collection_ChequeAmount::UpdatePostingStatus::Error occured.", ex);
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
