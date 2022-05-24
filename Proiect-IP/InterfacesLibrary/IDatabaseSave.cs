using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDatabaseSave
    {
        void Save(string filename, List<string> fieldNames,List<Row> records);
    }
}
