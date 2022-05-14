using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.DatabaseParser
{
    public class JSONDatabase : IDatabaseParser
    {
        public void Parse(in string pathToDatabase, out List<string> fieldNames, out List<string> records)
        {
            throw new NotImplementedException();
        }
    }
}
