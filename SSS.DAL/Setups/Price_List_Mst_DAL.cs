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

namespace SSS.DAL.Setups
{
    public class Price_List_Mst_DAL : DBInteractionBase
    {
        private Price_List_Mst_Property ObjPriceListMstProperty;
        private ErrorTracer objErrorTrace;

        public Price_List_Mst_DAL(Price_List_Mst_Property ObjPriceListMst_Property)
        {
            ObjPriceListMstProperty = ObjPriceListMst_Property;
        }



        //private Batch_Property ObjPriceListMstProperty;
        ///// <summary>
        ///// Purpose: Insert method. This method will insert one new row into the database.
        ///// </summary>
        ///// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        ///// <remarks>
        ///// Properties needed for this method: 
        ///// <UL>
        /////		 <LI>Batch_Code</LI>
        /////		 <LI>Description. May be SqlString.Null</LI>
        /////		 <LI>Active_Status. May be SqlString.Null</LI>
        /////		 <LI>Product_ID</LI>
        /////		 <LI>Price_ID. May be SqlInt32.Null</LI>
        /////		 <LI>Batch_Index. May be SqlInt32.Null</LI>
        /////		 <LI>Batch_Date. May be SqlDateTime.Null</LI>
        /////		 <LI>Expire_Date. May be SqlDateTime.Null</LI>
        /////		 <LI>Sale_Alert_Days. May be SqlInt32.Null</LI>
        /////		 <LI>Sale_Stop_Days. May be SqlInt32.Null</LI>
        ///// </UL>
        ///// Properties set after a succesful call of this method: 
        ///// <UL>
        /////		 <LI>ID</LI>
        /////		 <LI>ErrorCode</LI>
        ///// </UL>
        ///// </remarks>
        //public override bool Insert()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_Insert]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sBatch_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Code));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Description));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Active_Status));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Product_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_Index", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Index));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daBatch_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daExpire_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Expire_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Alert_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Sale_Alert_Days));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Sale_Stop_Days));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }

        //        // Execute query.
        //        _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //        //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
        //        _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_BATCH_SETUP_Insert' reported the ErrorCode: " + _errorCode);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("BATCH_SETUP::Insert::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //}


        ///// <summary>
        ///// Purpose: Update method. This method will Update one existing row in the database.
        ///// </summary>
        ///// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        ///// <remarks>
        ///// Properties needed for this method: 
        ///// <UL>
        /////		 <LI>ID</LI>
        /////		 <LI>Batch_Code</LI>
        /////		 <LI>Description. May be SqlString.Null</LI>
        /////		 <LI>Active_Status. May be SqlString.Null</LI>
        /////		 <LI>Product_ID</LI>
        /////		 <LI>Price_ID. May be SqlInt32.Null</LI>
        /////		 <LI>Batch_Index. May be SqlInt32.Null</LI>
        /////		 <LI>Batch_Date. May be SqlDateTime.Null</LI>
        /////		 <LI>Expire_Date. May be SqlDateTime.Null</LI>
        /////		 <LI>Sale_Alert_Days. May be SqlInt32.Null</LI>
        /////		 <LI>Sale_Stop_Days. May be SqlInt32.Null</LI>
        ///// </UL>
        ///// Properties set after a succesful call of this method: 
        ///// <UL>
        /////		 <LI>ErrorCode</LI>
        ///// </UL>
        ///// </remarks>
        //public override bool Update()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_Update]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sBatch_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Code));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Description));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Active_Status));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Product_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_Index", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Index));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daBatch_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daExpire_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Expire_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Alert_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Sale_Alert_Days));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Sale_Stop_Days));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }

        //        // Execute query.
        //        _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //        _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_BATCH_SETUP_Update' reported the ErrorCode: " + _errorCode);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("BATCH_SETUP::Update::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //}

        ///// <summary>
        ///// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
        ///// </summary>
        ///// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        ///// <remarks>
        ///// Properties needed for this method: 
        ///// <UL>
        /////		 <LI>ID</LI>
        ///// </UL>
        ///// Properties set after a succesful call of this method: 
        ///// <UL>
        /////		 <LI>ErrorCode</LI>
        /////		 <LI>ID</LI>
        /////		 <LI>Batch_Code</LI>
        /////		 <LI>Description</LI>
        /////		 <LI>Active_Status</LI>
        /////		 <LI>Product_ID</LI>
        /////		 <LI>Price_ID</LI>
        /////		 <LI>Batch_Index</LI>
        /////		 <LI>Batch_Date</LI>
        /////		 <LI>Expire_Date</LI>
        /////		 <LI>Sale_Alert_Days</LI>
        /////		 <LI>Sale_Stop_Days</LI>
        ///// </UL>
        ///// Will fill all properties corresponding with a field in the table with the value of the row selected.
        ///// </remarks>
        //public override DataTable SelectOne()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_SelectOne]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable("BATCH_SETUP");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }

        //        // Execute query.
        //        adapter.Fill(toReturn);
        //        _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_BATCH_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
        //        }

        //        if (toReturn.Rows.Count > 0)
        //        {
        //            //_iD = (Int32)toReturn.Rows[0]["ID"];
        //            //_batch_Code = (string)toReturn.Rows[0]["Batch_Code"];
        //            //_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Description"];
        //            //_active_Status = toReturn.Rows[0]["Active_Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Active_Status"];
        //            //_product_ID = (Int32)toReturn.Rows[0]["Product_ID"];
        //            //_price_ID = toReturn.Rows[0]["Price_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Price_ID"];
        //            //_batch_Index = toReturn.Rows[0]["Batch_Index"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Batch_Index"];
        //            //_batch_Date = toReturn.Rows[0]["Batch_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Batch_Date"];
        //            //_expire_Date = toReturn.Rows[0]["Expire_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Expire_Date"];
        //            //_sale_Alert_Days = toReturn.Rows[0]["Sale_Alert_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Alert_Days"];
        //            //_sale_Stop_Days = toReturn.Rows[0]["Sale_Stop_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Stop_Days"];
        //        }
        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("BATCH_SETUP::SelectOne::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //        adapter.Dispose();
        //    }
        //}


        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Product_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Price_Code</LI>
        ///		 <LI>Price_Title</LI>
        ///		 <LI>Active_Status</LI>
        ///		 <LI>Currency_Code. May be SqlString.Null</LI>
        ///		 <LI>TradePrice</LI>
        ///		 <LI>SalePrice. May be SqlDecimal.Null</LI>
        ///		 <LI>RetailPrice. May be SqlDecimal.Null</LI>
        ///		 <LI>MSRP. May be SqlDecimal.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        ///		 <LI>TaxID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_ID. May be SqlInt32.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public bool PriceListInsert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceProduct_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Title", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PricelistActive_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Currency_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Currency_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTradePrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TradePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSalePrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.SalePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRetailPrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.RetailPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcMSRP", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.MSRP));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceListStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTaxID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TaxID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Index", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Index));
                cmdToExecute.Parameters.Add(new SqlParameter("@PrimaryPrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PrimaryPrice));

                if (ObjPriceListMstProperty.Batch_ID == 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlInt32.Null ));

                    
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Batch_ID));

                }

                


                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                //cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar , 50, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar , 50, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));



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
                ObjPriceListMstProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                ObjPriceListMstProperty.ErrorCode  = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;


                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_PRICE_LIST_MST_Insert' reported the ErrorCode: " + _errorCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("PRICE_LIST_MST::Insert::Error occured.", ex);
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

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceListStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Operated_By));

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
                //objErrorTrace.Error_Msg = (SqlString)ex.Message;
                //objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                //objErrorTrace.Insert();
                //HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                //mailMessage.To.Add("ammar.ali@armtech.com.pk");
                //mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                //mailMessage.From = new MailAddress("Error@SSS.com");
                //mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                //mailMessage.Body = (String)objErrorTrace.Error_Msg;
                //SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                //smtpClient.Send(mailMessage);



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
        ///		 <LI>Day_Code</LI>
        ///		 <LI>Day_Name</LI>
        ///		 <LI>Description</LI>
        ///		 <LI>IsDayClose</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
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
        ///		 <LI>Day_Code</LI>
        ///		 <LI>Day_Name</LI>
        ///		 <LI>Description</LI>
        ///		 <LI>IsDayClose</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public DataTable Selectlatestbatchid()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_SelectLatest]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DAY");
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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_DAY_SelectOne' reported the ErrorCode: " + _errorCode);
                //}


                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DAY::SelectOne::Error occured.", ex);
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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PricelistSETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceProduct_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Title", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Active_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Currency_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Currency_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Effective_From_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDateTime.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@Effective_To_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDateTime.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reg_Trade_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TradePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reg_Retail_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.RetailPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reg_Pur_Trade_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDecimal.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reg_Pur_Retail_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDecimal.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@UnReg_Trade_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDecimal.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@UnReg_Purchase_Price", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SqlDecimal.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@MSRP", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.MSRP));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceListStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PageNum ));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, SqlInt32.Null));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Company_ID));




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
                    //throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);


                    return toReturn;

                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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


        public DataTable SelectAll_Price()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_SelectAll_Price]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PricelistSETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Product_ID));                
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));                
                
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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);


                    return toReturn;

                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectAll_Price_WithPriceCode()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_SelectAll_Price_WithPriceCode]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PricelistSETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));

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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);


                    return toReturn;

                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRICE_LIST_MST");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_PRICE_LIST_MST_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    ObjPriceListMstProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    ObjPriceListMstProperty.PriceProduct_ID = toReturn.Rows[0]["Product_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_ID"];
                    ObjPriceListMstProperty.Price_Code = (string)toReturn.Rows[0]["Price_Code"];
                    ObjPriceListMstProperty .Price_Title = (string)toReturn.Rows[0]["Price_Title"];
                    ObjPriceListMstProperty.Active_Status = (string)toReturn.Rows[0]["Active_Status"];
                    ObjPriceListMstProperty.Currency_Code = toReturn.Rows[0]["Currency_Code"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Currency_Code"];
                    ObjPriceListMstProperty.TradePrice = (Decimal)toReturn.Rows[0]["TradePrice"];
                    ObjPriceListMstProperty.SalePrice = toReturn.Rows[0]["SalePrice"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["SalePrice"];
                    ObjPriceListMstProperty.RetailPrice = toReturn.Rows[0]["RetailPrice"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["RetailPrice"];
                    ObjPriceListMstProperty.MSRP = toReturn.Rows[0]["MSRP"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["MSRP"];
                    //ObjPriceListMstProperty.PriceListStatus = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                    //ObjPriceListMstProperty.TaxID = toReturn.Rows[0]["TaxID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["TaxID"];
                    //ObjPriceListMstProperty.Batch_ID = toReturn.Rows[0]["Batch_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Batch_ID"];
                    ObjPriceListMstProperty.Price_Index = toReturn.Rows[0]["Price_Index"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Price_Index"];
                    ObjPriceListMstProperty.PrimaryPrice = toReturn.Rows[0]["PrimaryPrice"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["PrimaryPrice"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("PRICE_LIST_MST::SelectOne::Error occured.", ex);

                return toReturn;


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
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Product_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Price_Code</LI>
        ///		 <LI>Price_Title</LI>
        ///		 <LI>Active_Status</LI>
        ///		 <LI>Currency_Code. May be SqlString.Null</LI>
        ///		 <LI>TradePrice</LI>
        ///		 <LI>SalePrice. May be SqlDecimal.Null</LI>
        ///		 <LI>RetailPrice. May be SqlDecimal.Null</LI>
        ///		 <LI>MSRP. May be SqlDecimal.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        ///		 <LI>TaxID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_ID. May be SqlInt32.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PRICE_LIST_MST_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.ID ));
                cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceProduct_ID ));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPrice_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPrice_Title", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Title ));
                cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PricelistActive_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCurrency_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Currency_Code ));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTradePrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TradePrice ));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSalePrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.SalePrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRetailPrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.RetailPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcMSRP", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.MSRP));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PriceListStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTaxID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SqlInt32.Null  ));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_Index", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Price_Index));
                cmdToExecute.Parameters.Add(new SqlParameter("@PrimaryPrice", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 16, 4, "", DataRowVersion.Proposed, ObjPriceListMstProperty.PrimaryPrice));
                
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
                ObjPriceListMstProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
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

        public DataTable SelectPricebySKUCode(string SKU_Previous_Code)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PriceSetup_SelectBySKU]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Price");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@SKU_Previous_Code", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SKU_Previous_Code));
                if (_mainConnectionIsCreatedLocal)
                {
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
                throw new Exception("DAY::SelectOne::Error occured.", ex);
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

        public DataSet PriceStructureReport()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PriceStructureReport]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("PricelistSETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.TempID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPriceListMstProperty.Company_ID));




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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);


                    return toReturn;

                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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
