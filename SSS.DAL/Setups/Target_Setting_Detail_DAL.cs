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
    public class Target_Setting_Detail_DAL : DBInteractionBase
    {
        private Target_Setting_Detail_Property objTRSDproperty;

        public Target_Setting_Detail_DAL(Target_Setting_Detail_Property objTRSD_property)
        {
            objTRSDproperty = objTRSD_property;
        }



        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_InsertTargetSetting_Detail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@TargetSetup_MasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.TargetSetting_MasterID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Prod_CategoryID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.Prod_CategoryID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.ProductID));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaxTarget_Qty", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.MaxTarget_Qty));
                cmdToExecute.Parameters.Add(new SqlParameter("@MaxTarget_Amt", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.MaxTarget_Amt));
                cmdToExecute.Parameters.Add(new SqlParameter("@MinTarget_Qty", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.MinTarget_Qty));
                cmdToExecute.Parameters.Add(new SqlParameter("@MinTarget_Amt", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.MinTarget_Amt));
                cmdToExecute.Parameters.Add(new SqlParameter("@NumberofShops", SqlDbType.Decimal, 13, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.NumberofShops));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsCategory", SqlDbType.Bit,4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.IsCategory));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTRSDproperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTRSDproperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.InsertedBy));


                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.ID));
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
                // _iD = (Int32)cmdToExecute.Parameters["@ID"].Value;
                
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_InsertTargetSetting_Detail' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING_DETAIL::Insert::Error occured.", ex);
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


        public DataTable GetTargetSetting_Detail_byMasterID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetTargetSettingdetail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TARGET_SETTING");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
              cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTRSDproperty.TargetSetting_MasterID));
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
                    throw new Exception("Stored Procedure 'sp_GetTargetSettingdetail' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TARGET_SETTING::SelectAll::Error occured.", ex);
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
