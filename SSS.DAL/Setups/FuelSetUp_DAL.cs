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
    public class FuelSetUp_DAL : DBInteractionBase
    {
        private FuelSetUp_Property objFuelSetUpProperty;
        
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public FuelSetUp_DAL(FuelSetUp_Property objFuelSetUp_Property)
		{
            objFuelSetUpProperty = objFuelSetUp_Property;
		}
        
		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>FuelTypeId. May be SqlInt32.Null</LI>
		///		 <LI>FuelRate. May be SqlDecimal.Null</LI>
		///		 <LI>ConsumptionInKm. May be SqlDecimal.Null</LI>
		///		 <LI>ValidFrom. May be SqlDateTime.Null</LI>
		///		 <LI>ValidTo. May be SqlDateTime.Null</LI>
		///		 <LI>Description. May be SqlString.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>InsertBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
		///		 <LI>UpdateBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdationDate. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>Id</LI>
		/// </UL>
		/// </remarks>
		public int Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSetup_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iFuelTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.FuelTypeId));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcFuelRate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSetUpProperty.FuelRate));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcConsumptionInKm", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSetUpProperty.ConsumptionInKm));
				cmdToExecute.Parameters.Add(new SqlParameter("@daValidFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.ValidFrom));
				cmdToExecute.Parameters.Add(new SqlParameter("@daValidTo", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.ValidTo));
				cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Description));
				cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Status));
				cmdToExecute.Parameters.Add(new SqlParameter("@iInsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.InsertBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daInsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.InsertionDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdateBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdationDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Id));

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
				throw new Exception("FuelSetup::Insert::Error occured.", ex);
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
		///		 <LI>FuelTypeId. May be SqlInt32.Null</LI>
		///		 <LI>FuelRate. May be SqlDecimal.Null</LI>
		///		 <LI>ConsumptionInKm. May be SqlDecimal.Null</LI>
		///		 <LI>ValidFrom. May be SqlDateTime.Null</LI>
		///		 <LI>ValidTo. May be SqlDateTime.Null</LI>
		///		 <LI>Description. May be SqlString.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>InsertBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
		///		 <LI>UpdateBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdationDate. May be SqlDateTime.Null</LI>
		/// </UL>
		/// </remarks>
		public int Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSetup_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFuelTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.FuelTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcFuelRate", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSetUpProperty.FuelRate));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcConsumptionInKm", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objFuelSetUpProperty.ConsumptionInKm));
                cmdToExecute.Parameters.Add(new SqlParameter("@daValidFrom", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.ValidFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@daValidTo", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.ValidTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iInsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.InsertBy));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daInsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdationDate));
				
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
				throw new Exception("FuelSetup::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_FuelSetup_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdationDate));
				
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
				throw new Exception("FuelSetup::Delete::Error occured.", ex);
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
		///		 <LI>FuelTypeId</LI>
		///		 <LI>FuelRate</LI>
		///		 <LI>ConsumptionInKm</LI>
		///		 <LI>ValidFrom</LI>
		///		 <LI>ValidTo</LI>
		///		 <LI>Description</LI>
		///		 <LI>Status</LI>
		///		 <LI>InsertBy</LI>
		///		 <LI>InsertionDate</LI>
		///		 <LI>UpdateBy</LI>
		///		 <LI>UpdationDate</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_FuelSetup_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("FuelSetup");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.Id));

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
				throw new Exception("FuelSetup::SelectOne::Error occured.", ex);
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

        public DataTable SelectFuelSetupByTransactionDateAndFuelTypeId()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_FuelSetupGetByTransactionDateAndFuelTypeId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("FuelSetup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@FuelTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.FuelTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFuelSetUpProperty.UpdationDate));

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
                throw new Exception("FuelSetup::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_FuelSetup_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("FuelSetup");
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
				throw new Exception("FuelSetup::SelectAll::Error occured.", ex);
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
