using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using SNDDAL;
using SSS.Property.Setups;
using SSS.Property;

namespace SSS.DAL.Setups
{
    public class Vehicle_DAL : DBInteractionBase
    {
        Vehicle_Property objVehicle_Property;

        public Vehicle_DAL(Vehicle_Property obj)
        {
            objVehicle_Property = obj;
        }

        public int Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Vehicle_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt32(SessionManager.CurrentUser.ID)));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@VehicleType", SqlDbType.VarChar, 16, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.VehicleType));
                cmdToExecute.Parameters.Add(new SqlParameter("@ShortDescription", SqlDbType.VarChar, 256, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ShortDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@LongDescription", SqlDbType.VarChar, 256, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.LongDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicle_Property.InsertBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.InsertionDate));
                
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
                return _rowsAffected; 
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception(ex.Message, ex);
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

        public int Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Vehicle_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt32(SessionManager.CurrentUser.ID)));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@VehicleType", SqlDbType.VarChar, 16, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.VehicleType));
                cmdToExecute.Parameters.Add(new SqlParameter("@ShortDescription", SqlDbType.VarChar, 256, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ShortDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@LongDescription", SqlDbType.VarChar, 256, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.LongDescription));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicle_Property.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@UpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.UpdationDate));

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
                return _rowsAffected;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception(ex.Message, ex);
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
        public DataTable GetGrid(int pageIndex, int pageSize, out int recordCount)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Get_Vehicle_Grid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Tax");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = _mainConnection;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, pageIndex));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.VarChar, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, pageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.VarChar, 16, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.VehicleType));

                cmdToExecute.Parameters["@RecordCount"].Direction = ParameterDirection.Output;

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
                adapter.Fill(toReturn);
                recordCount = Convert.ToInt32(cmdToExecute.Parameters["@RecordCount"].Value);

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception(ex.Message, ex);
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

        public DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Get_Vehicle]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Tax");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = _mainConnection;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@userID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt32(SessionManager.CurrentUser.ID)));
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ID));
                
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
                adapter.Fill(toReturn);
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception(ex.Message, ex);
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

        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Vehicle_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Tax");
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicle_Property.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@UpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicle_Property.UpdationDate));

                if (_mainConnectionIsCreatedLocal) {
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
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception(ex.Message, ex);
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
        /// </remarks>
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Vehicle_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Vehicle");
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
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Vehicle::SelectAll::Error occured.", ex);
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
