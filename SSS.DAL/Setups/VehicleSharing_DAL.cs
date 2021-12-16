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
    public class VehicleSharing_DAL : DBInteractionBase
    {
        private VehicleSharingDetail_Property objVehicleSharingDetailProperty;
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public VehicleSharing_DAL(VehicleSharingDetail_Property objVehicleSharingDetail_Property)
		{
            objVehicleSharingDetailProperty = objVehicleSharingDetail_Property;
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
		///		 <LI>VehicleID. May be SqlInt32.Null</LI>
		///		 <LI>VehicleNo. May be SqlString.Null</LI>
		///		 <LI>MonthlyRent. May be SqlDecimal.Null</LI>
		///		 <LI>Percentage. May be SqlDecimal.Null</LI>
		///		 <LI>Amount. May be SqlDecimal.Null</LI>
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
		public int Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetail_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DistributorId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iDeliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DeliveryManId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iVehicleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.VehicleID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sVehicleNo", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.VehicleNo));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcMonthlyRent", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.MonthlyRent));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcPercentage", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Percentage));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Amount));
				cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Status));
				cmdToExecute.Parameters.Add(new SqlParameter("@iInsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.InsertedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daInsertedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.InsertedOn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iUpdatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daUpdatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedOn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iClaimStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.ClaimStatus));

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
                return _rowsAffected;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("VehicleSharingDetail::Insert::Error occured.", ex);
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
		///		 <LI>VehicleID. May be SqlInt32.Null</LI>
		///		 <LI>VehicleNo. May be SqlString.Null</LI>
		///		 <LI>MonthlyRent. May be SqlDecimal.Null</LI>
		///		 <LI>Percentage. May be SqlDecimal.Null</LI>
		///		 <LI>Amount. May be SqlDecimal.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>InsertedBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertedOn. May be SqlDateTime.Null</LI>
		///		 <LI>UpdatedBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdatedOn. May be SqlDateTime.Null</LI>
		/// </UL>
		/// </remarks>
		public int Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetail_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Id));
				cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DistributorId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iDeliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DeliveryManId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iVehicleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.VehicleID));
				cmdToExecute.Parameters.Add(new SqlParameter("@sVehicleNo", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.VehicleNo));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcMonthlyRent", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.MonthlyRent));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcPercentage", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Percentage));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Amount));
				cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Status));
				//cmdToExecute.Parameters.Add(new SqlParameter("@iInsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.InsertedBy));
				//cmdToExecute.Parameters.Add(new SqlParameter("@daInsertedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.InsertedOn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iUpdatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daUpdatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedOn));
                cmdToExecute.Parameters.Add(new SqlParameter("@iClaimStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.ClaimStatus));
				
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
                return _rowsAffected;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("VehicleSharingDetail::Update::Error occured.", ex);
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
		public int Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetail_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.UpdatedOn));

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
                return _rowsAffected;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("VehicleSharingDetail::Delete::Error occured.", ex);
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
		///		 <LI>VehicleID</LI>
		///		 <LI>VehicleNo</LI>
		///		 <LI>MonthlyRent</LI>
		///		 <LI>Percentage</LI>
		///		 <LI>Amount</LI>
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
			cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetail_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("VehicleSharingDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.Id));

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
                //    _vehicleID = toReturn.Rows[0]["VehicleID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["VehicleID"];
                //    _vehicleNo = toReturn.Rows[0]["VehicleNo"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["VehicleNo"];
                //    _monthlyRent = toReturn.Rows[0]["MonthlyRent"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["MonthlyRent"];
                //    _percentage = toReturn.Rows[0]["Percentage"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Percentage"];
                //    _amount = toReturn.Rows[0]["Amount"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Amount"];
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
				throw new Exception("VehicleSharingDetail::SelectOne::Error occured.", ex);
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
        
        public DataTable GetVehicleSharingDetailByDeliverManId()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetailByDeliverManId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("VehicleSharingDetail");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@deliveryManId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DeliveryManId));

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
                throw new Exception("VehicleSharingDetail::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_VehicleSharingDetail_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("VehicleSharingDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVehicleSharingDetailProperty.DistributorId));

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
				throw new Exception("VehicleSharingDetail::SelectAll::Error occured.", ex);
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
