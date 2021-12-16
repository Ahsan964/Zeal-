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
    public class Personnel_Setup_DAL : DBInteractionBase
    {
        private Personnel_Setup_Property objPersonnelSetupProperty;
        private ErrorTracer objErrorTrace;

        public Personnel_Setup_DAL(Personnel_Setup_Property objPersonnelSetup_Property)
        {
            objPersonnelSetupProperty = objPersonnelSetup_Property;
        }

        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Distributor_Mst_Setup_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Parent_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Personnel_Code</LI>
        ///		 <LI>Personnel_Name</LI>
        ///		 <LI>Sales_Rep_Type_ID</LI>
        ///		 <LI>Father_Name. May be SqlString.Null</LI>
        ///		 <LI>Address1. May be SqlString.Null</LI>
        ///		 <LI>Address2. May be SqlString.Null</LI>
        ///		 <LI>NIC. May be SqlString.Null</LI>
        ///		 <LI>Phone_No. May be SqlString.Null</LI>
        ///		 <LI>Mobile_No. May be SqlString.Null</LI>
        ///		 <LI>Email. May be SqlString.Null</LI>
        ///		 <LI>Police_Station. May be SqlString.Null</LI>
        ///		 <LI>DOB. May be SqlDateTime.Null</LI>
        ///		 <LI>DOA. May be SqlDateTime.Null</LI>
        ///		 <LI>QualificationID. May be SqlString.Null</LI>
        ///		 <LI>Vehicle_ID. May be SqlString.Null</LI>
        ///		 <LI>DLicense_No. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Is_Active. May be SqlBoolean.Null</LI>
        ///		 <LI>Blood_Group. May be SqlString.Null</LI>
        ///		 <LI>Working_Nature. May be SqlInt32.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_Mst_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sFather_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Father_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Address1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Address2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sNIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Phone_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Mobile_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDOB", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DOB));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDOA", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DOA));
                cmdToExecute.Parameters.Add(new SqlParameter("@sQualificationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.QualificationID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sVehicle_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Vehicle_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDLicense_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DLicense_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBlood_Group", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Blood_Group));
                cmdToExecute.Parameters.Add(new SqlParameter("@iWorking_Nature", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Working_Nature));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
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
                //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                    return false;

                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
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
        /// Purpose: Update method. This method will Update one existing row in the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Company_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Distributor_Mst_Setup_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Parent_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Personnel_Code</LI>
        ///		 <LI>Personnel_Name</LI>
        ///		 <LI>Sales_Rep_Type_ID</LI>
        ///		 <LI>Father_Name. May be SqlString.Null</LI>
        ///		 <LI>Address1. May be SqlString.Null</LI>
        ///		 <LI>Address2. May be SqlString.Null</LI>
        ///		 <LI>NIC. May be SqlString.Null</LI>
        ///		 <LI>Phone_No. May be SqlString.Null</LI>
        ///		 <LI>Mobile_No. May be SqlString.Null</LI>
        ///		 <LI>Email. May be SqlString.Null</LI>
        ///		 <LI>Police_Station. May be SqlString.Null</LI>
        ///		 <LI>DOB. May be SqlDateTime.Null</LI>
        ///		 <LI>DOA. May be SqlDateTime.Null</LI>
        ///		 <LI>QualificationID. May be SqlString.Null</LI>
        ///		 <LI>Vehicle_ID. May be SqlString.Null</LI>
        ///		 <LI>DLicense_No. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Is_Active. May be SqlBoolean.Null</LI>
        ///		 <LI>Blood_Group. May be SqlString.Null</LI>
        ///		 <LI>Working_Nature. May be SqlInt32.Null</LI>
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
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iCompany_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iDistributor_Mst_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Parent_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sFather_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Father_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Address1));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Address2));
                cmdToExecute.Parameters.Add(new SqlParameter("@sNIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Phone_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Mobile_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@sEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDOB", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DOB));
                cmdToExecute.Parameters.Add(new SqlParameter("@daDOA", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DOA));
                cmdToExecute.Parameters.Add(new SqlParameter("@sQualificationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.QualificationID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sVehicle_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Vehicle_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDLicense_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DLicense_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@sBlood_Group", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Blood_Group));
                cmdToExecute.Parameters.Add(new SqlParameter("@iWorking_Nature", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Working_Nature));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
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

                if (_errorCode.Value == 0)
                    return false;
                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_Update' reported the ErrorCode: " + _errorCode);
                //}

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::Update::Error occured.", ex);
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
        ///		 <LI>ID</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        ///		 <LI>ID</LI>
        ///		 <LI>Company_ID</LI>
        ///		 <LI>Distributor_Mst_Setup_ID</LI>
        ///		 <LI>Parent_ID</LI>
        ///		 <LI>Personnel_Code</LI>
        ///		 <LI>Personnel_Name</LI>
        ///		 <LI>Sales_Rep_Type_ID</LI>
        ///		 <LI>Father_Name</LI>
        ///		 <LI>Address1</LI>
        ///		 <LI>Address2</LI>
        ///		 <LI>NIC</LI>
        ///		 <LI>Phone_No</LI>
        ///		 <LI>Mobile_No</LI>
        ///		 <LI>Email</LI>
        ///		 <LI>Police_Station</LI>
        ///		 <LI>DOB</LI>
        ///		 <LI>DOA</LI>
        ///		 <LI>QualificationID</LI>
        ///		 <LI>Vehicle_ID</LI>
        ///		 <LI>DLicense_No</LI>
        ///		 <LI>Counter_Sale</LI>
        ///		 <LI>Is_Active</LI>
        ///		 <LI>Blood_Group</LI>
        ///		 <LI>Working_Nature</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objPersonnelSetupProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objPersonnelSetupProperty.Company_ID = toReturn.Rows[0]["Company_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Company_ID"];
                    objPersonnelSetupProperty.Distributor_Mst_Setup_ID = toReturn.Rows[0]["Distributor_Mst_Setup_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Distributor_Mst_Setup_ID"];
                    objPersonnelSetupProperty.Parent_ID = toReturn.Rows[0]["Parent_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Parent_ID"];
                    objPersonnelSetupProperty.Personnel_Code = (string)toReturn.Rows[0]["Personnel_Code"];
                    objPersonnelSetupProperty.Personnel_Name = (string)toReturn.Rows[0]["Personnel_Name"];
                    objPersonnelSetupProperty.Sales_Rep_Type_ID = (Int32)toReturn.Rows[0]["Sales_Rep_Type_ID"];
                    objPersonnelSetupProperty.Father_Name = toReturn.Rows[0]["Father_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Father_Name"];
                    objPersonnelSetupProperty.Address1 = toReturn.Rows[0]["Address1"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Address1"];
                    objPersonnelSetupProperty.Address2 = toReturn.Rows[0]["Address2"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Address2"];
                    objPersonnelSetupProperty.NIC = toReturn.Rows[0]["NIC"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["NIC"];
                    objPersonnelSetupProperty.Phone_No = toReturn.Rows[0]["Phone_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Phone_No"];
                    objPersonnelSetupProperty.Mobile_No = toReturn.Rows[0]["Mobile_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Mobile_No"];
                    objPersonnelSetupProperty.Email = toReturn.Rows[0]["Email"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Email"];
                    objPersonnelSetupProperty.Police_Station = toReturn.Rows[0]["Police_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Police_Station"];
                    objPersonnelSetupProperty.DOB = toReturn.Rows[0]["DOB"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["DOB"];
                    objPersonnelSetupProperty.DOA = toReturn.Rows[0]["DOA"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["DOA"];
                    objPersonnelSetupProperty.QualificationID = toReturn.Rows[0]["QualificationID"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["QualificationID"];
                    objPersonnelSetupProperty.Vehicle_ID = toReturn.Rows[0]["Vehicle_ID"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Vehicle_ID"];
                    objPersonnelSetupProperty.DLicense_No = toReturn.Rows[0]["DLicense_No"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["DLicense_No"];
                    objPersonnelSetupProperty.Counter_Sale = toReturn.Rows[0]["Counter_Sale"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Counter_Sale"];
                    objPersonnelSetupProperty.Is_Active = toReturn.Rows[0]["Is_Active"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Is_Active"];
                    objPersonnelSetupProperty.Blood_Group = toReturn.Rows[0]["Blood_Group"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Blood_Group"];
                    objPersonnelSetupProperty.Working_Nature = toReturn.Rows[0]["Working_Nature"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Working_Nature"];
                    objPersonnelSetupProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectOne::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Mst_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@NIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID2", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_IDOld));

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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllForFuelSharing()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_SelectAllForFuelsSharing]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Mst_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@NIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID2", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_IDOld));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DateFrom));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.DateTime, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.DateTo));

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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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


        public DataTable SelectAllForVehicleSharing()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_SelectAllForVehicleSharing]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Company_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_Mst_Setup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Personnel_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@NIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.TotalRowsNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID2", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_IDOld));
               
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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Operated_By));

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

        
        public DataTable Get_SalesRep()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllSalesRep]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));

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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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


        public DataTable Select_All_OrderBookerbyDistributorID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllSalesRep_ByDistributor_ID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));

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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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

        public DataTable SelectAllbyPRP_PersonnelID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PERSONNEL_SETUP_SelectAll_by_PRP_PersonnelID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID2", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Sales_Rep_Type_IDOld));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Company_ID));


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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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


        public DataTable SelectExistingSR_PRP()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ExistingSR_PRP]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PERSONNEL_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.ID));

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
                //    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PERSONNEL_SETUP::SelectAll::Error occured.", ex);
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


        public string UpdatePersonnelSetupXMLbyNIC()
        {

            SqlConnection conn = new SqlConnection();
            conn = _mainConnection;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[PERSONNELSETUPNICXML]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;
            DataTable toReturn = new DataTable("PersonnelSetup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = conn;
            conn.Open();

            cmdToExecute.Parameters.Add(new SqlParameter("@CNIC", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));

            cmdToExecute.Parameters.Add(new SqlParameter("@XmlOutput", SqlDbType.NVarChar, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.XmlOutPut));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            objPersonnelSetupProperty.PersonnelSetupxml = Convert.ToString(cmdToExecute.Parameters["@XmlOutput"].Value);
            _rowsAffected = (string)objPersonnelSetupProperty.PersonnelSetupxml;
            return _rowsAffected;

        }

        public int getDistributorIDByCNIC()
        {
            SqlConnection conn = new SqlConnection();
            conn = _mainConnection;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelectDistributorByCNIC]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;

            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = conn;
            conn.Open();

            cmdToExecute.Parameters.Add(new SqlParameter("@CNIC", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));

            cmdToExecute.Parameters.Add(new SqlParameter("@Dist_ID", SqlDbType.Int, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            cmdToExecute.ExecuteNonQuery();
            //adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            objPersonnelSetupProperty.Distributor_Mst_Setup_ID = int.Parse(cmdToExecute.Parameters["@Dist_ID"].Value.ToString());

            return int.Parse(cmdToExecute.Parameters["@Dist_ID"].Value.ToString());
        }

        public int getDistributorCodeByCNIC()
        {
            SqlConnection conn = new SqlConnection();
            conn = _mainConnection;
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelectDistributorIDByCNIC]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;

            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = conn;
            conn.Open();

            cmdToExecute.Parameters.Add(new SqlParameter("@CNIC", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.NIC));

            cmdToExecute.Parameters.Add(new SqlParameter("@Dist_ID", SqlDbType.Int, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPersonnelSetupProperty.Distributor_Mst_Setup_ID));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            cmdToExecute.ExecuteNonQuery();
            //adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            objPersonnelSetupProperty.Distributor_Mst_Setup_ID = int.Parse(cmdToExecute.Parameters["@Dist_ID"].Value.ToString());

            return int.Parse(cmdToExecute.Parameters["@Dist_ID"].Value.ToString());
        }
    }
}
