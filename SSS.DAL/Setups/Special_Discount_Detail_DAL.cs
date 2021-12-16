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
using SSS.Property;

namespace SSS.DAL.Setups
{
    public class Special_Discount_Detail_DAL : DBInteractionBase
    {

        private Special_Discount_Detail_Property objSpecialDiscountDetailProperty;
         public Special_Discount_Detail_DAL()
        {
        }
         public Special_Discount_Detail_DAL(Special_Discount_Detail_Property objobjSpecialDiscountDetailProperty)
        {
            objSpecialDiscountDetailProperty = objobjSpecialDiscountDetailProperty;
        }

    }
}
