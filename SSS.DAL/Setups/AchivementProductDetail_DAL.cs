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
    public class AchivementProductDetail_DAL : DBInteractionBase
    {
    
       private AchivementProductDetail_Property objAProductDetailProperty;

       public AchivementProductDetail_DAL(AchivementProductDetail_Property objAProductDetail_Property)
        {
            objAProductDetailProperty = objAProductDetail_Property;
        }

       public DataTable GetProductDetailbyMasterID()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_GetAchProductDetail_MasterID]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;
           DataTable toReturn = new DataTable("ACHIVEMENTPRODUCT_DETAIL");
           SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.AchivementMasterID));
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
                   throw new Exception("Stored Procedure 'sp_GetAchProductDetail_MasterID' reported the ErrorCode: " + _errorCode);
               }

               return toReturn;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("ACHIVEMENTPRODUCT_DETAIL::SelectAll::Error occured.", ex);
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


       public override bool Insert()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_AchivementProductDetail_INSERT]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;

           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.AchivementMasterID));
               cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.ProductID));
               cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.Description));
               cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.Status));
               cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.InsertedBy));
               cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.InsertionDate));


               cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objAProductDetailProperty.ID));
               cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


             
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
               //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
               //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

               if (_errorCode != (int)LLBLError.AllOk)
               {
                   // Throw error.
                   throw new Exception("Stored Procedure 'sp_AchivementProductDetail_INSERT' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               // some error occured. Bubble it to caller and encapsulate Exception object
               throw new Exception("ACHIVEMENT_PRODUCT_DETAIL::Insert::Error occured.", ex);
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
