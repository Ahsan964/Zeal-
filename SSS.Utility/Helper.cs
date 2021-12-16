using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Reflection;
using SSS.Property.Setups;

namespace SSS.Utility
{
    public class Helper
    {
        //public static void EncryptConnString()
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        //    ConfigurationSection section = config.GetSection("appSettings");
        //    if (!section.SectionInformation.IsProtected)
        //    {
        //        section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
        //        config.Save();
        //    }
        //}
        //public static void DecryptConnString()
        // {
        //     Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        //     ConfigurationSection section = config.GetSection("appSettings");
        //     if (section.SectionInformation.IsProtected)
        //     {
        //         section.SectionInformation.UnprotectSection();
        //         config.Save();
        //     }
        // }

        /******************************************************************************************************************************/
        public static class AsymmetricEncryption
        {
            private static bool _optimalAsymmetricEncryptionPadding = false;

            public static void GenerateKeys(int keySize, out string publicKey, out string publicAndPrivateKey)
            {
                using (var provider = new RSACryptoServiceProvider(keySize))
                {
                    publicKey = provider.ToXmlString(false);
                    publicAndPrivateKey = provider.ToXmlString(true);
                }
            }

            public static string EncryptText(string text, int keySize, string publicKeyXml)
            {
                var encrypted = Encrypt(Encoding.UTF8.GetBytes(text), keySize, publicKeyXml);
                return Convert.ToBase64String(encrypted);
            }

            public static byte[] Encrypt(byte[] data, int keySize, string publicKeyXml)
            {
                if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
                int maxLength = GetMaxDataLength(keySize);
                if (data.Length > maxLength) throw new ArgumentException(String.Format("Maximum data length is {0}", maxLength), "data");
                if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
                if (String.IsNullOrEmpty(publicKeyXml)) throw new ArgumentException("Key is null or empty", "publicKeyXml");

                using (var provider = new RSACryptoServiceProvider(keySize))
                {
                    provider.FromXmlString(publicKeyXml);
                    return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
                }
            }

            public static string DecryptText(string text, int keySize, string publicAndPrivateKeyXml)
            {
                var decrypted = Decrypt(Convert.FromBase64String(text), keySize, publicAndPrivateKeyXml);
                return Encoding.UTF8.GetString(decrypted);
            }

            public static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml)
            {
                if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
                if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
                if (String.IsNullOrEmpty(publicAndPrivateKeyXml)) throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

                using (var provider = new RSACryptoServiceProvider(keySize))
                {
                    provider.FromXmlString(publicAndPrivateKeyXml);
                    return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
                }
            }

            public static int GetMaxDataLength(int keySize)
            {
                if (_optimalAsymmetricEncryptionPadding)
                {
                    return ((keySize - 384) / 8) + 7;
                }
                return ((keySize - 384) / 8) + 37;
            }

            public static bool IsKeySizeValid(int keySize)
            {
                return keySize >= 384 &&
                        keySize <= 16384 &&
                        keySize % 8 == 0;
            }
        }
        /******************************************************************************************************************************/
        public static void DisplayMessage(Page page, string message, MessageType msg)
        {
            if (msg == MessageType.Error)
            {
                Label lbl = (Label)page.Master.FindControl("lblErrorMessage");
                if (lbl != null)
                {
                    lbl.Visible = true;
                    lbl.Text = message;
                }
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowCallScript", MessageAlert(MessageType.Error), true);
            }
            else if (msg == MessageType.Success)
            {
                Label lbl = (Label)page.Master.FindControl("lblSuccessMessage");
                if (lbl != null)
                {
                    lbl.Visible = true;
                    lbl.Text = message;
                }
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowCallScript", MessageAlert(MessageType.Success), true);
            }
            else if (msg == MessageType.Confirmation)
            {
                Label lbl = (Label)page.Master.FindControl("lblMessage");
                if (lbl != null)
                {
                    lbl.Visible = true;
                    lbl.Text = message;
                }
                //lbl.Text = "<img src='images/alert.png' class='MessageIcon'>" + message;
                lbl.CssClass = "Confirmation";
            }
            else if (msg == MessageType.Normal)
            {
                Label lbl = (Label)page.Master.FindControl("lblMessage");
                if (lbl != null)
                {
                    lbl.Visible = true;
                    lbl.Text = message;
                }
                //lbl.Text = "<img src='images/alert.png' class='MessageIcon'>" + message;
                lbl.CssClass = "Message";
            }
        }

        public static string MessageAlert(MessageType messageType)
        {
            string javascript = "";
            switch (messageType)
            {
                case MessageType.Success:
                    javascript = "<script language=JavaScript>\n" +
                         "$(document).ready(function() {" +
             "$(\".msg-success\").animate({ height: 23, paddingTop: 3, paddingBottom: 2, paddingLeft: 10, paddingRight: 0 }, 500);\n" +
             "});" +
                         "</script>";
                    break;

                case MessageType.Error:
                    javascript = //"<script language=JavaScript>\n" +
                "$(document).ready(function() {" +
    "$(\".msg-error\").animate({ height: 23, paddingTop: 3, paddingBottom: 2, paddingLeft: 10, paddingRight: 0 }, 500);\n" +
    "});";
                    break;
            }
            return javascript;

        }

        public static string ConvertDataSetIntoXMLString(DataSet ds, int nodePosition)
        {
            XmlElement xE = (XmlElement)Helper.Serialize(ds);
            return xE.ChildNodes.Item(nodePosition).InnerXml.ToString();
        }

        public static XmlElement Serialize(object transformObject)
        {
            XmlElement serializedElement = null;
            try
            {
                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(transformObject.GetType());
                serializer.Serialize(memStream, transformObject);
                memStream.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                serializedElement = xmlDoc.DocumentElement;
            }
            catch (Exception SerializeException)
            {

            }
            return serializedElement;
        }

        public static void ResetForm(object parent)
        {            
            if (parent is HtmlTable)
            {
                HtmlTable tbl = (HtmlTable)parent;

                foreach (HtmlTableRow row in tbl.Rows)
                {
                    foreach (HtmlTableCell cell in row.Cells)
                    {
                        foreach (Control ctrl in cell.Controls)
                        {
                            if (ctrl is TextBox)
                            {
                                TextBox txt = (TextBox)ctrl;
                                txt.Text = string.Empty;
                                //txt.Enabled = true;
                                txt.Visible = true;
                            }
                            if (ctrl is CheckBox)
                            {
                                CheckBox cb = (CheckBox)ctrl;
                                cb.Checked = false;
                                cb.Enabled = true;
                                cb.Visible = true;
                            }
                            if (ctrl is DropDownList)
                            {
                                DropDownList ddl = (DropDownList)ctrl;
                                if (ddl.Items.Count > 0)
                                {
                                    ddl.SelectedIndex = 0;
                                    ddl.Enabled = true;
                                    ddl.Visible = true;
                                }
                            }
                            if (ctrl is CheckBoxList)
                            {
                                ((CheckBoxList)ctrl).ClearSelection();
                            }
                            if (ctrl is AjaxControlToolkit.ComboBox)
                            {
                                ((AjaxControlToolkit.ComboBox)ctrl).ClearSelection(); 
                            }
                        }
                    }
                }
            }
        }

        public static void ResetRepeater(Repeater repeater)
        {
            foreach (Control ctrl in repeater.Controls)
            {
                if (ctrl is RepeaterItem)
                {
                    foreach (Control rptItemctrl in ctrl.Controls)
                    {
                        if (rptItemctrl is CheckBox)
                        {
                            ((CheckBox)rptItemctrl).Checked = false;
                        }
                    }
                }
            }
        }


        public static void ClearMessage(Page page)
        {
            Label lbl = (Label)page.Master.FindControl("lblErrorMessage");
            Label lbl1 = (Label)page.Master.FindControl("lblSuccessMessage");
            
            lbl.Visible = false;
            lbl.Text = string.Empty;
            lbl1.Visible = true;
            lbl1.Text = string.Empty;
        }

        public static void PageError(Page page, string value, string errorType)
        {
            switch (errorType)
            {
                case "success":
                    ((Label)page.Master.FindControl("lblSuccessMessage")).Visible = true;
                    ((Label)page.Master.FindControl("lblSuccessMessage")).Text = value;
                    break;
                case "error":
                    ((Label)page.Master.FindControl("lblErrorMessage")).Visible = true;
                    ((Label)page.Master.FindControl("lblErrorMessage")).Text = value;
                    break;
            }
        }

        public static string SuccessMessageAlert(string messageType)
        {
            string javascript = "";
            switch (messageType)
            {
                case "success":
                    javascript = "<script language=JavaScript>\n" +
                "$(document).ready(function() {" + "alert();" + 
    "$(\".msg-success\").animate({ height: 23, paddingTop: 3, paddingBottom: 2, paddingLeft: 10, paddingRight: 0 }, 500);\n" +
    "});" +
                "</script>";
                    
                    break;

                case "error":
                    javascript = "<script language=JavaScript>\n" +
                "$(document).ready(function() {" +
    "$(\".msg-error\").animate({ height: 23, paddingTop: 3, paddingBottom: 2, paddingLeft: 10, paddingRight: 0 }, 500);\n" +
    "});" +
                "</script>";

                    break;
            }
            return javascript;

        }


        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        var a = dr[column.ColumnName].ToString();
                        if (a.ToString() =="")
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }

                    }

                    else
                        continue;
                }
            }
            return obj;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        // Added By Ahsan
        #region PAgeAmane

        public static bool CheckPageAccess(string pagename, List<LP_Pages_Property> PGlst)
        {

            bool flg = false;

            for (int i = 0; i < PGlst.Count; i++)
            {
                if (PGlst[i].PagePath == pagename)
                {
                    flg = true;
                }

            }

            return flg;
        }

        #endregion
    }
}
