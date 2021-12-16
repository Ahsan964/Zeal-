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
    public class TreeView_DAL : DBInteractionBase
    {
        public  DataTable SelectAll(string TableName)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (TableName == "LOCATIONS_SETUPS")
            {
                cmdToExecute.CommandText = "SELECT *, (Location_code +' - '+ Location_Name) CompleteName  FROM LOCATIONS_SETUP Where Status<>'Deleted' and ID in (select parent_location_ID from LOCATIONS_SETUP) order by ID Desc";
                //cmdToExecute.CommandText= "SELECT * FROM LOCATIONS_SETUP Where Status<> 'Deleted' and ID in (select parent_location_ID from LOCATIONS_SETUP) and Location_Code like '%-597' OR Location_Code like '%-597-%' OR Location_Code like '%-467' OR Location_Code like '%-467-%'  order by ID Desc"; // order by Parent_Location_ID, ID ASC
            }
            else
            {
                cmdToExecute.CommandText = "SELECT * FROM [" + TableName + "] Where Status<>'Deleted'  order by ID Desc";

            }

            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TreeViewData");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllNew(string TableName, int lvl, char greaterorLess)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (TableName == "LOCATIONS_SETUPS")
            {
                cmdToExecute.CommandText = "SELECT * FROM LOCATIONS_SETUP Where Status<>'Deleted' and ID in (select parent_location_ID from LOCATIONS_SETUP)  and (len(location_code) - len(replace(location_code,'-',''))) " + greaterorLess.ToString() + " " + lvl.ToString() + " order by ID Desc";

            }
            else
            {
                cmdToExecute.CommandText = "SELECT * FROM [" + TableName + "] Where Status<>'Deleted'  and (len(location_code) - len(replace(location_code,'-',''))) " + greaterorLess.ToString() + " " + lvl.ToString() + " order by ID Desc";

            }

            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TreeViewData");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectByNode(string Node, string TableName, string NodeColumn, string Code, string KeyMember)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if(TableName== "LOCATIONS_SETUP")
                cmdToExecute.CommandText = "SELECT " + Code + ", " + KeyMember + ", (Location_Code+' - ' + Location_Name) CompleteName FROM [" + TableName + "] where (Location_Code+' - ' + Location_Name) = '" + Node + "'";
  else
                cmdToExecute.CommandText = "SELECT "+ Code +", " + KeyMember + " FROM [" + TableName + "] where [" + NodeColumn + "] = '" + Node + "'";
            //cmdToExecute.CommandText = "SELECT " + Code + ", " + KeyMember + " FROM [" + TableName + "] where [Location_Name] = 'LAHORE' OR [Location_Name] = 'KARACHI'";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TreeViewData");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllLocations(string TableName)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "SELECT  ID, Location_Name, Location_Short_Name, Location_Code, CASE WHEN Parent_Location_ID = 0 THEN NULL ELSE Parent_Location_ID END Parent_Location_ID FROM [" + TableName + "] Where Status<>'Deleted' order by Parent_Location_ID,ID ASC"; //
            
            //cmdToExecute.CommandText = "SELECT Top(2500) ID, Location_Name, Parent_Location_ID FROM [" + TableName + "] Where Status<>'Deleted' order by Parent_Location_ID,ID ASC"; //Location_Short_Name,Location_Code, CASE WHEN Parent_Location_ID = 0 THEN NULL ELSE Parent_Location_ID END Parent_Location_ID
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TreeViewData");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllLocationsNew(string TableName, int lvl, char greaterorLess)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "SELECT  ID, Location_Name, Location_Short_Name, Location_Code, CASE WHEN Parent_Location_ID = 0 THEN NULL ELSE Parent_Location_ID END Parent_Location_ID FROM [" + TableName + "] Where Status<>'Deleted' and (len(location_code) - len(replace(location_code,'-',''))) " + greaterorLess.ToString() + " " + lvl.ToString() + " order by Parent_Location_ID,ID ASC"; //

            DataTable toReturn = new DataTable("TreeViewData");
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
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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

        public DataTable SelectAll2(string TableName)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (TableName == "LOCATIONS_SETUPS")
            {
                cmdToExecute.CommandText = "SELECT * FROM LOCATIONS_SETUP Where Status<>'Deleted' and ID in (select parent_location_ID from LOCATIONS_SETUP) order by ID Desc";

            }
            else
            {
                cmdToExecute.CommandText = "SELECT * FROM PRODUCT_SETUP Where Is_Final_Product = 0";

            }

            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("TreeViewData");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_Product_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Product::SelectAll::Error occured.", ex);
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
