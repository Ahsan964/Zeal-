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
using SSS.Property.Report;

namespace SSS.DAL.Report
{
    public class Salesandstock_Report_DAL : DBInteractionBase
    {
        private Salesandstock_Report_Property objSalesandstockReportProperty;

        public Salesandstock_Report_DAL(Salesandstock_Report_Property objalesandstockReport_Property)
        {
            objSalesandstockReportProperty = objalesandstockReport_Property;
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
        public  DataSet SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_SALESANDSTOCK]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Fromdate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Todate", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ToDate));

                if (objSalesandstockReportProperty.ProductGroup=="0")
                {
                    objSalesandstockReportProperty.ProductGroup = null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                else
                {


                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));

                }



                if (objSalesandstockReportProperty.SaleTypeID == string.Empty )
                {
                    objSalesandstockReportProperty.SaleTypeID = SqlString.Null   ;
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));
                }
                else
                {


                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));

                }             
                
                
                
                
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
              
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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
        /// Purpose: SelectAll method. This method will Select all rows from the table.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///   <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public DataSet SelectAllNew()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Rpt_SALESANDSTOCKCOPY]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
              
                if (objSalesandstockReportProperty.ProductGroup == "0")
                {
                    objSalesandstockReportProperty.ProductGroup = null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@Product_Id", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@Product_Id", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                // cmdToExecute.Parameters.Add(new SqlParameter("@Product_Id", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.FromDate));

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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet GetClosing()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetClosing]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                if (objSalesandstockReportProperty.ProductGroup == "0")
                {
                    objSalesandstockReportProperty.ProductGroup = null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@Product_Id", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@Product_Id", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.FromDate));

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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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


        public DataSet Report_SaleAndStock()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_rpt_Sales_And_Stock_ForBothTables]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Fromdate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Todate", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ToDate));

                if (objSalesandstockReportProperty.ProductGroup == "0")
                {
                    objSalesandstockReportProperty.ProductGroup = null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                if (objSalesandstockReportProperty.SaleTypeID == string.Empty)
                {
                    objSalesandstockReportProperty.SaleTypeID = SqlString.Null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));
                }
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.CompanyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FLAG", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.Flag));

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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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



        public DataSet Report_DisProductivityPlan()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DistributorProductivityPlan]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Channel", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.Channel));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                       
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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


        public DataSet Report_DSRSKU(int chk)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (chk == 0)
                cmdToExecute.CommandText = "dbo.[sp_DSRSKUDrawn]";//"dbo.[sp_rpt_Sales_And_Stock]";
            else
                cmdToExecute.CommandText = "dbo.[sp_DSRSKUActual]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet Report_DSRCategory(int chk)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (chk == 0)
                cmdToExecute.CommandText = "dbo.[sp_DSRCategoryDrawn]";//"dbo.[sp_rpt_Sales_And_Stock]";
            else
                cmdToExecute.CommandText = "dbo.[sp_DSRCategoryActual]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet Report_DSRBrand(int chk)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (chk == 0)
                cmdToExecute.CommandText = "dbo.[sp_DSRBrandDrawn]";//"dbo.[sp_rpt_Sales_And_Stock]";
            else
                cmdToExecute.CommandText = "dbo.[sp_DSRBrandActual]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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
        

        public DataSet Report_ZonalProductivityPlan()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ZonalProductivityPlan]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Channel", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.Channel));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                       
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet Report_RegionalProductivityPlan()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_RegionalProductivityPlan]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Id", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Channel", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.Channel));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetPeriodId));
                cmdToExecute.Parameters.Add(new SqlParameter("@monthtpid", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.TargetMonthId));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                                 
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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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

        public DataSet Report_SaleAndStockWithStChange()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "[dbo].[sp_rpt_Sales_And_Stock_ForBothTablesWithStChange_CCLNew]";//"dbo.[sp_rpt_Sales_And_Stock_ForBothTablesWithStChange]";//"dbo.[sp_rpt_Sales_And_Stock]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Fromdate", SqlDbType.DateTime, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Todate", SqlDbType.DateTime, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ToDate));

                if (objSalesandstockReportProperty.ProductGroup == "0")
                {
                    objSalesandstockReportProperty.ProductGroup = null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.ProductGroup));
                }
                if (objSalesandstockReportProperty.SaleTypeID == string.Empty)
                {
                    objSalesandstockReportProperty.SaleTypeID = SqlString.Null;
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@SaletypeId", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.SaleTypeID));
                }
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.CompanyID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FLAG", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSalesandstockReportProperty.Flag));

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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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


        public DataTable SelectSaleReport(int DistributorID,int PeriodID ,int ProductID)    
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SaleReport]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TRANSACTION_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try 
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributerID", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPeriodID", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, PeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 32, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ProductID));






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
                    //throw new Exception("Stored Procedure 'sp_Rpt_SALESANDSTOCK' reported the ErrorCode: " + _errorCode);
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("TRANSACTION_DETAIL::SelectAll::Error occured.", ex);
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
    
    }
}
