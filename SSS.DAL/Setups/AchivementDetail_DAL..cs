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
    public class AchivementDetail_DAL : DBInteractionBase
    {

       private AchivementDetail_Property objAchivementDetailProperty;

       public AchivementDetail_DAL(AchivementDetail_Property objAchivementDetail_Property)
        {
            objAchivementDetailProperty = objAchivementDetail_Property;
        }

        public int InsertSlabDetail()
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_InsertAchivementSlab_Detail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterId", SqlDbType.Int, 4 , ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Achivement_MasterId));

                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Short_Description));


                cmdToExecute.Parameters.Add(new SqlParameter("@ValidFromValue", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ValidFromValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@ValidToValue", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ValidToValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsentiveAmount", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsentiveAmount));


                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsertionDate));

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ID));
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

                Int32 _iD = 0;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _iD = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_InsertAchivementSlab_Detail' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENTDetail::Insert::Error occured.", ex);
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

        public DataTable GetSlabDetailbyMasterID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetSlabDetail_MasterID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ACHIVEMENT_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Achivement_MasterId));
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
                    throw new Exception("Stored Procedure 'sp_GetSlabDetail_MasterID' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("ACHIVEMENT_DETAIL::SelectAll::Error occured.", ex);
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

        public bool validateAchivementSlab(int MasterID, int slabID, decimal fromQty, decimal toQty)
        {
            bool isValidSlab = true;

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_IsValidAchivementSlab]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MasterID));
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

        public DataTable GetSlabDetailByID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAchivemenDetailByID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("ACHIVEMENT_DETAIL");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_ACHIVEMENT_MASTER_SelectAllWDiscount_Type_IDLogic' reported the ErrorCode: " + _errorCode);
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

        public int UpdateSlabDetail()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_UpdateAchivementSlab_Detail]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ID));
                
                cmdToExecute.Parameters.Add(new SqlParameter("@AchivementMasterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Achivement_MasterId));

                cmdToExecute.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Short_Description));


                cmdToExecute.Parameters.Add(new SqlParameter("@ValidFromValue", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ValidFromValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@ValidToValue", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.ValidToValue));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsentiveAmount", SqlDbType.Decimal, 12, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsentiveAmount));


                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsertedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@InsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objAchivementDetailProperty.InsertionDate));
                
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

                Int32 _iD = 0;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                _iD = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
                
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_DISCOUNT_SLABS_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

                return _iD;
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

    }



}
