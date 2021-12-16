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


namespace SSS.DAL.Report
{
    public class ConsolidatedSalesSummary_Report_DAL : DBInteractionBase
    {
        private SSS.Property.Report.ConsolidateSalesSummary_Report_Property objConsolidateSalesSummaryReportProperty;

        public ConsolidatedSalesSummary_Report_DAL(SSS.Property.Report.ConsolidateSalesSummary_Report_Property objConsolidateSalesSummaryReport_Property)
        {
            objConsolidateSalesSummaryReportProperty = objConsolidateSalesSummaryReport_Property;
        }


       // private ErrorTracer objErrorTrace;

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
        /// 
        public DataSet SelectAll(string OrderbookerID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYFromBothTables]";//"dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, OrderbookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));



              
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
               // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);
               
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Rpt_CONSOLIDATEDSALESSUMMARY' reported the ErrorCode: " + _errorCode);
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

        public DataSet SelectAll_CategoryWise(string OrderbookerID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYFromBothTables_CategoryWise]";//"dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, OrderbookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));




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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Rpt_CONSOLIDATEDSALESSUMMARY' reported the ErrorCode: " + _errorCode);
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

        public DataSet SelectAllWithStChange(string OrderbookerID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYFromBothTablesWithStChange]";//"dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, OrderbookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));




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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Rpt_CONSOLIDATEDSALESSUMMARY' reported the ErrorCode: " + _errorCode);
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
        
        
        public DataSet SelectAllForDailyTran(string OrderbookerID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, OrderbookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));




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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Rpt_CONSOLIDATEDSALESSUMMARY' reported the ErrorCode: " + _errorCode);
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

        
        public DataSet SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.OrderBookerId));



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

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARY' reported the ErrorCode: " + _errorCode);
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

        public DataSet ShopWiseSaleReport(int ShopIds)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_Wise_Sale_Summary_UPDATED]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ReportType", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ShopIds));
                cmdToExecute.Parameters.Add(new SqlParameter("@POSID", SqlDbType.NVarChar, -1, ParameterDirection.Input, true , 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));



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
                //  cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARYbyPOS' reported the ErrorCode: " + _errorCode);
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
        public DataTable SelectAllbyPOS(string PosIDs)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYbyPOS]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@PosID", SqlDbType.NVarChar, 30000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, PosIDs));



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
              //  cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARYbyPOS' reported the ErrorCode: " + _errorCode);
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
        public DataTable SelectAllbyPOSForDailyTran(string PosIDs)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYbyPOSForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@PosID", SqlDbType.NVarChar, 30000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, PosIDs));



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
                //  cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARYbyPOS' reported the ErrorCode: " + _errorCode);
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

        public DataSet SelectAllbyDM(string DeliveryManID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYDM]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DeliveryManID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));
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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARYDM' reported the ErrorCode: " + _errorCode);
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

        public DataSet SelectAllbyDMForDailyTran(string DeliveryManID)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_CONSOLIDATEDSALESSUMMARYDMForDailyTran]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@From", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@To", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderbookerId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DeliveryManID));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objConsolidateSalesSummaryReportProperty.ProductIds));
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
                // cmdToExecute.CommandTimeout = 300;
                // Execute query.
                adapter.Fill(toReturn);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Rpt_CONSOLIDATEDSALESSUMMARYDM' reported the ErrorCode: " + _errorCode);
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


    }
}
