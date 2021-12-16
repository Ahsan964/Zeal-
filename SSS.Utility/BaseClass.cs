using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;

namespace SSS.Utility
{
    public class BaseClass :System.Web.UI.Page
    {
        // Constructor 
        // Contain authentication object

        #region FindControlRecursive
        protected virtual Control FindControlRecursive(string id)
        {
            return FindControlRecursive(id, this);
        }

        protected virtual Control FindControlRecursive(string id, Control parent)
        {
            // If parent is the control we're looking for, return it
            if (string.Compare(parent.ID, id, true) == 0)
                return parent;

            // Search through children
            foreach (Control child in parent.Controls)
            {
                Control match = FindControlRecursive(id, child);

                if (match != null)
                    return match;
            }

            // If we reach here then no control with id was found
            return null;
        }
        #endregion
        #region ViewStateMethods


        /// <summary>
        /// Retrieves a value from ViewState
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        protected object GetViewStateValue(string key, object defaultValue)
        {
            return ((ViewState[key] == null) ? defaultValue : ViewState[key]);
        }

        /// <summary>
        /// Sets a value in ViewState
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        protected void SetViewStateValue(string key, object val)
        {
            ViewState[key] = val;
        }

        /// <summary>
        /// Clears a value from ViewState
        /// </summary>
        /// <param name="key"></param>
        protected void ClearViewStateValue(string key)
        {
            ViewState[key] = null;
        }
        
        #endregion
        #region MyRegion

         protected void BindControl(Repeater control,DataTable dt)
         {
             if (dt !=null )
             {
                 control.DataSource = dt;
                 control.DataBind();
                 
             }
         }


        #endregion
        #region ExecutionTime
         protected virtual bool MeasureExecutionTime
         {
             get
             {
                 object o = ViewState["MeasureExecutionTime"];
                 if (o == null)
                     return false;
                 else
                     return (bool)o;
             }
             set
             {
                 ViewState["MeasureExecutionTime"] = value;
             }
         }

         private Stopwatch watch = null;

         private List<TimestampInfo> timestamps = null;
         protected virtual List<TimestampInfo> ExecutionTimestamps
         {
             get
             {
                 if (timestamps == null)
                     timestamps = new List<TimestampInfo>();

                 return timestamps;
             }
         }

         protected virtual void RecordTimestamp(string description)
         {
             if (watch == null)
                 throw new ArgumentException("In order to record page execution time MeasureExecutionTime must be set to True.");

             ExecutionTimestamps.Add(new TimestampInfo(watch.ElapsedMilliseconds, description));
         }
         #endregion

        // Form Reset
        
        /// Authentication
    }
}
