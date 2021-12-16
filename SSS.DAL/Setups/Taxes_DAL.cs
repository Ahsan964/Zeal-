using SNDDAL;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SSS.DAL.Setups
{
    public class Taxes_DAL : DBInteractionBase
    {
        private Taxes_Property objTaxesProperty;

        public Taxes_DAL(Taxes_Property objTaxes_Property)
        {
            objTaxesProperty = objTaxes_Property;
        }
        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Company_Code. May be SqlString.Null</LI>
        ///		 <LI>Name. May be SqlString.Null</LI>
        ///		 <LI>Short_Description. May be SqlString.Null</LI>
        ///		 <LI>Long_Description. May be SqlString.Null</LI>
        ///		 <LI>Logo_Path. May be SqlString.Null</LI>
        ///		 <LI>Address. May be SqlString.Null</LI>
        ///		 <LI>Phone_Number1. May be SqlString.Null</LI>
        ///		 <LI>Phone_Number2. May be SqlString.Null</LI>
        ///		 <LI>Fax_Number. May be SqlString.Null</LI>
        ///		 <LI>Email. May be SqlString.Null</LI>
        ///		 <LI>Website. May be SqlString.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"INSERT INTO TAXES
(
taxName,taxPercent,createdByUserIdx,IsClaimble,shortName
)
values
(
@taxName,@taxPercent,@createdByUserIdx,@IsClaimble,@shortName
)";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@taxName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.taxName));
                cmdToExecute.Parameters.Add(new SqlParameter("@shortName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.shortName));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxPercent", SqlDbType.Decimal, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.taxPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.createdByUserIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsClaimble", SqlDbType.Bit, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.IsClaimble));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sWebsite", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objCompanyProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_insert_branch' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("BRanch::Insert::Error occured.", ex);
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


        /// <summary>
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Company_Code. May be SqlString.Null</LI>
        ///		 <LI>Name. May be SqlString.Null</LI>
        ///		 <LI>Short_Description. May be SqlString.Null</LI>
        ///		 <LI>Long_Description. May be SqlString.Null</LI>
        ///		 <LI>Logo_Path. May be SqlString.Null</LI>
        ///		 <LI>Address. May be SqlString.Null</LI>
        ///		 <LI>Phone_Number1. May be SqlString.Null</LI>
        ///		 <LI>Phone_Number2. May be SqlString.Null</LI>
        ///		 <LI>Fax_Number. May be SqlString.Null</LI>
        ///		 <LI>Email. May be SqlString.Null</LI>
        ///		 <LI>Website. May be SqlString.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        /// 

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update Taxes set taxName=@taxName,IsClaimble=@IsClaimble,taxPercent=@taxPercent,lastModifiedByUserIdx=@lastModifiedByUserIdx,
              lastModificationDate=@lastModificationDate,shortName=@shortName where idx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.idx));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.taxName));
                cmdToExecute.Parameters.Add(new SqlParameter("@shortName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.shortName));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxPercent", SqlDbType.Decimal, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.taxPercent));
                cmdToExecute.Parameters.Add(new SqlParameter("@lastModifiedByUserIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.lastModifiedByUserIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.lastModificationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsClaimble", SqlDbType.Bit, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.IsClaimble));
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


        /// <summary>
        /// Purpose: SelectAll method. This method will Select all rows from the table.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select concat(us.firstName,'',us.lastName) as userName,tr.* from taxes tr 
                                         left join users us on us.idx=tr.createdByUserIdx
                                         where tr.visible=1";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COMPANY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objCompanyProperty.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Company_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Company_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Short_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Long_Description", SqlDbType.NVarChar, 1500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Long_Description));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Address));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Phone_Number1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Phone_Number2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Fax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Fax_Number));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Website));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.TotalRowsNum));


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
                // objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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
        public  DataTable SelectAllTaxesForCheckBox()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select idx,concat(taxName,'(',taxPercent,'%',')') as taxName,IsClaimble,taxPercent from Taxes where visible=1";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Taxes");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
               

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
                // objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
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

        //public DataTable SelectAllMainBranch()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_selectAll_mainBranch]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable("COMPANY");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objCompanyProperty.ID));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Company_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Company_Code));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Name));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Short_Description));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Long_Description", SqlDbType.NVarChar, 1500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Long_Description));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Address));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number1", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Phone_Number1));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_Number2", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Phone_Number2));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Fax_Number", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Fax_Number));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Email));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Website));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.Status));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.PageNum));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.PageSize));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.SortColumn));
        //        //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.TotalRowsNum));


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
        //        adapter.Fill(toReturn);
        //        // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //        // objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_selectAll_mainBranch' reported the ErrorCode: " + _errorCode);
        //        }

        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("Branch::SelectAllmainBranch::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //        adapter.Dispose();
        //    }
        //}
        public DataTable SelectById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select * from taxes where idx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COMPANY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objTaxesProperty.idx));

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
                //objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_Branch_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public DataTable XElementToDataTable(XElement x)
        {
            DataTable dt = new DataTable();

            XElement setup = (from p in x.Descendants() select p).First();
            foreach (XElement xe in setup.Descendants()) // build your DataTable
                dt.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt

            var all = from p in x.Descendants(setup.Name.ToString()) select p;
            foreach (XElement xe in all)
            {
                DataRow dr = dt.NewRow();
                foreach (XElement xe2 in xe.Descendants())
                    dr[xe2.Name.ToString()] = xe2.Value; //add in the values
                dt.Rows.Add(dr);
            }
            return dt;
        }


        public bool Delete(int? id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "update taxes set visible =0 where idx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@branchName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.branchName));
                //cmdToExecute.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.address));
                //cmdToExecute.Parameters.Add(new SqlParameter("@contactNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.contactNumber));
                //cmdToExecute.Parameters.Add(new SqlParameter("@lastModifiedByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.lastModifiedByUserIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.lastModificationDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isMainBranch", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objTaxesProperty.isMainBranch));

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
