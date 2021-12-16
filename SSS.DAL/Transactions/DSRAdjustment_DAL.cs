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
    public class DSRAdjustment_DAL : DBInteractionBase
    {
        private DSRAdjustment_Property objDSRAdjustmentProperty;
        private ErrorTracer objErrorTrace;

        public DSRAdjustment_DAL()
        { }

        public DSRAdjustment_DAL(DSRAdjustment_Property objDSRAdjustment_Property)
        {
            objDSRAdjustmentProperty = objDSRAdjustment_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Code. May be SqlString.Null</LI>
        ///		 <LI>Distributor_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Daily_Cash_Recieved_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Adjustment_Type. May be SqlString.Null</LI>
        ///		 <LI>Reason. May be SqlString.Null</LI>
        ///		 <LI>Adjust_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Adjust_Amount_Type. May be SqlString.Null</LI>
        ///		 <LI>Adjustment_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Personnel_ID. May be SqlInt32.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_DSR_ADJUSTMENT_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDaily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAdjustment_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReason", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAdjust_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAdjust_Amount_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@daAdjustment_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
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
                objDSRAdjustmentProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::Insert::Error occured.", ex);
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
        ///		 <LI>Code. May be SqlString.Null</LI>
        ///		 <LI>Distributor_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Daily_Cash_Recieved_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Adjustment_Type. May be SqlString.Null</LI>
        ///		 <LI>Reason. May be SqlString.Null</LI>
        ///		 <LI>Adjust_Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>Adjust_Amount_Type. May be SqlString.Null</LI>
        ///		 <LI>Adjustment_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Personnel_ID. May be SqlInt32.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DSR_ADJUSTMENT_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCode", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDaily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAdjustment_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReason", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAdjust_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAdjust_Amount_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@daAdjustment_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Status));
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
                    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::Update::Error occured.", ex);
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
        ///		 <LI>Code</LI>
        ///		 <LI>Distributor_ID</LI>
        ///		 <LI>Company_ID</LI>
        ///		 <LI>Daily_Cash_Recieved_ID</LI>
        ///		 <LI>Adjustment_Type</LI>
        ///		 <LI>Reason</LI>
        ///		 <LI>Adjust_Amount</LI>
        ///		 <LI>Adjust_Amount_Type</LI>
        ///		 <LI>Adjustment_Date</LI>
        ///		 <LI>Personnel_ID</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DSR_ADJUSTMENT_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DSR_ADJUSTMENT");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objDSRAdjustmentProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objDSRAdjustmentProperty.Code = toReturn.Rows[0]["Code"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Code"];
                    objDSRAdjustmentProperty.Distributor_ID = toReturn.Rows[0]["Distributor_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Distributor_ID"];
                    objDSRAdjustmentProperty.Company_ID = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
                    objDSRAdjustmentProperty.Daily_Cash_Recieved_ID = toReturn.Rows[0]["Daily_Cash_Recieved_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Daily_Cash_Recieved_ID"];
                    objDSRAdjustmentProperty.Adjustment_Type = toReturn.Rows[0]["Adjustment_Type"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Adjustment_Type"];
                    objDSRAdjustmentProperty.Reason = toReturn.Rows[0]["Reason"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Reason"];
                    objDSRAdjustmentProperty.Adjust_Amount = toReturn.Rows[0]["Adjust_Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Adjust_Amount"];
                    objDSRAdjustmentProperty.Adjust_Amount_Type = toReturn.Rows[0]["Adjust_Amount_Type"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Adjust_Amount_Type"];
                    objDSRAdjustmentProperty.Adjustment_Date = toReturn.Rows[0]["Adjustment_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Adjustment_Date"];
                    objDSRAdjustmentProperty.Personnel_ID = toReturn.Rows[0]["Personnel_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Personnel_ID"];
                    objDSRAdjustmentProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_DSR_ADJUSTMENT_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DSR_ADJUSTMENT");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Daily_Cash_Recieved_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Daily_Cash_Recieved_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Adjustment_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Reason));
                cmdToExecute.Parameters.Add(new SqlParameter("@Adjust_Amount", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Adjust_Amount_Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjust_Amount_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Adjustment_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Adjustment_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.TotalRowsNum));

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
                //    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::SelectAll::Error occured.", ex);
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


        // New Development Start
        public DataTable GetAdjustmentType()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_AdjustmentType_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DSR_ADJUSTMENT");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                
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
                //    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::SelectAll::Error occured.", ex);
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

        public DataTable SelectAll_Adjustment()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DSRAdjustment_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DSR_ADJUSTMENT");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.From_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.TO_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@personnel_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.TotalRowsNum));

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
                //    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::SelectAll::Error occured.", ex);
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Operated_By));

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


        public DataTable SelectAdjustment_DSID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDSRAdjustment_DSID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DSR_ADJUSTMENT");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDSRAdjustmentProperty.Daily_Cash_Recieved_ID));
              
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
                //    throw new Exception("Stored Procedure 'sp_DSR_ADJUSTMENT_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DSR_ADJUSTMENT::SelectAll::Error occured.", ex);
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
