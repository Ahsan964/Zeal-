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
    public class Product_Selection_DLL : DBInteractionBase
    {
        private Product_Selection_Property objProdSelectProperty;
        private ErrorTracer objErrorTrace;

        public Product_Selection_DLL(Product_Selection_Property objProdSelectProperty)
        {
        }
    }
}
