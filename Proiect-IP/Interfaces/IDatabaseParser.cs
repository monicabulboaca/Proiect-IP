using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.interfaces
{
    interface IDatabaseParser
    {
        void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records);
    }
}
