using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
   public class Tax_BLL
    {
       Tax_Property objTax_Property;
       Tax_DAL objTax_DAL;

       public Tax_BLL(Tax_Property obj_Tax_Property)
       {
           objTax_Property = obj_Tax_Property;
       }

       public DataTable SelectAll()
       {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.SelectAll();
       }
       public DataTable SelectOne()
       {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.SelectOne();
       }
       public bool Insert() {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.Insert();
       
       }

       public bool Update()
       {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.Update();

       }
       public bool UpdateStatus()
       {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.UpdateStatus();

       }
       public bool Delete()
       {
           objTax_DAL = new Tax_DAL(objTax_Property);
           return objTax_DAL.Delete();

       } 
   
   }
}
