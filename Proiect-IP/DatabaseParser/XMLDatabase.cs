using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.DatabaseParser
{
    public class XMLDatabase : IDatabaseParser
    {
        public void Parse(in string pathToDatabase, out List<string> fieldNames, out List<Row> records)
        {
            throw new NotImplementedException();
        }
    }
}
