using SNDDAL;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Setups
{
    public class CustomerType_DAL : DBInteractionBase
    {
        private CustomerType_Property objVendorType;
        public CustomerType_DAL(CustomerType_Property objVendor_Type)
        {
            objVendorType = objVendor_Type;
        }
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select concat(us.firstName,'',us.lastName) as userName,ct.* from customerType ct 
left join users us on us.idx=ct.createdByUserIdx where ct.visible=1";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Vendor_Category");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objUserProperty.branchIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Company_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Company_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Short_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Long_Description", SqlDbType.NVarChar, 1500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Long_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Address));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Fax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.TotalRowsNum));


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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                // objVendor_Type.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_selectAll_branch' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Branch::SelectAll::Error occured.", ex);
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
            cmdToExecute.CommandText = @"INSERT INTO CustomerType(customerType,createdByuserIdx)
                                       VALUES(@customerType,@createdByUserIdx)";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@customerType", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.customerType));

                cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.createdByUserIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sWebsite", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objVendor_Type.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_insert_company' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = @"UPDATE CustomerType SET customerType=@customerType,lastModifiedByUserIdx=@lastModifiedByUserIdx,lastModificationDate=@lastModificationDate where
                           idx=@idx
                                       ";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@customerType", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.customerType));

                cmdToExecute.Parameters.Add(new SqlParameter("@lastModifiedByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.lastModifiedByUserIdx));

                cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.lastModificationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendorType.idx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sWebsite", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objVendor_Type.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_insert_company' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::Insert::Error occured.", ex);
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

        public bool Delete(int? id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update CustomerType SET visible=0 where idx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@branchName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.branchName));
                //cmdToExecute.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.address));
                //cmdToExecute.Parameters.Add(new SqlParameter("@contactNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.contactNumber));
                //cmdToExecute.Parameters.Add(new SqlParameter("@lastModifiedByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.lastModifiedByUserIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.lastModificationDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isMainBranch", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.isMainBranch));

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
        public DataTable SelectById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select idx,customerType from CustomerType where idx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Vendor_Category");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objVendorType.idx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Company_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Company_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Short_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Long_Description", SqlDbType.NVarChar, 1500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Long_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Address));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Fax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objVendor_Type.TotalRowsNum));


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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                // objVendor_Type.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_selectAll_branch' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Branch::SelectAll::Error occured.", ex);
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
