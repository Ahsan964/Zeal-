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
    public class Discount_Slabs_Setup_DAL : DBInteractionBase
    {
        private Discount_Slabs_Setup_Property objDiscountSlabsSetup;

        public Discount_Slabs_Setup_DAL(Discount_Slabs_Setup_Property objDiscount_Slabs_Setup_Property)
        {
            objDiscountSlabsSetup = objDiscount_Slabs_Setup_Property;
        }

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISCOUNT_SLABS_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.ID));
               // cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcFrom_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.From_Value));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTo_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.To_Value));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFor_Each", SqlDbType.Decimal , 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.For_Each));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount_Limit", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Discount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Description", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Operation_Date));


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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISCOUNT_SLABS_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISCOUNT_SLABS_SETUP::Update::Error occured.", ex);
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

        public DataTable SelectAllByID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_DISCOUNT_SLAB_DETAIL_SELECTALL_BY_ID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("DISCOUNT_SLABS_SETUP ");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DETAILID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISCOUNT_MASTER_SelectAllWDiscount_Type_IDLogic' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISCOUNT_MASTER::SelectAllWDiscount_Type_IDLogic::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_DISCOUNT_SLABS_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _discount_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcFrom_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, _from_Value));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcTo_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, _to_Value));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iFor_Each", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _for_Each));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount_Limit", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, _discount_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, _discount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Description", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _short_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _iD));

               // cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDiscount_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Discount_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcFrom_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.From_Value));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcTo_Value", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.To_Value));
                cmdToExecute.Parameters.Add(new SqlParameter("@iFor_Each", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.For_Each));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount_Limit", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Discount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcDiscount", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 25, 4, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Description", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objDiscountSlabsSetup.Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

              //  cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
              //  _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
               // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISCOUNT_SLABS_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("DISCOUNT_SLABS_SETUP::Insert::Error occured.", ex);
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

        public bool validateSlab(int discountID, int slabID, decimal fromQty, decimal toQty)
        {
            bool isValidSlab = true;

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_IsValidSlab]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;           

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@discountID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, discountID));
                cmdToExecute.Parameters.Add(new SqlParameter("@slabID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, slabID));
                cmdToExecute.Parameters.Add(new SqlParameter("@FromQty", SqlDbType.Decimal, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, fromQty));
                cmdToExecute.Parameters.Add(new SqlParameter("@ToQty", SqlDbType.Decimal, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, toQty));
                cmdToExecute.Parameters.Add(new SqlParameter("@retVal", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, 0));
                // cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                cmdToExecute.ExecuteNonQuery();

                if (cmdToExecute.Parameters["@retVal"].Value.ToString() == "1")
                    isValidSlab = false;

                return isValidSlab;
            }
            catch (Exception ex)
            {
                throw new Exception("DISCOUNT_MASTER::SelectAllWDiscount_Type_IDLogic::Error occured.", ex);
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
            return isValidSlab;
        }

     
    }
}
