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
        public void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records)
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
            while((line = file.ReadLine()) != null)
            {
                Row row = new Row();
                
                string[] fields = line.Split(',');
                foreach(string field in fields)
                {
                    row.Data.Add(field);
                }
                records.Add(row);   
            }
        }

        public static bool IsCSV(string filePath)
        {
            Int32 no = 0;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Int32 number = line.Split(',').Length;
                if (no == 0)
                    no = number;
                if (no != number)
                    return false;
            }
            return true;

        }
    }
}
