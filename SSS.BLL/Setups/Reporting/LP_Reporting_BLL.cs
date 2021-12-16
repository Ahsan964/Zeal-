using SSS.DAL.Setups;
using SSS.Property.Setups.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups.Reporting
{
    public class LP_Reporting_BLL
    {
        LP_Report_Property objrprtprpty;
        Reporting_DAL objrprtDAL;

        public LP_Reporting_BLL()
        {
        }

        public LP_Reporting_BLL(LP_Report_Property _objrpt)
        {
            objrprtprpty = _objrpt;
        }

        public DataTable SelectReportData()
        {
            objrprtDAL = new Reporting_DAL(objrprtprpty);
            return objrprtDAL.SelectReportData();
        }
    }
}
