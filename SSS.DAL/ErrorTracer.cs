using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SNDDAL
{
    public class ErrorTracer : DBInteractionBase
    {

        #region Class Member Declarations
        private SqlDateTime _error_Date;
        private SqlInt32 _error_Line, _error_ID, _error_Severity, _error_Number, _error_State;
        private SqlString _error_Msg, _user_Name, _error_Proc;
        #endregion

        /// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public ErrorTracer()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>Error_Number. May be SqlInt32.Null</LI>
		///		 <LI>Error_State. May be SqlInt32.Null</LI>
		///		 <LI>Error_Severity. May be SqlInt32.Null</LI>
		///		 <LI>Error_Line. May be SqlInt32.Null</LI>
		///		 <LI>Error_Proc. May be SqlString.Null</LI>
		///		 <LI>Error_Msg. May be SqlString.Null</LI>
		///		 <LI>User_Name. May be SqlString.Null</LI>
		///		 <LI>Error_Date. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>Error_ID</LI>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_ERROR_TRACER_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iError_Number", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _error_Number));
				cmdToExecute.Parameters.Add(new SqlParameter("@iError_State", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _error_State));
				cmdToExecute.Parameters.Add(new SqlParameter("@iError_Severity", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _error_Severity));
				cmdToExecute.Parameters.Add(new SqlParameter("@iError_Line", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _error_Line));
				cmdToExecute.Parameters.Add(new SqlParameter("@sError_Proc", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _error_Proc));
				cmdToExecute.Parameters.Add(new SqlParameter("@sError_Msg", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _error_Msg));
				cmdToExecute.Parameters.Add(new SqlParameter("@sUser_Name", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _user_Name));
				cmdToExecute.Parameters.Add(new SqlParameter("@daError_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _error_Date));
				cmdToExecute.Parameters.Add(new SqlParameter("@iError_ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _error_ID));
				cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                _error_ID = (SqlInt32)cmdToExecute.Parameters["@iError_ID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_ERROR_TRACER_Insert' reported the ErrorCode: " + _errorCode);
                }

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("ERROR_TRACER::Insert::Error occured.", ex);
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


		#region Class Property Declarations
		public SqlInt32 Error_ID
		{
			get
			{
				return _error_ID;
			}
			set
			{
				SqlInt32 error_IDTmp = (SqlInt32)value;
				if(error_IDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Error_ID", "Error_ID can't be NULL");
				}
				_error_ID = value;
			}
		}


		public SqlInt32 Error_Number
		{
			get
			{
				return _error_Number;
			}
			set
			{
				_error_Number = value;
			}
		}


		public SqlInt32 Error_State
		{
			get
			{
				return _error_State;
			}
			set
			{
				_error_State = value;
			}
		}


		public SqlInt32 Error_Severity
		{
			get
			{
				return _error_Severity;
			}
			set
			{
				_error_Severity = value;
			}
		}


		public SqlInt32 Error_Line
		{
			get
			{
				return _error_Line;
			}
			set
			{
				_error_Line = value;
			}
		}


		public SqlString Error_Proc
		{
			get
			{
				return _error_Proc;
			}
			set
			{
				_error_Proc = value;
			}
		}


		public SqlString Error_Msg
		{
			get
			{
				return _error_Msg;
			}
			set
			{
				_error_Msg = value;
			}
		}


		public SqlString User_Name
		{
			get
			{
				return _user_Name;
			}
			set
			{
				_user_Name = value;
			}
		}


		public SqlDateTime Error_Date
		{
			get
			{
				return _error_Date;
			}
			set
			{
				_error_Date = value;
			}
		}
		#endregion










    }
}
