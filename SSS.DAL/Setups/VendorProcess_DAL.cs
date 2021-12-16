using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SNDDAL;
using SSS.Property.Setups;
using System.Data.SqlClient;

namespace SSS.DAL.Setups
{
    public class VendorProcess_DAL : DBInteractionBase
    {
        private VendorProcessVM_Property _objVendorProcessVmProperty;

        public VendorProcess_DAL()
        {
            
        }
        public VendorProcess_DAL(VendorProcessVM_Property objVendorProcessVmProperty)
        {
            _objVendorProcessVmProperty = objVendorProcessVmProperty;
        }
        

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
          
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            try
            {
                   if (_mainConnectionIsCreatedLocal)
                   {
                    // Open connection.
                    //   _mainConnection.Open();
                    OpenConnection();
                   }
                   else
                   {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                   }
                   this.StartTransaction();
              
                if (_objVendorProcessVmProperty.DetailData != null)
                {
                    decimal totalmount;
                    foreach (DataRow row in _objVendorProcessVmProperty.DetailData.Rows)
                    {
                        row["creationDate"] = DateTime.Now;
                        row["CreatedBy"] = 1;
                        row["itemIdx"] = _objVendorProcessVmProperty.itemIdx;
                        //row["vendorCatIdx"] = _objVendorProcessVmProperty.vendorCatIdx;
                        //row["vendorIdx"] = _objVendorProcessVmProperty.vendorIdx;
                        //row["activityPrice"] = _objVendorProcessVmProperty.activityPrice;
                        row["visible"] = _objVendorProcessVmProperty.visible;
                        
                    }


                    _objVendorProcessVmProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    _objVendorProcessVmProperty.DetailData.TableName = "Vendor_Process_Price";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    sbc.ColumnMappings.Add("CreatedBy", "CreatedBy");
                    sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                    sbc.ColumnMappings.Add("vendorCatIdx", "vendorCatIdx");
                    sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                    sbc.ColumnMappings.Add("activityPrice", "activityPrice");
                    sbc.ColumnMappings.Add("visible", "visible");

                    sbc.DestinationTableName = _objVendorProcessVmProperty.DetailData.TableName;
                    sbc.WriteToServer(_objVendorProcessVmProperty.DetailData);

                }
                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        //public override bool Insert()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_VendorProcess]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@itemIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.itemIdx));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@vendorCatIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorCatIdx));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorIdx));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@activityPrice", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.activityPrice));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.DateTime, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.creationDate));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.CreatedBy));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Bit, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.visible));

        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }

        //        // Execute query.
        //        _rowsAffected = cmdToExecute.ExecuteNonQuery();
        //        // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
        //        // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_insert_user' reported the ErrorCode: " + _errorCode);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("user::Insert::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //}


        // Edit Vendor Process
        public DataTable selectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_selectOneVendorProcess";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select One Vendor Process");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@vendorCatIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorCatIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorIdx));

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



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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

        // Single vendor process data
        public DataTable singlevendorProcess()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_singleVendorProcess";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select One Vendor Process");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.itemIdx));
              

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



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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

        // For Vendor Process Main listing
        public DataTable viewAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetAllVendorProcess";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Vendor Process");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@itemIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.itemIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@vendorCatIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorCatIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.vendorIdx));

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



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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

        public bool DeleteAndInsert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "delete from Vendor_Process_Price where ID=" + _objVendorProcessVmProperty.ID;
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            try
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    //   _mainConnection.Open();
                    OpenConnection();
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
                //// Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                if (_objVendorProcessVmProperty.DetailData != null)
                {
                    foreach (DataRow row in _objVendorProcessVmProperty.DetailData.Rows)
                    {
                        row["creationDate"] = _objVendorProcessVmProperty.creationDate;
                        row["createdBy"] = _objVendorProcessVmProperty.CreatedBy;



                    }


                    _objVendorProcessVmProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    _objVendorProcessVmProperty.DetailData.TableName = "Vendor_Process_Price";

                    sbc.ColumnMappings.Clear();
                    //sbc.ColumnMappings.Add("activityDate", "activityDate");
                    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    sbc.ColumnMappings.Add("CreatedBy", "CreatedBy");
                    sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                    sbc.ColumnMappings.Add("vendorCatIdx", "vendorCatIdx");
                    sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                    sbc.ColumnMappings.Add("activityPrice", "activityPrice");
                    sbc.ColumnMappings.Add("visible", "visible");
                    sbc.DestinationTableName = _objVendorProcessVmProperty.DetailData.TableName;
                    sbc.WriteToServer(_objVendorProcessVmProperty.DetailData);

                }
                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update Vendor_Process_Price SET visible=0 where ID=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objVendorProcessVmProperty.ID));
                
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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_upate_branch' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Branch::Update::Error occured.", ex);
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
