using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SNDDAL;
using SSS.Property.Setups;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace SSS.DAL.Setups
{
    public class Discount_Pos_Detail_DAL : DBInteractionBase
    {
        Discount_Pos_Detail_Property objDiscount_Pos_Detail_Property;

        public Discount_Pos_Detail_DAL(Discount_Pos_Detail_Property obj_Discount_Pos_Detail_Property)
        {
            objDiscount_Pos_Detail_Property = obj_Discount_Pos_Detail_Property;
        }
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[Discount_Pos_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                // The formal parameter "@ID" was not declared as an OUTPUT parameter, but the actual parameter passed in requested output.
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.DiscountId));
              //  cmdToExecute.Parameters.Add(new SqlParameter("@Business_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Business_Type_Detail_Property.BusinessTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@POS_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.POS_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.ID));
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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Discount_BusinessTypeAndPos_Insert' reported the ErrorCode: " + _errorCode);
                    // return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Discount_BusinessType::Insert::Error occured.", ex);
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
        public DataTable Select_DiscountPOS_BUS_DIST_POSTYPE()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[Select_DiscountPOS_BUS_DIST_POSTYPE]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable Discount = new DataTable("DiscountPOS_BUS_DIST_POSTYPE");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                // The formal parameter "@ID" was not declared as an OUTPUT parameter, but the actual parameter passed in requested output.
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.DiscountId));
                //  cmdToExecute.Parameters.Add(new SqlParameter("@Business_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Business_Type_Detail_Property.BusinessTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.Status));



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
                // _rowsAffected = cmdToExecute.ExecuteNonQuery();
                adapter.Fill(Discount);
                // _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Discount_Pos_Type_Insert' reported the ErrorCode: " + _errorCode);
                    // return false;
                }

                return Discount;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Discount_BusinessType::Insert::Error occured.", ex);
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
        public bool InsertPosType()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[Discount_Pos_Type_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                // The formal parameter "@ID" was not declared as an OUTPUT parameter, but the actual parameter passed in requested output.
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.DiscountId));
                //  cmdToExecute.Parameters.Add(new SqlParameter("@Business_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Business_Type_Detail_Property.BusinessTypeId));
                cmdToExecute.Parameters.Add(new SqlParameter("@POS_TypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.POS_TypeID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@@Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objDiscount_Pos_Detail_Property.ID));
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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'Discount_Pos_Type_Insert' reported the ErrorCode: " + _errorCode);
                    // return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Discount_BusinessType::Insert::Error occured.", ex);
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
