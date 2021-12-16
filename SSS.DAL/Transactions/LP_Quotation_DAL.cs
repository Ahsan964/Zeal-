using SNDDAL;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Transactions
{
    public class LP_Quotation_DAL : DBInteractionBase
    {
        private LP_Quotation_Master_Property _objPOMasterProperty;
        private LP_Quotation_Detail_Property _objPODetailProperty;

        public LP_Quotation_DAL()
        {

        }
        public LP_Quotation_DAL(LP_Quotation_Master_Property objPOMasterProperty)
        {
            _objPOMasterProperty = objPOMasterProperty;
        }
        public LP_Quotation_DAL(LP_Quotation_Detail_Property objPODetailProperty)
        {
            _objPODetailProperty = objPODetailProperty;
        }


        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update quotation SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));

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


        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objPOMasterProperty.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_QuotationUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_QuotationInsert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objPOMasterProperty.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@qsNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.qsNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customerIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netAmount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.totalAmount));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.status));


                   // cmdToExecute.Parameters.Add(new SqlParameter("@quotationDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.quotationDate));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.MRNIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.reference));


                    cmdToExecute.Parameters.Add(new SqlParameter("@shippingCost", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.shippingCost));
                    cmdToExecute.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@taxAount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.taxAount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@salescheck", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.salescheck));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.lastModificationDate));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.MRNIdx));
                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@qsNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.qsNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customerIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netAmount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objPOMasterProperty.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@quotationDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.quotationDate));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.MRNIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.reference));

                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@shippingCost", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.shippingCost));
                    cmdToExecute.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@taxAount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.taxAount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@salescheck", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.salescheck));


                }

                if (_mainConnectionIsCreatedLocal)
                {

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
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_objPOMasterProperty.idx > 0)
                {
                    if (_objPOMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objPOMasterProperty.DetailData.Rows)
                            row["quotationIdx"] = _objPOMasterProperty.idx;

                        _objPOMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objPOMasterProperty.DetailData.TableName = "quotationDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("quotationIdx", "quotationIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        sbc.ColumnMappings.Add("salePrice", "salePrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");

                        sbc.DestinationTableName = _objPOMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objPOMasterProperty.DetailData);

                    }
                    //if (_objPOMasterProperty.SalesTaxData != null)
                    //{
                    //    foreach (DataRow row in _objPOMasterProperty.SalesTaxData.Rows)
                    //    {
                    //        row["quotationIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                    //        row["taxType"] = "2";
                    //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                    //        //row["createdBy"] = Convert.ToInt16(Session["UID"].ToString());
                    //    }
                    //    _objPOMasterProperty.SalesTaxData.AcceptChanges();

                    //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    //    _objPOMasterProperty.SalesTaxData.TableName = "salesTaxes";

                    //    sbc.ColumnMappings.Clear();
                    //    sbc.ColumnMappings.Add("taxIdx", "taxIdx");
                    //    sbc.ColumnMappings.Add("taxPercent", "taxPercent");
                    //    sbc.ColumnMappings.Add("status", "status");
                    //    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    //    //sbc.ColumnMappings.Add(2, 1);
                    //    sbc.ColumnMappings.Add("quotationIdx", "quotationIdx");
                    //    sbc.ColumnMappings.Add("taxType", "taxType");
                    //    sbc.DestinationTableName = _objPOMasterProperty.SalesTaxData.TableName;
                    //    sbc.WriteToServer(_objPOMasterProperty.SalesTaxData);

                    //}
                }
                else
                {
                    if (_objPOMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objPOMasterProperty.DetailData.Rows)
                            row["quotationIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                        _objPOMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objPOMasterProperty.DetailData.TableName = "quotationDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("quotationIdx", "quotationIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        sbc.ColumnMappings.Add("salePrice", "salePrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");

                        sbc.DestinationTableName = _objPOMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objPOMasterProperty.DetailData);

                    }
                    //if (_objPOMasterProperty.SalesTaxData != null)
                    //{
                    //    foreach (DataRow row in _objPOMasterProperty.SalesTaxData.Rows)
                    //    {
                    //        row["quotationIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                    //        row["taxType"] = "2";
                    //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                    //        //row["createdBy"] = Convert.ToInt16(Session["UID"].ToString());
                    //    }
                    //    _objPOMasterProperty.SalesTaxData.AcceptChanges();

                    //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    //    _objPOMasterProperty.SalesTaxData.TableName = "salesTaxes";

                    //    sbc.ColumnMappings.Clear();
                    //    sbc.ColumnMappings.Add("taxIdx", "taxIdx");
                    //    sbc.ColumnMappings.Add("taxPercent", "taxPercent");
                    //    sbc.ColumnMappings.Add("status", "status");
                    //    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    //    //sbc.ColumnMappings.Add(2, 1);
                    //    sbc.ColumnMappings.Add("quotationIdx", "quotationIdx");
                    //    sbc.ColumnMappings.Add("taxType", "taxType");
                    //    sbc.DestinationTableName = _objPOMasterProperty.SalesTaxData.TableName;
                    //    sbc.WriteToServer(_objPOMasterProperty.SalesTaxData);

                    //}
                }

              

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllQuotations]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Parent_Code", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Parent_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Conversion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Conversion));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Level", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Level));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Narration));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Product_Type_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Type));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Packing_Unit_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Packing_Unit_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Width));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@PriceApplyOn", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PriceApplyOn));
                // cmdToExecute.Parameters.Add(new SqlParameter("@SKU_Previous_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SKU_Previous_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Free_SKU", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Free_SKU));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Schedule_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Schedule_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Purchase_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Days));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Stop_Days));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Qty_Limit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Qty_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Value_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Value_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Active));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_Date));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_By", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Final_Product));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.ID));
                //// cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.TotalRowsNum));

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
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelectQSByid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@qsid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));

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


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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
        public  DataTable SelectTaxOnQS()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "select * from salesTaxes where taxType=2 and quotationIdx=@qsid";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@qsid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPOMasterProperty.idx));

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


                if (toReturn.Rows.Count > 0)
                {
                  

                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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
        public DataTable SelectQS()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "select idx,concat('QS-',idx) as qsNumber from quotation where visible=1 and status=0";

            DataTable toReturn = new DataTable("MRN");
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
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                

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

        public DataTable GeneratePONo(LP_GenerateTransNumber_Property objTranNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GenerateTransNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Po");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tablename", SqlDbType.VarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@identityfieldname", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.Identityfieldname));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.userid));

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


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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
