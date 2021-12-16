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
    public class AchivementMaster_DAL : DBInteractionBase
    {
        private AchivementMaster_Property objAchivementMasterProperty;

        public AchivementMaster_DAL(AchivementMaster_Property objAchivementMaster_Property)
        {
            objAchivementMasterProperty = objAchivementMaster_Property;
        }

        public DataTable GetAchivementMaster()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAchivementMaster]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ACHIVEMENT_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.ID));

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
                    throw new Exception("Stored Procedure 'sp_GetAchivementMaster' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENT_MASTER::SelectAll::Error occured.", ex);
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

        public int InsertMaster()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_InsertAchivement_Master]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Description));

                cmdToExecute.Parameters.Add(new SqlParameter("@TargetTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.SalePersonID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetAnnualPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetPeriodID));

                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertionDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.ID));
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
                if (objAchivementMasterProperty.DetailData != null)
                {

                    foreach (DataRow row in objAchivementMasterProperty.DetailData.Rows)
                    {

                        row["AchivementMasterId"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                    }

                    objAchivementMasterProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objAchivementMasterProperty.DetailData.TableName = "ACHIVEMENT_DETAIL";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add(2,1);
                    sbc.ColumnMappings.Add(3,3);
                    sbc.ColumnMappings.Add(4,2);
                    sbc.ColumnMappings.Add(5,6);
                    sbc.ColumnMappings.Add(6,4);
                    sbc.ColumnMappings.Add(7,5);
                    sbc.ColumnMappings.Add(8,7);
                    sbc.ColumnMappings.Add(9,8);
                    sbc.ColumnMappings.Add(10,9);
                    
                    sbc.DestinationTableName = objAchivementMasterProperty.DetailData.TableName;
                    sbc.WriteToServer(objAchivementMasterProperty.DetailData);

                }
               // this.Commit();

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_InsertAchivement_Master' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
            }
            catch (Exception ex)
            {
                //this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENTMASTER::Insert::Error occured.", ex);
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

        public int StatusUpdate(string tablename)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_AchivementStatusUpdate]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Table_Name", SqlDbType.VarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, tablename));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertionDate));
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

                Int32 _iD = 0;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _iD = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());

                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_AchivementStatusUpdate' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENT_MASTER::Update::Error occured.", ex);
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

        public int UpdateMaster()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateAchivement_Master]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Description));

                cmdToExecute.Parameters.Add(new SqlParameter("@TargetTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetTypeID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.SalePersonID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetAnnualPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetAnnualPeriodID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetPeriodID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.TargetPeriodID));

                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementMasterProperty.InsertionDate));

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
                    throw new Exception("Stored Procedure 'sp_UpdateAchivement_Master' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENTMASTER::Insert::Error occured.", ex);
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

        public DataTable GetTargetPerson()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetTargetPerson]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGET_PERSON");
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
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetTargetPerson' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_PERSON::SelectAll::Error occured.", ex);
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
