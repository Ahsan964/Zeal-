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
    public class Personel_Setup_DAL : DBInteractionBase
    {
        private Personel_Setup_Property ObjPersonelSetupProperty;


        public Personel_Setup_DAL(Personel_Setup_Property ObjPersonelSetup_Property)
        {
            ObjPersonelSetupProperty = ObjPersonelSetup_Property;
        }


        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>Personnel_Code. May be SqlString.Null</LI>
        ///		 <LI>Short_Name. May be SqlString.Null</LI>
        ///		 <LI>Personnel_Name</LI>
        ///		 <LI>Sales_Rep_Type_ID</LI>
        ///		 <LI>Parent_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Father_Name. May be SqlString.Null</LI>
        ///		 <LI>NIC. May be SqlString.Null</LI>
        ///		 <LI>Vehicle_ID. May be SqlString.Null</LI>
        ///		 <LI>QualificationID. May be SqlString.Null</LI>
        ///		 <LI>Address1. May be SqlString.Null</LI>
        ///		 <LI>Address2. May be SqlString.Null</LI>
        ///		 <LI>DOB. May be SqlDateTime.Null</LI>
        ///		 <LI>DOA. May be SqlDateTime.Null</LI>
        ///		 <LI>Blood_Group. May be SqlString.Null</LI>
        ///		 <LI>Phone_No. May be SqlString.Null</LI>
        ///		 <LI>Mobile_No. May be SqlString.Null</LI>
        ///		 <LI>DLicense_No. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Working_Nature. May be SqlInt32.Null</LI>
        ///		 <LI>Is_Active. May be SqlBoolean.Null</LI>
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
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _personnel_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _short_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _personnel_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _sales_Rep_Type_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _parent_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFather_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _father_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sNIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _nIC));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sVehicle_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _vehicle_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sQualificationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _qualificationID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _address1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _address2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daDOB", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dOB));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daDOA", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dOA));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sBlood_Group", SqlDbType.NVarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _blood_Group));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _phone_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _mobile_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sDLicense_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dLicense_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _counter_Sale));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iWorking_Nature", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _working_Nature));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _is_Active));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _iD));
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
                //_iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                     return false ;
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("PERSONNEL_SETUP::Insert::Error occured.", ex);
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
        ///		 <LI>Personnel_Code. May be SqlString.Null</LI>
        ///		 <LI>Short_Name. May be SqlString.Null</LI>
        ///		 <LI>Personnel_Name</LI>
        ///		 <LI>Sales_Rep_Type_ID</LI>
        ///		 <LI>Parent_ID. May be SqlInt32.Null</LI>
        ///		 <LI>Father_Name. May be SqlString.Null</LI>
        ///		 <LI>NIC. May be SqlString.Null</LI>
        ///		 <LI>Vehicle_ID. May be SqlString.Null</LI>
        ///		 <LI>QualificationID. May be SqlString.Null</LI>
        ///		 <LI>Address1. May be SqlString.Null</LI>
        ///		 <LI>Address2. May be SqlString.Null</LI>
        ///		 <LI>DOB. May be SqlDateTime.Null</LI>
        ///		 <LI>DOA. May be SqlDateTime.Null</LI>
        ///		 <LI>Blood_Group. May be SqlString.Null</LI>
        ///		 <LI>Phone_No. May be SqlString.Null</LI>
        ///		 <LI>Mobile_No. May be SqlString.Null</LI>
        ///		 <LI>DLicense_No. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Working_Nature. May be SqlInt32.Null</LI>
        ///		 <LI>Is_Active. May be SqlBoolean.Null</LI>
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
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _personnel_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _short_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPersonnel_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _personnel_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _sales_Rep_Type_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iParent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _parent_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sFather_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _father_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sNIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _nIC));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sVehicle_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _vehicle_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sQualificationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _qualificationID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sAddress1", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _address1));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sAddress2", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _address2));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daDOB", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dOB));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daDOA", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dOA));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sBlood_Group", SqlDbType.NVarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _blood_Group));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPhone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _phone_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sMobile_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _mobile_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sDLicense_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _dLicense_No));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _counter_Sale));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iWorking_Nature", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _working_Nature));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _is_Active));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _status));
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
                _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

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

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Personnel_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Short_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Personnel_Name", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Personnel_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Sales_Rep_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Sales_Rep_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Parent_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Parent_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Father_Name", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Father_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@NIC", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.NIC));
                cmdToExecute.Parameters.Add(new SqlParameter("@Vehicle_ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Vehicle_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@QualificationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.QualificationID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Address1));
                cmdToExecute.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Address2));
                cmdToExecute.Parameters.Add(new SqlParameter("@DOB", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.DOB));
                cmdToExecute.Parameters.Add(new SqlParameter("@DOA", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.DOA));
                cmdToExecute.Parameters.Add(new SqlParameter("@Blood_Group", SqlDbType.NVarChar, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Blood_Group));
                cmdToExecute.Parameters.Add(new SqlParameter("@Phone_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Phone_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Mobile_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@DLicense_No", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.DLicense_No));
                cmdToExecute.Parameters.Add(new SqlParameter("@Counter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@Working_Nature", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Working_Nature));
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 32, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, ObjPersonelSetupProperty.TotalRowsNum));
               
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
                ObjPersonelSetupProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_PERSONNEL_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                }

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


    }
}
