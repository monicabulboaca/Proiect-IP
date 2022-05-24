/**************************************************************************
 *                                                                        *
 *  File:        Unit test                                                *
 *  Copyright:   (c) 2022, Tălmăcel Larisa-Maria                          *
 *  E-mail:      larisa-maria.talmacel@student.tuiasi.ro                  *
 *  Description: This file contains tests for the functions used          *
 *               in the application                                       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Modeler;
using CSV;
using XML;
using JSON;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
       [TestMethod()]
        public void AddDataTestFalse()
        {
            List<Row> listRows = new List<Row>();
            Row row1 = new Row();
            row1.Data.Add("random data");
            
            Assert.AreEqual(false, listRows.Contains(row1));
        }

    
        [TestMethod()]
        public void AddDataTestTrue()
        {
            List<string> list = new List<string>();
            List<Row> records = new List<Row>();
            Row row1 = new Row();
            row1.Data.Add("data 1");

            DatabaseModeler DB = new DatabaseModeler(list, records);
            DB.AddData(row1);

            Assert.AreEqual(true, records.Contains(row1));
        }

        [TestMethod()]
        public void DeleteDataTestTrue()
        {
            List<string> list = new List<string>();
            List<Row> records = new List<Row>();
            Row row1 = new Row();
            row1.Data.Add("data 1");

            DatabaseModeler DB = new DatabaseModeler(list, records);
            DB.AddData(row1);
            DB.DeleteData(row1);

            Assert.AreEqual(true, !records.Contains(row1));
        }

        [TestMethod()]
        public void UpdateDataTestTrue()
        {
            int row = 0;
            int column = 0;
            string newData = "data";

            List<string> list = new List<string>();
            List<Row> records = new List<Row>();
            Row row1 = new Row();
            row1.Data.Add("data 1");

            DatabaseModeler DB = new DatabaseModeler(list, records);
            DB.AddData(row1);
            DB.UpdateData(row, column, newData) ;
            Assert.AreEqual(true, DB.GetRecords().Contains(row1));
        }

        [TestMethod()]
        public void GetFieldsTestTrue()
        {
            List<string> list = new List<string>();
            list.Add("data1");
            list.Add("data2");

            List<Row> records = new List<Row>();
            Row row1 = new Row();

            DatabaseModeler DB = new DatabaseModeler(list, records);
            
            Assert.AreEqual(true, DB.GetFields().Equals(list));
        }

        [TestMethod]
        public void EqualsFalse()
        {
            Row row = new Row();
            row.Data.Add("ss");
            row.Data.Add("ss1");

            Row row2 = new Row();
            row.Data.Add("ss2");
            row.Data.Add("ss");

            Assert.AreEqual(false, row.Equals(row2));
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]

        public void IsCSV()
        {
            CSVDatabase csv = new CSVDatabase() ;
            List<string> fields = new List<string>();
            List<Row> records = new List<Row>();
            csv.Parse("sksks.txt", out fields, out records);

            Assert.AreEqual(true, csv.IsCSV(@"random.csv"));
        }

        [TestMethod]
        public void ParseXML()
        {
            //XMLDatabase xml = new XMLDatabase();
            //List<string> fields = new List<string>();
            //List<Row> records = new List<Row>();
            //xml.Parse(@"C:\Users\Larisa\Desktop\xml-uri\ceva.xml", out fields, out records);

            Assert.IsTrue(XML.XMLDatabase.IsXML(@"../../XMLExemplu.xml"));
        }






    }
}
