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

namespace SSS.DAL.Setups
{
   public class Special_DiscountMasterDAL : DBInteractionBase
    {

       private Special_Discount_Master_Property objSpecialDiscountMasterProperty;
       public Special_DiscountMasterDAL()
        {
        }
       public Special_DiscountMasterDAL(Special_Discount_Master_Property objSpecial_Discount_Master_Property)
        {
            objSpecialDiscountMasterProperty = objSpecial_Discount_Master_Property;
        }

       public override bool Insert()
       {
           SqlCommand cmdToExecute = new SqlCommand();
           cmdToExecute.CommandText = "dbo.[sp_Special_Discount_Master_Insert]";
           cmdToExecute.CommandType = CommandType.StoredProcedure;

           // Use base class' connection object
           cmdToExecute.Connection = _mainConnection;
           cmdToExecute.CommandTimeout = 0;
           try
           {
               cmdToExecute.Parameters.Add(new SqlParameter("@iCashMemoId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.CashMemoId));
               cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.Distributor_Id));
               cmdToExecute.Parameters.Add(new SqlParameter("@iOverAll_Free_Peices", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.OverAll_Free_Peices));
               cmdToExecute.Parameters.Add(new SqlParameter("@dcOverAll_Discount_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.OverAll_Discount_Amount));
               cmdToExecute.Parameters.Add(new SqlParameter("@dcOverAll_Percentage_Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.OverAll_Percentage_Amount));
               cmdToExecute.Parameters.Add(new SqlParameter("@sstatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.Status));
               cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objSpecialDiscountMasterProperty.Id));
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

               this.StartTransaction();
               cmdToExecute.Transaction = this.Transaction;
               // Execute query.
               _rowsAffected = cmdToExecute.ExecuteNonQuery();
               //_id = (Int32)cmdToExecute.Parameters["@iid"].Value;
               //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

            //   objSpecialDiscountMasterProperty.Id = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
               if (objSpecialDiscountMasterProperty.DetailData != null)
               {
                   foreach (DataRow row in objSpecialDiscountMasterProperty.DetailData.Rows)
                       row["Transaction_Id"] = cmdToExecute.Parameters["@iid"].Value.ToString();

                   objSpecialDiscountMasterProperty.DetailData.AcceptChanges();

                   SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                   objSpecialDiscountMasterProperty.DetailData.TableName = "Special_Discount_Detail";

                   sbc.ColumnMappings.Clear();
                   sbc.ColumnMappings.Add(1, 1);
                   sbc.ColumnMappings.Add(2, 2);
                   sbc.ColumnMappings.Add(3, 3);
                   sbc.ColumnMappings.Add(4, 4);
                   sbc.ColumnMappings.Add(5, 5);
                   sbc.ColumnMappings.Add(6, 6);
                   sbc.ColumnMappings.Add(7, 7);
                   sbc.ColumnMappings.Add(8, 8);
                   sbc.ColumnMappings.Add(9, 9);
                   sbc.ColumnMappings.Add(10, 10);
                   sbc.ColumnMappings.Add(11, 11);



                   sbc.DestinationTableName = objSpecialDiscountMasterProperty.DetailData.TableName;
                   sbc.WriteToServer(objSpecialDiscountMasterProperty.DetailData);

               }
               this.Commit();
               if (_errorCode != (int)LLBLError.AllOk)
               {
                   this.RollBack();
                 //  throw new Exception("Stored Procedure 'sp_Special_Discount_Master_Insert' reported the ErrorCode: " + _errorCode);
               }

               return true;
           }
           catch (Exception ex)
           {
               this.RollBack();
               // some error occured. Bubble it to caller and encapsulate Exception object
               //throw new Exception("Special_Discount_Master::Insert::Error occured.", ex);

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
