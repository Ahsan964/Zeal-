using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Supplier_BLL: GridCommandBase
    {
        private Suppliers_Property ObjSuppliersProperty;
        private Supplier_DAL ObjSuppliersDAL;
        public Supplier_BLL()
        {

        }

        public Supplier_BLL(Suppliers_Property ObjSupplier_Property)
        {
            ObjSuppliersProperty = ObjSupplier_Property;
        }

        public bool Insert()
        {
            ObjSuppliersDAL = new Supplier_DAL(ObjSuppliersProperty);
            return ObjSuppliersDAL.Insert();
        }
        public DataTable ViewAllSuppliers()
        {
            ObjSuppliersDAL = new Supplier_DAL();
            return ObjSuppliersDAL.SelectAll();
        }


        public DataTable GetSupplierById()
        {
            ObjSuppliersDAL = new Supplier_DAL(ObjSuppliersProperty);
            return ObjSuppliersDAL.SelectOne();
        }


        public DataTable ViewMaxSupplierCode()
        {
            ObjSuppliersDAL = new Supplier_DAL();
            return ObjSuppliersDAL.ViewMaxSupplierCode();
        }


        public bool UpdateStatus(Suppliers_Property objsupplier)
        {
            Suppliers_Property objsupplierpropertynew = new Suppliers_Property();
            objsupplierpropertynew.Supplier_Id = objsupplier.Supplier_Id;
            objsupplierpropertynew.Status = base.Status;
            objsupplierpropertynew.TableName = ObjSuppliersProperty.TableName;
            objsupplierpropertynew.Operated_By = ObjSuppliersProperty.Operated_By;
            ObjSuppliersDAL = new Supplier_DAL(objsupplierpropertynew);
            return ObjSuppliersDAL.UpdateStatus();


        }


        public override void UpdateStatus()
        {
            Suppliers_Property objsupplierpropertynew = new Suppliers_Property();
            objsupplierpropertynew.Supplier_Id = base.Id;
            objsupplierpropertynew.Status = base.Status;
            objsupplierpropertynew.TableName = ObjSuppliersProperty.TableName;
            objsupplierpropertynew.Operated_By = ObjSuppliersProperty.Operated_By;
            ObjSuppliersDAL = new Supplier_DAL(objsupplierpropertynew);
            ObjSuppliersDAL.UpdateStatus();


        }


        public DataTable View()
        {
            ObjSuppliersDAL = new Supplier_DAL(ObjSuppliersProperty);
            return ObjSuppliersDAL.SelectOne();
        }

        public bool Update()
        {
            ObjSuppliersDAL = new Supplier_DAL(ObjSuppliersProperty);
            return ObjSuppliersDAL.Update();
        }
    }
}
