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
    public class Replenishment_Detail_DAL : DBInteractionBase
    {
        private Replenishment_Detail_Property ObjReplenishmentDetailProperty;
        /// <summary>
		/// Purpose: Class constructor.
		/// </summary>
        public Replenishment_Detail_DAL()
		{
			// Nothing for now.
		}

        public Replenishment_Detail_DAL(Replenishment_Detail_Property objReplenishment_Detail_Property)
        {
            ObjReplenishmentDetailProperty = objReplenishment_Detail_Property;
        }

       /// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ReplenishmentMasterId. May be SqlInt32.Null</LI>
		///		 <LI>ProductId. May be SqlInt32.Null</LI>
		///		 <LI>ScmPrice. May be SqlDecimal.Null</LI>
		///		 <LI>Opening. May be SqlInt32.Null</LI>
		///		 <LI>PrimarySales. May be SqlInt32.Null</LI>
		///		 <LI>SalesReturn. May be SqlInt32.Null</LI>
		///		 <LI>TotalOnHandStock. May be SqlInt32.Null</LI>
		///		 <LI>TotalSecondarySales. May be SqlInt32.Null</LI>
		///		 <LI>Closing. May be SqlInt32.Null</LI>
		///		 <LI>AverageSales. May be SqlInt32.Null</LI>
		///		 <LI>SafetyStock. May be SqlInt32.Null</LI>
		///		 <LI>RDR. May be SqlInt32.Null</LI>
		///		 <LI>AdditionInOrder. May be SqlInt32.Null</LI>
		///		 <LI>TotalFinalDBR. May be SqlInt32.Null</LI>
		///		 <LI>DBRValue. May be SqlDecimal.Null</LI>
		///		 <LI>InsertBy. May be SqlInt32.Null</LI>
		///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
		///		 <LI>Status. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>Id</LI>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_ReplenishmentDetail_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iReplenishmentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.ReplenishmentMasterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@iProductId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.ProductId));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcScmPrice", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.ScmPrice));
				cmdToExecute.Parameters.Add(new SqlParameter("@iOpening", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.Opening));
				cmdToExecute.Parameters.Add(new SqlParameter("@iPrimarySales", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.PrimarySales));
				cmdToExecute.Parameters.Add(new SqlParameter("@iSalesReturn", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.SalesReturn));
				cmdToExecute.Parameters.Add(new SqlParameter("@iTotalOnHandStock", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.TotalOnHandStock));
				cmdToExecute.Parameters.Add(new SqlParameter("@iTotalSecondarySales", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.TotalSecondarySales));
				cmdToExecute.Parameters.Add(new SqlParameter("@iClosing", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.Closing));
				cmdToExecute.Parameters.Add(new SqlParameter("@iAverageSales", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.AverageSales));
				cmdToExecute.Parameters.Add(new SqlParameter("@iSafetyStock", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.SafetyStock));
				cmdToExecute.Parameters.Add(new SqlParameter("@iRDR", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.RDR));
				cmdToExecute.Parameters.Add(new SqlParameter("@iAdditionInOrder", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.AdditionInOrder));
				cmdToExecute.Parameters.Add(new SqlParameter("@iTotalFinalDBR", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.TotalFinalDBR));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcDBRValue", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 4, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.DBRValue));
				cmdToExecute.Parameters.Add(new SqlParameter("@iInsertBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.InsertBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@daInsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.InsertionDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.Status));
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjReplenishmentDetailProperty.Id));
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
				//_id = (Int32)cmdToExecute.Parameters["@iId"].Value;
				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_ReplenishmentDetail_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("ReplenishmentDetail::Insert::Error occured.", ex);
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
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>Id</LI>
		///		 <LI>ReplenishmentMasterId</LI>
		///		 <LI>ProductId</LI>
		///		 <LI>ScmPrice</LI>
		///		 <LI>Opening</LI>
		///		 <LI>PrimarySales</LI>
		///		 <LI>SalesReturn</LI>
		///		 <LI>TotalOnHandStock</LI>
		///		 <LI>TotalSecondarySales</LI>
		///		 <LI>Closing</LI>
		///		 <LI>AverageSales</LI>
		///		 <LI>SafetyStock</LI>
		///		 <LI>RDR</LI>
		///		 <LI>AdditionInOrder</LI>
		///		 <LI>TotalFinalDBR</LI>
		///		 <LI>DBRValue</LI>
		///		 <LI>InsertBy</LI>
		///		 <LI>InsertionDate</LI>
		///		 <LI>Status</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_ReplenishmentDetail_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("ReplenishmentDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,ObjReplenishmentDetailProperty.Id));
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
				adapter.Fill(toReturn);
				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_ReplenishmentDetail_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
                    //_id = (Int32)toReturn.Rows[0]["Id"];
                    //_replenishmentMasterId = toReturn.Rows[0]["ReplenishmentMasterId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["ReplenishmentMasterId"];
                    //_productId = toReturn.Rows[0]["ProductId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["ProductId"];
                    //_scmPrice = toReturn.Rows[0]["ScmPrice"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["ScmPrice"];
                    //_opening = toReturn.Rows[0]["Opening"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Opening"];
                    //_primarySales = toReturn.Rows[0]["PrimarySales"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["PrimarySales"];
                    //_salesReturn = toReturn.Rows[0]["SalesReturn"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["SalesReturn"];
                    //_totalOnHandStock = toReturn.Rows[0]["TotalOnHandStock"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["TotalOnHandStock"];
                    //_totalSecondarySales = toReturn.Rows[0]["TotalSecondarySales"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["TotalSecondarySales"];
                    //_closing = toReturn.Rows[0]["Closing"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Closing"];
                    //_averageSales = toReturn.Rows[0]["AverageSales"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["AverageSales"];
                    //_safetyStock = toReturn.Rows[0]["SafetyStock"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["SafetyStock"];
                    //_rDR = toReturn.Rows[0]["RDR"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["RDR"];
                    //_additionInOrder = toReturn.Rows[0]["AdditionInOrder"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["AdditionInOrder"];
                    //_totalFinalDBR = toReturn.Rows[0]["TotalFinalDBR"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["TotalFinalDBR"];
                    //_dBRValue = toReturn.Rows[0]["DBRValue"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["DBRValue"];
                    //_insertBy = toReturn.Rows[0]["InsertBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["InsertBy"];
                    //_insertionDate = toReturn.Rows[0]["InsertionDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["InsertionDate"];
                    //_status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("ReplenishmentDetail::SelectOne::Error occured.", ex);
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
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[sp_ReplenishmentDetail_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("ReplenishmentDetail");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
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
				adapter.Fill(toReturn);
				_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'sp_ReplenishmentDetail_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("ReplenishmentDetail::SelectAll::Error occured.", ex);
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
