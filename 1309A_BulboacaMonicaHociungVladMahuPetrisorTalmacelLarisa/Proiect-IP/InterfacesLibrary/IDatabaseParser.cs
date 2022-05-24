using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDatabaseParser
    {
        void Parse(string pathToDatabase, out List<string> fieldNames, out List<Row> records);
    }
}
