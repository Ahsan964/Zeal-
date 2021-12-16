using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNDDAL;
using SSS.Property.Setups;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace SSS.DAL.Setups
{
   public class Tax_DAL : DBInteractionBase
    {
       Tax_Property objTax_Property;

       public Tax_DAL(Tax_Property obj_Tax_Property)
       {
           objTax_Property = obj_Tax_Property;
       }

       public override bool Insert()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_Insert]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@TaxName", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.TaxName));
               cmdToExecute.Parameters.Add(new SqlParameter("@TaxRate", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.TaxRate));
               cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.Status));
               cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.ID));
               cmdToExecute.Parameters.Add(new SqlParameter("@regID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.RegID));
               cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
               cmdToExecute.Parameters.Add(new SqlParameter("@EffectiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.EffectiveFrom));
               
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
               _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

               if (_errorCode != (int)LLBLError.AllOk)
               {
                   // Throw error.
                   throw new Exception("Stored Procedure 'sp_Tax_Insert' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::Insert::Error occured.", ex);
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



       public override bool Update()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_Update]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@TaxName", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.TaxName));
               cmdToExecute.Parameters.Add(new SqlParameter("@TaxRate", SqlDbType.Decimal, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.TaxRate));
               cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.Status));
               cmdToExecute.Parameters.Add(new SqlParameter("@regID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.RegID));
               cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.ID));
               cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
               cmdToExecute.Parameters.Add(new SqlParameter("@EffectiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.EffectiveFrom));
               
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
               _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

               if (_errorCode != (int)LLBLError.AllOk)
               {
                   // Throw error.
                   throw new Exception("Stored Procedure 'sp_Tax_Insert' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::Insert::Error occured.", ex);
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
       public override bool Delete()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_Delete]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.ID));
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
               _rowsAffected = cmdToExecute.ExecuteNonQuery();
               _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

               if (_errorCode != (int)LLBLError.AllOk)
               {
                   // Throw error.
                   throw new Exception("Stored Procedure 'sp_Tax_Insert' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::Insert::Error occured.", ex);
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

       public  bool UpdateStatus()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_UpdateStatus]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.ID));
               cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.Status));
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
               _rowsAffected = cmdToExecute.ExecuteNonQuery();
               _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

               if (_errorCode != (int)LLBLError.AllOk)
               {
                   // Throw error.
                   throw new Exception("Stored Procedure 'sp_Tax_Insert' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::Insert::Error occured.", ex);
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

       public override DataTable SelectAll()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_SelectAll]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;
           DataTable toReturn = new DataTable("Tax");
           SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.Status));
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

               // Execute query.
               adapter.Fill(toReturn);
               //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

               //if (_errorCode != (int)LLBLError.AllOk)
               //{
               //    // Throw error.
               //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
               //}



               return toReturn;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::SelectAll::Error occured.", ex);
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



       public override DataTable SelectOne()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Tax_SelectOne]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;
           DataTable toReturn = new DataTable("Tax");
           SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTax_Property.ID));
           
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

               // Execute query.
               adapter.Fill(toReturn);
               //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

               //if (_errorCode != (int)LLBLError.AllOk)
               //{
               //    // Throw error.
               //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
               //}



               return toReturn;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("Tax::SelectAll::Error occured.", ex);
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
