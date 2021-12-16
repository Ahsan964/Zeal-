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
using System.Xml;

namespace SSS.DAL.Setups
{
    public class Replenishment_Master_DAL : DBInteractionBase
    {
        private Replenishment_Master_Property ObjReplenishmentMasterProperty;
        /// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public Replenishment_Master_DAL()
		{
			// Nothing for now.
		}

        public Replenishment_Master_DAL(Replenishment_Master_Property objReplenishment_Master_Property)
        {
            ObjReplenishmentMasterProperty = objReplenishment_Master_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ReplenishmentNo. May be SqlString.Null</LI>
        ///		 <LI>DistributorId. May be SqlInt32.Null</LI>
        ///		 <LI>TransactionDate. May be SqlDateTime.Null</LI>
        ///		 <LI>Datefrom. May be SqlDateTime.Null</LI>
        ///		 <LI>Dateto. May be SqlDateTime.Null</LI>
        ///		 <LI>InsertBy. May be SqlInt32.Null</LI>
        ///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>Id</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ReplenishmentMaster_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.TransactionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Datefrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Datefrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@Dateto", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Dateto));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.InsertBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Status));                
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Id));

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

                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (ObjReplenishmentMasterProperty.DetailData != null)
                {
                    foreach (DataRow row in ObjReplenishmentMasterProperty.DetailData.Rows)
                        row["ReplenishmentMasterId"] = cmdToExecute.Parameters["@Id"].Value.ToString();

                    ObjReplenishmentMasterProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    ObjReplenishmentMasterProperty.DetailData.TableName = "ReplenishmentDetail";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add(0, 1);
                    sbc.ColumnMappings.Add(1, 2);
                    sbc.ColumnMappings.Add(2, 3);
                    sbc.ColumnMappings.Add(3, 4);
                    sbc.ColumnMappings.Add(4, 5);
                    sbc.ColumnMappings.Add(5, 6);
                    sbc.ColumnMappings.Add(6, 7);
                    sbc.ColumnMappings.Add(7, 8);
                    sbc.ColumnMappings.Add(8, 9);
                    sbc.ColumnMappings.Add(9, 10);
                    sbc.ColumnMappings.Add(10, 11);
                    sbc.ColumnMappings.Add(11, 12);
                    sbc.ColumnMappings.Add(12, 13);
                    sbc.ColumnMappings.Add(13, 14);
                    sbc.ColumnMappings.Add(14, 15);
                    sbc.ColumnMappings.Add(15, 16);
                    sbc.ColumnMappings.Add(16, 17);
                    sbc.ColumnMappings.Add(17, 18);

                    sbc.DestinationTableName = ObjReplenishmentMasterProperty.DetailData.TableName;
                    sbc.WriteToServer(ObjReplenishmentMasterProperty.DetailData);

                }

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::Insert::Error occured.", ex);
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
        ///		 <LI>Id</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        ///		 <LI>Id</LI>
        ///		 <LI>ReplenishmentNo</LI>
        ///		 <LI>DistributorId</LI>
        ///		 <LI>TransactionDate</LI>
        ///		 <LI>Datefrom</LI>
        ///		 <LI>Dateto</LI>
        ///		 <LI>InsertBy</LI>
        ///		 <LI>InsertionDate</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ReplenishmentMaster_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ReplenishmentMaster");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Id));
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
                adapter.Fill(toReturn);
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    //_id = (Int32)toReturn.Rows[0]["Id"];
                    //_replenishmentNo = toReturn.Rows[0]["ReplenishmentNo"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["ReplenishmentNo"];
                    //_distributorId = toReturn.Rows[0]["DistributorId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DistributorId"];
                    //_transactionDate = toReturn.Rows[0]["TransactionDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TransactionDate"];
                    //_datefrom = toReturn.Rows[0]["Datefrom"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Datefrom"];
                    //_dateto = toReturn.Rows[0]["Dateto"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["Dateto"];
                    //_insertBy = toReturn.Rows[0]["InsertBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["InsertBy"];
                    //_insertionDate = toReturn.Rows[0]["InsertionDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["InsertionDate"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_ReplenishmentMaster_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ReplenishmentMaster");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
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
                adapter.Fill(toReturn);
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::SelectAll::Error occured.", ex);
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

        public DataTable GetGenerateNeededStock()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetGenerateNeededStock2]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ReplenishmentMaster");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Datefrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Dateto));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.DistributorCode));
                
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
                //    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::SelectAll::Error occured.", ex);
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


        public DataTable GetGenerateNeededStockMultiDistributorAndProduct()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetGenerateNeededStockMultiDistributorAndProduct]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ReplenishmentMaster");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Datefrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Dateto));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.NVarChar, 5000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.DistributorIdsMultiple));
                cmdToExecute.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar, 5000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.ProductId));

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
                //    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::SelectAll::Error occured.", ex);
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

        public DataTable GetDistributorAgainstMultipleIds()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDistributorMstSetupMultipleSelect]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ReplenishmentMaster");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar, 5000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.DistributorIdsMultiple));

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
                //    throw new Exception("Stored Procedure 'sp_ReplenishmentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ReplenishmentMaster::SelectAll::Error occured.", ex);
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
                //cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.TableName));
                //cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentMasterProperty.Operated_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.DistributorID));

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
    }
}
