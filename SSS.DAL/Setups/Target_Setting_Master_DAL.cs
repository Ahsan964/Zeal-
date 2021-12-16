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
    public class Target_Setting_Master_DAL : DBInteractionBase
    {


        private Target_Setting_Master_Property objTRSMproperty;

        public Target_Setting_Master_DAL(Target_Setting_Master_Property objTRSM_property)
        {
            objTRSMproperty = objTRSM_property;
        }


        public int InsertMaster()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_InsertTargetSetting_Master]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderBookerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetAnnualPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductivityTarget", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.ProductivityTarget));

                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTRSMproperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTRSMproperty.InsertionDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.ID));
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

                Int32 _iD = 0;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _iD = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_InsertTargetSetting_Master' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING_MASTER::Insert::Error occured.", ex);
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


        public DataTable GetTargetMasterbyParam()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetTargetSetMaster_param]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGET_SETTING");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrderBookerID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetAnnualPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
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
                    throw new Exception("Stored Procedure 'sp_GetTargetSetMaster_param' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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

        public DataTable GetTargetsReportDll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TargetsReport2]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGETsReport");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@orderBookerID", SqlDbType.NVarChar, 9000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookersMultipleIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@targetPeriodId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.NVarChar, 9000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.ProductsMultipleIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrganogramLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrganogramLevel));
                
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
                    throw new Exception("Stored Procedure 'sp_GetTargetSetMaster_param' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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

        public DataTable GetTargetsReportDllChannelWise()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TargetsReport2ChannelWise]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGETsReport");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@orderBookerID", SqlDbType.NVarChar, 9000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookersMultipleIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@targetPeriodId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.NVarChar, 9000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.ProductsMultipleIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@OrganogramLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrganogramLevel));

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
                    throw new Exception("Stored Procedure 'sp_GetTargetSetMaster_param' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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

        public DataTable GetTargetSettingMasterByOrderBookerAndTargetPeriodIdsDll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_TargetSettingMasterGetByOrderBookerAndTargetPeriodIds]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGETsReport");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@orderBookerID", SqlDbType.NVarChar, 9000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookersMultipleIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@targetPeriodId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
                
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
                    throw new Exception("Stored Procedure 'sp_GetTargetSetMaster_param' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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

        public DataTable GetProductiveCallsAchievementDll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetProductiveCallsAchievement]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGETsReport");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPersonLevel", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.OrderBookerID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetTypeID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPeriodId", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.TargetPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@inputAchievement", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSMproperty.InputAchievement));
                
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
                    throw new Exception("Stored Procedure 'sp_GetTargetSetMaster_param' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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
