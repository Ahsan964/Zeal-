using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class Personel_Setup_BLL
    {
        private Personel_Setup_Property objPersonelSetupProperty;
        private Personel_Setup_DAL objPersonelSetupDAL;

        public Personel_Setup_BLL(Personel_Setup_Property objPersonel_Setup_Property)
        {
            objPersonelSetupProperty = objPersonel_Setup_Property;

        }
        public DataTable ViewAll()
        {
            objPersonelSetupDAL = new Personel_Setup_DAL(objPersonelSetupProperty);
            return objPersonelSetupDAL.SelectAll();
        }
    }
}
