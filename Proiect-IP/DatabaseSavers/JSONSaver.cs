/**************************************************************************
 *                                                                        *
 *  File:        JSONSaver                                                *
 *  Copyright:   (c) 2022, Mahu Petrișor                                  *
 *  E-mail:      petrisor.mahu@student.tuiasi.ro                          *
 *  Description: JSON Database Saver.                                     *
 *               Serializes the data in a .json database file.            *
 *                                                                        *
 **************************************************************************/
using Newtonsoft.Json;
using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.DatabaseSavers
{
    public class JSONSaver : IDatabaseSave
    {
        /// <summary>
        /// Saves all the data in a file, at a specified location
        /// </summary>
        /// <param name="filename">File path</param>
        /// <param name="fieldNames">Database fields to be saved</param>
        /// <param name="records">Values to be saved</param>
        public void Save(string filename, List<string> fieldNames, List<Row> records)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach(Row row in records)
            {
                Dictionary<string, string> record = new Dictionary<string, string>();
                for (int i = 0; i < fieldNames.Count; i++) 
                {
                    record[fieldNames[i]] = row.Data[i];   
                }
                list.Add(record);
            }

            string jsonString = JsonConvert.SerializeObject(list);

            using (StreamWriter streamWriter = new StreamWriter(filename, false))
            {
                streamWriter.WriteLine(jsonString);
                streamWriter.Close();
            }
        }
    }
}
