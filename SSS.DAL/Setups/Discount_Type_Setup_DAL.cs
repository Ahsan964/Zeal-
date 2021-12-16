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
    public class Discount_Type_Setup_DAL : DBInteractionBase
    {
        private Discount_Type_Setup_Property objDiscountTypeSetupProperty;

        public Discount_Type_Setup_DAL(Discount_Type_Setup_Property objDiscount_Type_Setup_Property)
        {
            objDiscountTypeSetupProperty = objDiscount_Type_Setup_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Batch_Code</LI>
        ///		 <LI>Description. May be SqlString.Null</LI>
        ///		 <LI>Active_Status. May be SqlString.Null</LI>
        ///		 <LI>Product_ID</LI>
        ///		 <LI>Price_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_Index. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Expire_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Sale_Alert_Days. May be SqlInt32.Null</LI>
        ///		 <LI>Sale_Stop_Days. May be SqlInt32.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        //public override bool Insert()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_Insert]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,objDiscountTypeSetupProperty.ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Type_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Discount_Type_Code));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Type_Title", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Discount_Type_Title));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Status));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.PageNum));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.PageSize));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.SortColumn));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.TotalRowsNum));
               

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


        /// <summary>
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Batch_Code</LI>
        ///		 <LI>Description. May be SqlString.Null</LI>
        ///		 <LI>Active_Status. May be SqlString.Null</LI>
        ///		 <LI>Product_ID</LI>
        ///		 <LI>Price_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_Index. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Expire_Date. May be SqlDateTime.Null</LI>
        ///		 <LI>Sale_Alert_Days. May be SqlInt32.Null</LI>
        ///		 <LI>Sale_Stop_Days. May be SqlInt32.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        //public override bool Update()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_Update]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sBatch_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Batch_Code));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Description));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Active_Status));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Product_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Price_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_Index", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Batch_Index));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daBatch_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Batch_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@daExpire_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Expire_Date));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Alert_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Sale_Alert_Days));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Sale_Stop_Days));
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
        ///		 <LI>Batch_Code</LI>
        ///		 <LI>Description</LI>
        ///		 <LI>Active_Status</LI>
        ///		 <LI>Product_ID</LI>
        ///		 <LI>Price_ID</LI>
        ///		 <LI>Batch_Index</LI>
        ///		 <LI>Batch_Date</LI>
        ///		 <LI>Expire_Date</LI>
        ///		 <LI>Sale_Alert_Days</LI>
        ///		 <LI>Sale_Stop_Days</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
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
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.ID));
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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISCOUNT_TYPE_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISCOUNT_TYPE_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Type_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Discount_Type_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Type_Title", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Discount_Type_Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.Status));
               // cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDiscountTypeSetupProperty.TotalRowsNum));
               
               

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
                objDiscountTypeSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISCOUNT_TYPE_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISCOUNT_TYPE_SETUP::SelectAll::Error occured.", ex);
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
