using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using SNDDAL;
using SSS.Property.Setups;

namespace SSS.DAL.Setups
{
    public class Page_DAL : DBInteractionBase
    {
        private Page_Property objPageProperty;
        private ErrorTracer objErrorTrace;

        public Page_DAL(Page_Property objPage_Property)
        {
            objPageProperty = objPage_Property;
            objErrorTrace = new ErrorTracer();
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Title. May be SqlString.Null</LI>
        ///		 <LI>Heading. May be SqlString.Null</LI>
        ///		 <LI>Description. May be SqlString.Null</LI>
        ///		 <LI>Path. May be SqlString.Null</LI>
        ///		 <LI>InsertBy. May be SqlInt32.Null</LI>
        ///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
        ///		 <LI>Status. May be SqlInt32.Null</LI>
        ///		 <LI>ParentPageId. May be SqlInt32.Null</LI>
        ///		 <LI>LinksOrder. May be SqlInt32.Null</LI>
        ///		 <LI>Tracking. May be SqlString.Null</LI>
        ///		 <LI>IsVisibleInMenu. May be SqlBoolean.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>Id</LI>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PAGE_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@stitle", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@sheading", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Heading));
                cmdToExecute.Parameters.Add(new SqlParameter("@sdescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@spath", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Path));
                cmdToExecute.Parameters.Add(new SqlParameter("@iinsertBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
                cmdToExecute.Parameters.Add(new SqlParameter("@dainsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@istatus", SqlDbType.NVarChar,12 , ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iparentPageId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.ParentPageId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ilinksOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.LinksOrder));
                cmdToExecute.Parameters.Add(new SqlParameter("@stracking", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Tracking));
                cmdToExecute.Parameters.Add(new SqlParameter("@bisVisibleInMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.IsVisibleInMenu));
                cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Id));
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
             //   objPageProperty.Id = (SqlInt32)cmdToExecute.Parameters["@iid"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_PAGE_Insert' reported the ErrorCode: " + _errorCode);
                    return false;


                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PAGE::Insert::Error occured.", ex);
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
        ///		 <LI>Id</LI>
        ///		 <LI>Title. May be SqlString.Null</LI>
        ///		 <LI>Heading. May be SqlString.Null</LI>
        ///		 <LI>Description. May be SqlString.Null</LI>
        ///		 <LI>Path. May be SqlString.Null</LI>
        ///		 <LI>InsertBy. May be SqlInt32.Null</LI>
        ///		 <LI>InsertionDate. May be SqlDateTime.Null</LI>
        ///		 <LI>Status. May be SqlInt32.Null</LI>
        ///		 <LI>ParentPageId. May be SqlInt32.Null</LI>
        ///		 <LI>LinksOrder. May be SqlInt32.Null</LI>
        ///		 <LI>Tracking. May be SqlString.Null</LI>
        ///		 <LI>IsVisibleInMenu. May be SqlBoolean.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PAGE_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@stitle", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@sheading", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Heading));
                cmdToExecute.Parameters.Add(new SqlParameter("@sdescription", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@spath", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Path));
                cmdToExecute.Parameters.Add(new SqlParameter("@iinsertBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.InsertBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@dainsertionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.InsertionDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@istatus", SqlDbType.NVarChar,12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iparentPageId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.ParentPageId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ilinksOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.LinksOrder));
                cmdToExecute.Parameters.Add(new SqlParameter("@stracking", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Tracking));
                cmdToExecute.Parameters.Add(new SqlParameter("@bisVisibleInMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.IsVisibleInMenu));
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
                    //throw new Exception("Stored Procedure 'sp_PAGE_Update' reported the ErrorCode: " + _errorCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PAGE::Update::Error occured.", ex);
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
        /// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
        /// </summary>
        /// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Id</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        ///		 <LI>Id</LI>
        ///		 <LI>Title</LI>
        ///		 <LI>Heading</LI>
        ///		 <LI>Description</LI>
        ///		 <LI>Path</LI>
        ///		 <LI>InsertBy</LI>
        ///		 <LI>InsertionDate</LI>
        ///		 <LI>Status</LI>
        ///		 <LI>ParentPageId</LI>
        ///		 <LI>LinksOrder</LI>
        ///		 <LI>Tracking</LI>
        ///		 <LI>IsVisibleInMenu</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PAGE_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PAGE");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Id));
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
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PAGE_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objPageProperty.Id = (Int32)toReturn.Rows[0]["id"];
                    objPageProperty.Title = toReturn.Rows[0]["title"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["title"];
                    objPageProperty.Heading = toReturn.Rows[0]["heading"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["heading"];
                    objPageProperty.Description = toReturn.Rows[0]["description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["description"];
                    objPageProperty.Path = toReturn.Rows[0]["path"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["path"];
                    objPageProperty.InsertBy = toReturn.Rows[0]["insertBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["insertBy"];
                    objPageProperty.InsertionDate = toReturn.Rows[0]["insertionDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["insertionDate"];
                    objPageProperty.Status = toReturn.Rows[0]["status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["status"];
                    objPageProperty.ParentPageId = toReturn.Rows[0]["parentPageId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["parentPageId"];
                    objPageProperty.LinksOrder = toReturn.Rows[0]["linksOrder"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["linksOrder"];
                    objPageProperty.Tracking = toReturn.Rows[0]["tracking"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["tracking"];
                    objPageProperty.IsVisibleInMenu = toReturn.Rows[0]["isVisibleInMenu"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["isVisibleInMenu"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PAGE::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_PAGE_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PAGE");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Title));
                cmdToExecute.Parameters.Add(new SqlParameter("@heading", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Heading));
                cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, -1 , ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@path", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Path));
                cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar ,50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@parentPageId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.ParentPageId));
                cmdToExecute.Parameters.Add(new SqlParameter("@linksOrder", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.LinksOrder));
                cmdToExecute.Parameters.Add(new SqlParameter("@tracking", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.Tracking));
                cmdToExecute.Parameters.Add(new SqlParameter("@isVisibleInMenu", SqlDbType.Bit, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.IsVisibleInMenu));
             
                
                
                
                
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 12, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objPageProperty.TotalRowsNum));

                
                
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
                adapter.Fill(toReturn);
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PAGE_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PAGE::SelectAll::Error occured.", ex);
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



        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPageProperty.Operated_By));

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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                objErrorTrace.Error_Msg = (SqlString)ex.Message;
                objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                objErrorTrace.Insert();
                HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                mailMessage.To.Add("ammar.ali@armtech.com.pk");
                mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                mailMessage.From = new MailAddress("Error@SSS.com");
                mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                mailMessage.Body = (String)objErrorTrace.Error_Msg;
                SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                smtpClient.Send(mailMessage);



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
