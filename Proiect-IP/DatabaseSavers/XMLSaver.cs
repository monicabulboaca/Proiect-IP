/**************************************************************************
 *                                                                        *
 *  File:        XMLSaver                                                 *
 *  Copyright:   (c) 2022, Talmacel Larisa-Maria                          *
 *  E-mail:      larisa-maria.talmacel@student.tuiasi.ro                  *
 *  Description: XML Database Saver.                                      *
 *               Serializes the data in a .xml database file.             *
 *                                                                        *
 **************************************************************************/


using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proiect_IP.DatabaseSavers
{
    public class XMLSaver : IDatabaseSave
    {
        /// <summary>
        /// Saves all the data in a file, at a specified location
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fieldNames"></param>
        /// <param name="records"></param>
        public void Save(string filename, List<string> fieldNames, List<Row> records)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false);

            streamWriter.Write("<?xml version=\"1.0\" encoding=\"UTF - 8\" ?> \n");
            streamWriter.Write("<root> \n");
            foreach (Row row in records)
            {
                streamWriter.Write("    <nodes> \n");
                for (int indexField = 0; indexField < fieldNames.Count; indexField++)
                {
                    streamWriter.Write("\t\t<" + fieldNames[indexField] + ">");
                    streamWriter.Write(row.Data[indexField]);
                    streamWriter.Write("</" + fieldNames[indexField] + ">\n");
                }
            }

            streamWriter.Write("    </nodes> \n");
            streamWriter.Write("</root> \n");
            streamWriter.Close();
        }
    }
}
