/**************************************************************************
 *                                                                        *
 *  File:        JSONDatabase                                             *
 *  Copyright:   (c) 2022, Bulboacă Monica-Andreea                        *
 *  E-mail:      monica-andreea.bulboaca@student.tuiasi.ro                *
 *  Description: CSV Database Saver.                                      *
 *               Serializes the data in a .csv database file.             *
 *                                                                        *
 **************************************************************************/
using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.DatabaseParser
{
    public class CSVDatabase : IDatabaseParser
    {
        /// <summary>
        /// Extract field names and records from a csv file
        /// </summary>
        /// <param name="pathToDatabase">Filepath to .csv file</param>
        /// <param name="fieldNames">Output parameter for fieldnames</param>
        /// <param name="records">Output parameter for records</param>
        public void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records)
        {
            if (IsCSV(pathToDatabase))
            {
                fieldNames = new List<string>();
                records = new List<Row>();
                StreamReader file = new StreamReader(pathToDatabase);
                string firstLine = file.ReadLine();
                string[] headers = firstLine.Split(',');
                foreach (string header in headers)
                {
                    fieldNames.Add(header);
                }

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Row row = new Row();

                    string[] fields = line.Split(',');
                    foreach (string field in fields)
                    {
                        row.Data.Add(field);
                    }
                    records.Add(row);
                }
                file.Close();
            }
            else
            {
                throw new Exception("The csv file is not valid!");
            }
        }

        /// <summary>
        /// Checks if the file from the path is a valid csv file
        /// </summary>
        /// <param name="filePath">Filepath to file</param>
        /// <returns>true if the file is a valid csv file, else otherwise</returns>
        private bool IsCSV(string filePath)
        {
            Int32 numberOfCommas = 0;
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Int32 number = line.Split(',').Length;
                if (numberOfCommas == 0)
                    numberOfCommas = number;
                if (numberOfCommas != number)
                    return false;
            }
            return true;
        }
    }
}
