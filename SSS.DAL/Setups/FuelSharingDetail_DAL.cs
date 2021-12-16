using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using System.Data.SqlClient;
using System.Data;
using SNDDAL;

namespace SSS.DAL.Setups
{
    public class FuelSharingDetail_DAL : DBInteractionBase
    {
        private FuelSharingDetail_Property objFuelSharingDetailProperty;
        /// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public FuelSharingDetail_DAL(FuelSharingDetail_Property objFuelSharingDetail_Property)
		{
            objFuelSharingDetailProperty = objFuelSharingDetail_Property;
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>DistributorId. May be SqlInt32.Null</LI>
		///		 <LI>DeliveryManId. May be SqlInt32.Null</LI>
		///		 <LI>VehicleId. May be SqlInt32.Null</LI>
		///		 <LI>VehicleNo. May be SqlString.Null</LI>
		///		 <LI>ClosingDate. May be SqlDateTime.Null</LI>
		///		 <LI>FuelTypeId. May be SqlInt32.Null</LI>
		///		 <LI>StartReading. May be SqlInt32.Null</LI>
		///		 <LI>EndReading. May be SqlInt32.Null</LI>
		///		 <LI>TotalTravelingInKm. May be SqlDecimal.Null</LI>
		///		 <LI>TotalFuelAmount. May be SqlDecimal.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>InsertedBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertedOn. May be SqlDateTime.Null</LI>
		///		 <LI>UpdatedBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdatedOn. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>Id</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSharingDetail_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DistributorId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iDeliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DeliveryManId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iVehicleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.VehicleId));
				cmdToExecute.Parameters.Add(new SqlParameter("@sVehicleNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.VehicleNo));
				cmdToExecute.Parameters.Add(new SqlParameter("@daClosingDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.ClosingDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@iFuelTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.FuelTypeId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iStartReading", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.StartReading));
				cmdToExecute.Parameters.Add(new SqlParameter("@iEndReading", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.EndReading));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcTotalTravelingInKm", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.TotalTravelingInKm));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcTotalFuelAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.TotalFuelAmount));
				cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Status));
				cmdToExecute.Parameters.Add(new SqlParameter("@iInsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.InsertedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daInsertedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.InsertedOn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iUpdatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.UpdatedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daUpdatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.UpdatedOn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Id));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				//_id = (Int32)cmdToExecute.Parameters["@iId"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("FuelSharingDetail::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
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
		///		 <LI>Id</LI>
		///		 <LI>DistributorId. May be SqlInt32.Null</LI>
		///		 <LI>DeliveryManId. May be SqlInt32.Null</LI>
		///		 <LI>VehicleId. May be SqlInt32.Null</LI>
		///		 <LI>VehicleNo. May be SqlString.Null</LI>
		///		 <LI>ClosingDate. May be SqlDateTime.Null</LI>
		///		 <LI>FuelTypeId. May be SqlInt32.Null</LI>
		///		 <LI>StartReading. May be SqlInt32.Null</LI>
		///		 <LI>EndReading. May be SqlInt32.Null</LI>
		///		 <LI>TotalTravelingInKm. May be SqlDecimal.Null</LI>
		///		 <LI>TotalFuelAmount. May be SqlDecimal.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>InsertedBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertedOn. May be SqlDateTime.Null</LI>
		///		 <LI>UpdatedBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdatedOn. May be SqlDateTime.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSharingDetail_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDeliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DeliveryManId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iVehicleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.VehicleId));
                cmdToExecute.Parameters.Add(new SqlParameter("@sVehicleNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.VehicleNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@daClosingDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.ClosingDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFuelTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.FuelTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iStartReading", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.StartReading));
                cmdToExecute.Parameters.Add(new SqlParameter("@iEndReading", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.EndReading));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTotalTravelingInKm", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.TotalTravelingInKm));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTotalFuelAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.TotalFuelAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iInsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daInsertedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.InsertedOn));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.UpdatedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.UpdatedOn));
				
				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("FuelSharingDetail::Update::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Id</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSharingDetail_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Id));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("FuelSharingDetail::Delete::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
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
		///		 <LI>Id</LI>
		///		 <LI>DistributorId</LI>
		///		 <LI>DeliveryManId</LI>
		///		 <LI>VehicleId</LI>
		///		 <LI>VehicleNo</LI>
		///		 <LI>ClosingDate</LI>
		///		 <LI>FuelTypeId</LI>
		///		 <LI>StartReading</LI>
		///		 <LI>EndReading</LI>
		///		 <LI>TotalTravelingInKm</LI>
		///		 <LI>TotalFuelAmount</LI>
		///		 <LI>Status</LI>
		///		 <LI>InsertedBy</LI>
		///		 <LI>InsertedOn</LI>
		///		 <LI>UpdatedBy</LI>
		///		 <LI>UpdatedOn</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSharingDetail_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("FuelSharingDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.Id));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
                //if(toReturn.Rows.Count > 0)
                //{
                //    _id = (Int32)toReturn.Rows[0]["Id"];
                //    _distributorId = toReturn.Rows[0]["DistributorId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DistributorId"];
                //    _deliveryManId = toReturn.Rows[0]["DeliveryManId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DeliveryManId"];
                //    _vehicleId = toReturn.Rows[0]["VehicleId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["VehicleId"];
                //    _vehicleNo = toReturn.Rows[0]["VehicleNo"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["VehicleNo"];
                //    _closingDate = toReturn.Rows[0]["ClosingDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["ClosingDate"];
                //    _fuelTypeId = toReturn.Rows[0]["FuelTypeId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["FuelTypeId"];
                //    _startReading = toReturn.Rows[0]["StartReading"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["StartReading"];
                //    _endReading = toReturn.Rows[0]["EndReading"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["EndReading"];
                //    _totalTravelingInKm = toReturn.Rows[0]["TotalTravelingInKm"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["TotalTravelingInKm"];
                //    _totalFuelAmount = toReturn.Rows[0]["TotalFuelAmount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["TotalFuelAmount"];
                //    _status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                //    _insertedBy = toReturn.Rows[0]["InsertedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["InsertedBy"];
                //    _insertedOn = toReturn.Rows[0]["InsertedOn"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["InsertedOn"];
                //    _updatedBy = toReturn.Rows[0]["UpdatedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["UpdatedBy"];
                //    _updatedOn = toReturn.Rows[0]["UpdatedOn"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["UpdatedOn"];
                //}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("FuelSharingDetail::SelectOne::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

        public DataSet GetFuelSharingDetailDAL()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetFuelSharingDetail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("FuelSharingDetail");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@deliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.DeliveryManId));
                cmdToExecute.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.UpdatedOn));
                cmdToExecute.Parameters.Add(new SqlParameter("@transactionDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSharingDetailProperty.InsertedOn));

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
                throw new Exception("FuelSharingDetail::SelectOne::Error occured.", ex);
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
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSharingDetail_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("FuelSharingDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				adapter.Fill(toReturn);
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("FuelSharingDetail::SelectAll::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
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
