using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP
{
    public class DatabaseModeler : IDatabaseModeler
    {
        private List<string> _fields;
        private List<Row> _records; // ?? list<list<string>> ??

        public DatabaseModeler(in List<string> fields, in List<Row> data)
        {
            this._fields = fields;
            this._records = data;
        }

        public void AddData(in List<string> data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(in List<string> data)
        {
            throw new NotImplementedException();
        }

        public void ReadData(in string filePath)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(in List<string> oldData, in List<string> newData)
        {
            throw new NotImplementedException();
        }


    }
}
