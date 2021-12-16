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
using System.Xml;
using System.Xml.Linq;

namespace SSS.DAL.Setups
{
    public class Company_DAL : DBInteractionBase
    {
        private Company_Property objCompanyProperty;

        public Company_DAL(Company_Property objCompany_Property)
        {
            objCompanyProperty = objCompany_Property;
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
            cmdToExecute.CommandText = "dbo.[sp_insert_company]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@companyName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.companyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@ownerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.ownerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@STRN", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.STRN));
                cmdToExecute.Parameters.Add(new SqlParameter("@NTN", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.NTN));
                cmdToExecute.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.address));
                cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.createdByUserIdx));


                cmdToExecute.Parameters.Add(new SqlParameter("@country", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.country));
                cmdToExecute.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.city));
                cmdToExecute.Parameters.Add(new SqlParameter("@state", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.state));
                cmdToExecute.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.email));
                cmdToExecute.Parameters.Add(new SqlParameter("@contactNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.contactNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@financialYearFrom", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.financialYearFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@financialYearTo", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.financialYearTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxYearFrom", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.taxYearFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxYearTo", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.taxYearTo));
                

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
            cmdToExecute.CommandText = "dbo.[sp_update_company]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 5000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.idx));
                cmdToExecute.Parameters.Add(new SqlParameter("@companyName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.companyName));
                cmdToExecute.Parameters.Add(new SqlParameter("@ownerName", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.ownerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@STRN", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.STRN));
                cmdToExecute.Parameters.Add(new SqlParameter("@NTN", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.NTN));
                cmdToExecute.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.address));
                cmdToExecute.Parameters.Add(new SqlParameter("@lastModifiedByUserIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.lastModifiedByUserIdx));

                cmdToExecute.Parameters.Add(new SqlParameter("@country", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.country));
                cmdToExecute.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.city));
                cmdToExecute.Parameters.Add(new SqlParameter("@state", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.state));
                cmdToExecute.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.email));
                cmdToExecute.Parameters.Add(new SqlParameter("@contactNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.contactNumber));
                cmdToExecute.Parameters.Add(new SqlParameter("@financialYearFrom", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.financialYearFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@financialYearTo", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.financialYearTo));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxYearFrom", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.taxYearFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@taxYearTo", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.taxYearTo));
                //cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.lastModificationDate));

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
                    throw new Exception("Stored Procedure 'sp_update_company' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::Update::Error occured.", ex);
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
            //cmdToExecute.CommandText = "dbo.[sp_COMPANY_SelectAll]";
            cmdToExecute.CommandText = @"select Concat(us.firstName,'',us.lastName) as userName,co.* from company co
inner join Users us on co.createdByUserIdx=us.idx  where co.visible=1";
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
                    throw new Exception("Stored Procedure 'sp_COMPANY_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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

        public DataTable SelectById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_COMPANY_GetById]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("COMPANY");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objCompanyProperty.idx));
                
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
                    throw new Exception("Stored Procedure 'sp_COMPANY_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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




        //public DataTable SelectByDistributerID(int DistributerID)
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_COMPANY_DstributerID]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable("COMPANY_SETUP");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@DistributerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DistributerID));
        //        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed ,_errorCode));

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
        //       // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        if (_errorCode != (int)LLBLError.AllOk)
        //        {
        //            // Throw error.
        //            throw new Exception("Stored Procedure 'sp_COMPANY_DstributerID' reported the ErrorCode: " + _errorCode);
        //        }

        //        if (toReturn.Rows.Count > 0)
        //        {
        //            objCompanyProperty.ID = (Int32)toReturn.Rows[0]["ID"];
        //            objCompanyProperty.Company_Code = (string)toReturn.Rows[0]["Company_Code"];
        //            objCompanyProperty.Name = toReturn.Rows[0]["Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Name"];
        //            objCompanyProperty.Short_Description = toReturn.Rows[0]["Short_Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Short_Description"];
        //            objCompanyProperty.Long_Description = toReturn.Rows[0]["Long_Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Long_Description"];
        //            objCompanyProperty.Logo_Path = toReturn.Rows[0]["Logo_Path"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Logo_Path"];
        //            objCompanyProperty.Address =  toReturn.Rows[0]["Address"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Address"];
        //            objCompanyProperty.Phone_Number1 = toReturn.Rows[0]["Phone_Number1"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone_Number1"];
        //            objCompanyProperty.Phone_Number2 = toReturn.Rows[0]["Phone_Number2"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone_Number2"];
        //            objCompanyProperty.Fax_Number = toReturn.Rows[0]["Fax_Number"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Fax_Number"];
        //            objCompanyProperty.Email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
        //            objCompanyProperty.Website = toReturn.Rows[0]["Website"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Website"];
        //            objCompanyProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                   
        //        }
        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("COMPANY_MST_SETUP::DISTRIBUTER_ID::Error occured.", ex);
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

        //public string UpdateCompanyXML()
        //{

        //    SqlConnection conn = new SqlConnection();
        //    conn = _mainConnection;
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[prCompanyCollectionXML]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    string _rowsAffected = string.Empty;
        //    DataTable toReturn = new DataTable("COMPANY");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
        //    cmdToExecute.Connection = conn;
        //    conn.Open();


        //    cmdToExecute.Parameters.Add(new SqlParameter("@XmlOutput", SqlDbType.NVarChar, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objCompanyProperty.XmlOutPut));
        //    cmdToExecute.CommandTimeout = 300;
        //    // Execute query.
        //    adapter.Fill(toReturn);
        //    // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //    objCompanyProperty.Companyxml = Convert.ToString(cmdToExecute.Parameters["@XmlOutput"].Value);


        //    _rowsAffected = (string)objCompanyProperty.Companyxml;




        //    return _rowsAffected;



        //}

    }
}
