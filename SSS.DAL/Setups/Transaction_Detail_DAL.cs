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
    public class Transaction_Detail_DAL : DBInteractionBase
    {
        private Transaction_Detail_Property ObjTransactionDetailProperty;

        public Transaction_Detail_DAL(Transaction_Detail_Property objTransaction_Detail_Property)
        {
            ObjTransactionDetailProperty = objTransaction_Detail_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Transaction_Id</LI>
        ///		 <LI>Sales_Type_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Product_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Discount_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Discount. May be SqlDecimal.Null</LI>
        ///		 <LI>Quantity. May be SqlDecimal.Null</LI>
        ///		 <LI>Sold_Quantity. May be SqlDecimal.Null</LI>
        ///		 <LI>Price_ListId. May be SqlInt32.Null</LI>
        ///		 <LI>Rate. May be SqlDecimal.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>GST. May be SqlDecimal.Null</LI>
        ///		 <LI>Warehouse_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
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
        //    cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_Insert]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iTransaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcQuantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcSold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcRate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@dcGST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iWarehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));

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
        //            throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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
        /// bilal ahmed
        /// </summary>
        /// <returns></returns>
        /// 


        public  bool Update_STI()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_STI_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
              //  if (ObjTransactionDetailProperty.TempID != null)
               // {
                   // ObjTransactionDetailProperty.Transaction_Id = Convert.ToInt16(ObjTransactionDetailProperty.TempID.ToString());
               // }
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation_Date));

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
                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                //if (ObjTransactionDetailProperty.TempID == null)
                //{
                //    ObjTransactionDetailProperty.TempID = cmdToExecute.Parameters["@iID"].Value.ToString();
                //}
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                Transaction_Detail_Property objDtl;
                // foreach (DataRow dr in ObjTransactionMasterProperty.DetailData.Rows)
                // {
                objDtl = new Transaction_Detail_Property();

                objDtl.Document_Date = SessionManager.CurrentUser.FinancialDate;
                objDtl.Company_ID = SessionManager.CurrentUser.CompanyID;
                objDtl.Distributor_ID = SessionManager.CurrentUser.DistributorID;
                objDtl.Product_ID = ObjTransactionDetailProperty.Product_ID;
                objDtl.Price_ListId = ObjTransactionDetailProperty.Price_ListId;
                objDtl.Batch_ID = ObjTransactionDetailProperty.Batch_ID;
                objDtl.Sales_Type_ID = ObjTransactionDetailProperty.Sales_Type_ID;
                objDtl.Quantity = ObjTransactionDetailProperty.Quantity;

                Transaction_Detail_DAL tran_DAL = new Transaction_Detail_DAL(objDtl);
                tran_DAL.InsertUpdateStock("StockIn");
                // }
                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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

        public bool Update_STIWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_STI_UpdateWithStChange]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation_Date));

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
                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
               
                Transaction_Detail_Property objDtl;
                
                objDtl = new Transaction_Detail_Property();

                objDtl.Document_Date = SessionManager.CurrentUser.FinancialDate;
                objDtl.Company_ID = SessionManager.CurrentUser.CompanyID;
                objDtl.Distributor_ID = SessionManager.CurrentUser.DistributorID;
                objDtl.Product_ID = ObjTransactionDetailProperty.Product_ID;
                objDtl.Price_ListId = ObjTransactionDetailProperty.Price_ListId;
                objDtl.Batch_ID = ObjTransactionDetailProperty.Batch_ID;
                objDtl.Sales_Type_ID = ObjTransactionDetailProperty.Sales_Type_ID;
                objDtl.Quantity = ObjTransactionDetailProperty.Quantity;

                Transaction_Detail_DAL tran_DAL = new Transaction_Detail_DAL(objDtl);
                tran_DAL.InsertUpdateStock("StockIn");
                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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
                
         public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (ObjTransactionDetailProperty.TempID != null)
                {
                    ObjTransactionDetailProperty.Transaction_Id = Convert.ToInt16(ObjTransactionDetailProperty.TempID.ToString());
                }
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation_Date));

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
                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                if (ObjTransactionDetailProperty.TempID == null)
                {
                    ObjTransactionDetailProperty.TempID = cmdToExecute.Parameters["@iID"].Value.ToString();
                }
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                Transaction_Detail_Property objDtl;
               // foreach (DataRow dr in ObjTransactionMasterProperty.DetailData.Rows)
               // {
                    objDtl = new Transaction_Detail_Property();

                    objDtl.Document_Date = SessionManager.CurrentUser.FinancialDate;
                    objDtl.Company_ID = SessionManager.CurrentUser.CompanyID;
                    objDtl.Distributor_ID = SessionManager.CurrentUser.DistributorID;
                    objDtl.Product_ID = ObjTransactionDetailProperty.Product_ID;
                    objDtl.Price_ListId = ObjTransactionDetailProperty.Price_ListId;
                    objDtl.Batch_ID = ObjTransactionDetailProperty.Batch_ID;
                    objDtl.Sales_Type_ID = ObjTransactionDetailProperty.Sales_Type_ID;
                    objDtl.Quantity = ObjTransactionDetailProperty.Quantity;

                    Transaction_Detail_DAL tran_DAL = new Transaction_Detail_DAL(objDtl);
                    tran_DAL.InsertUpdateStock("StockIn");
               // }
                    this.Commit();
                    if (_errorCode != (int)LLBLError.AllOk)
                    {
                        // Throw error.
                        this.RollBack();
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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
         public int InsertDetailForNPT(string Product_Code)
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[Tran_Mst_DETAIL_For_NPT]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                 cmdToExecute.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));

                 cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                 cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                 cmdToExecute.Parameters.Add(new SqlParameter("@Product_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Product_Code));
                 cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                 //cmdToExecute.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));


                 _mainConnection.Open();


                 cmdToExecute.ExecuteNonQuery();
                 int ID = int.Parse(cmdToExecute.Parameters["@DetailID"].Value.ToString());


                 return ID;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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

        public bool Transaction_stockedit_Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Transaction_detail_edit_insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));

                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operation_Date));

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
                //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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

        public bool DeleteSti()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Sti_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
        
        public bool DeleteStiWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Sti_DeleteWithStChange]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
        
        
        public bool DeleteAllSockInDetail()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Delete_In_Stock_Documents]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));


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

        public bool DeleteAllSockInDetailWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Delete_In_Stock_DocumentsWithStChange]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));


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

        
        /// <summary>
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Transaction_Id</LI>
        ///		 <LI>Sales_Type_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Product_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Batch_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Discount_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Discount. May be SqlDecimal.Null</LI>
        ///		 <LI>Quantity. May be SqlDecimal.Null</LI>
        ///		 <LI>Sold_Quantity. May be SqlDecimal.Null</LI>
        ///		 <LI>Price_ListId. May be SqlInt32.Null</LI>
        ///		 <LI>Rate. May be SqlDecimal.Null</LI>
        ///		 <LI>Amount. May be SqlDecimal.Null</LI>
        ///		 <LI>GST. May be SqlDecimal.Null</LI>
        ///		 <LI>Warehouse_ID. May be SqlInt32.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTransaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcQuantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcGST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@iWarehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }
                else
                {
                    _mainConnection.Close();
                   
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Update::Error occured.", ex);
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

        public bool UpdateStockDetailWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_StockDetail_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iTransaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iBatch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcQuantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcSold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPrice_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcRate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcGST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@iWarehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }
                else
                {
                    _mainConnection.Close();
                   
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Update::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.TotalRowsNum));

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
                ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataTable Stock_Doc_PrintView()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Stock_Print_View]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //    ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataTable Stock_Doc_PrintViewWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Stock_Print_ViewWithStChange]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //    ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        
        public DataTable SelectAll_ProductDetail()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_SelectProductDescription]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@transactionId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                
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
                ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Operated_By));

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

        public bool UpdateCashMemo()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateCashMemoDetail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                Transaction_Master_Property objTransMaster = new Transaction_Master_Property();
                objTransMaster.ID = ObjTransactionDetailProperty.Transaction_Id;
                objTransMaster.Distributor_ID = ObjTransactionDetailProperty.Distributor_ID;
                Transaction_Master_DAL objTransaction_Master_DAL = new Transaction_Master_DAL(objTransMaster);

                objTransMaster.ID = objTransaction_Master_DAL.GetGINIdByCMId();
                if (objTransMaster.ID != 0)
                {
                    objTransMaster.Document_Date = SessionManager.CurrentUser.FinancialDate;
                    objTransMaster.Flag = "DeAllocate";
                    objTransMaster.Distributor_ID = (Int32)SessionManager.CurrentUser.DistributorID;
                    objTransaction_Master_DAL.AdjustTransactionalStock_SPOT();
                }
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Document_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Stock", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Stock));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Update::Error occured.", ex);
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


        public bool UpdateSalesReturn()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateSalesReturnDetail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));

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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Update::Error occured.", ex);
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

        public DataSet GetTransactionMasterAndDetailByTransactionID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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
        public DataSet GetTransactionMasterAndDetailByTransactionIDForDailyTran()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterIdForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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

        public DataTable SelectInHandStock()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Stock_Check]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Company_ID));
                
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
                // ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataTable selectAllByDetailId()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));

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
                // ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataTable selectAllStockDetailByDetailIdWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_StockDetail_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                // ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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


        public bool InsertSpecialTranDetail(string DiscountTypeTitle)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.sp_Insert_SpecialDiscount_TranDetail";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sold_Quantity", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sold_Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Price_ListId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 25, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.GST));
                cmdToExecute.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Warehouse_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@DiscountTypeTitle", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DiscountTypeTitle));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
                //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Insert::Error occured.", ex);
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


        public DataSet SelectAll_ReturnProduct()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_SelectAll_Product]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                
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
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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
        public DataSet SelectAll_ReturnProductForDailyTran()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TRANSACTION_DETAIL_SelectAll_ProductForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Transaction_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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


        
        public bool UpdateCashMemo_ReturnProduct()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateCashMemoDetail_ReturnProduct]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Tax_Amount", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Tax_Amount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 10, 4, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Rate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Batch_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PriceID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

                
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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::Update::Error occured.", ex);
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

        //Consolidated Stock Receipt Report
        public DataSet Consolidated_StockReceiptReport()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Consolidate_Stock_Report]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 9999, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.TempID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //    ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet Consolidated_StockReceiptReportWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Consolidate_Stock_ReportWithStChange]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 9999, ParameterDirection.Input, true, 100, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.TempID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributor_id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));

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
                //    ObjTransactionDetailProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_DETAIL_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        //Get TAX of Particular Product
        public DataTable Get_TaxofProduct()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetTaxofParticular_Product]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));

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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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

        public DataTable Get_TaxProduct_Price()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CalculateTax]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));
                

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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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
        
        public DataTable Get_TaxProduct_PriceForWRCM()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CalculateTaxForWRCM]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CashmemoNo", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.DocumentNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));


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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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
        public DataTable Get_TaxProduct_PriceForWRCMFromTranId()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CalculateTaxForWRCMFromTranId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Transaction_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID));


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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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
       
        public string UpdateSKUXML()
        {

            SqlConnection conn = new SqlConnection();
            conn = _mainConnection;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[prSKUCollectionXMLForAndroid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;
            DataTable toReturn = new DataTable("SKU");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = conn;
            conn.Open();


            cmdToExecute.Parameters.Add(new SqlParameter("@XmlOutput", SqlDbType.NVarChar, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.XmlOutPut));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            ObjTransactionDetailProperty.Skuxml = Convert.ToString(cmdToExecute.Parameters["@XmlOutput"].Value);


            _rowsAffected = (string)ObjTransactionDetailProperty.Skuxml;




            return _rowsAffected;



        }


        public void InsertUpdateStock(string sflag)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_InsertUpdateStock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //    @TransDate DateTime,
                //    @companyID INT = 1,
                //    @DistributorID INT,
                //    @ProductID INT,
                //    @PriceId INT,
                //    @BatchID INT,
                //    @SaleTypeID INT,
                //    @Flag VARCHAR(50),
                //    @Quantity INT,
                //--  @StockIn INT,
                //--  @StockOut INT,
                //--  @Allocated INT,
                //    @Result INT OUTPUT
                cmdToExecute.Parameters.Add(new SqlParameter("@TransDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Document_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@companyID", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Distributor_ID ));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Product_ID ));
                cmdToExecute.Parameters.Add(new SqlParameter("@PriceId", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Price_ListId ));
                cmdToExecute.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Batch_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@SaleTypeID", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Sales_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Flag", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, sflag));
                cmdToExecute.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionDetailProperty.Quantity.ToSqlInt32()));
                cmdToExecute.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                // ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_SelectAll' reported the ErrorCode: " + _errorCode);
                }
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
