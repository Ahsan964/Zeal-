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
    public class MiscellaneousExpenseDetail_DAL : DBInteractionBase
    {
        private MiscellaneousExpenseDetail_Property objMiscellaneousExpenseDetailProperty;
        
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public MiscellaneousExpenseDetail_DAL(MiscellaneousExpenseDetail_Property objMiscellaneousExpenseDetail_Property)
		{
            objMiscellaneousExpenseDetailProperty = objMiscellaneousExpenseDetail_Property;
		}
        
        /// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>MiscellaneousSetupId. May be SqlInt32.Null</LI>
		///		 <LI>DistributorId. May be SqlInt32.Null</LI>
		///		 <LI>ExpenseDate. May be SqlDateTime.Null</LI>
		///		 <LI>TransactionDate. May be SqlDateTime.Null</LI>
		///		 <LI>Details. May be SqlString.Null</LI>
		///		 <LI>Reasons. May be SqlString.Null</LI>
		///		 <LI>ReciptNo. May be SqlString.Null</LI>
		///		 <LI>ExpenseAmount. May be SqlDecimal.Null</LI>
		///		 <LI>ClaimStatus. May be SqlInt32.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>DataRefId. May be SqlInt32.Null</LI>
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
			cmdToExecute.CommandText = "dbo.[sp_MiscellaneousExpenseDetail_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iMiscellaneousSetupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.MiscellaneousSetupId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@daExpenseDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ExpenseDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.TransactionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDetails", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Details));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReasons", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Reasons));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReciptNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ReciptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcExpenseAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ExpenseAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@iClaimStatus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ClaimStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDataRefId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.DataRefId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iInsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.InsertBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daInsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Id));

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
				throw new Exception("MiscellaneousExpenseDetail::Insert::Error occured.", ex);
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
		///		 <LI>MiscellaneousSetupId. May be SqlInt32.Null</LI>
		///		 <LI>DistributorId. May be SqlInt32.Null</LI>
		///		 <LI>ExpenseDate. May be SqlDateTime.Null</LI>
		///		 <LI>TransactionDate. May be SqlDateTime.Null</LI>
		///		 <LI>Details. May be SqlString.Null</LI>
		///		 <LI>Reasons. May be SqlString.Null</LI>
		///		 <LI>ReciptNo. May be SqlString.Null</LI>
		///		 <LI>ExpenseAmount. May be SqlDecimal.Null</LI>
		///		 <LI>ClaimStatus. May be SqlInt32.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		///		 <LI>DataRefId. May be SqlInt32.Null</LI>
		///		 <LI>InsertBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
		///		 <LI>UpdateBy. May be SqlInt32.Null</LI>
		///		 <LI>UpdationDate. May be SqlDateTime.Null</LI>
		/// </UL>
		/// </remarks>
		public int Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_MiscellaneousExpenseDetail_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iMiscellaneousSetupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.MiscellaneousSetupId));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.DistributorId));
                cmdToExecute.Parameters.Add(new SqlParameter("@daExpenseDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ExpenseDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.TransactionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDetails", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Details));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReasons", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Reasons));
                cmdToExecute.Parameters.Add(new SqlParameter("@sReciptNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ReciptNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcExpenseAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ExpenseAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@iClaimStatus", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.ClaimStatus));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDataRefId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.DataRefId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iInsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.InsertBy));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daInsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdationDate));

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
				throw new Exception("MiscellaneousExpenseDetail::Update::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[sp_MiscellaneousExpenseDetail_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@iUpdateBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdateBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@daUpdationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.UpdationDate));

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
				throw new Exception("MiscellaneousExpenseDetail::Delete::Error occured.", ex);
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
		///		 <LI>MiscellaneousSetupId</LI>
		///		 <LI>DistributorId</LI>
		///		 <LI>ExpenseDate</LI>
		///		 <LI>TransactionDate</LI>
		///		 <LI>Details</LI>
		///		 <LI>Reasons</LI>
		///		 <LI>ReciptNo</LI>
		///		 <LI>ExpenseAmount</LI>
		///		 <LI>ClaimStatus</LI>
		///		 <LI>Status</LI>
		///		 <LI>DataRefId</LI>
		///		 <LI>InsertBy</LI>
		///		 <LI>InsertionDate</LI>
		///		 <LI>UpdateBy</LI>
		///		 <LI>UpdationDate</LI>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_MiscellaneousExpenseDetail_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("MiscellaneousExpenseDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.Id));

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
				throw new Exception("MiscellaneousExpenseDetail::SelectOne::Error occured.", ex);
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


		/// <summary>
		/// Purpose: SelectAll method. This method will Select all rows from the table.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_MiscellaneousExpenseDetail_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("MiscellaneousExpenseDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objMiscellaneousExpenseDetailProperty.DistributorId));

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
				throw new Exception("MiscellaneousExpenseDetail::SelectAll::Error occured.", ex);
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
