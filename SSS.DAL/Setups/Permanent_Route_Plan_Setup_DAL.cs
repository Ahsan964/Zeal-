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
    public class Permanent_Route_Plan_Setup_DAL : DBInteractionBase
    {
        private Permanent_Route_Plan_Setup_Property ObjPermanentRoutePlanSetupProperty;

        public Permanent_Route_Plan_Setup_DAL(Permanent_Route_Plan_Setup_Property ObjPermanent_Route_Plan_Setup_Property)
        {
            ObjPermanentRoutePlanSetupProperty = ObjPermanent_Route_Plan_Setup_Property;
        }

//        /// <summary>
//        /// Purpose: Insert method. This method will insert one new row into the database.
//        /// </summary>
//        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
//        /// <remarks>
//        /// Properties needed for this method: 
//        /// <UL>
//        ///		 <LI>PRP_Code</LI>
//        ///		 <LI>PRP_Name. May be SqlString.Null</LI>
//        ///		 <LI>Personnel_ID. May be SqlInt32.Null</LI>
//        ///		 <LI>Route_Name. May be SqlString.Null</LI>
//        ///		 <LI>Active_Status. May be SqlString.Null</LI>
//        ///		 <LI>Status. May be SqlString.Null</LI>
//        /// </UL>
//        /// Properties set after a succesful call of this method: 
//        /// <UL>
//        ///		 <LI>ID</LI>
//        ///		 <LI>ErrorCode</LI>
//        /// </UL>
//        /// </remarks>
//        public override bool Insert()
//        {
//            SqlCommand cmdToExecute = new SqlCommand();
//            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_Insert]";
//            cmdToExecute.CommandType = CommandType.StoredProcedure;

//            // Use base class' connection object
//            cmdToExecute.Connection = _mainConnection;

//            try
//            {
//                cmdToExecute.Parameters.Add(new SqlParameter("@sPRP_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Code));
//                cmdToExecute.Parameters.Add(new SqlParameter("@sPRP_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Name));
//                cmdToExecute.Parameters.Add(new SqlParameter("@iPersonnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));   
//                cmdToExecute.Parameters.Add(new SqlParameter("@sRoute_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Route_Name));
//                cmdToExecute.Parameters.Add(new SqlParameter("@sActive_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Active_Status));
//                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
//                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
//                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

//                if (_mainConnectionIsCreatedLocal)
//                {
//                    // Open connection.
//                    _mainConnection.Open();
//                }
//                else
//                {
//                    if (_mainConnectionProvider.IsTransactionPending)
//                    {
//                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
//                    }
//                }

//                // Execute query.
//                _rowsAffected = cmdToExecute.ExecuteNonQuery();
//               // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
//                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

//                if (_errorCode != (int)LLBLError.AllOk)
//                {
//                    // Throw error.
//                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_Insert' reported the ErrorCode: " + _errorCode);
//                }

//=======
//                if (ObjPermanentRoutePlanSetupProperty.DetailData != null)
//                {
//                    foreach (DataRow row in ObjPermanentRoutePlanSetupProperty.DetailData.Rows)
//                        row["Permanent_Route_Plan_Setup_ID"] = cmdToExecute.Parameters["@iID"].Value.ToString();

//                    ObjPermanentRoutePlanSetupProperty.DetailData.AcceptChanges();

//                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
//                    ObjPermanentRoutePlanSetupProperty.DetailData.TableName = "PERMANENT_ROUTE_PLAN_DETAIL";

//                    sbc.ColumnMappings.Clear();
//                    sbc.ColumnMappings.Add(2, 1);
//                    sbc.ColumnMappings.Add(3, 2);
//                    sbc.ColumnMappings.Add(5, 3);
//                    sbc.ColumnMappings.Add(7, 4);
//                    sbc.ColumnMappings.Add(9, 5);
//                    sbc.ColumnMappings.Add(11, 6);

//                    sbc.DestinationTableName = ObjPermanentRoutePlanSetupProperty.DetailData.TableName;
//                    sbc.WriteToServer(ObjPermanentRoutePlanSetupProperty.DetailData);

//                }

//                this.Commit();


//                return true;
//            }
//            catch (Exception ex)
//            {
//                // some error occured. Bubble it to caller and encapsulate Exception object
//                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::Insert::Error occured.", ex);
//            }
//            finally
//            {
//                if (_mainConnectionIsCreatedLocal)
//                {
//                    // Close connection.
//                    _mainConnection.Close();
//                }
//                cmdToExecute.Dispose();
//            }
//        }
        
        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///   <LI>PRP_Code</LI>
        ///   <LI>PRP_Name. May be SqlString.Null</LI>
        ///   <LI>Personnel_ID. May be SqlInt32.Null</LI>
        ///   <LI>Route_Name. May be SqlString.Null</LI>
        ///   <LI>Active_Status. May be SqlString.Null</LI>
        ///   <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///   <LI>ID</LI>
        ///   <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.DIstributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Product_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Record_Table_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Operation_Date));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    //_mainConnection.Open();
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
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                }

                if (ObjPermanentRoutePlanSetupProperty.DetailData != null)
                {
                    foreach (DataRow row in ObjPermanentRoutePlanSetupProperty.DetailData.Rows)
                        row["Permanent_Route_Plan_Setup_ID"] = cmdToExecute.Parameters["@iID"].Value.ToString();

                    ObjPermanentRoutePlanSetupProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    ObjPermanentRoutePlanSetupProperty.DetailData.TableName = "PERMANENT_ROUTE_PLAN_DETAIL";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add(3, 2);
                    sbc.ColumnMappings.Add(5, 3);
                    sbc.ColumnMappings.Add(7, 4);
                    sbc.ColumnMappings.Add(9, 5);
                    sbc.ColumnMappings.Add(11, 6);

                    sbc.DestinationTableName = ObjPermanentRoutePlanSetupProperty.DetailData.TableName;
                    sbc.WriteToServer(ObjPermanentRoutePlanSetupProperty.DetailData);

                }

                this.Commit();

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
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
        ///		 <LI>PRP_Code</LI>
        ///		 <LI>PRP_Name. May be SqlString.Null</LI>
        ///		 <LI>Personnel_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Route_Name. May be SqlString.Null</LI>
        ///		 <LI>Active_Status. May be SqlString.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Product_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Product_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));

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
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::Update::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERMANENT_ROUTE_PLAN_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Route_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Route_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Active_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.TotalRowsNum));
               

                
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
                ObjPermanentRoutePlanSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllForListing()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_LISTING]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERMANENT_ROUTE_PLAN_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@PRP_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PRP_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.DIstributor_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Route_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Route_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Active_Status", SqlDbType.VarChar, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Active_Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.TotalRowsNum));



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
                ObjPermanentRoutePlanSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable SelectAllPermanentRoute_new()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllPermanentRoute_Xml]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERMANENT_ROUTE_PLAN_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                //if (ObjPermanentRoutePlanSetupProperty.Personnel_ID == -1)
                //{
                //    ObjPermanentRoutePlanSetupProperty.Personnel_ID = SqlInt32.Null;
                //}
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.VarChar , 5000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID_XML ));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.DIstributor_ID));


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
                // ObjPermanentRoutePlanSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetAllPermanentRoute_Xml' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("sp_GetAllPermanentRoute_Xml::SelectAll::Error occured.", ex);
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

        public  DataTable SelectAllPermanentRoute()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllPermanentRoute]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERMANENT_ROUTE_PLAN_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                if (ObjPermanentRoutePlanSetupProperty.Personnel_ID == -1)
                {
                    ObjPermanentRoutePlanSetupProperty.Personnel_ID = SqlInt32.Null;
                }    
                cmdToExecute.Parameters.Add(new SqlParameter("@PersonalID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Personnel_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.DIstributor_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
                
                
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
               // ObjPermanentRoutePlanSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::SelectAll::Error occured.", ex);
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

        public DataSet SelectAllMasterDetailByMasterID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAllMasterDetailByMasterID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("PERMANENT_ROUTE_PLAN_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));

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
                //ObjPermanentRoutePlanSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERMANENT_ROUTE_PLAN_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERMANENT_ROUTE_PLAN_SETUP::SelectAll::Error occured.", ex);
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.Operated_By));

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


        public string UpdatePermenantRoutPlanSetupXML()
        {

            SqlConnection conn = new SqlConnection();
            conn = _mainConnection;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[prPermenantRoutPlanXML]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;
            DataTable toReturn = new DataTable("PersonnelSetup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = conn;
            conn.Open();


            cmdToExecute.Parameters.Add(new SqlParameter("@XmlOutput", SqlDbType.NVarChar, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjPermanentRoutePlanSetupProperty.XmlOutPut));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            ObjPermanentRoutePlanSetupProperty.PermenantRoutPlanSetupxml = Convert.ToString(cmdToExecute.Parameters["@XmlOutput"].Value);
            _rowsAffected = (string)ObjPermanentRoutePlanSetupProperty.PermenantRoutPlanSetupxml;
            return _rowsAffected;

        }

    }
}
