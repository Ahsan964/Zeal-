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
    public class Distributor_Discount_Limit_DAL : DBInteractionBase
    {
        private Distributor_Discount_Limit_Property objDistributorDiscountLimitProperty;

        public Distributor_Discount_Limit_DAL(Distributor_Discount_Limit_Property objDistributor_Discount_Limit_Property)
        {
            objDistributorDiscountLimitProperty = objDistributor_Discount_Limit_Property;
        }
       
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_DISCOUNT_LIMIT_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Discount_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Max_Allowed_Skus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Max_Allowed_Skus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Status));

                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.ID));
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
                objDistributorDiscountLimitProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;


                objDistributorDiscountLimitProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_BATCH_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("BATCH_SETUP::Insert::Error occured.", ex);
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


        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_DISCOUNT_LIMIT_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("BATCH_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Master_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Discount_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Max_Allowed_Skus", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Max_Allowed_Skus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.TotalRowsNum));

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
                    //throw new Exception("Stored Procedure 'sp_BATCH_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("BATCH_SETUP::SelectAll::Error occured.", ex);
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

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Operated_By));

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
            cmdToExecute.CommandText = "dbo.[sp_DISTRIBUTOR_DISCOUNT_LIMIT_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_Master_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Discount_Master_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Max_Allowed_Skus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Max_Allowed_Skus));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objDistributorDiscountLimitProperty.Status));

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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    // throw new Exception("Stored Procedure 'sp_BATCH_SETUP_Update' reported the ErrorCode: " + _errorCode);

                    return false;

                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("BATCH_SETUP::Update::Error occured.", ex);
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

       // public override DataTable SelectOne()
       // {
       //     SqlCommand cmdToExecute = new SqlCommand();
       //     cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_SelectOne]";
       //     cmdToExecute.CommandType = CommandType.StoredProcedure;
       //     DataTable toReturn = new DataTable("BATCH_SETUP");
       //     SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

       //     // Use base class' connection object
       //     cmdToExecute.Connection = _mainConnection;

       //     try
       //     {
       //         if (objBatchProperty.ID <= 0)
       //             objBatchProperty.ID = System.Data.SqlTypes.SqlInt32.Null;
       //         cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@BatchCode", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Batch_Code));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed,_errorCode));

       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Open connection.
       //             _mainConnection.Open();
       //         }
       //         else
       //         {
       //             if (_mainConnectionProvider.IsTransactionPending)
       //             {
       //                 cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
       //             }
       //         }

       //         // Execute query.
       //         adapter.Fill(toReturn);
       //         _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

       //         if (_errorCode != (int)LLBLError.AllOk)
       //         {
       //             // Throw error.
       //             throw new Exception("Stored Procedure 'sp_BATCH_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
       //         }

       //         if (toReturn.Rows.Count > 0)
       //         {
       //             objBatchProperty.ID  = (Int32)toReturn.Rows[0]["ID"];
       //             objBatchProperty.Company_ID  = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
       //             objBatchProperty.Distributor_ID  = toReturn.Rows[0]["Distributor_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Distributor_ID"];
       //             objBatchProperty.Batch_Code  = (string)toReturn.Rows[0]["Batch_Code"];
       //             objBatchProperty.Description  = toReturn.Rows[0]["Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Description"];
       //             objBatchProperty.Active_Status  = toReturn.Rows[0]["Active_Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Active_Status"];
       //             objBatchProperty.Batch_Index  = toReturn.Rows[0]["Batch_Index"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Batch_Index"];
       //             objBatchProperty.Batch_Date = toReturn.Rows[0]["Batch_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Batch_Date"];
       //             objBatchProperty.Expire_Date  = toReturn.Rows[0]["Expire_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Expire_Date"];
       //             objBatchProperty.Sale_Alert_Days = toReturn.Rows[0]["Sale_Alert_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Alert_Days"];
       //             objBatchProperty.Sale_Stop_Days  = toReturn.Rows[0]["Sale_Stop_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Stop_Days"];
       //             objBatchProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
       //         }
       //         return toReturn;
       //     }
       //     catch (Exception ex)
       //     {
       //         // some error occured. Bubble it to caller and encapsulate Exception object
       //         throw new Exception("BATCH_SETUP::SelectOne::Error occured.", ex);
       //     }
       //     finally
       //     {
       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Close connection.
       //             _mainConnection.Close();
       //         }
       //         cmdToExecute.Dispose();
       //         adapter.Dispose();
       //     }
       // }

       // public  DataTable SELECT_BY_PRODUCT_ID()
       // {
       //     SqlCommand cmdToExecute = new SqlCommand();
       //     cmdToExecute.CommandText = "dbo.[sp_BATCH_SETUP_SelectAll]";
       //     cmdToExecute.CommandType = CommandType.StoredProcedure;
       //     DataTable toReturn = new DataTable("BATCH_SETUP");
       //     SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

       //     // Use base class' connection object
       //     cmdToExecute.Connection = _mainConnection;

       //     try
       //     {
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Company_ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Distributor_ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Batch_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Batch_Code));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Description));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Active_Status));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Product_ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Price_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Price_ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Batch_Index", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Batch_Index));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Batch_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Batch_Date));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Expire_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Expire_Date));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Alert_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Sale_Alert_Days));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Sale_Stop_Days));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.Status));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.ID));
       //        // cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


       //         cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.PageNum));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.PageSize));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.SortColumn));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objBatchProperty.TotalRowsNum));


       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Open connection.
       //             _mainConnection.Open();
       //         }
       //         else
       //         {
       //             if (_mainConnectionProvider.IsTransactionPending)
       //             {
       //                 cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
       //             }
       //         }

       //         // Execute query.
       //         adapter.Fill(toReturn);
       //        // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

       //         if (_errorCode != (int)LLBLError.AllOk)
       //         {
       //             // Throw error.
       //             throw new Exception("Stored Procedure 'sp_BATCH_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
       //         }

       //         if (toReturn.Rows.Count > 0)
       //         {
       //             //_iD = (Int32)toReturn.Rows[0]["ID"];
       //             //_batch_Code = (string)toReturn.Rows[0]["Batch_Code"];
       //             //_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Description"];
       //             //_active_Status = toReturn.Rows[0]["Active_Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Active_Status"];
       //             //_product_ID = (Int32)toReturn.Rows[0]["Product_ID"];
       //             //_price_ID = toReturn.Rows[0]["Price_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Price_ID"];
       //             //_batch_Index = toReturn.Rows[0]["Batch_Index"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Batch_Index"];
       //             //_batch_Date = toReturn.Rows[0]["Batch_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Batch_Date"];
       //             //_expire_Date = toReturn.Rows[0]["Expire_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Expire_Date"];
       //             //_sale_Alert_Days = toReturn.Rows[0]["Sale_Alert_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Alert_Days"];
       //             //_sale_Stop_Days = toReturn.Rows[0]["Sale_Stop_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Stop_Days"];
       //         }
       //         return toReturn;
       //     }
       //     catch (Exception ex)
       //     {
       //         // some error occured. Bubble it to caller and encapsulate Exception object
       //         throw new Exception("BATCH_SETUP::SelectOne::Error occured.", ex);
       //     }
       //     finally
       //     {
       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Close connection.
       //             _mainConnection.Close();
       //         }
       //         cmdToExecute.Dispose();
       //         adapter.Dispose();
       //     }
       // }

       // public DataTable SelectPricelistAndExpiry() 
       // {
       //     SqlCommand cmdToExecute = new SqlCommand();
       //     cmdToExecute.CommandText = "dbo.[sp_PriceList_Select_By_ProductAndBatch]";
       //     cmdToExecute.CommandType = CommandType.StoredProcedure;
       //     DataTable toReturn = new DataTable("BATCH_SETUP");
       //     SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

       //     // Use base class' connection object
       //     cmdToExecute.Connection = _mainConnection;

       //     try
       //     {
       //         cmdToExecute.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.Product_ID));
       //         cmdToExecute.Parameters.Add(new SqlParameter("@BATCH_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objBatchProperty.ID));

       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Open connection.
       //             _mainConnection.Open();
       //         }
       //         else
       //         {
       //             if (_mainConnectionProvider.IsTransactionPending)
       //             {
       //                 cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
       //             }
       //         }

       //         // Execute query.
       //         adapter.Fill(toReturn);
       //       //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

       //         if (_errorCode != (int)LLBLError.AllOk)
       //         {
       //             // Throw error.
       //             throw new Exception("Stored Procedure 'sp_BATCH_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
       //         }

       //         if (toReturn.Rows.Count > 0)
       //         {
       //             //_iD = (Int32)toReturn.Rows[0]["ID"];
       //             //_batch_Code = (string)toReturn.Rows[0]["Batch_Code"];
       //             //_description = toReturn.Rows[0]["Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Description"];
       //             //_active_Status = toReturn.Rows[0]["Active_Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Active_Status"];
       //             //_product_ID = (Int32)toReturn.Rows[0]["Product_ID"];
       //             //_price_ID = toReturn.Rows[0]["Price_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Price_ID"];
       //             //_batch_Index = toReturn.Rows[0]["Batch_Index"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Batch_Index"];
       //             //_batch_Date = toReturn.Rows[0]["Batch_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Batch_Date"];
       //             //_expire_Date = toReturn.Rows[0]["Expire_Date"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Expire_Date"];
       //             //_sale_Alert_Days = toReturn.Rows[0]["Sale_Alert_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Alert_Days"];
       //             //_sale_Stop_Days = toReturn.Rows[0]["Sale_Stop_Days"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sale_Stop_Days"];
       //         }
       //         return toReturn;
       //     }
       //     catch (Exception ex)
       //     {
       //         // some error occured. Bubble it to caller and encapsulate Exception object
       //         throw new Exception("BATCH_SETUP::SelectOne::Error occured.", ex);
       //     }
       //     finally
       //     {
       //         if (_mainConnectionIsCreatedLocal)
       //         {
       //             // Close connection.
       //             _mainConnection.Close();
       //         }
       //         cmdToExecute.Dispose();
       //         adapter.Dispose();
       //     }
       // }



    }
}
