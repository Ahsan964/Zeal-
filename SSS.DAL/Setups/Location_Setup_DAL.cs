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
    public class Location_Setup_DAL : DBInteractionBase
    {
        private Location_Setup_Property ObjLocationSetupProperty;
        private ErrorTracer objErrorTrace;

        public Location_Setup_DAL(Location_Setup_Property ObjLocationSetup_Property)
        {
            ObjLocationSetupProperty = ObjLocationSetup_Property;
        }
        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_LOCATIONS_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
    //                @ID int = NULL,
    //@Location_Code varchar(50) = NULL,
    //@Location_Name varchar(200) = NULL,
    //@Parent_Location_ID int = NULL,
    //@Company_ID int = NULL,
    //@Pos_Type_ID int = NULL,
    //@Sub_Pos_Type_ID int = NULL,
    //@Shop_No nvarchar(20) = NULL,
    //@Owner_Name nvarchar(30) = NULL,
    //@PageNum int = NULL,
    //@PageSize int = NULL,	
    //@sortColumn nvarchar(12) = NULL,	
    //@TotalRowsNum int output
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Parent_Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Pos_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sub_Pos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Sub_Pos_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Shop_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Shop_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Owner_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Status));


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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable SelectAllWLocation()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_W_LOCATION]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.TotalRowsNum));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::SelectAll::Error occured.", ex);
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
        //public DataTable LocationForBulkPOS()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_Location_For_Bulk_POS]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable("LOCATIONS_SETUP");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@ParentLocation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Parent_Location_Code_For_Bulk_POS));

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
        //        //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

        //        //if (_errorCode != (int)LLBLError.AllOk)
        //        //{
        //        //    // Throw error.
        //        //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
        //        //}



        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("POS_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable SelectLocationNodeName()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Select_Location_Node_Name]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable SelectThirdLevelLocationDAL()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_LocationGetThirdLevel]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
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

                adapter.Fill(toReturn);
                
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::SelectAll::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_LOCATIONS_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Short_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Short_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Parent_Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Pos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Pos_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sub_Pos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Sub_Pos_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Shop_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Shop_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Market_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Market_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Street));
                cmdToExecute.Parameters.Add(new SqlParameter("@Police_Station", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@Post_Code", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Post_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Phone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Phone_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Fax_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Fax_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_Turnover", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Company_Turnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@Total_Turnover", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Total_Turnover));
                cmdToExecute.Parameters.Add(new SqlParameter("@Amount_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Amount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@Owner_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Owner_NIC", SqlDbType.NVarChar, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Owner_NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@Counter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Location_POS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Is_Location_POS));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Operation));
                cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Operated_By));
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
               // ObjLocationSetupProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("LOCATIONS_SETUP::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_LOCATIONS_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sLocation_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sLocation_Short_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Short_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sLocation_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Location_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@iParent_Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Parent_Location_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Company_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iPos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Pos_Type_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSub_Pos_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Sub_Pos_Type_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sShop_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Shop_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sMarket_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Market_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStreet", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Street));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Police_Station));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPost_Code", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Post_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Phone_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFax_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Fax_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Email));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcCompany_Turnover", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Company_Turnover));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcTotal_Turnover", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Total_Turnover));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcAmount_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Amount_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Owner_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_NIC", SqlDbType.NVarChar, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,ObjLocationSetupProperty.Owner_NIC));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Counter_Sale));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Location_POS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Is_Location_POS));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.Status));
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
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("LOCATIONS_SETUP::Update::Error occured.", ex);
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
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_LOCATIONS_SETUP_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));
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
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_LOCATIONS_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    ObjLocationSetupProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    ObjLocationSetupProperty.Location_Code = toReturn.Rows[0]["Location_Code"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Location_Code"];
                    ObjLocationSetupProperty.Location_Short_Name = toReturn.Rows[0]["Location_Short_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Location_Short_Name"];
                    ObjLocationSetupProperty.Location_Name = (string)toReturn.Rows[0]["Location_Name"];
                    ObjLocationSetupProperty.Parent_Location_ID = toReturn.Rows[0]["Parent_Location_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Parent_Location_ID"];
                    ObjLocationSetupProperty.Company_ID = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
                    ObjLocationSetupProperty.Pos_Type_ID = toReturn.Rows[0]["Pos_Type_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Pos_Type_ID"];
                    ObjLocationSetupProperty.Sub_Pos_Type_ID = toReturn.Rows[0]["Sub_Pos_Type_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Sub_Pos_Type_ID"];
                    ObjLocationSetupProperty.Shop_No = toReturn.Rows[0]["Shop_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Shop_No"];
                    ObjLocationSetupProperty.Market_Name = toReturn.Rows[0]["Market_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Market_Name"];
                    ObjLocationSetupProperty.Street = toReturn.Rows[0]["Street"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Street"];
                    ObjLocationSetupProperty.Police_Station = toReturn.Rows[0]["Police_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Police_Station"];
                    ObjLocationSetupProperty.Post_Code = toReturn.Rows[0]["Post_Code"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Post_Code"];
                    ObjLocationSetupProperty.Phone_No = toReturn.Rows[0]["Phone_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone_No"];
                    ObjLocationSetupProperty.Fax_No = toReturn.Rows[0]["Fax_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Fax_No"];
                    ObjLocationSetupProperty.Email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
                    ObjLocationSetupProperty.Company_Turnover = toReturn.Rows[0]["Company_Turnover"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Company_Turnover"];
                    ObjLocationSetupProperty.Total_Turnover = toReturn.Rows[0]["Total_Turnover"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Total_Turnover"];
                    ObjLocationSetupProperty.Amount_Limit = toReturn.Rows[0]["Amount_Limit"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Amount_Limit"];
                    ObjLocationSetupProperty.Owner_Name = toReturn.Rows[0]["Owner_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Owner_Name"];
                    ObjLocationSetupProperty.Owner_NIC = toReturn.Rows[0]["Owner_NIC"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Owner_NIC"];
                    ObjLocationSetupProperty.Counter_Sale = toReturn.Rows[0]["Counter_Sale"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Counter_Sale"];
                    ObjLocationSetupProperty.Is_Location_POS = toReturn.Rows[0]["Is_Location_POS"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Is_Location_POS"];
                    ObjLocationSetupProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("LOCATIONS_SETUP::SelectOne::Error occured.", ex);
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
        public DataTable ISLocationDelete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Locations_Setup_DeleteLogic]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("LOCATIONS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("LOCATIONS_SETUP::SelectAll::Error occured.", ex);
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
        public DataTable SelectLocationNodeName2()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Select_Sale_Category_Product]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRODUCT_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjLocationSetupProperty.ID));

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

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectAll::Error occured.", ex);
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
