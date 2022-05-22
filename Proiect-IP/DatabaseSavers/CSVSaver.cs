/**************************************************************************
 *                                                                        *
 *  File:        CSVSaver                                             *
 *  Copyright:   (c) 2022, Bulboacă Monica-Andreea                        *
 *  E-mail:      monica-andreea.bulboaca@student.tuiasi.ro                *
 *  Description: CSV Database Saver.                                      *
 *               Serializes the data in a .csv database file.             *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_IP.interfaces;

namespace Proiect_IP.DatabaseSavers
{
    public class CSVSaver : IDatabaseSave
    {
        /// <summary>
        /// Saves all the data in a csv file, at a specified location
        /// </summary>
        /// <param name="filename">The path to file</param>
        /// <param name="fieldNames">Database fields to be saved</param>
        /// <param name="records">Values to be saved</param>
        public void Save(string filename, List<string> fieldNames, List<Row> records)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false);
            Row row;
            for (int i = 0; i < fieldNames.Count - 1; i++)
            {
                streamWriter.Write(fieldNames[i] + ", ");
            }
            streamWriter.Write(fieldNames[fieldNames.Count - 1] + "\n");

            for (int i = 0; i < records.Count - 1; i++)
            {
                row = records[i];
                for(int j = 0; j < row.Data.Count - 1; j++)
                {
                    streamWriter.Write(row.Data[j] + ", ");
                }
                streamWriter.Write(row.Data[row.Data.Count - 1] + "\n");
            }
            row = records[records.Count - 1];
            for (int j = 0; j < row.Data.Count - 1; j++)
            {
                streamWriter.Write(row.Data[j] + ", ");
            }
            streamWriter.Write(records[records.Count - 1].Data[records[records.Count - 1].Data.Count - 1]);

            streamWriter.Close();
            
        }
    }
}
