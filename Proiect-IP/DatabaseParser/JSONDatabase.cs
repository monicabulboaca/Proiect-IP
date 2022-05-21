/**************************************************************************
 *                                                                        *
 *  File:        JSONDatabase                                             *
 *  Copyright:   (c) 2022, Mahu Petrișor                                  *
 *  E-mail:      petrisor.mahu@student.tuiasi.ro                          *
 *  Description: JSON Database Parser.                                    *
 *               Validating, extracting field names and records from a    *
 *               .json file.                                              *
 *                                                                        *
 **************************************************************************/
using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;


namespace Proiect_IP.DatabaseParser
{
    public class JSONDatabase : IDatabaseParser
    {
        /// <summary>
        /// Extract field names and records.
        /// </summary>
        /// <param name="pathToDatabase">Filepath to .json file</param>
        /// <param name="fieldNames">Output for field names</param>
        /// <param name="records">Output for records</param>
        /// <exception cref="JsonReaderException">If json file is invalid</exception>
        /// <exception cref="Exception">General exception</exception>
        public void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records)
        {
            fieldNames = new List<string>();
            records = new List<Row>();
            string jsonAsString = "";
            try
            {
                StreamReader streamReader = new StreamReader(pathToDatabase);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    jsonAsString+=line;
                }
                streamReader.Close();

                //function call used for validating the .json file
                JContainer.Parse(jsonAsString);

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonAsString, (typeof(DataTable)));
                foreach (DataColumn col in dt.Columns)
                {
                    fieldNames.Add(col.ColumnName);
                }
                foreach (DataRow dataRow in dt.Rows)
                {
                    Row row = new Row();
                    row.Data = Array.ConvertAll(dataRow.ItemArray, cellValue => cellValue.ToString()).OfType<string>().ToList();
                    records.Add(row);
                }
            }
            catch (JsonReaderException ex)
            {
                throw new JsonReaderException("The JSON file is not valid!");
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem reading the file!");
            }

        }
    }
}
