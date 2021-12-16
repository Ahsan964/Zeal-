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
   public class TargetType_DAL : DBInteractionBase
    {
         private TargetType_Property objTargetTypeProperty;

         public TargetType_DAL(TargetType_Property objTargetType_Property)
        {
            objTargetTypeProperty = objTargetType_Property;
        }


         public DataTable GetTargetType()
         {
             SqlCommand cmdToExecute = new SqlCommand();
             cmdToExecute.CommandText = "dbo.[sp_GetTargetType]";
             cmdToExecute.CommandType = CommandType.StoredProcedure;
             DataTable toReturn = new DataTable("TARGET_Type");
             SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

             // Use base class' connection object
             cmdToExecute.Connection = _mainConnection;

             try
             {
                // cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTargetPeriodProperty.ParentID));

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
                     throw new Exception("Stored Procedure 'sp_GetTargetType' reported the ErrorCode: " + _errorCode);
                 }

                 return toReturn;
             }
             catch (Exception ex)
             {
                 // some error occured. Bubble it to caller and encapsulate Exception object
                 throw new Exception("TARGET_Type::SelectAll::Error occured.", ex);
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
