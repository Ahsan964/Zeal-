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
    public class POS_Setup_DAL : DBInteractionBase
    {
        private POS_Setup_Property objPOSSetupProperty;
        private ErrorTracer objErrorTrace;

        public POS_Setup_DAL(POS_Setup_Property objPOS_Setup_Property)
        {
            objPOSSetupProperty = objPOS_Setup_Property;
        }


        /// <summary>
        /// Purpose: Insert method. This method will insert one new row into the database.
        /// </summary>
        /// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
        /// <remarks>
        /// Properties needed for this method: 
        /// <UL>
        ///		 <LI>ID</LI>
        ///		 <LI>Location_ID</LI>
        ///		 <LI>Short_Description. May be SqlString.Null</LI>
        ///		 <LI>Detail_Description. May be SqlString.Null</LI>
        ///		 <LI>Address. May be SqlString.Null</LI>
        ///		 <LI>Market_Name. May be SqlString.Null</LI>
        ///		 <LI>Owner_Name. May be SqlString.Null</LI>
        ///		 <LI>P_Phone_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_Mobile_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_UAN_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_FAX_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_Email_Address. May be SqlString.Null</LI>
        ///		 <LI>P_URL. May be SqlString.Null</LI>
        ///		 <LI>P_Tex_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>Post_Code. May be SqlDecimal.Null</LI>
        ///		 <LI>Telegraph_Add. May be SqlString.Null</LI>
        ///		 <LI>Railway_Station. May be SqlString.Null</LI>
        ///		 <LI>Police_Station. May be SqlString.Null</LI>
        ///		 <LI>POS_Type_ID</LI>
        ///		 <LI>Account_Type</LI>
        ///		 <LI>Area_Type</LI>
        ///		 <LI>POS_Registration. May be SqlString.Null</LI>
        ///		 <LI>Sub_Element. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Company_Turn_Over. May be SqlString.Null</LI>
        ///		 <LI>POS_Turn_Over. May be SqlString.Null</LI>
        ///		 <LI>Company_Rank. May be SqlString.Null</LI>
        ///		 <LI>POS_Rank. May be SqlString.Null</LI>
        ///		 <LI>Credit_Allowed. May be SqlBoolean.Null</LI>
        ///		 <LI>Credit_Amount_Limit. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Allowed. May be SqlBoolean.Null</LI>
        ///		 <LI>Cheque_Amount_Limit. May be SqlString.Null</LI>
        ///		 <LI>Freezer. May be SqlBoolean.Null</LI>
        ///		 <LI>Cool_Cab. May be SqlBoolean.Null</LI>
        ///		 <LI>Refrigerator. May be SqlBoolean.Null</LI>
        ///		 <LI>Air_Conditioner. May be SqlBoolean.Null</LI>
        ///		 <LI>Active. May be SqlBoolean.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iLocation_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDetail_Description", SqlDbType.VarChar, 24, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Detail_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress", SqlDbType.VarChar, 44, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMarket_Name", SqlDbType.VarChar, 24, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Market_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_Name", SqlDbType.VarChar, 24, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Phone_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, true, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Phone_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Mobile_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, true, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Mobile_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_UAN_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, true,14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_UAN_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_FAX_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, true, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_FAX_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sP_Email_Address", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Email_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sP_URL", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.P_URL));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Tex_Number", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Tex_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcPost_Code", SqlDbType.Decimal, 14, ParameterDirection.Input, true, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.Post_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTelegraph_Add", SqlDbType.VarChar, 14, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Telegraph_Add));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRailway_Station", SqlDbType.VarChar, 24, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Railway_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.VarChar, 24, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPOS_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iAccount_Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Business_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@iArea_Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Area_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Registration", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Registration));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Category_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Category));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCompany_Turn_Over", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Company_Turn_Over));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Turn_Over", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Turn_Over));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCompany_Rank", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Company_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Rank", SqlDbType.NChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCredit_Allowed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Credit_Allowed));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCredit_Amount_Limit", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Credit_Amount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCheque_Allowed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cheque_Allowed));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_Amount_Limit", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cheque_Amount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@bFreezer", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Freezer));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCool_Cab", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cool_Cab));
                cmdToExecute.Parameters.Add(new SqlParameter("@bRefrigerator", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Refrigerator));
                cmdToExecute.Parameters.Add(new SqlParameter("@bAir_Conditioner", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Air_Conditioner));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
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
                    throw new Exception("Stored Procedure 'sp_POS_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::Insert::Error occured.", ex);
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


        public int SSSCodesVerificationDAL()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSSCodesVerification]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@sssCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.SssCode));
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
                int errorCode = Convert.ToInt32(cmdToExecute.Parameters["@iErrorCode"].Value.ToString());

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_POS_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                }

                return errorCode;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::Insert::Error occured.", ex);
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
        ///		 <LI>Code</LI>
        ///		 <LI>Location_ID</LI>
        ///		 <LI>Short_Description. May be SqlString.Null</LI>
        ///		 <LI>Detail_Description. May be SqlString.Null</LI>
        ///		 <LI>Address. May be SqlString.Null</LI>
        ///		 <LI>Market_Name. May be SqlString.Null</LI>
        ///		 <LI>Owner_Name. May be SqlString.Null</LI>
        ///		 <LI>P_Phone_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_Mobile_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_UAN_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_FAX_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>P_Email_Address. May be SqlString.Null</LI>
        ///		 <LI>P_URL. May be SqlString.Null</LI>
        ///		 <LI>P_Tex_Number. May be SqlDecimal.Null</LI>
        ///		 <LI>Post_Code. May be SqlDecimal.Null</LI>
        ///		 <LI>Telegraph_Add. May be SqlString.Null</LI>
        ///		 <LI>Railway_Station. May be SqlString.Null</LI>
        ///		 <LI>Police_Station. May be SqlString.Null</LI>
        ///		 <LI>POS_Type_ID</LI>
        ///		 <LI>Account_Type</LI>
        ///		 <LI>Area_Type</LI>
        ///		 <LI>POS_Registration. May be SqlString.Null</LI>
        ///		 <LI>Sub_Element. May be SqlString.Null</LI>
        ///		 <LI>Counter_Sale. May be SqlBoolean.Null</LI>
        ///		 <LI>Company_Turn_Over. May be SqlString.Null</LI>
        ///		 <LI>POS_Turn_Over. May be SqlString.Null</LI>
        ///		 <LI>Company_Rank. May be SqlString.Null</LI>
        ///		 <LI>POS_Rank. May be SqlString.Null</LI>
        ///		 <LI>Credit_Allowed. May be SqlBoolean.Null</LI>
        ///		 <LI>Credit_Amount_Limit. May be SqlString.Null</LI>
        ///		 <LI>Cheque_Allowed. May be SqlBoolean.Null</LI>
        ///		 <LI>Cheque_Amount_Limit. May be SqlString.Null</LI>
        ///		 <LI>Freezer. May be SqlBoolean.Null</LI>
        ///		 <LI>Cool_Cab. May be SqlBoolean.Null</LI>
        ///		 <LI>Refrigerator. May be SqlBoolean.Null</LI>
        ///		 <LI>Air_Conditioner. May be SqlBoolean.Null</LI>
        ///		 <LI>Status. May be SqlString.Null</LI>
        /// </UL>
        /// Properties set after a succesful call of this method: 
        /// <UL>
        ///		 <LI>ErrorCode</LI>
        /// </UL>
        /// </remarks>
        /// 


        public DataTable SelectAll_POS_SETUP_OnlyByLocationID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_OnlyByLocationID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@RouteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@regionalLocationsIds", SqlDbType.VarChar, 9999999, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.LocationIDs));

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
                throw new Exception("POS_SETUP::sp_POS_SETUP_SelectAll_ByLocationID::Error occured.", ex);
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
      

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCode", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@iLocation_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@sShort_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sDetail_Description", SqlDbType.VarChar, 24, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Detail_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@sAddress", SqlDbType.VarChar, 44, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sMarket_Name", SqlDbType.VarChar, 24, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Market_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@sOwner_Name", SqlDbType.VarChar, 24, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Owner_Name));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Phone_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, false, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Phone_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Mobile_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, false, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Mobile_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_UAN_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, false, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_UAN_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_FAX_Number", SqlDbType.Decimal, 14, ParameterDirection.Input, false, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_FAX_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@sP_Email_Address", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Email_Address));
                cmdToExecute.Parameters.Add(new SqlParameter("@sP_URL", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.P_URL));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcP_Tex_Number", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.P_Tex_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@dcPost_Code", SqlDbType.Decimal, 14, ParameterDirection.Input, false, 14, 1, "", DataRowVersion.Proposed, objPOSSetupProperty.Post_Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@sTelegraph_Add", SqlDbType.VarChar, 14, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Telegraph_Add));
                cmdToExecute.Parameters.Add(new SqlParameter("@sRailway_Station", SqlDbType.VarChar, 24, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Railway_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPolice_Station", SqlDbType.VarChar, 24, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Police_Station));
                cmdToExecute.Parameters.Add(new SqlParameter("@iPOS_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@iAccount_Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Business_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@iArea_Type", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Area_Type));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Registration", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Registration));
                cmdToExecute.Parameters.Add(new SqlParameter("@sSub_Element", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Category));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCounter_Sale", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Counter_Sale));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCompany_Turn_Over", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Company_Turn_Over));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Turn_Over", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Turn_Over));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCompany_Rank", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Company_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@sPOS_Rank", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Rank));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCredit_Allowed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Credit_Allowed));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCredit_Amount_Limit", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Credit_Amount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCheque_Allowed", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cheque_Allowed));
                cmdToExecute.Parameters.Add(new SqlParameter("@sCheque_Amount_Limit", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cheque_Amount_Limit));
                cmdToExecute.Parameters.Add(new SqlParameter("@bFreezer", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Freezer));
                cmdToExecute.Parameters.Add(new SqlParameter("@bCool_Cab", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Cool_Cab));
                cmdToExecute.Parameters.Add(new SqlParameter("@bRefrigerator", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Refrigerator));
                cmdToExecute.Parameters.Add(new SqlParameter("@bAir_Conditioner", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Air_Conditioner));
                cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
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
                    throw new Exception("Stored Procedure 'pr_POS_SETUP_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::Update::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 300;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@POS_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.TotalRowsNum));

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



        public  DataTable SelectAll_WithLoc()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_WithLoc]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@POS_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.TotalRowsNum));

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
        public DataTable SelectAll_BY_Route()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_BY_Route]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));

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

        //******//

        public DataTable SelectAll_BY_BusinessType()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_BY_BusinessType]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Business_Type_ID", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Business_TypeStr));

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

        public DataTable SelectAll_POS_SETUP_LocID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_ByLocationID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@RouteID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DistributorID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorID));

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
                throw new Exception("POS_SETUP::sp_POS_SETUP_SelectAll_ByLocationID::Error occured.", ex);
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

        //******//

        public DataTable SelectAll_POS_SETUP_ByRouteID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SetupGetPOSByRouteId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@RouteId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));

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
                throw new Exception("POS_SETUP::sp_POS_SETUP_SelectAll_ByLocationID::Error occured.", ex);
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
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Operated_By));

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
                //objErrorTrace.Error_Msg = (SqlString)ex.Message;
                //objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                //objErrorTrace.Insert();
                //HttpContext.Current.Response.Redirect("~/Error.aspx");


                //Send Email To Application Developer's
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                //mailMessage.To.Add("ammar.ali@armtech.com.pk");
                //mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                //mailMessage.From = new MailAddress("Error@SSS.com");
                //mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                //mailMessage.Body = (String)objErrorTrace.Error_Msg;
                //SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                //smtpClient.Send(mailMessage);



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
        ///		 <LI>Code</LI>
        ///		 <LI>Location_ID</LI>
        ///		 <LI>Short_Description</LI>
        ///		 <LI>Detail_Description</LI>
        ///		 <LI>Address</LI>
        ///		 <LI>Market_Name</LI>
        ///		 <LI>Owner_Name</LI>
        ///		 <LI>P_Phone_Number</LI>
        ///		 <LI>P_Mobile_Number</LI>
        ///		 <LI>P_UAN_Number</LI>
        ///		 <LI>P_FAX_Number</LI>
        ///		 <LI>P_Email_Address</LI>
        ///		 <LI>P_URL</LI>
        ///		 <LI>P_Tex_Number</LI>
        ///		 <LI>Post_Code</LI>
        ///		 <LI>Telegraph_Add</LI>
        ///		 <LI>Railway_Station</LI>
        ///		 <LI>Police_Station</LI>
        ///		 <LI>POS_Type_ID</LI>
        ///		 <LI>Account_Type</LI>
        ///		 <LI>Area_Type</LI>
        ///		 <LI>POS_Registration</LI>
        ///		 <LI>Sub_Element</LI>
        ///		 <LI>Counter_Sale</LI>
        ///		 <LI>Company_Turn_Over</LI>
        ///		 <LI>POS_Turn_Over</LI>
        ///		 <LI>Company_Rank</LI>
        ///		 <LI>POS_Rank</LI>
        ///		 <LI>Credit_Allowed</LI>
        ///		 <LI>Credit_Amount_Limit</LI>
        ///		 <LI>Cheque_Allowed</LI>
        ///		 <LI>Cheque_Amount_Limit</LI>
        ///		 <LI>Freezer</LI>
        ///		 <LI>Cool_Cab</LI>
        ///		 <LI>Refrigerator</LI>
        ///		 <LI>Air_Conditioner</LI>
        ///		 <LI>Status</LI>
        /// </UL>
        /// Will fill all properties corresponding with a field in the table with the value of the row selected.
        /// </remarks>
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
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
                    throw new Exception("Stored Procedure 'sp_POS_SETUP_SelectOne' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    objPOSSetupProperty.ID = (Int32)toReturn.Rows[0]["ID"];
                    objPOSSetupProperty.Code = (string)toReturn.Rows[0]["Code"];
                    objPOSSetupProperty.Location_ID = (Int32)toReturn.Rows[0]["Location_ID"];
                    objPOSSetupProperty.Short_Description = toReturn.Rows[0]["Short_Description"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Short_Description"];
                    objPOSSetupProperty.Detail_Description = toReturn.Rows[0]["Detail_Description"] == System.DBNull.Value ? "" : (string)toReturn.Rows[0]["Detail_Description"];
                    objPOSSetupProperty.Address = toReturn.Rows[0]["Address"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Address"];
                    objPOSSetupProperty.Market_Name = toReturn.Rows[0]["Market_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Market_Name"];
                    objPOSSetupProperty.Owner_Name = toReturn.Rows[0]["Owner_Name"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Owner_Name"];
                    objPOSSetupProperty.P_Phone_Number = toReturn.Rows[0]["P_Phone_Number"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["P_Phone_Number"];
                    objPOSSetupProperty.P_Mobile_Number = toReturn.Rows[0]["P_Mobile_Number"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["P_Mobile_Number"];
                    objPOSSetupProperty.P_UAN_Number = toReturn.Rows[0]["P_UAN_Number"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["P_UAN_Number"];
                    objPOSSetupProperty.P_FAX_Number = toReturn.Rows[0]["P_FAX_Number"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["P_FAX_Number"];
                    objPOSSetupProperty.P_Email_Address = toReturn.Rows[0]["P_Email_Address"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["P_Email_Address"];
                    objPOSSetupProperty.P_URL = toReturn.Rows[0]["P_URL"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["P_URL"];
                    //objPOSSetupProperty.P_Tex_Number = toReturn.Rows[0]["P_Tex_Number"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["P_Tex_Number"];
                    objPOSSetupProperty.P_Tex_Number = toReturn.Rows[0]["P_Tex_Number"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["P_Tex_Number"];
                    objPOSSetupProperty.Post_Code = toReturn.Rows[0]["Post_Code"] == System.DBNull.Value ? SqlDecimal.Null : (Decimal)toReturn.Rows[0]["Post_Code"];
                    objPOSSetupProperty.Telegraph_Add = toReturn.Rows[0]["Telegraph_Add"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Telegraph_Add"];
                    objPOSSetupProperty.Railway_Station = toReturn.Rows[0]["Railway_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Railway_Station"];
                    objPOSSetupProperty.Police_Station = toReturn.Rows[0]["Police_Station"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Police_Station"];
                    objPOSSetupProperty.POS_Type_ID = (Int32)toReturn.Rows[0]["POS_Type_ID"];
                    objPOSSetupProperty.Business_Type = (Int32)toReturn.Rows[0]["Business_Type_ID"];
                    objPOSSetupProperty.Area_Type = (Int32)toReturn.Rows[0]["Area_Type_ID"];
                    objPOSSetupProperty.POS_Registration = (Int32)toReturn.Rows[0]["Registration_Type_ID"];
                    objPOSSetupProperty.POS_Category = (Int32)toReturn.Rows[0]["POS_Category_ID"];
                    objPOSSetupProperty.Counter_Sale = toReturn.Rows[0]["Counter_Sale"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Counter_Sale"];
                    objPOSSetupProperty.Company_Turn_Over = toReturn.Rows[0]["Company_Turn_Over"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Company_Turn_Over"];
                    objPOSSetupProperty.POS_Turn_Over = toReturn.Rows[0]["POS_Turn_Over"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["POS_Turn_Over"];
                    objPOSSetupProperty.Company_Rank = toReturn.Rows[0]["Company_Rank"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Company_Rank"];
                    objPOSSetupProperty.POS_Rank = toReturn.Rows[0]["POS_Rank"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["POS_Rank"];
                    objPOSSetupProperty.Credit_Allowed = toReturn.Rows[0]["Credit_Allowed"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Credit_Allowed"];
                    objPOSSetupProperty.Credit_Amount_Limit = toReturn.Rows[0]["Credit_Amount_Limit"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Credit_Amount_Limit"];
                    objPOSSetupProperty.Cheque_Allowed = toReturn.Rows[0]["Cheque_Allowed"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Cheque_Allowed"];
                    objPOSSetupProperty.Cheque_Amount_Limit = toReturn.Rows[0]["Cheque_Amount_Limit"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Cheque_Amount_Limit"];
                    objPOSSetupProperty.Freezer = toReturn.Rows[0]["Freezer"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Freezer"];
                    objPOSSetupProperty.Cool_Cab = toReturn.Rows[0]["Cool_Cab"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Cool_Cab"];
                    objPOSSetupProperty.Refrigerator = toReturn.Rows[0]["Refrigerator"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Refrigerator"];
                    objPOSSetupProperty.Air_Conditioner = toReturn.Rows[0]["Air_Conditioner"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["Air_Conditioner"];
                    objPOSSetupProperty.Status = toReturn.Rows[0]["Status"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Status"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("POS_SETUP::SelectOne::Error occured.", ex);
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


        //GET ALL POS_SETUP ROUTE 
        public DataTable SelectAllPOS_SETUPROUTE()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_SETUP_SelectAll_Routes]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Location_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Short_Description", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
                cmdToExecute.Parameters.Add(new SqlParameter("@POS_Type_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Distributor_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageNum));
                cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.PageSize));
                cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 12, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.SortColumn));
                cmdToExecute.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.RouteID));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.TotalRowsNum));

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



        public DataTable ViewPOSbyLocation_Business_PosType(String LocationIDs, String PosTypeIDs, String BusTypeIDs)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPosbyStringIDs]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("POS_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@LocationIDs", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, LocationIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@PosTypeIDs", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, PosTypeIDs));
                cmdToExecute.Parameters.Add(new SqlParameter("@BusTypeIDs", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, BusTypeIDs));


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

        public string UpdatePOSSetupXML()
        {



            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[prPOSSETUPXMLForAndroid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string _rowsAffected = string.Empty;
            DataTable toReturn = new DataTable("COMPANY");

            cmdToExecute.Connection = _mainConnection;
            _mainConnection.Open();

            cmdToExecute.Parameters.Add(new SqlParameter("@CNIC", SqlDbType.NVarChar, 13, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.nic));
            cmdToExecute.Parameters.Add(new SqlParameter("@XmlOutput", SqlDbType.NVarChar, -1, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.XmlOutPut));
            cmdToExecute.CommandTimeout = 300;
            // Execute query.
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            object x = cmdToExecute.ExecuteScalar();
            adapter.Fill(toReturn);
            // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
            objPOSSetupProperty.PosSetupxml = Convert.ToString(cmdToExecute.Parameters["@XmlOutput"].Value);


            _rowsAffected = (string)objPOSSetupProperty.PosSetupxml;




            return _rowsAffected;



        }

        public bool Multiple()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_POS_Multiple_Add]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object

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

            cmdToExecute.Connection = _mainConnection;

            cmdToExecute.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 20, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Code));

            this.StartTransaction();
            cmdToExecute.Transaction = this.Transaction;

            if (objPOSSetupProperty.DetailData != null)
            {
                int codeIncr = 0;
                int count = 0;
                foreach (DataRow row in objPOSSetupProperty.DetailData.Rows)
                {
                   
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                     
                        if (count == 0)
                        {
                            codeIncr = Convert.ToInt32(cmdToExecute.Parameters["@code"].Value.ToString());
                        }
                        
                     //  row["Code"] = cmdToExecute.Parameters["@code"].Value.ToString();   ***///Old  code **////***
                        row["Code"] = codeIncr;
                        codeIncr++;     //Increment in previous Id(code)
                        count++;   // increment loop
                  
                }
                  
                objPOSSetupProperty.DetailData.AcceptChanges();

                SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                objPOSSetupProperty.DetailData.TableName = "POS_SETUP";

                sbc.ColumnMappings.Clear();
                sbc.ColumnMappings.Add(1, 2);
                sbc.ColumnMappings.Add(3, 19);
                sbc.ColumnMappings.Add(5, 3);
                sbc.ColumnMappings.Add(6, 4);
                sbc.ColumnMappings.Add(7, 20);
                sbc.ColumnMappings.Add(9, 21);
                sbc.ColumnMappings.Add(11, 23);
                sbc.ColumnMappings.Add(13, 22);
                sbc.ColumnMappings.Add(15, 37);
                sbc.ColumnMappings.Add(16, 1);


                sbc.DestinationTableName = objPOSSetupProperty.DetailData.TableName;
                sbc.WriteToServer(objPOSSetupProperty.DetailData);

            }

            this.Commit();

            //if (_mainConnectionIsCreatedLocal)
            //{
            //    // Open connection.
            //    _mainConnection.Open();
            //}
            //else
            //{
            //    if (_mainConnectionProvider.IsTransactionPending)
            //    {
            //        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
            //    }
            //}

            //// Execute query.
            
            if (_mainConnectionIsCreatedLocal)
            {
                    // Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
            }
            cmdToExecute.Dispose();
            

            //try
            //{
            //    cmdToExecute.Parameters.Add(new SqlParameter("@locationid", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Location_ID));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@shortdescription", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Short_Description));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@detaildescription", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Detail_Description));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@postypeid", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Type_ID));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@businesstypeid", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Business_Type));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@areatypeid", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Area_Type));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@posregistrationtypeid", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Registration));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@poscategoryid", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.POS_Category));
            //    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPOSSetupProperty.Status));

            //    if (_mainConnectionIsCreatedLocal)
            //    {
            //        // Open connection.
            //        _mainConnection.Open();
            //    }
            //    else
            //    {
            //        if (_mainConnectionProvider.IsTransactionPending)
            //        {
            //            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
            //        }
            //    }
                

            //    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    // some error occured. Bubble it to caller and encapsulate Exception object
            //    throw new Exception("POS_SETUP::Insert::Error occured.", ex);
            //}
            //finally
            //{
            //    if (_mainConnectionIsCreatedLocal)
            //    {
            //        // Close connection.
            //        _mainConnection.Close();
            //    }
            //    cmdToExecute.Dispose();
            //}
            return true;
        }


    }
}
