/**************************************************************************
 *                                                                        *
 *  File:        XMLDatabase                                              *
 *  Copyright:   (c) 2022, Talmacel Larisa-Maria                          *
 *  E-mail:      larisa-maria.talmacel@student.tuiasi.ro                  *
 *  Description: XML Database Parser.                                     *
 *               Validating, extracting field names and records from a    *
 *               .xml file.                                               *
 *                                                                        *
 **************************************************************************/

using Proiect_IP.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proiect_IP.DatabaseParser
{
    public class XMLDatabase : IDatabaseParser
    {
        /// <summary>
        /// Function used in order to extract data from XML file
        /// </summary>
        /// <param name="pathToDatabase"></param>
        /// <param name="fieldNames"></param>
        /// <param name="records"></param>
        public void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records)
        {
            fieldNames = new List<string>();
            records = new List<Row>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            int withoutFirstAndSecondTags = 0;
            string repetitiveNode = "";
            Row row = new Row();

            using (var fileStream = File.OpenText(pathToDatabase))
            using (XmlReader reader = XmlReader.Create(fileStream, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && !fieldNames.Contains(reader.Name) && repetitiveNode != reader.Name)
                    {
                        if (withoutFirstAndSecondTags < 2)
                        {
                            withoutFirstAndSecondTags++;
                            repetitiveNode = reader.Name;
                        }
                        else
                        {
                            fieldNames.Add(reader.Name);
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        row.Data.Add(reader.Value);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && (reader.Name).Equals(repetitiveNode))
                    {
                        records.Add(row);
                        row = new Row();
                    }
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Function used in order to validate the format of the XML file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsXML(string filePath)
        {
            //reads the next node from the stream
            XmlTextReader reader = null;
            Stack nodesStack = new Stack();
            object previousTag;

            try
            {
                reader = new XmlTextReader(filePath);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            nodesStack.Push(reader.Name);
                            break;

                        case XmlNodeType.Text:
                            break;

                        case XmlNodeType.EndElement:
                            previousTag = nodesStack.Pop();
                            if (previousTag != reader.Name)
                            {
                                return false;
                            }
                            break;
                    }
                }
                return true;
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}


