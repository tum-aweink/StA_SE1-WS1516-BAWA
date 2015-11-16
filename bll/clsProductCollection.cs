﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bll
{
   internal class clsProductCollection : clsBLLCollections
    {
        string _databaseFile; // String zur Access-Datei
        DAL.DALObjects.dDataProvider _myDAL; // DAL: Zugriff auf die Datenbank

        internal clsProductCollection()
        {
            _databaseFile = System.Configuration.ConfigurationManager.AppSettings["AccessFileName"];
            _myDAL = DAL.DataFactory.GetAccessDBProvider(_databaseFile);
        }

        internal List<clsProduct> getAllProducts()
        {
            DataSet _myDataSet = _myDAL.GetStoredProcedureDSResult("QPGetAllProducts");
            DataTable _myDataTable = _myDataSet.Tables[0];
            List<clsProduct> _myProductList = new List<clsProduct>();

            foreach (DataRow _dr in _myDataTable.Rows)
            {
                clsProduct _myProduct = DatarowToClsProduct(_dr);
                _myProductList.Add(_myProduct);
            }

            return _myProductList;
        }

        internal List<clsProduct> createListofProducts(params clsProduct[] _Products)
        {
            List<clsProduct> _myProductsList = new List<clsProduct>(_Products);

            return _myProductsList;
        }

        internal List<clsProduct> getAllProductsByCategory(int _category)
        {
            _myDAL.AddParam("PFKCategory", _category, DAL.DataDefinition.enumerators.SQLDataType.INT);
            DataSet _myDataSet = _myDAL.GetStoredProcedureDSResult("QPGetAllProductsByCategory");
            DataTable _myDataTable = _myDataSet.Tables[0];
            List<clsProduct> _myProductList = new List<clsProduct>();

            foreach (DataRow _dr in _myDataTable.Rows)
            {
                clsProduct _myProduct = DatarowToClsProduct(_dr);
                _myProductList.Add(_myProduct);
            }

            return _myProductList;
        }

        /// <summary>
        /// Gibt Produkt mit gegebener ID zurück
        /// </summary>
        /// <param name="_id">ID des gesuchten Produkts</param>
        /// <returns>Produkt-Objekt (oder NULL) </returns>
        internal clsProduct GetProductById(int _id)
        {
            _myDAL.AddParam("ID", _id, DAL.DataDefinition.enumerators.SQLDataType.INT);

            DataSet _myDataSet = _myDAL.GetStoredProcedureDSResult("QPGetProductByID");

            if (_myDataSet.Tables[0].Rows.Count != 0)
            {
                DataRow _dr = _myDataSet.Tables[0].Rows[0];
                return DatarowToClsProduct(_dr);
            }
            else
            {
                return null;
            }

        } // getProductById()

        internal bool UpdateProduct(clsProductExtended _product)
        {
            _myDAL.AddParam("PName", _product.Name, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myDAL.AddParam("PPricePerUnit", _product.PricePerUnit, DAL.DataDefinition.enumerators.SQLDataType.DOUBLE);
            _myDAL.AddParam("PSell", _product.ToSell, DAL.DataDefinition.enumerators.SQLDataType.BOOL);
            _myDAL.AddParam("CName", _product.Category, DAL.DataDefinition.enumerators.SQLDataType.VARCHAR);
            _myDAL.AddParam("PID", _product.Id, DAL.DataDefinition.enumerators.SQLDataType.INT);

            int affectedRow = _myDAL.MakeStoredProcedureAction("QPUpdateProductByID");
            return affectedRow == 1;
        }

        internal clsProduct DatarowToClsProduct(DataRow _dr)
        {
            clsProduct _myProduct = new clsProduct();
            _myProduct.Id = AddIntFieldValue(_dr, "PID");
            _myProduct.Name = AddStringFieldValue(_dr, "PName");
            _myProduct.PricePerUnit = AddDoubleFieldValue(_dr, "PPricePerUnit");
            _myProduct.CUnit = AddStringFieldValue(_dr, "CUnit");
            _myProduct.Category = AddStringFieldValue(_dr, "CName");
            _myProduct.ToSell = AddBoolFieldValue(_dr, "PSell");
            return _myProduct;
        }
    }
}
