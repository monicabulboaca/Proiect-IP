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
        public void Parse(in string pathToDatabase, out List<string> fieldNames, out List<string> records)
        {
            throw new NotImplementedException();
        }

        public static bool IsCSV(in string filePath)
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
